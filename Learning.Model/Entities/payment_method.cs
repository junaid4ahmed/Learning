using System.Collections.Generic;

namespace Learning.Model.Entities {
  public class payment_method {
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public virtual ICollection<payment> payments { get; set; }
  }
}