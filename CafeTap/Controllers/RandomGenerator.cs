using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using DataAccess.Database;
using Domain.Models;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace CafeTap.Controllers
{
    public class RandomGenerator : Controller
    {
        private readonly DatabaseContext _context;
        private Faker<Restaurant> _restaurantFaker;
        private Random _random = new Random();

        private List<string> _cities = new List<string>()
        {
            "Baku",
            "Shaki",
            "Yevlax",
            "Sumqayit",
            "Ismayilli",
            "Paris",
            "Moscow"
        };

        public RandomGenerator(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("/test")]
        public IActionResult CreateRestaurant()
        {
            return View();
        }

        [HttpPost]
        [Route("/test")]
        public IActionResult CreateRestaurant(int amount)
        {
            _restaurantFaker = new Faker<Restaurant>()
                .RuleFor(prop => prop.Name, val => val.Company.CompanyName() + $" Restaurant-{_random.Next(1, 100000)}")
                .RuleFor(p => p.Address, val => val.Address.SecondaryAddress())
                .RuleFor(p => p.PhoneNumber, val => val.Phone.PhoneNumber())
                .RuleFor(p => p.City, val => val.PickRandom(_cities))
                .RuleFor(p => p.RestaurantStatus, val => StatusFaker())
                .RuleFor(p => p.RestaurantNetworks, val => NetworkFaker())
                .RuleFor(p => p.CreatedAt, val => DateTime.Now.ToAzDateTime());


            var restaurants = _restaurantFaker.Generate(amount);

            _context.AddRange(restaurants);

            var result = _context.SaveChanges();



            return View();
        }

        private Faker<RestaurantStatus> StatusFaker()
        {
            List<string> statuses = new List<string>()
            {
                "Menu Hazirlanir",
                "Qr Code Hazirlanir",
                "Menu Hazirdir",
                "Qr Code Hazirdir"
            };
            Faker<RestaurantStatus> statusFaker = new Faker<RestaurantStatus>();
            statusFaker.RuleFor(p => p.Name, val => val.PickRandom(statuses))
                .RuleFor(e => e.CreatedAt, val => DateTime.Now.ToAzDateTime());

            return statusFaker;
        }

        private Faker<RestaurantNetwork> NetworkFaker()
        {
            Faker<RestaurantNetwork> networkFaker = new Faker<RestaurantNetwork>();
            networkFaker.RuleFor(p => p.Name, val => val.Company.CompanyName())
                .RuleFor(e => e.CreatedAt, val => DateTime.Now.ToAzDateTime());
            return networkFaker;
        }
    }
}
