//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyFamilay
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbFamily
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> MemberId { get; set; }
        public Nullable<System.Guid> GroupId { get; set; }
        public Nullable<System.Guid> MainAddressId { get; set; }
    
        public virtual tbGroup tbGroup { get; set; }
        public virtual tbMember tbMember { get; set; }
    }
}
