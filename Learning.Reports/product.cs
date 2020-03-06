using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class product 
    : parent {

    public product() { }
    public void select() {
      Console.WriteLine("products");
      var products = _context.Products;
      foreach(Model.Entities.product item in products) {
        Console.WriteLine($" { item.name }, { item.list_price } ");
      }
    }

  }
}
