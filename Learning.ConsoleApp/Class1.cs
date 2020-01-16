using Learning.Model;
using Learning.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Learning.ConsoleApp {
  public class Class1 {

    private readonly Context _context = null;
    public Class1(Context context) {
      _context = context;
    }
    public void CreateCategories() {
      category Beverages = new category() { name = "Beverages" };
      _context.Categories.Add(Beverages);
      _context.SaveChanges();
    }
    public void CreateProducts() {

      product Chai = new product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-1",
        name = "Northwind Traders Chai",
        recoder_level = 10,
        traget_level = 40,
        quantity_per_unit = "10 boxes x 20 bags",
        standard_cast = 13.50m,
        list_price = 18.00m,
        discontinued = false,
        insert_date = DateTime.Now
      };

      product Beer = new product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-34",
        name = "Northwind Traders Beer",
        recoder_level = 15,
        traget_level = 60,
        quantity_per_unit = "24 - 12 oz bottles",
        standard_cast = 10.50m,
        list_price = 14.00m,
        discontinued = false,
        insert_date = DateTime.Now
      };

      product Coffee = new product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-43",
        name = "Northwind Traders Coffee",
        recoder_level = 25,
        traget_level = 100,
        quantity_per_unit = "16 - 500 g tins",
        standard_cast = 34.50m,
        list_price = 46.00m,
        discontinued = false,
        insert_date = DateTime.Now
      };

      product GreenTea = new product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-81",
        name = "Northwind Traders Green Tea",
        recoder_level = 100,
        traget_level = 125,
        quantity_per_unit = "20 bags per box",
        standard_cast = 2.00m,
        list_price = 2.99m,
        discontinued = false,
        insert_date = DateTime.Now
      };

      _context.Products.Add(Chai);
      _context.Products.Add(Beer);
      _context.Products.Add(Coffee);
      _context.Products.Add(GreenTea);
      _context.SaveChanges();
    }
    public void CreateSupplier() {
      supplier supplier = new supplier() {
        company = "Supplier A",
        first_name = "Andersen",
        last_name = "Elizabeth A",
        business_phone = "+923235860384",
        email = "88junaid88@gmail.com"
      };

      _context.Suppliers.Add(supplier);
      _context.SaveChanges();
    }
    private ICollection<purchase_item> CreatePurchaseItems() {
      List<purchase_item> purchaseItems = new List<purchase_item>() {
          new purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-1" ),
            quantity = 40,
            unit_cast = 14
          },
          new purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-34" ),
            quantity = 60,
            unit_cast = 10
          },
          new purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-43" ),
            quantity = 100,
            unit_cast = 34
          },
          new purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-81" ),
            quantity = 125,
            unit_cast = 2
          },
        };
      return purchaseItems;
    }
    public void CreatePurchase() {
      purchase purchase = new purchase() {
        purchase_items = CreatePurchaseItems(),
        supplier = _context.Suppliers.SingleOrDefault(p => p.company == "Supplier A"),
        purchase_status = _context.Purchase_Statuses.Single(s => s.id == 0),
        expect_date = DateTime.Now.AddDays(15),
        insert_date = DateTime.Now,
        insert_by = "consoleApp",
        submit_date = null,
        submit_by = string.Empty,
        approve_date = null,
        approve_by = string.Empty,
        shipping_fee = 0
      };

      _context.Purchases.Add(purchase);
      _context.SaveChanges();
    }

    #region "Payments"
    public void CreatePayment(int purchase_id, ICollection<payment> payments) {
      purchase recorded_purchase = _context.Purchases.FirstOrDefault(p => p.purchase_id == purchase_id);
      ICollection<payment> recorded_payments = recorded_purchase.payments;

      decimal recorded_total_purchase = recorded_purchase.purchase_items.Sum(tp => (tp.quantity * tp.unit_cast));

      if (recorded_payments != null) {
        decimal recorded_total_payment = recorded_payments.Sum(tp => tp.amount);
        decimal recorded_remaning_purchase = recorded_total_purchase - recorded_total_payment;

        decimal total_payment = payments.Sum(pt => pt.amount);
        decimal remaning_purchase = recorded_remaning_purchase - total_payment;

        if (remaning_purchase > 0) {
          Console.WriteLine($"remaning { recorded_remaning_purchase }");
          Console.WriteLine($"payment { total_payment }");
          Console.WriteLine($"after payment { remaning_purchase }");
          // simply add the payment to payment's collection of respective purchase
          // set the status to paying as payment has not completed

          recorded_purchase.status_id = 5;
          foreach (payment item in payments) {
            recorded_purchase.payments.Add(item);
          }
        }
        
        if (remaning_purchase < 0) {
          Console.WriteLine($"remaning { recorded_remaning_purchase }");
          Console.WriteLine($"payment { total_payment }");
          Console.WriteLine($"purchase's payment { total_payment + remaning_purchase }");
          Console.WriteLine($"advance payment { remaning_purchase }");
          // simply add the payment to payment's collection of respective purchase
          // set the status to payed as payment has completed
          // remaning payment to respective purchaser's account
        }

        _context.SaveChanges();

      }
    }

    #endregion

    public void SubmitPurchase(int purchase_id) {
      purchase purchase_submit = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase_id);
      purchase_submit.status_id = 1;
      purchase_submit.submit_date = DateTime.Now;
      purchase_submit.submit_by = "ConsoleApp";
      _context.SaveChanges();
    }
    public void ReceivingPurchase(int purchase_id) {
      purchase purchase_submit = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase_id);
      // Receving  Purchase
      purchase_submit.status_id = 3;
      _context.SaveChanges();
    }
    public void ReceivedPurchase(int purchase_id) {
      purchase purchase_submit = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase_id);
      // Received Purchase
      purchase_submit.status_id = 4;
      _context.SaveChanges();
    }
    public void ApprovePerchase(int purchase_id) {
      purchase purchase_approve = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase_id);
      purchase_approve.status_id = 2;
      purchase_approve.submit_date = DateTime.Now;
      purchase_approve.submit_by = "ConsoleApp";
      _context.SaveChanges();
    }

  }
}
