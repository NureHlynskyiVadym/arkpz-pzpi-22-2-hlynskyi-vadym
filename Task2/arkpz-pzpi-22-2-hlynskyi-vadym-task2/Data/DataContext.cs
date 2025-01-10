using LevelUp.Models;
using Microsoft.EntityFrameworkCore;

namespace LevelUp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
         public DbSet<Reward> Rewards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LevelUp.Models.Task> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserReward> UserRewards { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);

            }  
    }
}
