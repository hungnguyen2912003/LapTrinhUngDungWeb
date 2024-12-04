using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleStudent.Models
{
	public class Student
	{
		public List<Student> stud { get; set; }
		public List<Student> studclass { get; set; }

		public int Id { get; set; }
		public string Name { get; set; }
		public string Class {  get; set; }
		public Student()
		{
			this.Id = Id;
			this.Name = Name;
			this.Class = Class;
		}
		public Student(int i, string n, string c) 
		{
			Id = i;
			Name = n;
			Class = c;
		}

	}
}