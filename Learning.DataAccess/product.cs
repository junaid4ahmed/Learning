using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class product
    : Base {

    public Model.Entities.product select(int product_id) {
      Model.Entities.product product =
        _context.Products.Find(new object[] { product_id });
      return product;
    }
    public bool insert(Model.Entities.product product) {
      bool result = false;
      try {
        _context.Products.Add(product);
        _context.SaveChanges();
        result = true;
      } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
        // log; cannot insert the product
      }
      return result;
    }
    public bool update(Model.Entities.product product) {
      bool result = false;
      Model.Entities.product temp = select(product.product_id);
      if (temp != null) {
        try {
          temp.name = product.name;
          temp.code = product.code;
          temp.standard_cast = product.standard_cast;
          temp.list_price = product.list_price;
          temp.recoder_level = product.recoder_level;
          temp.traget_level = product.traget_level;
          temp.quantity_per_unit = product.quantity_per_unit;
          temp.discontinued = product.discontinued;
          temp.insert_date = product.insert_date;
          temp.category_id = product.category_id;
          _context.SaveChanges();
          result = true;
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update the product
        }
      } else {
        // log; cannot find the product for update
      }
      return result;
    }
    public bool delete(int product_id) {
      bool result = false;
      Model.Entities.product product = select(product_id);
      if (product != null) {
        _context.Products.Remove(product);
        _context.SaveChanges();
      } else {
        // log; cannot delete teh product
      }
      return result;
    }

  }
}
