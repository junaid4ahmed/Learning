
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.ConsoleApp {
  public class testData {

    #region "classes"
    private Reports.category r_category;
    private Reports.supplier r_supplier;
    private Reports.product r_product;
    private Reports.purchase r_purchase;
    private Reports.account r_account;
    private Reports.payment r_payment;
    private Reports.post_type r_post_type;
    private Reports.post r_post;

    private DataAccess.category d_category;
    private DataAccess.supplier d_supplier;
    private DataAccess.product d_product;
    private DataAccess.account d_account;
    private DataAccess.payment d_payment;
    private DataAccess.post d_post;
    private DataAccess.purchase d_purchase;
    private DataAccess.purchase_item d_purchase_Item;
    #endregion

    public testData() {
      r_category = new Reports.category();
      r_supplier = new Reports.supplier();
      r_product = new Reports.product();
      r_purchase = new Reports.purchase();
      r_account = new Reports.account();
      r_payment = new Reports.payment();
      r_post_type = new Reports.post_type();
      r_post = new Reports.post();

      d_category = new DataAccess.category();
      d_supplier = new DataAccess.supplier();
      d_product = new DataAccess.product();
      d_account = new DataAccess.account();
      d_payment = new DataAccess.payment();
      d_post = new DataAccess.post();
      d_purchase = new DataAccess.purchase();
      d_purchase_Item = new DataAccess.purchase_item();
    }

    #region "Insert Functions"
    public void category_insert() {
      List<Model.Entities.category> categories = new List<Model.Entities.category> {
        new Model.Entities.category() { name = "Beverages", description = string.Empty }
      };
      categories.ForEach(ca => d_category.insert(ca));
    }
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
    public void account_insert() {
      List<Model.Entities.account> accounts = new List<Model.Entities.account>() {
        new Model.Entities.account() {
          account_type_id = 0,
          name = "New Account",
          address = string.Empty,
          phone = string.Empty,
          register = DateTime.Now
        }
      };
      accounts.ForEach(ac => d_account.insert(ac));
    }
    #endregion

    #region "PurchaseItem"
    public void purchaseitem_update(int purchase_id = 1, int product_id = 1) {
      Model.Entities.purchase_item item = d_purchase_Item.select(purchase_id, product_id);
      if (item != null) {
        item.quantity = 10;
        d_purchase_Item.update(item);

        purchase_postUpdate(purchase_id);
      }
    }
    public void purchaseitem_delete(int purchase_id, int product_id) {
      d_purchase_Item.delete(purchase_id, product_id);

      purchase_postUpdate(purchase_id);
    }
    public void purchaseitem_insert(int purchase_id = 1) {
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
      items.ForEach(it => d_purchase_Item.insert(it));

      purchase_postUpdate(purchase_id);
    }
    #endregion

    #region "purchase"
    public void purchase_postDelete(int id) {
      d_post.delete(post_type_id: (int)DataAccess.post_type.Purchase, identifier: id);
    }
    public void purchase_postUpdate(int id) {

      // storing the entity type we what to update in post aka leger
      int purchase = (int)DataAccess.post_type.Purchase;

      // get purchase from post aka leger
      Model.Entities.post post = d_post.select(purchase, identifier: id);
      if (post != null) {

        // if exists update purchase in post aka leger
        d_post.update(post_type_id: purchase, identifier: id, total: d_purchase.total(id));
      }

    }
    public void purchase_setStatus(int purchase_id, DataAccess.purchase_status status_id) {
      d_purchase.change_status(purchase_id, (int)status_id);
    }
    public DataAccess.purchase_status purchase_getStatus(int purchase_id) {
      Model.Entities.purchase purchase = d_purchase.select(purchase_id);
      return (DataAccess.purchase_status)purchase.status_id;
    }
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
    public void purchase_postInsert(int purchase_id = 1) {
      int post_type = (int)DataAccess.post_type.Purchase;

      Model.Entities.purchase p = d_purchase.select(purchase_id);
      if (p != null) {
        d_post.insert(new Model.Entities.post() {
          log = DateTime.Now,
          account_id = p.account_id,
          identifier = p.purchase_id,
          description = string.Empty,
          post_type_id = post_type,
          crebit = d_purchase.total(purchase_id),
          debit = 0.0M
        });
      } else {
        //log; operation failed; cannot find the require purchase
      }

    }
    #endregion

    #region "payment"
    public void payment_insert(int account_id = 1) {
      Model.Entities.payment cash_payment = new Model.Entities.payment() {
        account_id = account_id,
        date = DateTime.Now,
        amount = 500.50m,
        payment_method_id = 0
      };
      Model.Entities.payment bank_transfers = new Model.Entities.payment() {
        account_id = account_id,
        date = DateTime.Now,
        amount = 5500.50m,
        payment_method_id = 4
      };
      List<Model.Entities.payment> payments = new List<Model.Entities.payment> { cash_payment, bank_transfers };

      payments.ForEach(p => d_payment.insert(p));

    }
    public void payment_update(int id) {
      Model.Entities.payment payment = d_payment.select(id);
      payment.amount = 252;
      d_payment.update(payment);

      // update payment information in post if exists
      payment_postUpdate(payment.id);
    }
    public void payment_delete(int id) {
      d_payment.delete(id);
    }
    public void payment_postInsert(int payment_id) {
      Model.Entities.payment p = d_payment.select(payment_id);
      d_post.insert(new Model.Entities.post() {
        log = DateTime.Now,
        account_id = p.account_id,
        identifier = p.id,
        description = string.Empty,
        post_type_id = (int)DataAccess.post_type.Payment,
        crebit = 0.0M,
        debit = p.amount
      });
    }
    public void payment_postUpdate(int payment_id) {
      Model.Entities.payment payment = d_payment.select(payment_id);
      if (payment != null) {
        Model.Entities.post post = d_post.select((int)DataAccess.post_type.Payment, payment.id);
        if (post != null) {
          post.debit = payment.amount;
          d_post.update(post);
        } else {
          //log; no such payment is exists in post
        }
      } else {
        //log; no such payment is made
      }
    }
    public void payment_postDelete(int payment_id) {
      d_post.delete((int)DataAccess.post_type.Payment, payment_id);
    }
    #endregion

    public void reports() {
      r_category.select();
      r_supplier.select();
      r_product.select();
      r_account.select();
      r_payment.select();
      r_purchase.select();

      r_post.select();
      r_post.Calculate();
      r_post_type.select();


    }

  }
}
