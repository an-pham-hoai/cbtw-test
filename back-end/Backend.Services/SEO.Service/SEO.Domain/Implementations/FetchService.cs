using Backend.Shared.DTO.Implementations;
using Backend.Shared.DTO.Interfaces;
using SEO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SEO.Domain.Implementations
{
    public class FetchService : IFetchService
    {
        public async Task<IFetchDTO> Fetch(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the specified URL
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Ensure we get a successful response
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string
                    string htmlContent = await response.Content.ReadAsStringAsync();
                    return new FetchDTO()
                    {
                        Content = htmlContent,
                    };
                }
                catch (HttpRequestException e)
                {
                    // Handle any errors
                    return new FetchDTO()
                    {
                        Error = e.Message,
                    };
                }
            }
        }
    }
}
