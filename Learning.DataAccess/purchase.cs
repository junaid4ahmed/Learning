using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Learning.DataAccess {
  public class purchase
    : Base {

    public Model.Entities.purchase select(int purchase_id) {
      Model.Entities.purchase purchase = _context.Purchases.Find(new object[] { purchase_id });
      return purchase;
    }
    public bool insert(Model.Entities.purchase purchase) {
      bool result = false;
      try {
        _context.Purchases.Add(purchase);
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot insert purchase in purchase's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot insert purchase in purchase's collection");
        Debug.WriteLine(exc.InnerException.InnerException.Message);
      }
      return result;
    }
    public bool update(Model.Entities.purchase purchase) {
      bool result = false;
      try {
        _context.Entry(purchase).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update purchase in purchase's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot update purchase in purchase's collection");
        Debug.WriteLine(exc.InnerException.InnerException.Message);
      }

      return result;
    }
    public bool delete(Model.Entities.purchase purchase) {
      bool result = false;
      try {
        _context.Purchases.Remove(purchase);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot delete purchase in purchase's collection");
        Debug.WriteLine($"{exc.InnerException.InnerException.Message}");
      }
      return result;
    }
  
    public decimal total(int purchase_id) {
      var temp = select(purchase_id);
      decimal total = 0.0m;
      total = temp.purchase_items.Count != 0 ? temp.purchase_items.Sum(pi => pi.quantity * pi.unit_cast) : 0.0m;
      return total;
    }
    public bool submit(int purchase_id, DateTime submitDate, string submitBy) {
      int submit = (int)DataAccess.purchase_status.Submit;
      bool result = false;
      Model.Entities.purchase p = select(purchase_id);
      if (p != null) {
        p.status_id = submit;
        p.submit_date = submitDate;
        p.submit_by = submitBy;
        _context.SaveChanges();
        result = true;
      } else {
        Debug.WriteLine($"cannot find purchase in purchase's collection");
      }
      return result;
    }
    public bool approve(int purchase_id, DateTime approveDate, string approveBy) {
      int approve = (int)DataAccess.purchase_status.Approve;
      bool result = false;

      Model.Entities.purchase p = select(purchase_id);
      if (p != null) {
        p.status_id = approve;
        p.submit_date = approveDate;
        p.submit_by = approveBy;
        _context.SaveChanges();
        result = true;
      } else {
        Debug.WriteLine($"cannot find purchase in purchase's collection");
      }
      return result;
    }
    public bool receive(int purchase_id) {
      bool result = false;
      int receive = (int)purchase_status.Receive;
      Model.Entities.purchase purchase = _context
        .Purchases
        .Include("purchase_items")
        .SingleOrDefault(p => p.purchase_id == purchase_id);

      if (purchase == null) {
        return result;
      }

      bool exists = purchase.purchase_items.Any(pi => pi.inventoried == false);
      if (exists == false) {
        result = true;
        purchase.status_id = receive;
        _context.SaveChanges();
      } else {
        // log; there are item in purchase that need receiving
      }
      return result;
    }

  }
}
