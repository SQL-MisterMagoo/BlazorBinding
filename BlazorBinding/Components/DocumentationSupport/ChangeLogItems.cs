using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBinding.Components.DocumentationSupport
{
	public class ChangeLog
	{
		public DateTime dated { get; set; }
		public string content { get; set; }
		public Child[] child { get; set; }
	}

	public class Child
	{
		public string text { get; set; }
	}

}

