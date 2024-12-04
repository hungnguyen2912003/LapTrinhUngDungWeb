using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace _63132095_NguyenKhacDuyHung.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Class {  get; set; }
		public string Photo {  get; set; }
		public Student(int i, string n, string c, string p) 
		{
			Id = i;
			Name = n;
			Class = c;
			Photo = p;
		}
	}
}