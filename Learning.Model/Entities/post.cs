using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.Entities {
 public class post {
		public int post_id { get; set; }
		public DateTime log { get; set; }
		public int account_id { get; set; }
		public account account { get; set; }
		public int post_type_id { get; set; }
		public post_type post_type { get; set; }
		public int identifier { get; set; }
		public string description { get; set; }
		public decimal crebit { get; set; }
		public decimal debit { get; set; }
	}
}
