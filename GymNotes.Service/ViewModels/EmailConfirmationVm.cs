using System.ComponentModel.DataAnnotations;

namespace GymNotes.Service.ViewModels
{
  public class EmailConfirmationVm
  {
    [Required]
    public string Email { get; set; }

    [Required]
    public string Token { get; set; }
  }
}