using Learning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class parent {
    protected readonly Context _context = null;
    public parent() {
      _context = new Context();
    }
  }
}
