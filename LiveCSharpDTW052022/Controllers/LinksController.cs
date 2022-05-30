using DTW.Repository.Links;
using LiveCSharpDTW052022.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LiveCSharpDTW052022.Controllers
{
    public class LinksController : Controller
    {
        public IActionResult Index()
        {
            //TODO : Récupérer le modèle depuis le repository...
            var vm = new ListLinksViewModel()
            {
                LstLinks = new List<LinkModel>()
                {
                    new LinkModel()
                    {
                        IdLink = 1,
                        Title = "test",
                        URL = "https://google.com",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean nisi neque, cursus eu porttitor at, interdum ut enim. Donec pellentesque dui tellus, non rhoncus nisl fermentum sed. Vivamus tincidunt, enim non posuere volutpat, diam erat maximus nunc, eget dignissim dolor lectus a felis."
                    },new LinkModel()
                    {
                        IdLink = 2,
                        Title = "test2",
                        URL = "https://google.com",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean nisi neque, cursus eu porttitor at, interdum ut enim. Donec pellentesque dui tellus, non rhoncus nisl fermentum sed. Vivamus tincidunt, enim non posuere volutpat, diam erat maximus nunc, eget dignissim dolor lectus a felis."
                    },new LinkModel()
                    {
                        IdLink = 3,
                        Title = "test3",
                        URL = "https://google.com",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean nisi neque, cursus eu porttitor at, interdum ut enim. Donec pellentesque dui tellus, non rhoncus nisl fermentum sed. Vivamus tincidunt, enim non posuere volutpat, diam erat maximus nunc, eget dignissim dolor lectus a felis."
                    },
                }
            };

            return View(vm);
        }
    }
}
