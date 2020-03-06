using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class supplier 
    : parent {

    public void insert() {
      Model.Entities.supplier supplier = new Model.Entities.supplier() {
        company = "Supplier A",
        first_name = "Andersen",
        last_name = "Elizabeth A",
        business_phone = "+923235860384",
        email = "88junaid88@gmail.com"
      };

      _context.Suppliers.Add(supplier);
      _context.SaveChanges();
    }

  }
}
