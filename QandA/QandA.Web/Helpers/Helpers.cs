using QandA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QandA.Web.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            //  Construct the first page tag
            TagBuilder fp_tag = new TagBuilder("a");
            fp_tag.MergeAttribute("href", pageUrl(1));
            fp_tag.InnerHtml = "First Page";
            result.AppendLine(fp_tag.ToString());

            //  Construct the previous page tag
            TagBuilder pp_tag = new TagBuilder("a");
            if (pagingInfo.CurrentPage == 1)
            {
                pp_tag.MergeAttribute("href", pageUrl(1));
            }
            else
            {
                pp_tag.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
            }
            pp_tag.InnerHtml = "Previous Page";
            result.AppendLine(pp_tag.ToString());


            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                // Construct an <a> tag
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                result.AppendLine(tag.ToString());
            }

            //  Construct the next page tag
            TagBuilder np_tag = new TagBuilder("a");
            if (pagingInfo.CurrentPage == pagingInfo.TotalPages)
            {
                np_tag.MergeAttribute("href", pageUrl(pagingInfo.TotalPages));
            }
            else
            {
                np_tag.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
            }
            np_tag.InnerHtml = "Next Page";
            result.AppendLine(np_tag.ToString());

            //  Construct the last page tag
            TagBuilder lp_tag = new TagBuilder("a");
            lp_tag.MergeAttribute("href", pageUrl(pagingInfo.TotalPages));
            lp_tag.InnerHtml = "Last Page";
            result.AppendLine(lp_tag.ToString());

            return MvcHtmlString.Create(result.ToString());
        }

    }
}