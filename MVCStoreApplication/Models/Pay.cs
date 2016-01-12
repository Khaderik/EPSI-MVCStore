using System;
using System.Collections.Generic;

namespace MVCStoreApplication.Models
{
    public partial class Pay
    {
        public Pay()
        {
            this.Artists = new List<Artist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
