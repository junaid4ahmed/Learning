using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot insert account in account's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot insert account in accounts collection");
        Debug.WriteLine($"{ exc.InnerException.InnerException.Message }");
      }
      return result;
    }
    public bool update(Model.Entities.account account) {
      bool result = false;
      try {
        _context.Entry(account).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update account in account's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot update account in account's collection");
        Debug.WriteLine($" { exc.InnerException.InnerException.Message } ");
      }

      return result;
    }
    public bool delete(Model.Entities.account account) {
      bool result = false;
      try {
        _context.Accounts.Remove(account);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot delete account in account's collection");
        Debug.WriteLine($"{ exc.InnerException.InnerException.Message }");
      }
      return result;
    }

  }
}
