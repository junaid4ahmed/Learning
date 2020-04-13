﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Entities {
  public class payment {
    public int id { get; set; }
    public decimal amount { get; set; }
    public DateTime date { get; set; }
    public int payment_method_id { get; set; }
    public payment_method payment_method { get; set; }

    public int account_id { get; set; }
    public account account { get; set; }

  }
}
