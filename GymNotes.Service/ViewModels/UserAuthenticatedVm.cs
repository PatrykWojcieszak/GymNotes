using System;
using System.Collections.Generic;
using System.Text;

namespace GymNotes.Service.ViewModels
{
  public class UserAuthenticatedVm
  {
    public string Token { get; set; }

    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Alias { get; set; }
  }
}