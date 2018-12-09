using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBinding.Pages
{
	
	public class CascadeCallbackModel : ComponentBase
	{
		private bool _parentValue;
		internal bool ParentValue
		{
			get
			{
				return _parentValue;
			}
			set
			{
				AddEvent("Parent", $"Set ParentValue: {value}");
				_parentValue = value;
			}
		}

		internal void AddEvent(string Entity,string Value)
		{
			EventList.Add($"{Entity} - {DateTime.Now.ToLongTimeString()} : {Value}");
		}

		internal void Refresh(UIMouseEventArgs args)
		{
			AddEvent("Parent", $"Refresh: {args?.Type ?? "page"}");
			StateHasChanged();
		}

		internal void UpdateValue(bool value)
		{
			AddEvent("Parent", $"UpdateValue : {value}");
			ParentValue = value;
			Refresh(null);
		}

		internal string StateHasChangedCss => ParentValue ? "ping-on" : "ping-off";

		internal List<string> EventList = new List<string>();

		internal MarkupString GetEvents()
		{
			if (EventList?.Count == 0)
				return (MarkupString)string.Empty;

			StringBuilder events = new StringBuilder();
			string last = EventList?.Count > 0 ? EventList[0] : string.Empty;
			string curr = string.Empty;
			int count = 0;
			foreach (var item in EventList)
			{
				curr = item;
				if (!curr.Equals(last,StringComparison.Ordinal))
				{
					events.Append($"<span>{last} ( x {count} )</span><br />");
					count = 0;
				}
				last = curr;
				count++;
			}
			events.Append($"<span>{last} ( x {count} )</span><br />");
			return (MarkupString)events.ToString();
		}
	}
}
