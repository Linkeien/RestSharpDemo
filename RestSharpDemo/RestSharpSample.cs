using RestSharp;
using RestSharpDemo.Model;
using RestSharpDemo.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class RestSharpSample
    {
        private const string Url = "http://localhost:59819";

        public void DeleteAllDataAsync()
        {
            var client = CreateClient();

            RestRequest request = new RestRequest("api/Contract");

            IRestResponse response = client.Delete(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
        }

        public void DeleteDataAsync(int numero)
        {
            var client = CreateClient();

            RestRequest request = new RestRequest("api/Contract/{numero}");
            request.AddUrlSegment("numero", numero);

            IRestResponse response = client.Delete(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
        }

        public async Task<IEnumerable<Contrat>> GetContrats()
        {
            var client = CreateClient();

            RestRequest request = new RestRequest("api/Contract");

            var response = await client.ExecuteTaskAsync<IEnumerable<Contrat>>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }

        public Contrat GetData(int numero)
        {
            var client = CreateClient();

            RestRequest request = new RestRequest("api/Contract/{numero}");
            request.AddUrlSegment("numero", numero);

            IRestResponse<Contrat> response = client.Execute<Contrat>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }

        public async Task<Contrat> GetDataAsync(int numero)
        {
            var client = CreateClient();

            RestRequest request = new RestRequest("api/Contract/{numero}");
            request.AddUrlSegment("numero", numero);

            IRestResponse<Contrat> response = await client.ExecuteTaskAsync<Contrat>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }

        public void PostDataAsync(Contrat contrat)
        {
            var client = CreateClient();

            RestRequest request = new RestRequest("api/Contract");
            request.AddJsonBody(contrat);

            IRestResponse response = client.Post(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
        }

        private IRestClient CreateClient() =>
            new RestClient(Url)
                .UseSerializer(new JsonNetSerializer()); // En attendant la v107 qui intégrera directement Newtonsoft.Json
    }
}