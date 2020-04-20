namespace Learning.Model.Entities {
  public class purchase_item {
    public int purchase_item_id { get; set; }

    public int purchase_id { get; set; }
    public virtual purchase purchase { get; set; }

    public int product_id { get; set; }
    public virtual product product { get; set; }

    public int quantity { get; set; }
    public decimal unit_cast { get; set; }
    public bool inventoried { get; set; }

  }
}