using MyFamily.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyFamily.DAL
{
    public class FamilyContext : DbContext
    {

        public FamilyContext() : base("FamilyContext")
        {
        }

        public DbSet<tbAddress> tbAddresss { get; set; }
        public DbSet<tbFamily> tbFamilys { get; set; }
        public DbSet<tbGroup> tbGroups { get; set; }
        public DbSet<tbMember> tbMembers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
