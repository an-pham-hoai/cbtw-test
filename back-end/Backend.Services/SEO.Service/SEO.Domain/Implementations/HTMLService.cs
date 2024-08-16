using SEO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEO.Domain.Implementations
{
    public class HTMLService : IHTMLService
    {
        public List<string> GetElementsByClassName(string html, string className)
        {
            var elements = new List<string>();
            string pattern = $@"<([a-zA-Z]+)([^>]*\bclass\s*=\s*['""]\b{className}\b['""][^>]*)>(.*?)<\/\1>";

            var matches = Regex.Matches(html, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                elements.Add(match.Value);
            }

            return elements;
        }
    }
}
