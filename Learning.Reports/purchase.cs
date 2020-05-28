using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Reports {
  public class purchase
     : parent {

    public purchase() { }

    public void select() {
      Console.WriteLine("purchases");
      var pur_col =
      _context
      .Purchases
      .Include("purchase_items.product")
      .Select(pur_sel => new {
        id = pur_sel.purchase_id,
        pur_sel.status_id,
        sub_total = pur_sel.purchase_items.Count != 0 ? pur_sel.purchase_items.Sum(su => su.quantity * su.unit_cast) : 0.0m,
        products = pur_sel.purchase_items.Select(ite_sel => new { id = ite_sel.purchase_item_id, ite_sel.product_id, ite_sel.product.name, ite_sel.quantity, ite_sel.unit_cast, ite_sel.inventoried, total = (ite_sel.quantity * ite_sel.unit_cast) }),
      });

      foreach (var pur in pur_col) {
        Console.WriteLine($"-{pur.id} { Enum.GetName(typeof(DataAccess.purchase_status), pur.status_id) } {pur.sub_total} { pur.status_id }");
        foreach (var ite in pur.products) {
          Console.WriteLine($"--{ite.product_id } {ite.name} {ite.quantity} {ite.unit_cast} {ite.total}, { ite.inventoried }");
        }
      }
      Console.WriteLine();
    }

    public void select_by_account() {

      Console.WriteLine("purchase; select by account");
      var pur_col = _context.Purchases.Include("purchase_items.product").Include("account")
      .Select(pur_sel => new {
        pur_sel.purchase_id,
        pur_sel.account.name,
        pur_sel.status_id,
        sub_total = pur_sel.purchase_items.Count != 0 ? pur_sel.purchase_items.Sum(su => su.quantity * su.unit_cast) : 0.0m,
        products = pur_sel.purchase_items.Select(ite_sel => new { id = ite_sel.purchase_item_id, ite_sel.product_id, ite_sel.product.name, ite_sel.quantity, ite_sel.unit_cast, ite_sel.inventoried, total = (ite_sel.quantity * ite_sel.unit_cast) }),
      }).GroupBy(g => g.name);

      foreach (var group in pur_col) {
        string total_purchases_worth = group.Sum(s => s.products.Sum(ss => ss.total)).ToString("N", new CultureInfo("hi-IN"));
        Console.WriteLine($"-{ group.Key } { total_purchases_worth }");
        foreach (var group_item in group) {
          Console.WriteLine($"--{ Enum.GetName(typeof(DataAccess.purchase_status), group_item.status_id) } { group_item.sub_total.ToString("N", new CultureInfo("hi-IN")) } ");
          foreach (var ite in group_item.products) {
            Console.WriteLine($"--{ ite.product_id } { ite.name } { ite.quantity } { ite.unit_cast } { ite.total.ToString("N", new CultureInfo("hi-IN")) }, { ite.inventoried }");
          }
        }
      }


      Console.WriteLine();
    }



  }
}
