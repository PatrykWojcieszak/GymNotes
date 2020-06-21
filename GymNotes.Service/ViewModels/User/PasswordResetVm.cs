using System.ComponentModel.DataAnnotations;

namespace GymNotes.Service.ViewModels
{
  public class PasswordResetVm
  {
    [Required]
    public string Email { get; set; }

    [Required]
    public string Token { get; set; }

    [Required]
    public string Password { get; set; }
  }
}