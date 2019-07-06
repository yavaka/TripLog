using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    //Azure Data Access
    public class TripLogApiDataService
        : BaseHttpService, ITripLogDataService
    {
        readonly Uri _baseUri;
        readonly IDictionary<string, string> _headers;

        public TripLogApiDataService(Uri baseUri)
        {
            _baseUri = baseUri;
            _headers = new Dictionary<string, string>();

            _headers.Add("ZUMO-API-Version", "2.0.0");
        }

        public async Task<IList<TripLogEntry>> GetEntriesAsync() //Get all entries
        {
            //url = "http://<service-name>.azurewebsites.net" + "/tables/entry"
            var url = new Uri(_baseUri,"/tables/entry");

            // Call the SendRequestAsync method from BaseHttpService class
            var response = await SendRequestAsync<TripLogEntry[]>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<TripLogEntry> AddEntryAsync(TripLogEntry entry) //Add
        {
            //url = "http://<service-name>.azurewebsites.net" + "/tables/entry"
            var url = new Uri(_baseUri,"/tables/entry");

            var response = await SendRequestAsync<TripLogEntry>(url,HttpMethod.Post,_headers,entry);

            return response;
        }
        public async Task<TripLogEntry> GetEntryAsync(string id) //Get
        {
            //url = "http://<service-name>.azurewebsites.net" + "/tables/entry/id"
            var url = new Uri(_baseUri,$"/tables/entry/{id}");

            var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Get, _headers);

            return response;
        }
        public async Task<TripLogEntry> UpdateEntryAsync(TripLogEntry entry) //Update
        {
            //url = "http://<service-name>.azurewebsites.net" + "/tables/entry/entry.id"
            var url = new Uri(_baseUri,$"/tables/entry/{entry.Id}");

            var response = await SendRequestAsync<TripLogEntry>(url, new HttpMethod("PATCH"), _headers, entry);

            return response;
        }
        public async Task RemoveEntryAsync(TripLogEntry entry) //Remove
        {
            //url = "http://<service-name>.azurewebsites.net" + "/tables/entry/entry.id"
            var url = new Uri(_baseUri,$"/tables/entry/{entry.Id}");

            var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Delete, _headers);
        }
    }
}
