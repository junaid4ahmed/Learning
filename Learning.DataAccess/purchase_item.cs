using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class purchase_item
    : Base {
    public purchase_item() { }
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
      } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
        // log; cannot update the purchase_item
      }
      return result;
    }
    public bool delete(Model.Entities.purchase_item pi) {
      bool result = false;
      Model.Entities.purchase_item item = select(pi.purchase_id, pi.product_id);
      if (item != null) {
        _context.Purchase_Items.Remove(item);
        _context.SaveChanges();
        result = true;
      }
      return result;
    }

  }
}
