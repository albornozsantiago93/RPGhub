using LMS.Domain;
using LMS.Domain.Stuff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public SqlContext() : base()
        {
            
        }

        public DbSet<BaseUserEntity> BaseUserEntity { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }



    }
}
