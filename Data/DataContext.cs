using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webtesting.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        
        }

        public DbSet<user> Characters  => Set<user>();
        public DbSet<Users> Users  => Set<Users>();

    }
}