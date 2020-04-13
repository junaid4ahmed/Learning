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
      foreach(Model.Entities.payment item in payments) {
        Console.WriteLine($"-{item.id}, { item.account_id }, { item.payment_method.name }, { item.amount }  ");
      }
    }

  }
}
