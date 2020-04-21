using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class inventory
    : parent {
    public inventory() { }
    public void select() {
      Console.WriteLine("inventories");
      var inventories = _context.Inventories
        .Include("product").Include("inventory_type");

      foreach (Model.Entities.inventory item in inventories) {
        Console.WriteLine($"-{ item.id } { item.inventory_type.name } { item.purchase_id } { item.product.name } { item.quantity } { item.price } '{ item.quantity * item.price }' ");
      }
      Console.WriteLine();
    }
  }
}
