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
      foreach (Model.Entities.post item in posts) {
        Console.WriteLine($"-{ item.post_id } { item.account_id } { item.identifier } { Enum.GetName(typeof(DataAccess.post_type), item.post_type_id) } { item.log } { item.crebit } { item.debit } ");
      }
      Console.WriteLine();
    }

    public void Calculate() {
      var posts = _context.Posts;
      decimal balance = 0;
      List<object> objects = new List<object>();

      foreach (Model.Entities.post item in posts) {
        balance = balance + item.crebit - item.debit;
        objects.Add(new {
          item.post_id,
          item.identifier,
          type = Enum.GetName(typeof(DataAccess.post_type), item.post_type_id),
          item.account_id,
          item.log,
          item.description,
          item.crebit,
          item.debit,
          balance
        });
      }

      foreach (var obj in objects) {
        Console.WriteLine($" { obj.ToString() } ");
      }
      Console.WriteLine();
    }

  }
}
