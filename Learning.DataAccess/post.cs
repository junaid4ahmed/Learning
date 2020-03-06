
using System;

namespace Learning.DataAccess {
  public class post 
    : parent {

    public void insert(Model.Entities.post post) {
      _context.Posts.Add(post);
      _context.SaveChanges();
    }

    public void update(Model.Entities.post post) {
      if(post != null) {
        Model.Entities.post temp = _context.Posts.Find(new object[] { post.post_id });
        if(temp != null) {
          try {
            temp = post;
            _context.SaveChanges();
          } catch(Exception) {
            throw;
          }
        }
      }
    }

    public void delete(Model.Entities.post post) {
      if(post != null) {
        Model.Entities.post temp = _context.Posts.Find(new object[] { post.post_id });
        if(temp != null) {
          try {
            _context.Posts.Remove(temp);
            _context.SaveChanges();
          } catch(Exception) {
            throw;
          }
        }
      }

    }

  }

}
