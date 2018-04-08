using FlightFinder.Shared;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlightFinder.Client.Services
{
    public class AppState
    {
        public IReadOnlyList<Itinery> SearchResults { get; private set; }
        public bool SearchInProgress { get; private set; }

        private readonly List<Itinery> shortList = new List<Itinery>();
        public IReadOnlyList<Itinery> Shortlist => shortList;

        // Lets components receive change notifications
        public event Action OnChange;

        private readonly HttpClient http;
        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task Search(SearchCriteria criteria)
        {
            SearchInProgress = true;
            NotifyStateChanged();

            SearchResults = await http.PostJsonAsync<Itinery[]>("api/flightsearch", criteria);

            SearchInProgress = false;
            NotifyStateChanged();
        }

        public void AddToShortlist(Itinery itinery)
        {
            shortList.Add(itinery);
            NotifyStateChanged();
        }

        public void RemoveFromShortlist(Itinery itinery)
        {
            shortList.Remove(itinery);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
