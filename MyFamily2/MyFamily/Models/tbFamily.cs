namespace MyFamily.Models
{
    using System;
    using System.Collections.Generic;

    public class tbFamily
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> MemberId { get; set; }
        public Nullable<System.Guid> GroupId { get; set; }
        public Nullable<System.Guid> MainAddressId { get; set; }

        public virtual tbGroup tbGroup { get; set; }
        public virtual tbMember tbMember { get; set; }
    }
}

