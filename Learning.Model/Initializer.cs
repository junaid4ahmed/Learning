using Learning.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Learning.Model {
  internal class Initializer
   : DropCreateDatabaseIfModelChanges<Context> {

    protected override void Seed(Context context) {

      List<Entities.category> categories = new List<Entities.category> {
        new Entities.category() { name = "Movies", description = string.Empty },
        new Entities.category() { name = "Games", description = string.Empty }
      };
      categories.ForEach(c => context.Categories.Add(c));

      // different values for the status that purchase have
      List<Entities.purchase_status> purchase_Statuses = new List<Entities.purchase_status> {
        new Entities.purchase_status(){
          purchase_status_id = 0,
          name = "new",
          description = "default status for the newly created purchase and it is set by system"
        },
        new Entities.purchase_status() { 
          purchase_status_id = 1, 
          name = "submit", 
          description = "is assigned when respective user submit his constructed purchase for approval to authority" 
        },
        new Entities.purchase_status() { 
          purchase_status_id = 2, 
          name = "approve", 
          description = "is assigned after purchase is reviewed by authority" 
        },
        new Entities.purchase_status() {
          purchase_status_id = 3, 
          name = "close", 
          description = "is assiged when purchase have completed it life cycle" 
        },
      };
      purchase_Statuses.ForEach(p => context.Purchase_Statuses.Add(p));

      base.Seed(context);
    }
  }
}