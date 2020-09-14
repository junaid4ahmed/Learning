
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace Learning.DataAccess {
  public class post
    : Base {

    public Model.Entities.post select(int type_id, int identifier) {
      Model.Entities.post post = _context.Posts.SingleOrDefault(p => (p.post_type_id == type_id & p.identifier == identifier));
      return post;
    }
    public bool insert(Model.Entities.post post) {
      bool result = false;
      try {
        _context.Posts.Add(post);
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update account in account's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($" cannot insert post in post's collection");
        Debug.WriteLine(exc.InnerException.InnerException.Message);
      }
      return result;
    }
    public bool update(Model.Entities.post post) {
      bool result = false;
      try {
        _context.Entry(post).State = System.Data.Entity.EntityState.Modified;
        _context.SaveChanges();
        result = true;
      } catch (DbEntityValidationException exc) {
        Debug.WriteLine($"cannot update post in post's collection");
        foreach (DbEntityValidationResult errors in exc.EntityValidationErrors) {
          foreach (DbValidationError item in errors.ValidationErrors) {
            Debug.WriteLine($"{ item.PropertyName }");
            Debug.WriteLine($"{ item.ErrorMessage }");
          }
        }
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot update post in post's collection");
        Debug.WriteLine(exc.InnerException.InnerException.Message);
      }
      return result;
    }
    public bool delete(Model.Entities.post post) {
      bool result = false;
      try {
        _context.Posts.Remove(post);
        _context.SaveChanges();
        result = true;
      } catch (DbUpdateException exc) {
        Debug.WriteLine($"cannot delete post in post's collection");
        Debug.WriteLine($"{exc.InnerException.InnerException.Message}");
      }
      return result;
    }

  }
}
