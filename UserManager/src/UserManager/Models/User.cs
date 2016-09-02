using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UserManager.Models
{
    public class User : IValidatableObject
    {
        public int ID { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(1)]
        public string MiddleInitial { get; set; }
        [Required, DataType(DataType.Date)]
        public Nullable<DateTime> BirthDate { get; set; }
        [Required, MaxLength(100), DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(20), DataType(DataType.PhoneNumber), Phone]
        public string Phone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BirthDate == null)
            {
                yield return new ValidationResult("Birthdate is required.", new[] { nameof(BirthDate) });
                yield break;
            }

            if (BirthDate > DateTime.Now)
                yield return new ValidationResult("Birthdate cannot be in the future.", new[] { nameof(BirthDate) });

            if (BirthDate?.AddYears(122) < DateTime.Now)
                yield return new ValidationResult("The oldest human to ever live was 122 years old. Are you really older than that?", new[] { nameof(BirthDate) });
        }

    }
}
