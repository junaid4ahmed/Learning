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

    public decimal Taxes { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in notes")]
    [DataType(dataType: DataType.MultilineText)]
    public string notes { get; set; }

    [Required]
    [RegularExpression(pattern: @"^[0-9]*$", ErrorMessage = "Only numbers are allowed in shipping Id")]
    public int supplier_id { get; set; }
    public virtual supplier supplier { get; set; }

    public int account_id { get; set; }
    public account account { get; set; }
    public int status_id { get; set; }

    // https://stackoverflow.com/questions/29414659/the-item-with-identity-x-already-exists-in-the-metadata-collection-how-do-i-f/45174778
    //This bug happens when you use underscores in the name of your entities.The reason is Entity Framework also uses underscores to create the names of the keys(concatenating the entity and property names).
    // for example table name is "purchase" and property name is "status" when 
    // entity frame concate it becone purchase_status and conflit with other table 
    // which as same name as purchase_status
    public purchase_status purchase_status { get; set; }
    public virtual ICollection<purchase_item> purchase_items { get; set; }
    public virtual ICollection<inventory> inventories { get; set; }

  }
}
