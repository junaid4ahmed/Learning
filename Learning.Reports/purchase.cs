using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class purchase
     : parent {

    public purchase() { }

    public void select() {
      Console.WriteLine("purchases");

      var purchases = _context.Purchases.Include(path: "purchase_status")
        .Select(p => new { purchase_id = p.purchase_id, status = p.purchase_status.name, Total = p.purchase_items.Sum(s => (s.quantity * s.unit_cast)) });

      foreach(var item in purchases) {
        Console.WriteLine($" { item.purchase_id }, { item.status }, { item.Total }");
      }
    }

  }
}
