using System;
using System.Collections.Generic;

namespace MVCStoreApplication.Models
{
    public partial class Genre
    {
        public Genre()
        {
            this.Albums = new List<Album>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
