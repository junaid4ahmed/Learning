using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class purchase_item
    : Base {

    public Model.Entities.purchase_item select(int purchase_id, int product_id) {
      Model.Entities.purchase_item temp =
        _context
        .Purchase_Items
        .FirstOrDefault(f => f.purchase_id == purchase_id && f.product_id == product_id);

      return temp;
    }
    public void insert(Model.Entities.purchase_item pi) {
      Model.Entities.purchase_item item = select(pi.purchase_id, pi.product_id);
      if (item != null) {
        item.quantity += pi.quantity;
        _context.SaveChanges();
      } else {
        _context.Purchase_Items.Add(pi);
        _context.SaveChanges();
      }
    }
    public bool update(Model.Entities.purchase_item pi) {
      bool result = false;
      try {
        _context.Entry(entity: pi).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot update purchase item in purchase item's collection");
        Debug.WriteLine($" { exc.InnerException.InnerException.Message } ");
      }
      return result;
    }
    public bool delete(Model.Entities.purchase_item pi) {
      bool result = false;
      try {
        _context.Purchase_Items.Remove(pi);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"delete update purchase item in purchase item's collection");
        Debug.WriteLine($"{ exc.InnerException.InnerException.Message }");
      }
      return result;
    }

  }
}
