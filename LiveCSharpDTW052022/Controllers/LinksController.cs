using DTW.Repository.Links;
using LiveCSharpDTW052022.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LiveCSharpDTW052022.Controllers
{
    public class LinksController : Controller
    {
        private readonly ILinkRepository _linkRepository;

        public LinksController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public IActionResult Index()
        {
            //TODO : Récupérer le modèle depuis le repository...
            var vm = new ListLinksViewModel()
            {
                LstLinks = _linkRepository.GetAllLinks()
            };

            return View(vm);
        }
    }
}
