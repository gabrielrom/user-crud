using System;
using Microsoft.EntityFrameworkCore;

namespace user_crud {
  public class DataContext : DbContext {
    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<User>().HasKey(c => c.id);
    }
  }
}