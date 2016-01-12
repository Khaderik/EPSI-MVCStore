using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MVCStoreApplication.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderId);

            // Properties
            this.Property(t => t.Username)
                .HasMaxLength(256);

            this.Property(t => t.FirstName)
                .HasMaxLength(160);

            this.Property(t => t.LastName)
                .HasMaxLength(160);

            this.Property(t => t.Address)
                .HasMaxLength(70);

            this.Property(t => t.City)
                .HasMaxLength(40);

            this.Property(t => t.State)
                .HasMaxLength(40);

            this.Property(t => t.PostalCode)
                .HasMaxLength(10);

            this.Property(t => t.Country)
                .HasMaxLength(40);

            this.Property(t => t.Phone)
                .HasMaxLength(24);

            this.Property(t => t.Email)
                .HasMaxLength(160);

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Total).HasColumnName("Total");
        }
    }
}
