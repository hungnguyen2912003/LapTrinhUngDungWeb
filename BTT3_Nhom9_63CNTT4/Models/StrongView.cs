using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTT3_Nhom9_63CNTT4.Models
{
	public class StrongView
	{
		public int Id {  get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public skills skills {  get; set; }
	}
	public enum skills
	{
		HTML5,
		CSS3,
		Bootstrap,
		MVC,
		WebAPI
	}
}