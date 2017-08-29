using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Markdig;

namespace CodeChallengeRunner.Pages.TagHelpers
{
    public class MarkdownTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var childContent = await output.GetChildContentAsync();
            var markdownContent = childContent.GetContent();
            var convertedHtml = Markdown.ToHtml(markdownContent);
            output.Content.SetHtmlContent(convertedHtml);
        }
    }
}
