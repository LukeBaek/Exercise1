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

        public MyFamilyContext(DbContextOptions<MyFamilyContext> options)
            : base(options)
        {
        }

        public DbSet<tbAddress> tbAddresss { get; set; }
        public DbSet<tbFamily> tbFamilies { get; set; }
        public DbSet<tbGroup> tbGroups { get; set; }
        public DbSet<tbMember> tbMembers { get; set; }


    }
}
