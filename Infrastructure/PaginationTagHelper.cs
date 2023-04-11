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

        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i  <= PageModel.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                if (i == 1 || i == PageModel.CurrentPage || i == PageModel.TotalPages || (i >= PageModel.CurrentPage - 2 && i <= PageModel.CurrentPage + 2))
                {
                    
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.InnerHtml.Append(i.ToString());
                }
                else if (i == PageModel.CurrentPage - 3 || i == PageModel.CurrentPage + 3)
                {
                    //display ellipsis (...) to indicate skipped pages
                    tb.InnerHtml.Append("...");
                }
                
                //TagBuilder tb = new TagBuilder("a");
                //tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                //tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
