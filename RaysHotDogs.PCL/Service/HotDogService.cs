using System;
using System.Collections.Generic;
using RaysHotDogs.PCL.Model;
using RaysHotDogs.PCL.Repository;

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
	}
}
