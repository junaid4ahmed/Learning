using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Entities {
  public class inventory {
    // (id, type, product_id, quantity, log, modify, purchase_id, order_id, comments)
    public int id { get; set; }

    public int product_id { get; set; }
    public product product { get; set; }

    public int? purchase_id { get; set; }
    public purchase purchase { get; set; }

    public int inventory_type_id { get; set; }
    public inventory_type inventory_type { get; set; }

    public int quantity { get; set; }
    public decimal price { get; set; }

    public DateTime log { get; set; }
    public DateTime modift { get; set; }

    public string comments { get; set; }

  }
}
