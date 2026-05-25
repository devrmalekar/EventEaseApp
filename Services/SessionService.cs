using System.Text.Json;
using EventEase.Models;

namespace EventEase.Services
{
    public class SessionService
    {
        private const string StorageKey = "eventEaseSessionUser";
        private readonly BrowserStorageService _storage;

        public Register? CurrentUser { get; private set; }

        public SessionService(BrowserStorageService storage)
        {
            _storage = storage;
        }

        public async Task InitializeAsync()
        {
            if (CurrentUser != null)
            {
                return;
            }

            CurrentUser = await _storage.GetItemAsync<Register>(StorageKey);
        }

        public async Task SignInAsync(Register r)
        {
            CurrentUser = r;
            await _storage.SetItemAsync(StorageKey, r);
        }

        public async Task SignOutAsync()
        {
            CurrentUser = null;
            await _storage.RemoveItemAsync(StorageKey);
        }
    }
}
