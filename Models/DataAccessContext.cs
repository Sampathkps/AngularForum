

using System.Data.Entity;

namespace AngularForum.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("testconnection")
        {
        }

        public DbSet<ForumModel> Forum { get; set; }

        public DbSet<CategoryModel> Category { get; set; }  
    }
}