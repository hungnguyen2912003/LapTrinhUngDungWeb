using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai4_Bonus.Models
{
	public class Subject
	{
		public string id {  get; set; }
		public string name {  get; set; }
		public byte sdvht { get; set; }
		public Subject(string i, string n, byte tc) 
		{
			id = i;
			name = n;
			sdvht = tc;
		}
	}
}