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

      using (Context _context = new Context()) {

        //paying for purchase
        payment cash_payment = new payment() {
          date = DateTime.Now,
          amount = 500.50m,
          payment_method_id = 0
        };
        payment bank_transfers = new payment() {
          date = DateTime.Now,
          amount = 500.50m,
          payment_method_id = 4
        };
        ICollection<payment> payments = new List<payment> { cash_payment, bank_transfers };
        

        Class1 c1 = new Class1(_context);
        //c1.CreateSupplier(); c1.CreateProducts(); c1.CreatePurchase();

        // payment is commence after receiving
        c1.ReceivedPurchase(1);
        c1.CreatePayment(purchase_id: 1, payments: payments);


        //purchases and their status along with total
        var purchases = _context.Purchases.Include(path: "purchase_status").Select(p => new { purchase_id = p.purchase_id, status = p.purchase_status.name, Total = p.purchase_items.Sum(s => (s.quantity * s.unit_cast)) });

        foreach (var item in purchases) {
          Console.WriteLine($"purchase_id { item.purchase_id }, status { item.status } total { item.Total }");
        }

        Console.WriteLine($" { _context.Purchases.FirstOrDefault().status_id } ");
        decimal Total = _context.Purchases.FirstOrDefault().purchase_items.Sum(p => (p.quantity * p.unit_cast));
        var Totals = _context.Purchases.Select(p => new { Id = p.purchase_id, Total = p.purchase_items.Sum(i => i.quantity * i.unit_cast) });
        Console.WriteLine($" Total { Total } ");
        foreach (var item in Totals) {
          Console.WriteLine($"Id { item.Id } Total { item.Total } ");
        }
      }

      Console.WriteLine("press any key ...");
      Console.ReadKey();

    }



  }
}
