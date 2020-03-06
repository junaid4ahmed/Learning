using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class account 
    : parent {
    public void insert(Model.Entities.account account) {
      _context.Accounts.Add(account);
      _context.SaveChanges();
    }
    public void delete(Model.Entities.account account) {
      Model.Entities.account temp = _context.Accounts.Find(new object[] { account.id });
      if(temp != null) {
        _context.Accounts.Remove(temp);
        _context.SaveChanges();
      }
    }



  }
}
