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
  }
}
