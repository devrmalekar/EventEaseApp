using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EventEase.Models
{
    public class Register : IValidatableObject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(
            100,
            MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 100 characters."
        )]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event ID is required.")]
        public string EventId { get; set; } = string.Empty;

        // Optional navigation property to the event (not populated automatically)
        [JsonIgnore]
        public Event? Event { get; set; }

        // Basic model-level validation: ensure EventId is a valid GUID string.
        // Use page-level or service-level checks to verify the Event actually exists.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!int.TryParse(EventId, out _))
            {
                yield return new ValidationResult(
                    "Event ID is not a valid identifier.",
                    new[] { nameof(EventId) }
                );
            }
        }

        // Attendance tracking
        public bool Attended { get; set; } = false;
        public DateTime? CheckInTime { get; set; }
    }
}
