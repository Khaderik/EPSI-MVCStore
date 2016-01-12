using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MVCStoreApplication.Models.Mapping
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            this.HasKey(t => t.RecordId);

            // Properties
            this.Property(t => t.CartId)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Cart");
            this.Property(t => t.RecordId).HasColumnName("RecordId");
            this.Property(t => t.CartId).HasColumnName("CartId");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.Carts)
                .HasForeignKey(d => d.AlbumId);

        }
    }
}
