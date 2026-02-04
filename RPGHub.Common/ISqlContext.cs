using Microsoft.EntityFrameworkCore;
using RPGHub.Domain;

namespace RPGHub.Common
{
    public interface ISqlContext
    {
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

        public void OnModelCreating(ModelBuilder modelBuilder);
        Task<int> SaveChangesAsync(CancellationToken token = default);

    }
}
