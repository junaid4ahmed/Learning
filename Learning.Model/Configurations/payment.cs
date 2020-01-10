using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class payment 
    : EntityTypeConfiguration<Entities.payment> {

    public payment() {
      HasKey(p => p.id);
      Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

    }

  }
}
