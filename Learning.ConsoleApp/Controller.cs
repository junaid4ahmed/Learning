
using Learning.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning.ConsoleApp {
  public class Controller {

    #region "classes"
    private Reports.category r_category;
    private Reports.supplier r_supplier;
    private Reports.product r_product;
    private Reports.purchase r_purchase;
    private Reports.account r_account;
    private Reports.payment r_payment;
    private Reports.post_type r_post_type;
    private Reports.post r_post;
    private Reports.inventory_type r_inventory_type;
    private Reports.inventory r_inventory;

    private DataAccess.category d_category;
    private DataAccess.supplier d_supplier;
    private DataAccess.product d_product;
    private DataAccess.account d_account;
    private DataAccess.payment d_payment;
    private DataAccess.post d_post;
    private DataAccess.purchase d_purchase;
    private DataAccess.purchase_item d_purchase_Item;
    private DataAccess.inventory d_inventory;
    #endregion

    public Controller() {
      r_category = new Reports.category();
      r_supplier = new Reports.supplier();
      r_product = new Reports.product();
      r_purchase = new Reports.purchase();
      r_account = new Reports.account();
      r_payment = new Reports.payment();
      r_post_type = new Reports.post_type();
      r_post = new Reports.post();
      r_inventory_type = new Reports.inventory_type();
      r_inventory = new Reports.inventory();

      d_category = new DataAccess.category();
      d_supplier = new DataAccess.supplier();
      d_product = new DataAccess.product();
      d_account = new DataAccess.account();
      d_payment = new DataAccess.payment();
      d_post = new DataAccess.post();
      d_purchase = new DataAccess.purchase();
      d_purchase_Item = new DataAccess.purchase_item();
      d_inventory = new DataAccess.inventory();
    }

    #region "Insert Functions"

    public void category_insert() {
      List<Model.Entities.category> categories = new List<Model.Entities.category> {
        new Model.Entities.category() { name = "Beverages", description = string.Empty }
      };
      categories.ForEach(ca => d_category.insert(ca));
    }

    public void category_update() {
      // get a category from categories collection
      Model.Entities.category category = d_category.select(1);
      if (category != null) {
        d_category.delect(category);
      } else {
        Debug.WriteLine($"cannot find category to update in categories collection");
      }
    }

    #endregion

    #region "supplier"

    public void supplier_insert() {
      List<Model.Entities.supplier> suppliers = new List<Model.Entities.supplier>() {
        new Model.Entities.supplier() {
          company = "Supplier A",
          first_name = "Andersen",
          last_name = "Elizabeth A",
          business_phone = "+923235860384",
          email = "88junaid88@gmail.com"
        }
      };
      suppliers.ForEach(su => d_supplier.insert(su));
    }

    public void supplier_update() {
      Model.Entities.supplier supplier = d_supplier.select(1);
      if (supplier != null) {
        supplier.first_name = $"Sophie";
        supplier.last_name = $"Dee";
        supplier.company = $"Sophie Dee Supplier";
        supplier.email = $"Sophie@gmail.com";
        supplier.business_phone = $"+123255860384";


        //supplier.home_phone;
        //supplier.address;
        //supplier.city;
        //supplier.state;
        //supplier.zip;
        //supplier.notes;

        d_supplier.update(supplier);
      } else {
        Debug.WriteLine($"cannot find supplier in supplier's collection ");
      }

    }

    #endregion

    #region "product"
    public void product_insert() {
      List<Model.Entities.product> products = new List<Model.Entities.product>() {
        new Model.Entities.product() {
          category_id = 1,
          code = "NWTB-1",
          name = "Northwind Traders Chai",
          recoder_level = 10,
          traget_level = 40,
          quantity_per_unit = "10 boxes x 20 bags",
          standard_cast = 13.50m,
          list_price = 18.00m,
          discontinued = false,
          insert_date = DateTime.Now
        },
        new Model.Entities.product() {
          category_id = 1,
          code = "NWTB-34",
          name = "Northwind Traders Beer",
          recoder_level = 15,
          traget_level = 60,
          quantity_per_unit = "24 - 12 oz bottles",
          standard_cast = 10.50m,
          list_price = 14.00m,
          discontinued = false,
          insert_date = DateTime.Now
        },
        new Model.Entities.product() {
          category_id = 1,
          code = "NWTB-43",
          name = "Northwind Traders Coffee",
          recoder_level = 25,
          traget_level = 100,
          quantity_per_unit = "16 - 500 g tins",
          standard_cast = 34.50m,
          list_price = 46.00m,
          discontinued = false,
          insert_date = DateTime.Now
        },
        new Model.Entities.product() {
          category_id = 1,
          code = "NWTB-81",
          name = "Northwind Traders Green Tea",
          recoder_level = 100,
          traget_level = 125,
          quantity_per_unit = "20 bags per box",
          standard_cast = 2.00m,
          list_price = 2.99m,
          discontinued = false,
          insert_date = DateTime.Now
        }
      };
      products.ForEach(pr => d_product.insert(pr));

    }
    public void product_update() {
      Model.Entities.product product = new Model.Entities.product() {
        product_id = 1,
        category_id = 1,
        code = "NWTB-1",
        name = "Northwind Traders Chai",
        recoder_level = 20,
        traget_level = 40,
        quantity_per_unit = "10 boxes x 20 bags",
        standard_cast = 13.50m,
        list_price = 18.00m,
        discontinued = false,
        insert_date = DateTime.Now
      };
      d_product.update(product);
    }
    #endregion

    #region "account"   
    public void account_insert() {
      List<Model.Entities.account> accounts = new List<Model.Entities.account>() {
        new Model.Entities.account() {
          account_type_id = 0,
          name = "New Account Three",
          address = string.Empty,
          phone = string.Empty,
          register = DateTime.Parse("06-Apr-20")
        }
      };
      accounts.ForEach(ac => d_account.insert(ac));
    }
    public void account_update() {

      Model.Entities.account account = new Model.Entities.account() {
        account_type_id = 0, // expanses account
        id = 1,
        name = $"New Account",
        address = $" Al-Faruq G.T Road ",
        phone = $" +92-323-5860323 ",
        register = DateTime.Parse("14-Sep-20")
      };

      if (account != null) {

        d_account.update(account);
      } else {
        Debug.WriteLine($"cannot update account");
      }


    }
    #endregion

    #region "PurchaseItem"
    public void purchaseitem_insert(int purchase_id) {

      // get the purchase that you what to add purchase item to
      Model.Entities.purchase purchase = d_purchase.select(purchase_id);

      if (purchase != null && purchase_status_IsNew_or_IsSubmit(purchase)) {

        // start inserting purchase item here
        List<Model.Entities.purchase_item> items = new List<Model.Entities.purchase_item>() {

        new Model.Entities.purchase_item() {
          purchase_id = purchase_id,
          product_id = 1,
          quantity = 2,
          unit_cast = 10.50m
        },
        new Model.Entities.purchase_item() {
          purchase_id = purchase_id,
          product_id = 2,
          quantity = 2,
          unit_cast = 14.00m
        },
        new Model.Entities.purchase_item() {
          purchase_id = purchase_id,
          product_id = 3,
          quantity = 2,
          unit_cast = 46.00m
        }

      };
        items.ForEach(it => { d_purchase_Item.insert(it); });

      } else {
        // log; cannot find require purchase
      }

    }
    public void purchaseitem_update(int purchase_id = 1, int product_id = 1) {

      // get the item from respective purchase it exists
      Model.Entities.purchase_item item = d_purchase_Item.select(purchase_id, product_id);

      // update purchase item properties here
      item.quantity = 525;

      if (item != null) {
        // get the purchase from respective purchase item it exists
        Model.Entities.purchase purchase = d_purchase.select(item.purchase_id);

        // purchase item of purchase with status "receive" and "approve" is not allowed to be updated
        if (purchase != null && purchase_status_IsNew_or_IsSubmit(purchase)) {
          d_purchase_Item.update(item);
        }

      }
    }
    public void purchaseitem_delete(int purchase_id, int product_id) {

      // get the respective purchase item from respective purchase
      Model.Entities.purchase_item item = d_purchase_Item.select(purchase_id, product_id);

      if (item != null) {

        // get the purchase from respective purchase item it exists
        Model.Entities.purchase purchase = d_purchase.select(item.purchase_id);

        // purchase item of purchase with status "receive" and "approve" is not allowed to be updated
        if (purchase != null && purchase_status_IsNew_or_IsSubmit(purchase)) {
          // delete it from respective purchase
          d_purchase_Item.delete(item);
        }


      }
    }
    #endregion

    #region "purchase"    
    public void purchase_insert() {
      int status = (int)DataAccess.purchase_status.New;

      List<Model.Entities.purchase> purchases = new List<Model.Entities.purchase>() {
        new Model.Entities.purchase() {
          supplier_id = 1,
          account_id = 1,
          status_id = status,
          expect_date = DateTime.Now.AddDays(15),
          insert_date = DateTime.Now,
          insert_by = "consoleApp",
          submit_date = null,
          submit_by = string.Empty,
          approve_date = null,
          approve_by = string.Empty,
          shipping_fee = 0
        }
      };
      purchases.ForEach(pu => d_purchase.insert(pu));
    }
    public void purchase_delete(int purchase_id) {

      // purchase can only be deleted with status "submit"
      // you cannot delete a purchase with status "received"
      Model.Entities.purchase purchase = d_purchase.select(purchase_id);
      if (purchase != null) {
        d_purchase.delete(purchase);
      } else {
        System.Diagnostics.Debug.WriteLine($"cannot find the purchase to delete in purchase colleciton");
      }

    }
    public void purchase_postDelete(int purchase_id) {

      // storing post type
      int post_type = (int)DataAccess.post_type.Purchase;

      // get post entry from post collection
      Model.Entities.post post = d_post.select(post_type, purchase_id);

      if (post != null) {
        d_post.delete(post);
      } else {
        Debug.WriteLine($" cannot find the post in post's collection ");
      }

    }
    public void purchase_postUpdate(int purchase_id) {

      // get a purchase against purchase_id provided
      Model.Entities.purchase pur = d_purchase.select(purchase_id);

      if (pur != null) {

        // properties can be changed to something you want
        d_purchase.update(pur);

        // storing the entity type we what to update in post aka leger
        int post_type_id = (int)DataAccess.post_type.Purchase;

        // get purchase from post aka leger if exists
        Model.Entities.post post = d_post.select(post_type_id, identifier: purchase_id);
        if (post != null) {

          // change post properties 
          post.crebit = d_purchase.total(pur.purchase_id);


          d_post.update(post);

        } else {
          System.Diagnostics.Debug.WriteLine($" cannot find purchase entry in post collection ");
        }

      } else {
        System.Diagnostics.Debug.WriteLine($" cannot find purchase entry in purchase collection ");
      }

    }
    public void purchase_postInsert(int purchase_id = 1) {

      // storing the type of post 
      int purchase_post_type = (int)DataAccess.post_type.Purchase;

      // only purchase that have status "receive" is added to post 
      // only once purchase is added
      Model.Entities.purchase p = d_purchase.select(purchase_id);
      if (p != null && purchase_status_isReceive(p)) {
        d_post.insert(new Model.Entities.post() {
          log = DateTime.Now,
          account_id = p.account_id,
          identifier = p.purchase_id,
          description = string.Empty,
          post_type_id = purchase_post_type,
          crebit = d_purchase.total(purchase_id),
          debit = 0.0M
        });
      } else {
        // log; operation failed; purchase is already posted
        // or purchase's status is not reveive
      }
    }
    public void purchase_submit(int purchase_id) {
      d_purchase.submit(purchase_id, DateTime.Now, "ConsoleApp");
    }
    public void purchase_approve(int purchase_id) {
      d_purchase.approve(purchase_id, DateTime.Now, "ConsoleApp");
    }

    private bool purchase_status_IsApprove_or_IsReceive(Model.Entities.purchase purchase) {

      // storing stats value for purchase's status for later use
      int receive_status = (int)DataAccess.purchase_status.Receive;
      int approve_status = (int)DataAccess.purchase_status.Approve;

      // purchase must not be null and it's status must not be "receive" and "approve" 
      // to add purchase item to it
      bool condition =
        purchase.status_id == receive_status ||
        purchase.status_id == approve_status;

      return condition;
    }
    private bool purchase_status_IsNew_or_IsSubmit(Model.Entities.purchase purchase) {

      // storing stats value for purchase's status for later use
      int new_status = (int)DataAccess.purchase_status.New;
      int submit_status = (int)DataAccess.purchase_status.Submit;
      // purchase must not be null and it's status must not be "receive" and "approve" 
      // to add purchase item to it
      bool condition =
        purchase.status_id == submit_status ||
        purchase.status_id == new_status;

      return condition;
    }
    private bool purchase_status_IsApprove(Model.Entities.purchase purchase) {
      // storing stats value for purchase's status for later use
      int approve_status = (int)DataAccess.purchase_status.Approve;


      bool condition =
        purchase.status_id == approve_status;

      return condition;

    }
    private bool purchase_status_isReceive(Model.Entities.purchase purchase) {
      // storing stats value for purchase's status for later use
      int receive_status = (int)DataAccess.purchase_status.Receive;

      bool condition =
        purchase.status_id == receive_status;

      return condition;
    }
    #endregion

    #region "payment"
    public void payment_insert(int account_id = 1) {
      int cash_type = (int)DataAccess.payment_method.Cash;
      int bank_type = (int)DataAccess.payment_method.BankTransfers;

      Model.Entities.payment cash_payment = new Model.Entities.payment() {
        account_id = account_id,
        date = DateTime.Now,
        amount = 25.50m,
        payment_method_id = cash_type
      };
      Model.Entities.payment bank_transfers = new Model.Entities.payment() {
        account_id = account_id,
        date = DateTime.Now,
        amount = 250.50m,
        payment_method_id = bank_type
      };
      List<Model.Entities.payment> payments = new List<Model.Entities.payment> { cash_payment, bank_transfers };

      payments.ForEach(p => d_payment.insert(p));

    }
    public void payment_update(int payment_id) {

      // getting payment 
      Model.Entities.payment payment = d_payment.select(payment_id);

      if (payment != null) {

        // storing the type of payment
        int cash = (int)DataAccess.payment_method.Cash;

        // modifying properties
        payment.amount = 25m;
        payment.date = DateTime.Parse("5-May-20");
        payment.payment_method_id = cash;

        // calling update method to update payment
        d_payment.update(payment);

        // update payment information in post if exists
        int post_type = (int)DataAccess.post_type.Payment;

        // getting payment's post if already exists, to update
        Model.Entities.post post = d_post.select(post_type, payment.id);

        if (post != null) {

          // properties you want to change, usually amount in post 
          post.debit = payment.amount;

          // updating payment properties
          d_post.update(post);

        } else {
          System.Diagnostics.Debug.WriteLine($" no entry was found of payment in post with following id { payment.id }");
        }

      } else {
        System.Diagnostics.Debug.WriteLine($" no entry was found of payment in payments with following id { payment_id }");
      }




    }
    public void payment_delete(int payment_id) {
      // getting payment 
      Model.Entities.payment payment = d_payment.select(payment_id);
      if (payment != null) {
        d_payment.delete(payment);

        // delete it from post if exists
        int post_type = (int)DataAccess.post_type.Payment;
        Model.Entities.post post = d_post.select(post_type, payment_id);
        if (post != null) {
          d_post.delete(post);
        } else {
          Debug.WriteLine($"cannot delete payment in post collection");
        }

      } else {
        Debug.WriteLine($"cannot delete payment in payment collection");
      }

    }
    public void payment_postInsert(int payment_id) {

      // get payment to post
      Model.Entities.payment p = d_payment.select(payment_id);

      if (p != null) {

        // store post's type 
        int ty_payment = (int)DataAccess.post_type.Payment;

        // get post of payment
        Model.Entities.post post = d_post.select(ty_payment, payment_id);

        // check, payment is not already posted
        if (post == null) {
          d_post.insert(new Model.Entities.post() {
            log = DateTime.Now,
            account_id = p.account_id,
            identifier = p.id,
            description = string.Empty,
            post_type_id = ty_payment,
            crebit = 0.0M,
            debit = p.amount
          });
        } else {
          Debug.WriteLine($"payment already posted in post's collection");
        }
      } else {
        Debug.WriteLine($"cannot find payment in payment's collection");
      }

    }
    public void payment_postDelete(int payment_id) {

      // storing status
      int status = (int)DataAccess.post_type.Payment;

      // get the payment in payment's collection
      Model.Entities.payment payment = d_payment.select(payment_id);

      if (payment != null) {

        // get the post in post collection
        Model.Entities.post post = d_post.select(status, payment_id);

        if (post != null) {
          d_post.delete(post);
        } else {
          Debug.WriteLine($"cannot find the post in post's collection");
        }

      } else {
        Debug.WriteLine($"cannot find the payment in payment's collection");
      }
    }
    #endregion

    #region "inventory"
    public void inventory_purchaseItemInsert(int purchase_id, int product_id) {

      // get the respective purchase item from respective purchase_id
      Model.Entities.purchase_item purchase_Item = d_purchase_Item.select(purchase_id, product_id);

      if (purchase_Item != null) {

        // get the purchase for that purchase item
        Model.Entities.purchase purchase = d_purchase.select(purchase_Item.purchase_id);

        // check for purchase is not null 
        bool NotNullPurchase = purchase != null;

        // check its status is "approve" 
        bool PurchaseStatusIsApprove = purchase_status_IsApprove(purchase);

        // check if that purchase item is not already exists in inventory
        bool NotInInventory = d_inventory.select(purchase_id, product_id) == null;

        // start inserting item in invetory
        if (NotNullPurchase && PurchaseStatusIsApprove && NotInInventory) {

          // add purchase item to inventory  
          Model.Entities.inventory inventory = new Model.Entities.inventory() {
            product_id = purchase_Item.product_id,
            purchase_id = purchase_Item.purchase_id,
            quantity = purchase_Item.quantity,
            price = purchase_Item.unit_cast,
            inventory_type_id = (int)inventory_type.Purchased,
            log = DateTime.Now,
            modift = DateTime.Now
          };
          bool success = d_inventory.insert(inventory);

          // set new added purchase_item inventoried bit to true
          if (success) {
            purchase_Item.inventoried = true;
            d_purchase_Item.update(purchase_Item);
          }

          // set purchase's status to receive when all items in that purchase are received 
          d_purchase.receive(purchase_id);

        } else {
          // log; cannot file the purchase
        }

      } else {
        // log; purchase_item not found
      }

    }
    public void inventory_purchaseItemDelete(int purchase_id, int product_id) {
      System.Diagnostics.Debug.WriteLine($"executing inventory_purchaseItemDelete function");

      // get the purchase 
      Model.Entities.purchase purchase = d_purchase.select(purchase_id);

      // check purchase's status, should not be "received"
      bool IsApprove = purchase_status_IsApprove(purchase);

      // make condition
      bool goodToGo = purchase != null && IsApprove;

      if (goodToGo) {

        // check for PurchaseItem that it belongs to respective purchase or not
        Model.Entities.purchase_item purchase_item = d_purchase_Item.select(purchase_id, product_id);

        if (purchase_item != null) {

          // check purchase's item is in inventory already ?
          Model.Entities.inventory inventory = d_inventory.select(purchase_id, product_id);

          if (inventory != null) {

            // deleting inventory from inventory
            d_inventory.delete(inventory);

            // we now need to change the status of purchase_item's inventoried property to false
            purchase_item.inventoried = false;
            d_purchase_Item.update(purchase_item);

          } else {
            System.Diagnostics.Debug.WriteLine($"cannot find the purchase item in inventory");
          }

        } else {
          System.Diagnostics.Debug.WriteLine($"cannot find the requested purchase item in inventory");
        }

      } else {
        System.Diagnostics.Debug.WriteLine($"either purchase is null or not approved");
      }

    }
    #endregion

    public void reports() {
      r_category.select();
      r_supplier.select();
      r_product.select();
      r_account.select();
      r_purchase.select();
      r_inventory.select();
      r_payment.select();

      r_post.select();
      r_post.Calculate();
    }
  }
}
