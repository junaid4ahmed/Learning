﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Entities {
 public class account_type {
    public int account_type_id { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    public string name { get; set; }
    public string description { get; set; }
    public ICollection<account> accounts { get; set; }
  }
}
