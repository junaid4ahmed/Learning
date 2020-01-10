using Learning.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Learning.Model {
  internal class Initializer
   : DropCreateDatabaseIfModelChanges<Context> {

    protected override void Seed(Context context) {

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
          name = "receiving",
          description = "set by system upon partial receiving"
        },
        new Entities.purchase_status() {
          id = 4,
          name = "received",
          description = "set by system upon full receiving"
        },
        new Entities.purchase_status() {
          id = 5,
          name = "paying",
          description = "set by system upon full receiving"
        },
        new Entities.purchase_status() {
          id = 6,
          name = "payd",
          description = "set by system upon full receiving"
        },
        new Entities.purchase_status() {
          id = 7,
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

      base.Seed(context);
    }
  }
}