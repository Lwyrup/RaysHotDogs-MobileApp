using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaysHotDogs.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogWebRepository
    {
        string uri = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

        public HotDogWebRepository()
        {
            Task.Run(() => this.LoadDataAsync(uri)).Wait();
        }

		public List<HotDog> GetAllHotDogs()
		{
			IEnumerable<HotDog> hotDogs =
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs

				select hotDog;
			return hotDogs.ToList<HotDog>();
		}

		public HotDog GetHotDogById(int hotDogId)
		{
			IEnumerable<HotDog> hotDogs =
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs
				where hotDog.HotDogId == hotDogId
				select hotDog;

			return hotDogs.FirstOrDefault();
		}

		public List<HotDogGroup> GetGroupedHotDogs()
		{
			return hotDogGroups;
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
		{
			var group = hotDogGroups.Where(h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

			if (group != null)
			{
				return group.HotDogs;
			}
			return null;
		}

		public List<HotDog> GetFavoriteHotDogs()
		{
			IEnumerable<HotDog> hotDogs =
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs
				where hotDog.IsFavorite
				select hotDog;
			return hotDogs.ToList<HotDog>();
		}

        // Variable holding all the data
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();

        public async Task LoadDataAsync(string uri)
        {
            if (hotDogGroups != null)
            {
                string responseJsonString = null;
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                        HttpResponseMessage response = await getResponse;
                        responseJsonString = await response.Content.ReadAsStringAsync();
                        hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(responseJsonString);
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }
            }
        }
    }
}
