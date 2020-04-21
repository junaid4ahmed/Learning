using Learning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class parent {
    protected static Context _context = null;
    static parent() {
      _context = new Context();
    }
  }
}
