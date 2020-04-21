using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class inventory
    : parent {
    public inventory() { }
    public Model.Entities.inventory select(int id) {
      Model.Entities.inventory inventory = _context.Inventories.Find(new object[] { id });
      return inventory;
    }

    public Model.Entities.inventory select(int purchase_id, int product_id) {
      Model.Entities.inventory temp = _context.Inventories.FirstOrDefault(i => i.purchase_id == purchase_id && i.product_id == product_id);
      return temp;
    }

    public void insert(Model.Entities.purchase_item item) {
      int purchase = (int)inventory_type.Purchased;
      // make sure purchase_item doesn't exist in inventory already
      Model.Entities.inventory temp = select(item.purchase_id, item.product_id);

      if (temp == null) {
        Model.Entities.inventory inventory = new Model.Entities.inventory() {
          product_id = item.product_id,
          purchase_id = item.purchase_id,
          quantity = item.quantity,
          price = item.unit_cast,
          inventory_type_id = purchase,
          log = DateTime.Now,
          modift = DateTime.Now
        };
        _context.Inventories.Add(inventory);
        
        // set purchase_item inventoried property to true upon insert into inventory
        item.inventoried = true;
        _context.SaveChanges();
      } else {
        // log; purchase_item already exists
      }
    }

    public void delete(Model.Entities.purchase_item item) {
      // make sure purchase_item exist in inventory already
      Model.Entities.inventory temp = select(item.purchase_id, item.product_id);
      if (temp != null) {
        _context.Inventories.Remove(temp);

        // set purchase_item inventoried property to false upon delete into inventory
        item.inventoried = false;
        _context.SaveChanges();
      } else {
        // log; purchase_item not found
      }
    }

  }
}
