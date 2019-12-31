using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;
using Blazor = Microsoft.AspNetCore.Components;

namespace BlazorBinding.Components
{
    public partial class BlazorComponentExt : ComponentBase
	{
		[Blazor.Parameter] public RenderFragment Body { get; set; }

		protected override void OnInitialized()
		{
			Console.WriteLine("MYINIT");
			base.OnInitialized();
			RegisterModels(GetType());
		}

		private void RegisterModels(Type type)
		{
			Console.WriteLine("REGISTER");
			var props = ((System.Reflection.TypeInfo)type).DeclaredProperties;
			foreach (var prop in props)
			{
				var attr = (ModelAttribute)Attribute.GetCustomAttribute(prop, typeof(ModelAttribute));
				if (attr is null)
				{
					Console.WriteLine($"Property {prop.Name} is not a Model");
				}
				else
				{
					Console.WriteLine($"Property {prop.Name} is a model called {prop.PropertyType.Name}");
					var model = prop.GetValue(this);
					if (model is null)
					{
						Console.WriteLine("The model is null, newing up...");
						model = Activator.CreateInstance(prop.PropertyType);
						prop.SetValue(this, model);
					}
					((INotifyPropertyChanged)model).PropertyChanged += Vm_PropertyChanged;
				}
			}
		}

		private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Console.WriteLine($"Property {e.PropertyName} changed on {sender.GetType().Name}");
			StateHasChanged();
		}
	}
}
