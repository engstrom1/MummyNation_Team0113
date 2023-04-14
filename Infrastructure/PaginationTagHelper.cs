using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MummyNation_Team0113.Models.ViewModels;

namespace MummyNation_Team0113.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory uhf;

        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            if (PageModel.TotalPages > 1)
            {
                // Show the first page link
                if (PageModel.CurrentPage > 2)
                {
                    TagBuilder firstPageLink = new TagBuilder("a");
                    firstPageLink.Attributes["href"] = uh.Action(PageAction, new { pageNum = 1 });
                    firstPageLink.InnerHtml.Append("1");
                    firstPageLink.AddCssClass(PageClass);
                    firstPageLink.AddCssClass(PageClassNormal);
                    final.InnerHtml.AppendHtml(firstPageLink);
                }

                // Show the first ellipsis
                if (PageModel.CurrentPage > 3)
                {
                    TagBuilder firstEllipsis = new TagBuilder("span");
                    firstEllipsis.InnerHtml.Append("...");
                    firstEllipsis.AddCssClass(PageClass);
                    firstEllipsis.AddCssClass(PageClassNormal);
                    final.InnerHtml.AppendHtml(firstEllipsis);
                }

                // Show the page links around the current page
                for (int i = Math.Max(1, PageModel.CurrentPage - 2); i <= Math.Min(PageModel.TotalPages, PageModel.CurrentPage + 2); i++)
                {
                    TagBuilder pageLink = new TagBuilder("a");
                    pageLink.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    pageLink.InnerHtml.Append(i.ToString());

                    if (i == PageModel.CurrentPage)
                    {
                        pageLink.AddCssClass(PageClass);
                        pageLink.AddCssClass(PageClassSelected);
                    }
                    else
                    {
                        pageLink.AddCssClass(PageClass);
                        pageLink.AddCssClass(PageClassNormal);
                    }

                    final.InnerHtml.AppendHtml(pageLink);
                }

                // Show the second ellipsis
                if (PageModel.CurrentPage < PageModel.TotalPages - 2)
                {
                    TagBuilder secondEllipsis = new TagBuilder("span");
                    secondEllipsis.InnerHtml.Append("...");
                    secondEllipsis.AddCssClass(PageClass);
                    secondEllipsis.AddCssClass(PageClassNormal);
                    final.InnerHtml.AppendHtml(secondEllipsis);
                }

                // Show the final page link
                if (PageModel.CurrentPage < PageModel.TotalPages - 1)
                {
                    TagBuilder lastPageLink = new TagBuilder("a");
                    lastPageLink.Attributes["href"] = uh.Action(PageAction, new { pageNum = PageModel.TotalPages });
                    lastPageLink.InnerHtml.Append(PageModel.TotalPages.ToString());
                    lastPageLink.AddCssClass(PageClass);
                    lastPageLink.AddCssClass(PageClassNormal);
                    final.InnerHtml.AppendHtml(lastPageLink);
                }
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
    }
}
