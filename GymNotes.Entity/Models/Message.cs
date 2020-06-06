using GymNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymNotes.Entity.Models
{
  public class Message
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime SendDate { get; set; }
    public Contact Contact { get; set; }
    public int ContactId { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
  }
}