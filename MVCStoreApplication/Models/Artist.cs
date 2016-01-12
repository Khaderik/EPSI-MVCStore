using System;
using System.Collections.Generic;

namespace MVCStoreApplication.Models
{
    public partial class Artist
    {
        public Artist()
        {
            this.Albums = new List<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Nationalite { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual Pay Pay { get; set; }
    }
}
