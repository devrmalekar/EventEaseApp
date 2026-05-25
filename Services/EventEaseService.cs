using EventEase.Models;

namespace EventEase.Services
{
    public class EventEaseService
    {
        private readonly List<Event> _events;
        private readonly List<Register> _registrations = new();

        public EventEaseService()
        {
            _events = GenerateMockEvents();
        }

        private static List<Event> GenerateMockEvents()
        {
            var locations = new[]
            {
                "Sydney",
                "Melbourne",
                "Brisbane",
                "Perth",
                "Adelaide",
                "Canberra",
                "Hobart",
                "Darwin",
            };
            var categories = new[]
            {
                "Tech",
                "Music",
                "Startup",
                "Art",
                "Food",
                "Business",
                "Health",
                "Sports",
                "Education",
                "Gaming",
            };
            var events = new List<Event>(100);

            for (int i = 1; i <= 1000; i++)
            {
                events.Add(
                    new Event
                    {
                        Id = i.ToString(),
                        Name = $"{categories[(i - 1) % categories.Length]} Event {i}",
                        Date = DateTime.Now.AddDays(i % 30 + (i / 10)),
                        Location = locations[(i - 1) % locations.Length],
                    }
                );
            }

            return events;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _events;
        }

        public bool EventExists(string id)
        {
            return _events.Any(e => e.Id == id);
        }

        public IEnumerable<Event> GetEventsByName(string name)
        {
            return _events.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public void AddEvent(Event newEvent)
        {
            _events.Add(newEvent);
        }

        public void AddRegistration(Register newRegistration)
        {
            _registrations.Add(newRegistration);
        }
    }
}
