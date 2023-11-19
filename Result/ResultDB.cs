using System.Data.Entity;
using System.Linq;
using TypingGame.Entities;

namespace TypingGame.Result
{
    internal class ResultDB: DbContext
    {
        public ResultDB() : base("DbConnection") { }
        public DbSet<Score> Scores { get; set; }

        public int GetCount() => Scores.Count();
    }
}
