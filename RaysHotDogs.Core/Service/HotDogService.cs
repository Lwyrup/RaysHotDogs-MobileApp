using System;
using System.Collections.Generic;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Repository;

namespace RaysHotDogs.Core.Service
{
	public class HotDogDataService
	{
		private static HotDogRepository hotDogRepository = new HotDogRepository();
		public HotDogDataService()
		{
		}

		public List<HotDog> getAllHotDogs()
		{
			return hotDogRepository.GetAllHotDogs();
		}

		public List<HotDogGroup> getGroupedHotDogs()
		{
			return hotDogRepository.GetGroupedHotDogs();
		}

		public List<HotDog> getHotDogsForGroup(int hotDogGroupId)
		{
			return hotDogRepository.GetHotDogsForGroup(hotDogGroupId);
		}

		public HotDog getHotDogById(int hotDogId)
		{
			return hotDogRepository.GetHotDogById(hotDogId);
		}
	}
}