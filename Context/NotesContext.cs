using Microsoft.EntityFrameworkCore;
using NotesApplication.Entities;

namespace NotesApplication.Context
{
    public class NotesContext:DbContext
    {

        public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }

        public DbSet<Notes> Notes { get; set; }
    }
}
