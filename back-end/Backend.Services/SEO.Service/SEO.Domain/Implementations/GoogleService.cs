using Backend.Share.DTO.Implementations;
using Backend.Share.DTO.Interfaces;
using Backend.Share.Enums;
using Backend.Shared.DTO.Interfaces;
using SEO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO.Domain.Implementations
{
    public class GoogleService : IGoogleService
    {
        private readonly IFetchService fetchService;

        public GoogleService(IFetchService fetchService)
        {
            this.fetchService = fetchService;
        }

        public async Task<ISEOInfoDTO> GetSeoInfo(string query)
        {
            try
            {
                //https://www.google.co.uk/search?num=100&q=land+registry+search
                IFetchDTO fetchDTO = await fetchService.Fetch($"https://www.google.co.uk/search?num=100&q={query}");
                if (!string.IsNullOrEmpty(fetchDTO.Error))
                {
                    return new SEOInfoDTO()
                    {
                        Error = fetchDTO.Error,
                    };
                }

                string html = fetchDTO.Content;
                List<string> anchors = GetAnchors(html);
                Log(anchors);
                int rank = GetRank(anchors);

                SEOInfoDTO sEOInfo = new SEOInfoDTO()
                {
                    Query = query,
                    SearchProvider = SearchProvider.Google,
                    Rank = rank,
                };
                return sEOInfo;
            }
            catch (Exception e) 
            { 
                return new SEOInfoDTO()
                {
                    Error = e.Message,
                };
            }
        }

        private int GetRank(List<string> anchors) 
        { 
            for (int i = 0; i < anchors.Count; i++)
            {
                Console.WriteLine(anchors[i]);
                if (anchors[i].IndexOf("infotrack.co.uk") > 0) { 
                    return i + 1;
                }
            }

            return 0;
        }

        private List<string> GetAnchors(string html)
        {
            string[] parts = html.Split(new string[] { "kCrYT\"><a href=\"/url?q=" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> anchors = new List<string>();

            foreach (string part in parts)
            {
                int i = part.IndexOf('"');
                if (i > 0)
                {
                    string url = part.Substring(0, i);
                    if (url.StartsWith("http")) anchors.Add(url);
                }
            }

            return anchors;
        }

        private void Log(List<string> anchors)
        {
            string s = string.Empty;
            foreach (string anchor in anchors)
            {
                s += anchor + "\n";
            }
            Console.WriteLine(s);
        }
    }
}
