
using ColorCode;
using ColorCode.Common;
using ColorCode.Styling;

namespace BlazorBinding.Services
{
	public class CodeHighlighter : ICodeHighlighter
	{
		public HtmlFormatter Formatter { get; }

		public CodeHighlighter()
		{
			StyleDictionary style = StyleDictionary.DefaultLight;
			style[ScopeName.PlainText].Background = "";
			Formatter = new HtmlFormatter(style);
		}

		public string HighlightHtml(string HtmlString)
		{
			return HighlightCode("Html", HtmlString);
		}

		public string HighlightCSharp(string CSharpString)
		{
			return HighlightCode("CSharp", CSharpString);
		}

		private string HighlightCode(string Language, string code)
		{
			var lang = ColorCode.Languages.FindById(Language);
			if (lang == null)
			{
				var langName = System.Net.WebUtility.HtmlEncode(Language);
				return $"<span style='color: red'>Unable to parse language <b>{langName}</b></span>";
			}
			return Formatter.GetHtmlString(code, lang);
		}
	}
}
