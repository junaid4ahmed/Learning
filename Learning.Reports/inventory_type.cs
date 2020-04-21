using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class inventory_type 
    : parent {

    public inventory_type() { }
    public void select() {
      Console.WriteLine("inventory_types");
      IEnumerable<Model.Entities.inventory_type> inventory_Types = _context.Inventory_Types;
      foreach (Model.Entities.inventory_type item in inventory_Types) {
        Console.WriteLine($" { item.Id }, { item.name }");
      }
      Console.WriteLine();
    }

  }
}
