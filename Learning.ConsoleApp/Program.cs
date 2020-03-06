using Learning.Model;
using Learning.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.ConsoleApp {
  class Program {

    static void Main(string[] args) {

      Console.Title = "Learning.ConsoleApp";
      //Console.WriteLine($" ");

      Reports.category r_category = new Reports.category();
      Reports.supplier r_supplier = new Reports.supplier();
      Reports.product r_product = new Reports.product();
      Reports.purchase r_purchase = new Reports.purchase();
      Reports.account r_account = new Reports.account();
      Reports.post_type r_post_type = new Reports.post_type();
      Reports.post r_post = new Reports.post();


      DataAccess.category d_category = new DataAccess.category();
      DataAccess.supplier d_supplier = new DataAccess.supplier();
      DataAccess.product d_product = new DataAccess.product();
      DataAccess.account d_account = new DataAccess.account();
      DataAccess.post d_post = new DataAccess.post();
      DataAccess.purchase d_purchase = new DataAccess.purchase();

      //d_category.insert();
      //d_supplier.insert();
      //d_product.insert();

      //d_account.insert(new Model.Entities.account() {
      //  account_type_id = 0,
      //  name = "New Account",
      //  address = string.Empty,
      //  phone = string.Empty,
      //  register = DateTime.Now
      //});

      //d_purchase.insert();
      //d_post.insert(new post() {
      //  log = DateTime.Now,
      //  account_id = 1,
      //  post_type_id = 0,
      //  identifier = 1,
      //  description = @"Purchase",
      //  crebit = 4810.00M,
      //  debit = 0.0M
      //});

      r_category.select();
      r_supplier.select();
      r_product.select();
      r_account.select();
      r_purchase.select();

      r_post.select();
      r_post_type.select();

      Console.WriteLine("press any key ...");
      Console.ReadKey();
    }


    static ICollection<payment> payments() {
      payment cash_payment = new payment() {
        date = DateTime.Now,
        amount = 500.50m,
        payment_method_id = 0
      };
      payment bank_transfers = new payment() {
        date = DateTime.Now,
        amount = 5500.50m,
        payment_method_id = 4
      };
      ICollection<payment> payments = new List<payment> { cash_payment, bank_transfers };
      return payments;
    }

  }
}
