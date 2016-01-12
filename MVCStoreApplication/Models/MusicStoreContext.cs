using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MVCStoreApplication.Models.Mapping;

namespace MVCStoreApplication.Models
{
    public partial class MusicStoreContext : DbContext
    {
        static MusicStoreContext()
        {
            Database.SetInitializer<MusicStoreContext>(null);
        }

        public MusicStoreContext()
            : base("Name=MusicStoreContext")
        {
        }

        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Cart> Carts { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }
        public IDbSet<Pay> Pays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumMap());
            modelBuilder.Configurations.Add(new ArtistMap());
            modelBuilder.Configurations.Add(new CartMap());
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new PayMap());
        }
    }
}
