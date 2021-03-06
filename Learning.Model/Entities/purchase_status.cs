﻿using System.Collections.Generic;

namespace Learning.Model.Entities {
  public class purchase_status {
    public int purchase_status_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public virtual ICollection<purchase> purchases { get; set; }
  }
}