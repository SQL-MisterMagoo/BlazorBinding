using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorBinding.Models
{
	class DataModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		bool _toggle;

		public bool Toggle
		{
			get => _toggle;
			set
			{
				if (value != _toggle)
				{
					_toggle = value;
					RaisePropertyChanged();
				}
			}
		}

		private void RaisePropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
