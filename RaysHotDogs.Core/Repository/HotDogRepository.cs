using System;
using System.Collections.Generic;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        public HotDogRepository()
        {
        }

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
					}
                }
            }
        };


    }
}
