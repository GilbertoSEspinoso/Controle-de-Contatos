using ControleDeContato.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContato.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
