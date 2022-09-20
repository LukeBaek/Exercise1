using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyFamily.Models;

namespace MyFamily.DAL
{
    public class MyFamilyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FamilyContext>
    {
        protected override void Seed(FamilyContext context)
        {
            var tbAddresss = new List<tbAddress>
            {
            new tbAddress{Id= new Guid(),AddressLine1="Melbourne2"},
            new tbAddress{Id= new Guid(),AddressLine1="Auckland"},
            new tbAddress{Id= new Guid(),AddressLine1="Dundas"},
            new tbAddress{Id= new Guid(),AddressLine1="Newington" },
            new tbAddress{Id= new Guid(),AddressLine1="Melbourne1"}
            };

            tbAddresss.ForEach(s => context.tbAddresss.Add(s));
            context.SaveChanges();
           
        }
    }
}