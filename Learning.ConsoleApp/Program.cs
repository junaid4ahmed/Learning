﻿using System;


namespace Learning.ConsoleApp {
  class Program {

    static void Main(string[] args) {

      Console.Title = "Learning.ConsoleApp";
      //Console.WriteLine($" ");

      Controller t = new Controller();
      //t.category_insert();
      //t.supplier_insert();

      //t.account_insert();
      //t.account_update();

      //t.product_insert();
      //t.product_update();

      //t.purchase_insert();
      //t.purchase_submit(3);
      //t.purchase_approve(12);
      //t.purchase_delete(3);

      //t.purchaseitem_insert(12);
      //t.purchaseitem_update(2, 1);
      //t.purchaseitem_delete(4, 1);

      //t.inventory_purchaseItemInsert(12, 1);
      //t.inventory_purchaseItemDelete(12, 1);

      //t.purchase_postInsert(11);
      //t.purchase_postUpdate(12);
      //t.purchase_postDelete(4);

      //t.payment_insert(1);
      //t.payment_update(6);
      //t.payment_delete(6);

      //t.payment_postInsert(7);
      //t.payment_postDelete(7);

      t.reports();

      Console.WriteLine("press any key ...");
      Console.ReadKey();
    }

  }
}
