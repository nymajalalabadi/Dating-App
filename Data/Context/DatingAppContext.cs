using Domain.Entities.Photo;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class DatingAppContext :DbContext
    {
        #region Constructor

        public DatingAppContext(DbContextOptions<DatingAppContext> options) : base(options) { }

        #endregion

        #region Users

        public DbSet<User> Users { get; set; }

        public DbSet<UserLike> UserLikes { get; set; }

        #endregion

        #region Photos

        public DbSet<Photo> Photos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
