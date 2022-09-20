namespace MyFamily.Models
{
    using System;
    using System.Collections.Generic;

    public class tbGroup
    {
        public tbGroup()
        {
            this.tbFamilies = new HashSet<tbFamily>();
        }

        public System.Guid Id { get; set; }
        public string Level { get; set; }
        public string DESCRIPTION { get; set; }

        public virtual ICollection<tbFamily> tbFamilies { get; set; }
    }
}

