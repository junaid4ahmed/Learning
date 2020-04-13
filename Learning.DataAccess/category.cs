using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class category
    : parent {
    public void CreateCategories() {
      Model.Entities.category Beverages = new Model.Entities.category() { name = "Beverages" };
      _context.Categories.Add(Beverages);
      _context.SaveChanges();
    }

    public IEnumerable<object> select(Model.Entities.category category) {
      var categories = _context.Categories.Select(c => new { c.category_id, c.name, c.description }).Where(p => p.category_id == category.category_id || p.name == category.name);

      return categories;
    }

    public void delect(Model.Entities.category category) {
      _context.Categories.Remove(category);
      _context.SaveChanges();
    }

    public void insert(Model.Entities.category category) {
      _context.Categories.Add(category);
      _context.SaveChanges();
    }

  }
}
