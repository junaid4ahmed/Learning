using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public enum purchase_status {
    New = 0,
    Submit = 1,
    Approve = 2,
    Receive = 3,
    Closed = 4
  }

  public enum post_type {
    Purchase = 0,
    Payment = 1,
    Recepit = 2,
    Sale = 3
  }

  public enum payment_method {
    Cash = 0,
    Ewallets = 1,
    CreditCards = 2,
    MobilePayments = 3,
    BankTransfers = 4,
    PrepaidCards = 5,
    DirectDeposit = 6
  }

  public enum account_type {
    Expanses = 0,
    Income = 1
  }

  public enum inventory_type {
    Purchased = 0,
    Sold = 1,
    OnHold = 2,
    Waste = 3
  }

}
