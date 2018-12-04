using Highlight.Engines;
using Highlight.Patterns;

namespace BlazorBinding.Services
{
	public interface ICodeHighlighter
	{
		Definition HtmlDefinition { get; }
		Definition CSharpDefinition { get; }
		HtmlEngine Engine { get; }

		string HighlightHtml(string HtmlString);

		string HighlightCSharp(string CSharpString);
	}
}
