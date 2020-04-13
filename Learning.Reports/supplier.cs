using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class supplier 
    : parent {

    public supplier() { }

    public void select() {
      Console.WriteLine("suppliers");
      var suppliers = _context.Suppliers;
      foreach(Model.Entities.supplier item in suppliers) {
        Console.WriteLine($"-{ item.company }, { item.business_phone } ");
      }
    }

  }
}
