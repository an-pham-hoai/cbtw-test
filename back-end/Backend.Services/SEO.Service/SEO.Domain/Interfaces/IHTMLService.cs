using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO.Domain.Interfaces
{
    public interface IHTMLService
    {
        List<string> GetElementsByClassName(string html, string className);
    }
}
