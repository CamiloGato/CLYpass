using System.ComponentModel.DataAnnotations;

namespace CLYPassBackend.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(150), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string PasswordHash { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}