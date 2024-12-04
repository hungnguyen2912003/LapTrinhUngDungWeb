using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewExample.Models
{
	public class Subject
	{
		public string Id {  get; set; }
		public string Name { get; set; }
		public byte Dvht {  get; set; }
		public Subject(string i, string n, byte tc) 
		{
			Id = i;
			Name = n;
			Dvht = tc;
		}
	}
}