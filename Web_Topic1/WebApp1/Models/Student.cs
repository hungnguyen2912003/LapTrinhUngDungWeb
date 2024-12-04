using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp1;

namespace WebApp1.Models
{
	public class Student
	{
		public string Name {  get; set; }
		public string Class {  get; set; }
		public Student(string n, string l) 
		{
			Name = n;
			Class = l;
		}
	}
}