using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Entities {
  public class account {
    public int id { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public DateTime register { get; set; }
    public int account_type_id { get; set; }
    public account_type account_type { get; set; }

  }
}
