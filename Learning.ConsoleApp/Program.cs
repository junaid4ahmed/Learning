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
        foreach (category item in context.Categories) {
          Console.WriteLine($" category_id { item.category_id } , name { item.name } ");
        }

      }

      Console.WriteLine("press any key ...");
      Console.ReadKey();

    }
  }
}
