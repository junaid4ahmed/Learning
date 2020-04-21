using Learning.Model;
using Learning.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning.ConsoleApp {
  class Program {

    static void Main(string[] args) {

      Console.Title = "Learning.ConsoleApp";
      //Console.WriteLine($" ");

      Controller t = new Controller();
      //t.category_insert();
      //t.supplier_insert();
      //t.account_insert();
      //t.product_insert();

      //t.purchase_insert();

      //t.purchaseitem_insert();
      //t.purchaseitem_update(1, 3);
      //t.purchaseitem_delete(1, 1);

      t.inventory_purchaseItemInsert(1, 1);
      //t.inventory_purchaseItemDelete(1, 1);

      //t.payment_insert();
      //t.payment_delete(2);
      //t.payment_update(2);

      //t.purchase_postInsert(1);
      //t.purchase_postUpdate(2);
      //t.purchase_postDelete(1);

      //t.payment_postInsert(1);
      //t.payment_postInsert(2);
      //t.payment_postDelete(2);
      //t.payment_postUpdate(2);

      t.reports();

      Console.WriteLine("press any key ...");
      Console.ReadKey();
    }


  }
}
