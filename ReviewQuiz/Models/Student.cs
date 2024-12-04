using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReviewQuiz.Models
{
	public class Student
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int Dvht { get; set; }
		public string Class {  get; set; }
		public Student(string i, string n, int tc)
		{
			Id = i;
			Name = n;
			Dvht = tc;
		}
		public Student(string n, string c)
		{
			Name = n;
			Class = c;
		}
	}
}