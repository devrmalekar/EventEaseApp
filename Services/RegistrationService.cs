using System.Text.Json;
using EventEase.Models;
using Microsoft.JSInterop;

namespace EventEase.Services
{
    public class RegistrationService
    {
        private const string StorageKey = "eventEaseRegistrations";
        private readonly BrowserStorageService _storage;
        private readonly List<Register> _registrations = new();
        private bool _initialized;

        public RegistrationService(BrowserStorageService storage)
        {
            _storage = storage;
        }

        public async Task InitializeAsync()
        {
            if (_initialized)
                return;
            _initialized = true;

            var saved = await _storage.GetItemAsync<List<Register>>(StorageKey);
            if (saved != null)
            {
                _registrations.Clear();
                _registrations.AddRange(saved);
            }
        }

        public async Task<IEnumerable<Register>> GetForEventAsync(string eventId)
        {
            await InitializeAsync();
            return _registrations.Where(r => r.EventId == eventId).ToList();
        }

        public async Task<bool> ExistsAsync(string eventId, string email)
        {
            await InitializeAsync();
            return _registrations.Any(r =>
                r.EventId == eventId
                && string.Equals(r.Email, email, StringComparison.OrdinalIgnoreCase)
            );
        }

        public async Task AddAsync(Register registration)
        {
            await InitializeAsync();
            _registrations.Add(registration);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _storage.SetItemAsync(StorageKey, _registrations);
        }

        public async Task<bool> CancelRegistrationAsync(string registrationId)
        {
            await InitializeAsync();
            var reg = _registrations.FirstOrDefault(r => r.Id == registrationId);
            if (reg == null)
                return false;

            _registrations.Remove(reg);
            await SaveAsync();
            return true;
        }

        public async Task<bool> ToggleAttendanceAsync(string registrationId)
        {
            await InitializeAsync();
            var reg = _registrations.FirstOrDefault(r => r.Id == registrationId);
            if (reg == null)
                return false;

            reg.Attended = !reg.Attended;
            reg.CheckInTime = reg.Attended ? DateTime.UtcNow : null;
            await SaveAsync();
            return true;
        }
    }
}
