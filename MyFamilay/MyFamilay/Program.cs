using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyFamilyEntities();
            var address = new tbAddress()
            {
                Id = Guid.NewGuid(),
                AddressLine1 = "Auckland"
            };
            context.tbAddresses.Add(address);
            context.SaveChanges();

        }
    }
}
