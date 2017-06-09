using System;
using System.Collections.Generic;
using System.Linq;
using RaysHotDogs.PCL.Model;

namespace RaysHotDogs.PCL.Repository
{
	public class HotDogRepository
	{
		public HotDogRepository()
		{
		}

		// HotDog related functions
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

		// Group related functions
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

		// Data variable
		private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
		{
			new HotDogGroup()
			{
				HotDogGroupId = 1, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog>
				{
					new HotDog()
					{
						HotDogId = 1,
						Name = "Regular Hot Dog",
						ShortDescription = "Simply the best.",
						Description = "Manchego smelly cheese danish fontina.",
						ImagePath = "hotdog1",
						Available = true,
						PrepTime = 10,
						Ingredients = new List<string>(){ "Reg. bun", "Sausage", "Ketchup"},
						Price = 8,
						IsFavorite = true
					},
					new HotDog()
					{
						HotDogId = 2,
						Name = "Haute Dog",
						ShortDescription = "The classy one.",
						Description = "Bacon, ham, melty gooey cheese, and mushroom.",
						ImagePath = "hotdog2",
						Available = true,
						PrepTime = 15,
						Ingredients = new List<string>(){ "Baked bun", "Gourmet Sausage", "Sharp cheddar", "Mushroom bits"},
						Price = 10,
						IsFavorite = false
					},
					new HotDog()
					{
						HotDogId = 3,
						Name = "Long Dog",
						ShortDescription = "Hungry?",
						Description = "Standard Hot Dog but simply longer to fight hunger.",
						ImagePath = "hotdog3",
						Available = true,
						PrepTime = 10,
						Ingredients = new List<string>(){ "Long bun", "Xtra long sausage", "Long ketchup"},
						Price = 8,
						IsFavorite = true
					}
				}
			},
			new HotDogGroup()
			{
				HotDogGroupId = 2, Title = "Veggie lovers", ImagePath = "", HotDogs = new List<HotDog>()
				{
					new HotDog()
					{
						HotDogId = 4,
						Name = "Veggie Hot Dog.",
						ShortDescription = "",
						Description = "",
						ImagePath = "hotdog4",
						Available = true,
						PrepTime = 0,
						Ingredients = new List<string>(){ "Whole wheat bun", "Tofu dog", "Organic mustard" },
						Price = 9,
						IsFavorite = false
					}
				}
			}
		};


	}
}
