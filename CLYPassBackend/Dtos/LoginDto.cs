using System.ComponentModel.DataAnnotations;

namespace CLYPassBackend.Dtos;

public record LoginDto(
    [Required, EmailAddress, StringLength(150)] string Email,
    [Required, StringLength(100)] string Password);