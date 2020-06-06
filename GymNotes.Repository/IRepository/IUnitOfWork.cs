using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.IRepository
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}