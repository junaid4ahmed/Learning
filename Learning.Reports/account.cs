using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class account
     : parent {

    public account() { }

    public void select() {
      var accounts = _context.Accounts;
      Console.WriteLine("accounts");
      foreach(Model.Entities.account account in accounts) {
        Console.WriteLine($" { account.id }, { account.name } ");
      }
    }


  }
}
