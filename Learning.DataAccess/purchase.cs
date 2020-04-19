using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class purchase
    : parent {

    private ICollection<Model.Entities.purchase_item> CreatePurchaseItems() {
      List<Model.Entities.purchase_item> purchaseItems = new List<Model.Entities.purchase_item>() {
          new Model.Entities.purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-1" ),
            quantity = 40,
            unit_cast = 14
          },
          new Model.Entities.purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-34" ),
            quantity = 60,
            unit_cast = 10
          },
          new Model.Entities.purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-43" ),
            quantity = 100,
            unit_cast = 34
          },
          new Model.Entities.purchase_item(){
            product = _context.Products.SingleOrDefault(p => p.code == "NWTB-81" ),
            quantity = 125,
            unit_cast = 2
          },
        };
      return purchaseItems;
    }
    public void insert() {
      Model.Entities.purchase temp = new Model.Entities.purchase() {
        purchase_items = CreatePurchaseItems(),
        supplier = _context.Suppliers.FirstOrDefault(),
        account = _context.Accounts.FirstOrDefault(),
        purchase_status = _context.Purchase_Statuses.Single(s => s.id == 0),
        expect_date = DateTime.Now.AddDays(15),
        insert_date = DateTime.Now,
        insert_by = "consoleApp",
        submit_date = null,
        submit_by = string.Empty,
        approve_date = null,
        approve_by = string.Empty,

        shipping_fee = 0
      };
      
      _context.Purchases.Add(temp);
      _context.SaveChanges();
    }
    public void insert(Model.Entities.purchase purchase) {
      _context.Purchases.Add(purchase);
      _context.SaveChanges();
    }
    public decimal total(int purchase_id) {
      var temp = _context.Purchases.Find(new object[] { purchase_id });
      decimal total = 0.0m;
      total = temp.purchase_items.Count != 0 ? temp.purchase_items.Sum(pi => pi.quantity * pi.unit_cast) : 0.0m;
      return total;
    }
    public Model.Entities.purchase select(int id) {
      Model.Entities.purchase temp = _context.Purchases.Find(new object[] { id });
      return temp;
    }
    public void delete(int id) {
      _context.Purchases.Remove(select(id));
      _context.SaveChanges();
    }
    public void update(Model.Entities.purchase purchase) {
      // update purchase in post as well such as total price
      _context.Entry(entity: purchase).State = System.Data.Entity.EntityState.Modified;
      _context.SaveChanges();
    }

    /// <summary>
    /// change the status of specific purchase specified with id
    /// </summary>
    /// <param name="purchase_id">purchase id</param>
    /// <param name="status_id">status id</param>
    public void change_status(int purchase_id, int status_id) {
      var temp = select(purchase_id);
      temp.status_id = status_id;
      _context.SaveChanges();
    }
    public void SubmitPurchase(Model.Entities.purchase purchase) {
      Model.Entities.purchase purchase_submit = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase.purchase_id);
      purchase_submit.status_id = 1;
      purchase_submit.submit_date = DateTime.Now;
      purchase_submit.submit_by = "ConsoleApp";
      _context.SaveChanges();
    }
    public void ReceivingPurchase(Model.Entities.purchase purchase) {
      Model.Entities.purchase purchase_submit = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase.purchase_id);
      // Receving  Purchase
      purchase_submit.status_id = 3;
      _context.SaveChanges();
    }
    public void ReceivedPurchase(Model.Entities.purchase purchase) {
      Model.Entities.purchase purchase_submit = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase.purchase_id);
      // Received Purchase
      purchase_submit.status_id = 4;
      _context.SaveChanges();
    }
    public void ApprovePerchase(Model.Entities.purchase purchase) {
      Model.Entities.purchase purchase_approve = _context.Purchases.SingleOrDefault(p => p.purchase_id == purchase.purchase_id);
      purchase_approve.status_id = 2;
      purchase_approve.submit_date = DateTime.Now;
      purchase_approve.submit_by = "ConsoleApp";
      _context.SaveChanges();
    }

  }
}
