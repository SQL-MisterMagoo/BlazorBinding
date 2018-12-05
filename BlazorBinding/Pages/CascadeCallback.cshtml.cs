using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBinding.Pages
{
	
	public class CascadeCallbackModel : BlazorComponent
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

		internal Dictionary<int,string> CodeSample = new Dictionary<int, string>();
		internal List<string> EventList = new List<string>();

		internal string ClearSamples()
		{
			CodeSample.Clear();
			return string.Empty;
		}

		internal MarkupString AddCode(int id, string code)
		{
			AddOrUpdateCode(id, code);
			return (MarkupString)code;
		}

		internal string AddCodeSample(int id, string code)
		{
			AddOrUpdateCode(id, code);
			return string.Empty;
		}

		private void AddOrUpdateCode(int id, string code)
		{
			if (CodeSample.ContainsKey(id))
			{
				CodeSample[id] += $"\n{code}";
			}
			else
			{
				CodeSample[id] = code;
			}
		}

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
