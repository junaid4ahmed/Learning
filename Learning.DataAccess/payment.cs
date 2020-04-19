using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class payment 
    : parent {

    public payment() { }
    public Model.Entities.payment select(int id) {
      Model.Entities.payment temp = _context.Payments.Find(new object[] { id });
      return temp;
    }
    public void insert(Model.Entities.payment payment) {
      _context.Payments.Add(payment);
      _context.SaveChanges();
    }
    public void update(Model.Entities.payment payment) {
      _context.Entry(payment).State = System.Data.Entity.EntityState.Modified;
      _context.SaveChanges();
    }
    public void delete(int id) {
      Model.Entities.payment temp =  select(id);
      if (temp != null) {
        _context.Payments.Remove(temp);
        _context.SaveChanges();
      } else {
        // log; delete; payment not found
      }
    }

  }
}
