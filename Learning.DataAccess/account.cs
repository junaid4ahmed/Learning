using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class account
    : Base {
    public Model.Entities.account select(int account_id) {
      Model.Entities.account account =
        _context.Accounts.Find(new object[] { account_id });
      return account;
    }
    public bool insert(Model.Entities.account account) {
      bool result = false;
      try {
        _context.Accounts.Add(account);
        _context.SaveChanges();
        result = true;
      } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
        // log; cannot insert the account
      }
      return result;
    }
    public bool update(Model.Entities.account account) {
      bool result = false;
      Model.Entities.account temp = select(account.id);
      if (temp != null) {
        try {
          temp.account_type_id = account.account_type_id;
          temp.name = account.name;
          temp.address = account.address;
          temp.phone = account.phone;
          _context.SaveChanges();

          result = true;
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update the account
        }
      } else {
        // log; cannot find the account
      }
      return result;
    }
    public bool delete(int account_id) {
      bool result = false;
      Model.Entities.account temp = select(account_id);
      if (temp != null) {
        _context.Accounts.Remove(temp);
        _context.SaveChanges();
        result = true;
      } else {
        // log; cannot delete the account;
      }
      return result;
    }

  }
}
