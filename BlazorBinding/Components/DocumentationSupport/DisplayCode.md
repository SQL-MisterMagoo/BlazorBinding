# DisplayCode enhancement

When I saw SQL Mister Magoo's excellent BlazorBinding project I thought it would be an
interesting experiment to try to add Code Syntax Highlighting to his `<DisplayCode>` component.

This turned out to be a bit tricker than I realised, since we had to permit Blazor to render the 
`ChildContent` render fragment first, and then grab the HTML via JS interop, and re-render 
using a .NET library.

### ColorCode

I looked on [Nuget](https://nuget.org) for Syntax Highlighting packages that would work on 
.NET Standard (required since this is client-side Blazor), and found 
[ColorCode](https://github.com/WilliamABradley/ColorCode-Universal), which works very well and 
supports multiple languages.

### DisplayCode
So I amended the `<DisplayCode>` component to add a unique ID to each code `<div>` so we
could pull the `innerText` from the element, apply the syntax highlighting, and then re-render
the text back.

I added the file `wwwroot/js/displayCode.js` library to host the Javascript methods I needed, and 
added these to the `index.html` page. The helper methods `GetInnerText` and `SetInnerHTML` call the 
Javascript code.

I also added an override for `OnAfterRenderAsync` which then grabs the raw inner text
from the `div` and applies the syntax highlighting.

I also added a new `[Parameter] string Languages {get;set;} = "html";` which
defaults to HTML (since most examples use this), but allows the component to do
highlighting for any of the
[supported languages](https://github.com/WilliamABradley/ColorCode-Universal/blob/master/ColorCode.Core/Common/LanguageId.cs)

Example:
```
  <DisplayCode Language="c#">
   @("<public static void Main() { };>")
  </DisplayCode>
```
### Issues

The `<pre>` tag added a number of blank lines and I added the `CleanCode` method to trim these off, otherwise the code sample 
has a lot of blank space above/below. There might be a better fix for this, as it would also remove intentionally blank lines within
the code as well as at the start/end.


