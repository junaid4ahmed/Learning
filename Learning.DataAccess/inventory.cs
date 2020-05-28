using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class inventory
    : Base {
    public inventory() { }
    public Model.Entities.inventory select(int id) {
      Model.Entities.inventory inventory = _context.Inventories.Find(new object[] { id });
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
      } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
        // log; cannot insert inventory
      }
      return result;
    }

    public bool update(Model.Entities.purchase_item item) {
      bool result = false;

      // find the inventory from purchase_id product_id in purchase section
      Model.Entities.inventory inventory = select(item.purchase_id, item.product_id);
      if (inventory != null) {
        try {
          inventory.price = item.unit_cast;
          inventory.quantity = item.quantity;
          inventory.modift = DateTime.Now;
          _context.SaveChanges();
          result = true;
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update the inventory
        }
      }
      return result;
    }

    public bool delete(Model.Entities.purchase_item item) {
      bool result = false;
      // make sure purchase_item exist in inventory already
      Model.Entities.inventory temp = select(item.purchase_id, item.product_id);
      if (temp != null) {
        _context.Inventories.Remove(temp);

        // set purchase_item inventoried property to false upon delete into inventory
        item.inventoried = false;
        result = true;
        _context.SaveChanges();
      } else {
        // log; purchase_item not found
      }
      return result;
    }

  }
}
