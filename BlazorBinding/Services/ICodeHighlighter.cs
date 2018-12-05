
namespace BlazorBinding.Services
{
	public interface ICodeHighlighter
	{
		string HighlightHtml(string HtmlString);

		string HighlightCSharp(string CSharpString);
	}
}
