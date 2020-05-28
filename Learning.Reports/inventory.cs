using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class inventory
    : parent {
    public inventory() { }
    public void select() {
      Console.WriteLine("inventory; simple");
      var inventories = _context.Inventories.Include("product");

      foreach (Model.Entities.inventory item in inventories) {
        Console.WriteLine($"-{ item.id } { Enum.GetName(typeof(DataAccess.inventory_type), item.inventory_type_id) } { item.purchase_id } { item.product.name } { item.quantity } { item.price } '{ item.quantity * item.price }' ");
      }

      Console.WriteLine();
    }

    public void invtory_purchased() {
      Console.WriteLine("inventory; purchased");

      var pro = _context.Products;
      var inv = _context.Inventories
        .GroupBy(g => g.product_id)
        .Select(sel => new { 
            sel.Key , 
            total_quantity = sel.Sum(e => e.quantity), 
            total_price = sel.Sum(tp => (tp.quantity * tp.price)) 
          }
        );

      
      var pro_inv = from p in pro join i in inv on p.product_id equals i.Key select new { p.name , i };
      foreach (var item in pro_inv) {
        Console.WriteLine($"{ item.name } { item.i.total_quantity } { item.i.total_price }");
      }
    }

  }
}
