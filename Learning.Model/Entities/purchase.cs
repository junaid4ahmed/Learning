using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Entities {
  public class purchase {
    public int purchase_id { get; set; }

    [DataType(DataType.Date)]
    public DateTime insert_date { get; set; }
    public string insert_by { get; set; }

    [DataType(DataType.Date)]
    public DateTime? submit_date { get; set; }
    public string submit_by { get; set; }

    [DataType(DataType.Date)]
    public DateTime? approve_date { get; set; }
    public string approve_by { get; set; }

    [DataType(DataType.Date)]
    public DateTime expect_date { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C0}")]
    //[RegularExpression(pattern: @"^[0-9]*$", ErrorMessage = "Only numbers are allowed in shipping fee")]
    public decimal shipping_fee { get; set; }

    [Required]
    [RegularExpression(pattern: @"^[0-9]*$", ErrorMessage = "Only numbers are allowed in shipping Id")]
    public int supplier_id { get; set; }
    public virtual supplier supplier { get; set; }
    public decimal Taxes { get; set; }

    [DataType(DataType.Date)]
    public DateTime? payment_date { get; set; }
    public decimal payment_amount { get; set; }
    public int payment_method_id { get; set; }
    public payment_method payment_method { get; set; }


    public int purchase_status_id { get; set; }
    public purchase_status purchase_status { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in notes")]
    [DataType(dataType: DataType.MultilineText)]
    public string notes { get; set; }

    public virtual ICollection<purchase_item> purchase_items { get; set; }

  }

}
