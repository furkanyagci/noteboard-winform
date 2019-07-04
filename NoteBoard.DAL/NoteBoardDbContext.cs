using NoteBoard.DAL.Mapping;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL
{
    class NoteBoardDbContext:DbContext
    {
        public NoteBoardDbContext():base("Server=.;Database=NoteBoardDb;Integrated Security=True")
        {
            Database.SetInitializer(new NoteBoardInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Note> Notess { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMapping());
            modelBuilder.Configurations.Add(new PasswordMapping());
            modelBuilder.Configurations.Add(new UserMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
