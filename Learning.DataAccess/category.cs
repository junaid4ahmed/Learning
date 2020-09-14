using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess {
  public class category
    : Base {

    public Model.Entities.category select(int category_id) {
      Model.Entities.category category =
        _context.Categories.Find(new object[] { category_id });

      return category;
    }
    public bool insert(Model.Entities.category category) {
      bool result = false;
      try {
        _context.Categories.Add(category);
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot insert category in category's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot insert category in category's collection");
        Debug.WriteLine($"{exc.InnerException.InnerException.Message}");
      }
      return result;
    }
    public bool update(Model.Entities.category category) {
      bool result = false;
      try {
        _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update category in category's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot update category in category's collection");
        Debug.WriteLine(exc.InnerException.InnerException.Message);
      }
      return result;
    }
    public bool delect(Model.Entities.category category) {
      bool result = false;
      try {
        _context.Categories.Remove(category);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot delete category in category's collection");
        Debug.WriteLine($"{exc.InnerException.InnerException.Message}");
      }
      return result;
    }

  }
}
