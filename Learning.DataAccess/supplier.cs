using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class supplier 
    : parent {
    public void insert(Model.Entities.supplier supplier) {
      _context.Suppliers.Add(supplier);
      _context.SaveChanges();
    }

  }
}
