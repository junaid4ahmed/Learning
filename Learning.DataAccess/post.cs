
using System;
using System.Linq;

namespace Learning.DataAccess {
  public class post
    : parent {

    public Model.Entities.post select(int post_type_id, int identifier) {
      Model.Entities.post post = _context.Posts.SingleOrDefault(p => (p.post_type_id == post_type_id & p.identifier == identifier));
      return post;
    }
    public void insert(Model.Entities.post post) {
      _context.Posts.Add(post);
      _context.SaveChanges();
    }
    public void update(Model.Entities.post post) {
      if (post != null) {
        _context.SaveChanges();
      }
    }
    public void update(int post_type_id, int identifier, decimal total) {
      Model.Entities.post temp = select(post_type_id, identifier);
      temp.crebit = total;
      _context.SaveChanges();
    }
    public void delete(int post_type_id, int identifier) {
      Model.Entities.post post = select(post_type_id, identifier);
      _context.Posts.Remove(post);
      _context.SaveChanges();
    }
    public void delete(Model.Entities.post post) {
      if (post != null) {
        Model.Entities.post temp = _context.Posts.Find(new object[] { post.post_id });
        if (temp != null) {
          try {
            _context.Posts.Remove(temp);
            _context.SaveChanges();
          } catch (Exception) {
            throw;
          }
        }
      }
    }
    public bool exists(int post_type_id, int identifier) {
      bool result = false;
      Model.Entities.post post = select(post_type_id, identifier);
      if (post != null) {
        result = true;
      }
      return result;
    }

  }

}
