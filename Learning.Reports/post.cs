using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class post 
    : parent {

    public post() { }

    public void select() {
      var posts = _context.Posts;
      Console.WriteLine($"Posts");
      foreach(Model.Entities.post item in posts) {
        Console.WriteLine($" { item.post_id }, { item.account_id }, { item.identifier }, { item.post_type_id }, { item.log }, { item.crebit }, { item.debit } ");
      }
    }

  }
}
