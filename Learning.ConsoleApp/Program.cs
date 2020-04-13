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

      testData t = new testData();
      //t.category_insert();
      //t.supplier_insert();
      //t.account_insert();
      //t.product_insert();

      //t.purchase_insert();
      //t.purchase_item_insert();
      //t.purchase_postInsert();

      //t.payment_insert();
      //t.payment_postInsert(2);
      //t.payment_postDelete(1);
      //t.payment_postUpdate(2);
      t.purchase_getStatus(1);
      t.reports();

      Console.WriteLine("press any key ...");
      Console.ReadKey();
    }


  }
}
