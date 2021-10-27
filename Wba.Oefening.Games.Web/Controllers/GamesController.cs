using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;
using Wba.Oefening.Games.Web.ViewModels;

namespace Wba.Oefening.Games.Web.Controllers
{

    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository();
        }

       
        public IActionResult Index()
        {
            var gamesIndexViewModel = new GamesIndexViewModel();
            gamesIndexViewModel.Games = new List<GamesDetailViewModel>();

            foreach(var game in _gameRepository.GetGames())
            {
                gamesIndexViewModel.Games.Add(new GamesDetailViewModel
                {
                    Id = game.Id,
                    Title = game.Title
                });
            }

            return View(gamesIndexViewModel);
        }

        
        public IActionResult ShowGame(int id)
        {
            return Content("I should make a view + view model for this!");
        }

    }
}