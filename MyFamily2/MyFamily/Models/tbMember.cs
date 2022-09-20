namespace MyFamily.Models
{
    using System;
    using System.Collections.Generic;

    public class tbMember
    {
        public tbMember()
        {
            this.tbFamilies = new HashSet<tbFamily>();
        }
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }

        public virtual tbAddress tbAddress { get; set; }
        public virtual ICollection<tbFamily> tbFamilies { get; set; }
    }
}

