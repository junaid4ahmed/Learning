using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learning.Model.Entities {
  public class post_type {
    public int post_type_id { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    public string name { get; set; }
    public string description { get; set; }
    public virtual ICollection<post> posts { get; set; }
  }
}