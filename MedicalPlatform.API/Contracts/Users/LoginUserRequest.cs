using System.ComponentModel.DataAnnotations;

namespace MedicalPlatform.API.Contracts.Users
{
    public record LoginUserRequest(
        [Required] string UserName,
        [Required] string Password);
}
