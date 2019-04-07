using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using HawksStartApp.Models;
using HawksStartApp.Models.Repositories;
using Newtonsoft.Json;
using HawksStartApp.Models.ViewModel;

namespace HawksStartApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FillDB();
            return View();
        }

        public ActionResult ShowDummyFiltersResult()
        {
            string fileName = "filters_data.txt";
            string path = Server.MapPath("~/App_Data/") + "\\" + fileName;

            string jsonString = string.Empty;
            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(path))
            {
                // Read the stream to a string
                jsonString = sr.ReadToEnd();
            }

            HawkaFilters filtersData = JsonConvert.DeserializeObject<HawkaFilters>(jsonString);

            List<RestaurantModel> model = new List<RestaurantModel>();
            using (HawkaContext db = new HawkaContext())
            {
                model = (from rest in db.Restaurants
                         where rest.Price == filtersData.Price && rest.Specialization == filtersData.Specialization
                             && rest.IsWifi == filtersData.IsWIfi && rest.AreSittingPlaces == filtersData.AreSittingPlaces
                         orderby rest.Name
                         select new RestaurantModel
                         {
                             Name = rest.Name
                         }).ToList();

            }
            return View("RestaurantResults", model);
        }

        private void FillDB()
        {
            using (HawkaContext db = new HawkaContext())
            {
                var corpuseRepo = new CorpuseRepository(db);
                corpuseRepo.Clear();
                corpuseRepo.Create(new Corpuse { Id = 1, Number = 100 });
                corpuseRepo.Create(new Corpuse { Id = 2, Number = 1 });
                corpuseRepo.Create(new Corpuse { Id = 3, Number = 4 });
                corpuseRepo.Create(new Corpuse { Id = 4, Number = 5 });
                corpuseRepo.Create(new Corpuse { Id = 5, Number = 7 });
                corpuseRepo.Create(new Corpuse { Id = 6, Number = 8 });
                corpuseRepo.Create(new Corpuse { Id = 7, Number = 20 });
                corpuseRepo.Create(new Corpuse { Id = 8, Number = 28 });
                corpuseRepo.Create(new Corpuse { Id = 9, Number = 38 });

                var restaurantRepo = new RestaurantRepository(db);
                restaurantRepo.Clear();
                restaurantRepo.Create(new Restaurant { Id = 1, Name = "PizzaHOUSE", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 2, Name = "Chellentano", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "pizzeria" });
                restaurantRepo.Create(new Restaurant { Id = 3, Name = "Cisar", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 4, Name = "La Creperie", AreSittingPlaces = false, IsWifi = true, Price = "middle", Specialization = "pancakes" });
                restaurantRepo.Create(new Restaurant { Id = 5, Name = "FriHouse", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "fastfood" });
                restaurantRepo.Create(new Restaurant { Id = 6, Name = "KebabChef", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "kebab" });
                restaurantRepo.Create(new Restaurant { Id = 7, Name = "UrbanCofee", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "coffee" });
                restaurantRepo.Create(new Restaurant { Id = 8, Name = "Univer", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "coffee" });
                restaurantRepo.Create(new Restaurant { Id = 9, Name = "Kormushka", AreSittingPlaces = true, IsWifi = false, Price = "low", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 10, Name = "Fornetti", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "bakery" });
                restaurantRepo.Create(new Restaurant { Id = 11, Name = "Ti100", AreSittingPlaces = true, IsWifi = false, Price = "middle", Specialization = "bakery" });
                restaurantRepo.Create(new Restaurant { Id = 12, Name = "Zapikanki", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "zapikanki" });
                restaurantRepo.Create(new Restaurant { Id = 13, Name = "TheChicken", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "kebab" });
                restaurantRepo.Create(new Restaurant { Id = 14, Name = "Erevan", AreSittingPlaces = true, IsWifi = true, Price = "high", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 15, Name = "CatchUp cafe", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 16, Name = "Lavash", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "lavash" });
                restaurantRepo.Create(new Restaurant { Id = 17, Name = "Cat Cafe", AreSittingPlaces = true, IsWifi = true, Price = "high", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 18, Name = "Starvin Coffee", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "coffee" });
                restaurantRepo.Create(new Restaurant { Id = 19, Name = "Casa Burito", AreSittingPlaces = true, IsWifi = false, Price = "middle", Specialization = "fastfood" });
                restaurantRepo.Create(new Restaurant { Id = 20, Name = "Atom", AreSittingPlaces = true, IsWifi = true, Price = "high", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 21, Name = "Gal Dar", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "bakery" });
                restaurantRepo.Create(new Restaurant { Id = 22, Name = "ChudoPich", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "bakery" });
                restaurantRepo.Create(new Restaurant { Id = 23, Name = "Lviv Croissants", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "croissants" });
                restaurantRepo.Create(new Restaurant { Id = 24, Name = "Amigos", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "differentways" });
                restaurantRepo.Create(new Restaurant { Id = 25, Name = "Doner & Burger", AreSittingPlaces = true, IsWifi = true, Price = "high", Specialization = "kebab" });
                restaurantRepo.Create(new Restaurant { Id = 26, Name = "SelfieCoffee", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "coffee" });
                restaurantRepo.Create(new Restaurant { Id = 27, Name = "Super Bulba", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "fastfood" });
                restaurantRepo.Create(new Restaurant { Id = 28, Name = "DonerKebab", AreSittingPlaces = false, IsWifi = false, Price = "low", Specialization = "kebab" });
                restaurantRepo.Create(new Restaurant { Id = 29, Name = "Americano", AreSittingPlaces = true, IsWifi = true, Price = "middle", Specialization = "differentways" });


                var restaurantcorpuseRepo = new RestaurantCorpuseRepository(db);
                restaurantcorpuseRepo.Clear();
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 1 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 20 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 17 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 19 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 10 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 21 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 18 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 16 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 9 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 22 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 6 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 1, RestaurantId = 27 });

                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 4 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 1 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 3 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 2 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 7 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 8 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 9 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 10 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 11 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 12 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 16 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 28 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 2, RestaurantId = 27 });

                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 14 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 15 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 17 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 4 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 1 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 3 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 2 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 7 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 8 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 9 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 10 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 11 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 12 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 16 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 3, RestaurantId = 27 });

                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 14 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 15 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 17 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 4 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 1 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 3 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 2 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 7 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 8 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 9 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 10 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 11 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 12 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 16 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 4, RestaurantId = 27 });

                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 4 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 1 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 3 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 2 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 7 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 8 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 9 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 10 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 11 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 12 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 16 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 28 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 5, RestaurantId = 27 });

                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 6, RestaurantId = 14 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 6, RestaurantId = 15 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 6, RestaurantId = 28 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 6, RestaurantId = 9 });

                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 7, RestaurantId = 29 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 7, RestaurantId = 25 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 7, RestaurantId = 24 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 7, RestaurantId = 23 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 7, RestaurantId = 5 });

                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 8, RestaurantId = 14 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 8, RestaurantId = 15 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 8, RestaurantId = 28 });
                restaurantcorpuseRepo.Create(new RestaurantCorpuse { CorpuseId = 8, RestaurantId = 9 });

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
