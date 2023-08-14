using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Model.Models
{
	public class MainBookDetails
	{
		public string Title { get; set; }
		public string ISBN { get; set; }
		public decimal Price { get; set; }
	}
}
