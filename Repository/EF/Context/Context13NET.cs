namespace SimpleBot.Repository.EF.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context13NET : DbContext
    {
        public Context13NET()
            : base("name=Context13NET")
        {
        }

        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Id)
                .IsUnicode(false);
        }
    }
}
