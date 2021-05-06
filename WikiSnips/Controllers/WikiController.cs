using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WikiSnips.Models;

namespace WikiSnips.Controllers
{
    public class WikiController
    {
        IRestClient Client = new RestClient();

        public async Task<ActionResult<string>> GetRandomWikiText()
        {
            IRestRequest request = new RestRequest("https://en.wikipedia.org/api/rest_v1/page/random/summary", Method.GET, DataFormat.Json);
            IRestResponse<WikiArticleResponse> response = await Client.ExecuteAsync<WikiArticleResponse>(request);

            return response.Content;
        }
    }
}
