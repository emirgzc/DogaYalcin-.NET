using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Settings : IEntity
	{
		[Key]
		public int SetId { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }		
		public string City { get; set; }		
		public string Country { get; set; }		
		public string WorkToDay { get; set; }
		public string Twitter { get; set; }
		public string Instagram { get; set; }
		public string Facebook { get; set; }		
		public string Linkedin { get; set; }		
		public string Youtube { get; set; }
		public string Map { get; set; }
	}
}
