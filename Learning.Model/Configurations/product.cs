using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
 public class product
    : EntityTypeConfiguration<Entities.product> {

    public product() {
      HasKey(p => new { p.product_id });

      Property(p => p.product_id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      // Name
      Property(p => p.name)
          .IsRequired();

      //  StandardCast
      Property(p => p.standard_cast)
          .IsRequired();

      //  ListPrice
      Property(p => p.list_price)
          .IsRequired();

      // Date
      Property(p => p.insert_date)
          .IsRequired();

      HasMany(p => p.Purchase_Items)
        .WithRequired(p => p.product)
        .HasForeignKey(p => p.product_id)
        .WillCascadeOnDelete(false);

    }

  }
}
