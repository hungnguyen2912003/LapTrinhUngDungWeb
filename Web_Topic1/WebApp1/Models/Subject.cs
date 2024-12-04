using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Models
{
	public class Subject
	{
		public string Id {  get; set; }
		public string Name { get; set; }
		public byte Sodvht {  get; set; }
		public Subject(string i, string n, byte tc) 
		{
			Id = i;
			Name = n;
			Sodvht = tc;
		}
	}
}