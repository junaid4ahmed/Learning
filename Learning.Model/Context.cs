
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Model;

namespace Learning.Model {
  public class Context
     : DbContext {

    public Context()
      : base(nameOrConnectionString: "Learning.Model") {

      this.Configuration.ProxyCreationEnabled = true;
      Database.SetInitializer<Context>(new Initializer());

      //Database.Log = Console.Write;

    }


    public DbSet<Entities.post> Posts { get; set; }
    public DbSet<Entities.post_type> Post_types { get; set; }
    public DbSet<Entities.account_type> Account_Types { get; set; }
    public DbSet<Entities.account> Accounts { get; set; }
    public DbSet<Entities.category> Categories { get; set; }
    public DbSet<Entities.product> Products { get; set; }
    public DbSet<Entities.purchase> Purchases { get; set; }
    public DbSet<Entities.purchase_status> Purchase_Statuses { get; set; }
    public DbSet<Entities.purchase_item> Purchase_Items { get; set; }
    public DbSet<Entities.payment> Payments { get; set; }
    public DbSet<Entities.payment_method> Payment_Methods { get; set; }
    public DbSet<Entities.supplier> Suppliers { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder) {

      // Configuration
      modelBuilder.Configurations.Add(new Configurations.post_type());
      modelBuilder.Configurations.Add(new Configurations.post());
      modelBuilder.Configurations.Add(new Configurations.account_type());
      modelBuilder.Configurations.Add(new Configurations.account());

      modelBuilder.Configurations.Add(new Configurations.category());
      modelBuilder.Configurations.Add(new Configurations.product());

      modelBuilder.Configurations.Add(new Configurations.purchase());
      modelBuilder.Configurations.Add(new Configurations.purchase_status());
      modelBuilder.Configurations.Add(new Configurations.purchase_item());

      modelBuilder.Configurations.Add(new Configurations.payment());
      modelBuilder.Configurations.Add(new Configurations.payment_method());

      modelBuilder.Configurations.Add(new Configurations.supplier());

      // Convention
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      base.OnModelCreating(modelBuilder);
    }

  }

}
