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

        #endregion

    }
}
