using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFamily.Models;

namespace MyFamily.Data
{
    public class MyFamilyContext : DbContext
    {
        public MyFamilyContext (DbContextOptions<MyFamilyContext> options)
            : base(options)
        {
        }

        public DbSet<MyFamily.Models.tbFamily> tbFamily { get; set; } = default!;
    }
}
