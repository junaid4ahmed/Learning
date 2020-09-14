using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class product
    : Base {

    public Model.Entities.product select(int product_id) {
      Model.Entities.product product =
        _context.Products.Find(new object[] { product_id });
      return product;
    }
    public bool insert(Model.Entities.product product) {
      bool result = false;
      try {
        _context.Products.Add(product);
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot insert product in product's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot insert product in product's collection");
        Debug.WriteLine(exc.InnerException.InnerException.Message);
      }
      return result;
    }
    public bool update(Model.Entities.product product) {
      bool result = false;
      try {
        _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update product in product's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot update product in product's collection");
        Debug.WriteLine(exc.InnerException.InnerException.Message);
      }

      return result;
    }
    public bool delete(Model.Entities.product product) {
      bool result = false;
      try {
        _context.Products.Remove(product);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot delete product in product's collection");
        Debug.WriteLine($"{exc.InnerException.InnerException.Message}");
      }
      return result;
    }

  }
}
