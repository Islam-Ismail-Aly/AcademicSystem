using System.ComponentModel.DataAnnotations;

namespace Academic.Application.Authentication
{
    public class JwtOptions
    {
        public static string SectionName = "JWT";

        [Required(ErrorMessage = "The JWT Key is required.")]
        public string? Key { get; init; } = string.Empty;

        [Range(1, 60, ErrorMessage = "The DurationInDays must be between 1 and 60.")]
        public double DurationInDays { get; init; }
    }
}
