using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
namespace Learning.Reports {
  public class account
     : parent {

    public account() { }

    public void select() {
      var accounts = _context.Accounts.Include(path: "purchases");
      Console.WriteLine($"accounts");
      foreach(Model.Entities.account account in accounts) {
        Console.WriteLine($"-{ account.id } { account.name }");
        Console.WriteLine($"--purchases");
        foreach(Model.Entities.purchase purchase in account.purchases) {
          Console.WriteLine($"---{ purchase.purchase_id } { purchase.status_id } { purchase.insert_date } ");
        }
      }
    }


  }
}
