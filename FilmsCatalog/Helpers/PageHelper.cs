using FilmsCatalog.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Text;
using System.Text.Encodings.Web;

namespace FilmsCatalog.Helpers
{
    public static class PageHelper
    {
        public static HtmlString PageLinks(this IHtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.Append(i.ToString());

                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                tag.AddCssClass("btn btn-default");

                result.Append(GetString(tag));
            }

            return new HtmlString(result.ToString());
        }

        /// <summary>
        /// Получить из TabBuilder строку
        /// 
        /// P.S. Костыль. ToString() не возвращает строку
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static string GetString(TagBuilder builder)
        {
            var stringWriter = new System.IO.StringWriter();
            builder.WriteTo(stringWriter, HtmlEncoder.Default);
            
            return stringWriter.ToString();
        }
    }
}
