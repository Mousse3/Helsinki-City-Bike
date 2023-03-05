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
    public DbSet<Journey> Journeys { get; set; } = null!;
    public DbSet<Station> Stations { get; set; } = null!;

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Journey>()
            .HasOne(s => s.DepartureStation)
            .WithMany(j => j.Departures)
            .HasForeignKey(j => j.DepartureStationId);

        modelBuilder.Entity<Journey>()
            .HasOne(s => s.ReturnStation)
            .WithMany(j => j.Returns)
            .HasForeignKey(j => j.ReturnStationId);
    }
}