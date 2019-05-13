using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MV.ApplicationService.ViewModels;
using MV.Common.WebServer.Server;
using Newtonsoft.Json;

namespace MV.Integration.Tests.Factories
{
    public class MovieControllerFactory
    {
        private string URL = "https://api.themoviedb.org/3/movie";
        private string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private string DEFAULT_LANGUAGE = "en-US";
        private readonly HttpClient client;

        public MovieControllerFactory()
        {
            this.client = new HttpClient();
        }

        public async Task<List<MovieViewModel>> GetUpcomingMovies()
        {
          // Act
          var response = await client.GetAsync($"{URL}/upcoming?api_key={API_KEY}&language={DEFAULT_LANGUAGE}&page=1");
          var responseModel = JsonConvert.DeserializeObject<TMDBViewModel>(await response.Content.ReadAsStringAsync());

          return responseModel.Results;
        }
    }
}
