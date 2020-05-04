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
      var posts = _context.Posts.Include("post_type");
      Console.WriteLine($"Posts");
      foreach(Model.Entities.post item in posts) {
        Console.WriteLine($"-{ item.post_id } { item.account_id } { item.identifier } { item.post_type.name } { item.log } { item.crebit } { item.debit } ");
      }
      Console.WriteLine();
    }

    public void Calculate() {
      var posts = _context.Posts;
      decimal balance = 0;
      List<object> objects = new List<object>();

      foreach(Model.Entities.post item in posts) {
        balance = balance + item.crebit - item.debit;
        objects.Add(new {
          item.post_id,
          item.log,
          item.account_id,
          item.post_type_id,
          item.identifier,
          item.description,
          item.crebit,
          item.debit,
          balance
        });
      }

      foreach(var obj in objects) {
        Console.WriteLine($" { obj.ToString() } ");
      }
      Console.WriteLine();
    }

  }
}
