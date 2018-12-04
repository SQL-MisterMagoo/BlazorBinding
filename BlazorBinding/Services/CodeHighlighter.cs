using Highlight.Configuration;
using Highlight.Engines;
using Highlight.Patterns;

namespace BlazorBinding.Services
{
	public class CodeHighlighter : ICodeHighlighter
	{
		public CodeHighlighter()
		{

			IConfiguration configuration = new DefaultConfiguration();
			HtmlDefinition = configuration.Definitions["HTML"];
			CSharpDefinition = configuration.Definitions["C#"];
			Engine = new HtmlEngine();

		}

		public Definition HtmlDefinition { get; }
		public Definition CSharpDefinition { get; }
		public HtmlEngine Engine { get; }

		public string HighlightHtml(string HtmlString)
		{
			return Engine.Highlight(HtmlDefinition, HtmlString);
		}

		public string HighlightCSharp(string CSharpString)
		{
			return Engine.Highlight(CSharpDefinition, CSharpString);
		}
	}
}
