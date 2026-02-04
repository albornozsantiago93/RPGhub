using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RPGHub.Common;
using RPGHub.Domain;

namespace RPGHub.Infrastructure
{
    public class SqlContext : DbContext, ISqlContext
    {
        private readonly IConfiguration _configuration;
        public SqlContext(DbContextOptions<SqlContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("UserView"); // El nombre de la vista en la base de datos
            });

        }

        #region Entities
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<PlatformPermission> PlatformPermission { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<LearningUser> LearningUser { get; set; }
        public DbSet<GameSession> GameSession { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Invitation> Invitation { get; set; }
        public DbSet<ChatMessage> ChatMessage { get; set; }
        public DbSet<GameSessionParticipant> GameSessionParticipant { get; set; }
        public DbSet<LogHistory> Log { get; set; }


        #endregion

        #region Views
        public DbSet<UserView> UserView { get; set; }

        #endregion



    }
}
