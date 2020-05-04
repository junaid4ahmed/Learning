using Learning.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Learning.Model {
  internal class Initializer
   : DropCreateDatabaseIfModelChanges<Context> {

    protected override void Seed(Context context) {

      // some account_type
      List<Entities.account_type> account_types = new List<Entities.account_type>() {
        new Entities.account_type(){ account_type_id = 0, name = "Expanses" },
        new Entities.account_type(){ account_type_id = 1, name = "Income" }
      };
      account_types.ForEach(a => context.Account_Types.Add(a));

      // some categories
      List<Entities.category> categories = new List<Entities.category> {
        new Entities.category() { name = "Beverages", description = string.Empty }
      };
      categories.ForEach(c => context.Categories.Add(c));

      // different values for the status that a purchase may have
      List<Entities.purchase_status> purchase_Statuses = new List<Entities.purchase_status> {
        new Entities.purchase_status(){
          id = 0,
          name = "new",
          description = "default status for the newly created purchase and it is set by system"
        },
        new Entities.purchase_status() {
          id = 1,
          name = "submit",
          description = "is assigned when respective user submit his constructed purchase for approval to authority"
        },
        new Entities.purchase_status() {
          id = 2,
          name = "approve",
          description = "is assigned after purchase is reviewed by authority"
        },
        new Entities.purchase_status() {
          id = 3,
          name = "receive",
          description = "is assigned after all items in purchase is received by authority"
        },
        new Entities.purchase_status() {
          id = 4,
          name = "closed",
          description = "is assiged when purchase have completed it life cycle"
        },
      };
      purchase_Statuses.ForEach(p => context.Purchase_Statuses.Add(p));

      // different values for the payment method that a payment may have
      List<Entities.payment_method> payment_methods = new List<Entities.payment_method>() {
        new Entities.payment_method(){ id = 0, name = "Cash" },
        new Entities.payment_method(){ id = 1, name = "Ewallets" },
        new Entities.payment_method(){ id = 2, name = "Credit Cards" },
        new Entities.payment_method(){ id = 3, name = "Mobile Payments" },
        new Entities.payment_method(){ id = 4, name = "Bank Transfers" },
        new Entities.payment_method(){ id = 5, name = "Prepaid Cards" },
        new Entities.payment_method(){ id = 6, name = "Direct Deposit" }
      };
      payment_methods.ForEach(p => context.Payment_Methods.Add(p));

      List<Entities.post_type> post_types = new List<Entities.post_type>() {
        new Entities.post_type(){ post_type_id = 0, name = "Purchase" },
        new Entities.post_type(){ post_type_id = 1, name = "Payment" },
        new Entities.post_type(){ post_type_id = 2, name = "Recepit" },
        new Entities.post_type(){ post_type_id = 3, name = "Sale" }
      };
      post_types.ForEach(p => context.Post_types.Add(p));

      List<Entities.inventory_type> inventory_Types = new List<Entities.inventory_type>() {
        new Entities.inventory_type(){ Id = 0, name = "Purchased", description = string.Empty },
        new Entities.inventory_type(){ Id = 1, name = "Sold", description = string.Empty },
        new Entities.inventory_type(){ Id = 2, name = "On Hold", description = string.Empty },
        new Entities.inventory_type(){ Id = 3, name = "Waste", description = string.Empty }
      };
      inventory_Types.ForEach(it => context.Inventory_Types.Add(it));

      base.Seed(context);
    }

  }
}