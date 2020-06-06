using GymNotes.Data;
using GymNotes.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Repository.Repository
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task CompleteAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}