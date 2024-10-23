using System.ComponentModel.DataAnnotations;

namespace MedicalPlatform.API.Contracts.Users
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Password);
 }