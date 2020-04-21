using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class post_type 
    : parent {

    public post_type() { }
    public void select() {
      Console.WriteLine("post_types");
      var post_types = _context.Post_types;
      foreach(Model.Entities.post_type item in post_types) {
        Console.WriteLine($"-{ item.post_type_id }, { item.name } ");
      }
      Console.WriteLine();
    }

  }
}
