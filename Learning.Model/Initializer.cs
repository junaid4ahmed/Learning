using Learning.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Learning.Model {
  internal class Initializer
   : DropCreateDatabaseIfModelChanges<Context> {

    protected override void Seed(Context context) {
      List<Entities.category> categories = new List<Entities.category> {
        new Entities.category() { name = "Movies", description = string.Empty },
        new Entities.category() { name = "Games", description = string.Empty }
      };
      categories.ForEach(c => context.Categories.Add(c));


      base.Seed(context);
    }
  }
}