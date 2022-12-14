using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class FormData
{
    [Required]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public DateTime ConsultationDate { get; set; }

    [Required]
    public string LanguageConsulstation { get; set; }

    public string[] Languages => new[] { "JavaScript", "C#", "Java", "Python", "Основи" };
}
