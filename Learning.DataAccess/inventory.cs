using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class inventory
    : Base {
    public inventory() { }
    public Model.Entities.inventory select(int inventory_id) {
      Model.Entities.inventory inventory = _context.Inventories.Find(new object[] { inventory_id });
      return inventory;
    }
    public Model.Entities.inventory select(int purchase_id, int product_id) {
      Model.Entities.inventory temp =
        _context.Inventories.SingleOrDefault(i => i.purchase_id == purchase_id && i.product_id == product_id);
      return temp;
    }
    public bool insert(Model.Entities.inventory inventory) {
      bool result = false;
      try {
        _context.Inventories.Add(inventory);
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot insert inventory in inventory's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot insert inventory in inventory's collection ");
        Debug.Write($"{ exc.InnerException.InnerException.Message }");
      }
      return result;
    }
    public bool update(Model.Entities.inventory inventory) {
      bool result = false;
      try {
        _context.Entry(entity: inventory).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update inventory in inventory's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError error in errors.ValidationErrors) {
            Debug.WriteLine($"{ error.PropertyName }");
            Debug.WriteLine($"{ error.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($" cannot update inventory in inventory's collection");
        Debug.WriteLine($"{ exc.InnerException.InnerException.Message  }");
      }
      return result;
    }
    public bool delete(Model.Entities.inventory inventory) {
      bool result = false;
      try {
        _context.Inventories.Remove(inventory);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($" cannot delete inventory in inventory's collection");
        Debug.Write($" { exc.InnerException.InnerException.Message } ");
      }

      return result;
    }

  }
}
