using Learning.Model;

namespace Learning.DataAccess {
  public class Base {
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
    // _context instance variable must be initialized 
    // (through constructor or in declaration) at run time, 
    // readony is a runtime constant as compare to const

    // protected, assessable in inherited classes only
    protected static readonly Context _context = null;
    static Base() {
      _context = new Context();
    }
  }
}
