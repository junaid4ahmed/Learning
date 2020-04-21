using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class payment
    : parent {

    public payment() { }

    public void select(int account_id = 1) {
      Console.WriteLine("payments");
      var payments = _context.Payments.Include("payment_method").Where(f => f.account_id == account_id);
      //total = temp.purchase_items.Count != 0 ? temp.purchase_items.Sum(pi => pi.quantity * pi.unit_cast) : 0.0m;

      decimal total = payments.Count() != 0 ? payments.Sum(p => p.amount) : 0.0m; 
      Console.WriteLine($"-total { total }");
      foreach(Model.Entities.payment item in payments) {
        Console.WriteLine($"--{item.id}, { item.account_id }, { item.payment_method.name }, { item.amount }  ");
      }
      Console.WriteLine();
    }

  }
}
