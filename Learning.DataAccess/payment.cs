using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class payment
    : Base {

    public payment() { }
    public Model.Entities.payment select(int id) {
      Model.Entities.payment temp = _context.Payments.Find(new object[] { id });
      return temp;
    }
    public void insert(Model.Entities.payment payment) {
      _context.Payments.Add(payment);
      _context.SaveChanges();
    }
    public bool update(Model.Entities.payment payment) {
      bool result = false;
      Model.Entities.payment temp = _context.Payments.SingleOrDefault(p => p.id == payment.id);
      if (temp != null) {
        try {
          temp.amount = payment.amount;
          temp.date = payment.date;
          temp.account_id = payment.account_id;
          temp.payment_method_id = payment.payment_method_id;
          _context.SaveChanges();
          result = true;
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update
        }
        // log; cannot file the payment
      }
      return result;
    }
    public void delete(int id) {
      Model.Entities.payment temp = select(id);
      if (temp != null) {
        _context.Payments.Remove(temp);
        _context.SaveChanges();
      } else {
        // log; delete; payment not found
      }
    }

  }
}
