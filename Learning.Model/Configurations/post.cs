using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Configurations {
  public class post
     : EntityTypeConfiguration<Entities.post> {
    public post() {
      HasKey(p => new { p.post_id });

      Property(p => p.identifier)
        .IsRequired();

    }


  }
}
