using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event : IValidatableObject
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(
            100,
            MinimumLength = 3,
            ErrorMessage = "Event name must be between 3 and 100 characters."
        )]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Event location is required.")]
        [StringLength(
            100,
            MinimumLength = 3,
            ErrorMessage = "Event location must be between 3 and 100 characters."
        )]
        public string Location { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date.HasValue && Date.Value.Date < DateTime.Today)
            {
                yield return new ValidationResult(
                    "Event date must be today or a future date.",
                    new[] { nameof(Date) }
                );
            }
        }
    }
}
