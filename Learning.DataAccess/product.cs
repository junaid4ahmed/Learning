using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class product 
    : parent {
    public void insert(Model.Entities.product product) {
      _context.Products.Add(product);
      _context.SaveChanges();



      Model.Entities.product GreenTea = new Model.Entities.product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-81",
        name = "Northwind Traders Green Tea",
        recoder_level = 100,
        traget_level = 125,
        quantity_per_unit = "20 bags per box",
        standard_cast = 2.00m,
        list_price = 2.99m,
        discontinued = false,
        insert_date = DateTime.Now
      };

    }

  }
}
