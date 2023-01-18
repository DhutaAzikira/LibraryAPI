using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<LibraryAPI.Models.Buku> bukus { get; set; }
        public DbSet<LibraryAPI.Models.Akun> Akuns { get; set; }
    }
}
