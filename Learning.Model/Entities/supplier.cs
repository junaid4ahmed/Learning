using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learning.Model.Entities {
  public class supplier {
    public int supplier_id { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in address")]
    [Required]
    [StringLength(70, MinimumLength = 3)]
    public string company { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in address")]
    [Required]
    [StringLength(70, MinimumLength = 3)]
    public string first_name { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in address")]
    [Required]
    [StringLength(70, MinimumLength = 3)]
    public string last_name { get; set; }

    [RegularExpression(pattern: @"^\+[0-9]\d{1,3}\d{3}\d{6}$", ErrorMessage = "Business phone is not currect, currect format +92 323 5860384")]
    [Required]
    [StringLength(70, MinimumLength = 3)]
    public string business_phone { get; set; }

    public string home_phone { get; set; }

    [RegularExpression(pattern: @"^\+[0-9]\d{1,3}\d{3}\d{6}$", ErrorMessage = "Business phone is not currect, currect format +92 323 5860384")]
    public string Fax_number { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in address")]
    public string address { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in city")]
    public string city { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in state")]
    public string state { get; set; }

    [RegularExpression(pattern: @"^[0-9]\d{4}$", ErrorMessage = "Only numbers are allowed in zip and must be 5 digits long")]
    public string zip { get; set; }

    [RegularExpression(pattern: @"^[a-zA-Z0-9 ]*$", ErrorMessage = "Only alphabets and numbers are allowed in notes")]
    [DataType(dataType: DataType.MultilineText)]
    public string notes { get; set; }

    [RegularExpression(pattern: @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email is not currect, currect format currect@gmail.com")]
    [Required]
    public string email { get; set; }

    public virtual ICollection<purchase> purchases {
      get; set;
    }

  }
}