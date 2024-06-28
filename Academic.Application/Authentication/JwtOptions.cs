using System.ComponentModel.DataAnnotations;

namespace Academic.Application.Authentication
{
    public class JwtOptions
    {
        public static string SectionName = "JWT";

        [Required]
        public string? Key { get; init; } = string.Empty;

        [Range(1, 60)]
        public double DurationInDays { get; init; }
    }
}
