using Microsoft.EntityFrameworkCore;

namespace HBike.Models;

public class HBikeContext : DbContext
{

    public string DbPath { get; }

    public HBikeContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "HBike.db");
    }

    public DbSet<TestItem> TestItems { get; set; } = null!;

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}