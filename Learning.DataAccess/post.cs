
using System;
using System.Linq;

namespace Learning.DataAccess {
  public class post
    : Base {

    public Model.Entities.post select(int post_type_id, int identifier) {
      Model.Entities.post post = _context.Posts.SingleOrDefault(p => (p.post_type_id == post_type_id & p.identifier == identifier));
      return post;
    }
    public bool insert(Model.Entities.post post) {
      bool result = false;
      try {
        _context.Posts.Add(post);
        _context.SaveChanges();
        result = true;
      } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
        // log; cannot insert purchase

      }
      return result;
    }
    public bool update(Model.Entities.post p) {
      bool result = false;
      Model.Entities.post post = select(p.post_type_id, p.identifier);
      if (post != null) {
        try {
          post.post_type_id = p.post_type_id;
          post.account_id = p.account_id;
          post.log = p.log;

          post.crebit = p.crebit;
          post.debit = p.debit;
          post.description = p.description;

          _context.SaveChanges();
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update the post
        }
        // log; cannot find the require post 
      }
      return result;
    }
    public bool update(int post_type_id, int identifier, decimal total) {
      bool result = false;
      Model.Entities.post post = select(post_type_id, identifier);
      if (post != null) {
        try {
          post.crebit = total;
          _context.SaveChanges();
          result = true;
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update the purchase in post
        }
      } else {
        // log; cannot find the required purchase post
      }
      return result;
    }
    public bool delete(int post_type_id, int identifier) {
      bool result = false;
      Model.Entities.post post = select(post_type_id, identifier);
      if (post != null) {
        try {
          _context.Posts.Remove(post);
          _context.SaveChanges();
          result = true;
        } catch (System.Data.Entity.Infrastructure.DbUpdateException) {
          // log; cannot update post
        }
      } else {
        // log; cannot find the post to delete
      }
      return result;
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
