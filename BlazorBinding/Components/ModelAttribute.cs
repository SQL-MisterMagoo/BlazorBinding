using System;

namespace BlazorBinding.Components
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	sealed class ModelAttribute : Attribute
	{
		public ModelAttribute() { }
	}
}
