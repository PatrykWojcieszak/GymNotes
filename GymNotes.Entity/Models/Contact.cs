using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class Contact
  {
    public int Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public ICollection<Message> Message { get; set; }

    public Contact()
    {
      Message = new Collection<Message>();
    }
  }
}