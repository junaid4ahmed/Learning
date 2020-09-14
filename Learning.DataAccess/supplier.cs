using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class supplier
    : Base {

    public Model.Entities.supplier select(int supplier_id) {
      Model.Entities.supplier supplier =
        _context.Suppliers.Find(new object[] { supplier_id });

      return supplier;
    }
    public bool insert(Model.Entities.supplier supplier) {
      bool result = false;
      try {
        _context.Suppliers.Add(supplier);
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot insert supplier in supplier's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot insert supplier in supplier's collection");
        Debug.WriteLine($"{ exc.InnerException.InnerException.Message }");
      }
      return result;
    }
    public bool update(Model.Entities.supplier supplier) {
      bool result = false;
      try {
        _context.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update supplier in supplier's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot update supplier in supplier's collection");
        Debug.WriteLine($" { exc.InnerException.InnerException.Message } ");
      }

      return result;
    }
    public bool delete(Model.Entities.supplier supplier) {
      bool result = false;
      try {
        _context.Suppliers.Remove(supplier);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot delete supplier in supplier's collection");
        Debug.WriteLine($"{ exc.InnerException.InnerException.Message }");
      }
      return result;
    }
  }
}
