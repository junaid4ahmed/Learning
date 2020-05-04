using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class supplier
    : Base {

    public Model.Entities.supplier select(int supplier_id) {
      Model.Entities.supplier supplier =
        _context.Suppliers.Find(new object[] { supplier_id });

      return supplier;
    }
    public bool insert(Model.Entities.supplier supplier) {
      bool result = false;
      try {
        _context.Suppliers.Add(supplier);
        _context.SaveChanges();
        result = true;
      } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
        // log; cannot insurt the supplier
      }
      return result;
    }
    public bool update(Model.Entities.supplier supplier) {
      bool result = false;
      Model.Entities.supplier temp = select(supplier.supplier_id);
      if (temp != null) {
        try {
          temp.first_name = supplier.first_name;
          temp.last_name = supplier.last_name;
          temp.email = supplier.email;
          temp.company = supplier.company;
          temp.business_phone = supplier.business_phone;
          temp.home_phone = supplier.home_phone;
          temp.address = supplier.address;
          temp.city = supplier.city;
          temp.state = supplier.state;
          temp.zip = supplier.zip;
          temp.notes = supplier.notes;
          _context.SaveChanges();
          result = true;
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update the supplier
        }
      } else {
        // log; cannot find the supplier for update
      }
      return result;
    }
    public bool delete(int supplier_id) {
      bool result = false;
      Model.Entities.supplier supplier = select(supplier_id);
      if (supplier != null) {
        _context.Suppliers.Remove(supplier);
        _context.SaveChanges();
        result = true;
      } else {
        // log; cannot find the require supplier
      }
      return result;
    }
  }
}
