using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class product 
    : parent {
    public void insert() {

      Model.Entities.product Chai = new Model.Entities.product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-1",
        name = "Northwind Traders Chai",
        recoder_level = 10,
        traget_level = 40,
        quantity_per_unit = "10 boxes x 20 bags",
        standard_cast = 13.50m,
        list_price = 18.00m,
        discontinued = false,
        insert_date = DateTime.Now
      };

      Model.Entities.product Beer = new Model.Entities.product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-34",
        name = "Northwind Traders Beer",
        recoder_level = 15,
        traget_level = 60,
        quantity_per_unit = "24 - 12 oz bottles",
        standard_cast = 10.50m,
        list_price = 14.00m,
        discontinued = false,
        insert_date = DateTime.Now
      };

      Model.Entities.product Coffee = new Model.Entities.product() {
        category = _context.Categories.SingleOrDefault(c => c.name == "Beverages"),
        code = "NWTB-43",
        name = "Northwind Traders Coffee",
        recoder_level = 25,
        traget_level = 100,
        quantity_per_unit = "16 - 500 g tins",
        standard_cast = 34.50m,
        list_price = 46.00m,
        discontinued = false,
        insert_date = DateTime.Now
      };

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

      _context.Products.Add(Chai);
      _context.Products.Add(Beer);
      _context.Products.Add(Coffee);
      _context.Products.Add(GreenTea);
      _context.SaveChanges();
    }

  }
}
