using QandA.Core.Domain;
using System.Data.Entity;

namespace QandA.Data
{
    public class SqlContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
