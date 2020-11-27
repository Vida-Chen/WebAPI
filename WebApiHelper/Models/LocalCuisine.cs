using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLibrary;

namespace WebApiHelper.Models
{
	[DbTableName("tb_LocalFood")]
	public class LocalCuisine
	{
		[Key]
		public string ID { get; set; }
		public string ITEM { get; set; }
		public string NAME { get; set; }
		public string DISTRICT { get; set; }
		public string PHONE { get; set; }
		public string ADDRESS { get; set; }
	}
}
