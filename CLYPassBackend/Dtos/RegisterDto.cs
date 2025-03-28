using System.ComponentModel.DataAnnotations;

namespace CLYPassBackend.Dtos;

public record RegisterDto(
    [Required, StringLength(100)] string Name,
    [Required, EmailAddress, StringLength(150)] string Email,
    [Required, StringLength(100, MinimumLength = 6)] string Password
);