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

      using (Context context = new Context()) {
        foreach (purchase_status item in context.Purchase_Statuses) {
          Console.WriteLine($" purchase_status_id { item.purchase_status_id } , name { item.name }, description { item.description } ");
        }
      }

      Console.WriteLine("press any key ...");
      Console.ReadKey();

    }
  }
}
