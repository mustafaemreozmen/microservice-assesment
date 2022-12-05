using Directory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Directory.Data;

public class DirectoryContext : DbContext
{
    public DirectoryContext(DbContextOptions<DirectoryContext> options) : base(options)
    {
        Informations ??= Set<Information>();
        Persons ??= Set<Person>();
    }
    public DbSet<Information> Informations { get; set; }
    public DbSet<Person> Persons { get; set; }
}