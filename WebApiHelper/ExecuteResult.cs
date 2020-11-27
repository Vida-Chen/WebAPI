using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHelper
{
	public class ExecuteResult
	{
		public bool IsSuccess { get; set; }
		public IEnumerable<object> Data { get; set; }
		public string Msg { get; set; }
	}
}
