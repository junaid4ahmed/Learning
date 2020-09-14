using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class payment
    : Base {

    public payment() { }
    public Model.Entities.payment select(int id) {
      Model.Entities.payment temp = _context.Payments.Find(new object[] { id });
      return temp;
    }
    public bool insert(Model.Entities.payment payment) {
      bool result = false;
      try {
        _context.Payments.Add(payment);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.Write($" cannot insert payment in payment's collection");
        Debug.Write(exc.InnerException.InnerException.Message);
      }
      return result;
    }
    public bool update(Model.Entities.payment payment) {
      bool result = false;
      try {
        _context.Entry(entity: payment).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($" cannot update payment in payment's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($" cannot update payment in payment's collection");
        Debug.WriteLine($"{  exc.InnerException.InnerException.Message }");
      }
      return result;
    }
    public bool delete(Model.Entities.payment payment) {
      bool result = false;
      try {
        _context.Payments.Remove(payment);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($" cannot delete payment in payment's collection");
        Debug.WriteLine($"{ exc.InnerException.InnerException.Message }");
      }
      return result;
    }

  }
}
