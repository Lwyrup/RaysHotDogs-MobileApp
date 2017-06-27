﻿using System;
using System.Collections.Generic;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Repository;

namespace RaysHotDogs.Core.Service
{
	public class HotDogDataService
	{
		static HotDogWebRepository hotDogRepository = new HotDogWebRepository();
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

        public List<HotDog> GetFavoriteHotDogs()
        {
            return hotDogRepository.GetFavoriteHotDogs();
        }

		public List<HotDog> GetMeatLoversHotDogs()
		{
			return hotDogRepository.GetHotDogsForGroup(1);
		}

		public List<HotDog> GetVeggieLoversHotDogs()
		{
            return hotDogRepository.GetHotDogsForGroup(2);
		}
	}
}