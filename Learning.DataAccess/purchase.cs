using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class purchase
    : Base {

    public Model.Entities.purchase select(int purchase_id) {
      Model.Entities.purchase purchase = _context.Purchases.Find(new object[] { purchase_id });
      return purchase;
    }
    public bool insert(Model.Entities.purchase purchase) {
      bool result = false;
      try {
        _context.Purchases.Add(purchase);
        _context.SaveChanges();
        result = true;
      } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
        // log error
      }
      return result;
    }
    public void update(Model.Entities.purchase purchase) {
      // update purchase in post as well such as total price
      _context.Entry(entity: purchase).State = System.Data.Entity.EntityState.Modified;
      _context.SaveChanges();
    }
    public bool delete(int purchase_id) {
      bool result = false;
      Model.Entities.purchase purchase = select(purchase_id);
      if (purchase != null) {
        _context.Purchases.Remove(purchase);
        _context.SaveChanges();
        result = true;
      } else {
        // log; cannot find the purchase
      }
      return result;
    }
    public decimal total(int purchase_id) {
      var temp = select(purchase_id);
      decimal total = 0.0m;
      total = temp.purchase_items.Count != 0 ? temp.purchase_items.Sum(pi => pi.quantity * pi.unit_cast) : 0.0m;
      return total;
    }
    public bool submit(int purchase_id, DateTime submitDate, string submitBy) {
      int submit = (int)DataAccess.purchase_status.Submit;
      bool result = false;
      Model.Entities.purchase p = select(purchase_id);
      if (p != null) {
        p.status_id = submit;
        p.submit_date = submitDate;
        p.submit_by = submitBy;
        _context.SaveChanges();
        result = true;
      } else {
        // log; cannot find the purchase
      }
      return result;
    }
    public bool approve(int purchase_id, DateTime approveDate, string approveBy) {
      int approve = (int)DataAccess.purchase_status.Approve;
      bool result = false;

      Model.Entities.purchase p = select(purchase_id);
      if (p != null) {
        p.status_id = approve;
        p.submit_date = approveDate;
        p.submit_by = approveBy;
        _context.SaveChanges();
        result = true;
      } else {
        // log; cannot find the purchase
      }
      return result;
    }
    public bool receive(int purchase_id) {
      bool result = false;
      int receive = (int)purchase_status.Receive;
      Model.Entities.purchase purchase = _context
        .Purchases
        .Include("purchase_items")
        .SingleOrDefault(p => p.purchase_id == purchase_id);

      if (purchase == null) {
        return result;
      }

      bool exists = purchase.purchase_items.Any(pi => pi.inventoried == false);
      if (exists == false) {
        result = true;
        purchase.status_id = receive;
        _context.SaveChanges();
      } else {
        // log; there are item in purchase that need receiving
      }
      return result;
    }
  }
}
