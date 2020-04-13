using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class category 
    : parent {

    public category() {

    }

    public void select() {
      Console.WriteLine("categories");
      var categories = _context.Categories;
      foreach(Model.Entities.category item in categories) {
        Console.WriteLine($"-{ item.category_id }, { item.name } ");
      }
    }

    public void insert(Model.Entities.category category) {
      _context.Categories.Add(category);
      _context.SaveChanges();
    }

  }
}
