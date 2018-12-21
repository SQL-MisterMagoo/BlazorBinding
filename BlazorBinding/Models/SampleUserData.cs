using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBinding.Models
{
	public class SampleUserData : ISampleData
	{
		public SampleUserData()
		{
		}

		public SampleUserData(string Name, string NickName)
		{
			this.Name = Name;
			this.NickName = NickName;
		}

		public int Id { get; }
		public string Name { get ; set ; }
		public string NickName { get ; set ; }
	}
}
