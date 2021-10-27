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
            var game = _gameRepository.GetGames().FirstOrDefault(g => g.Id == id);
            if (game == null) return NotFound();

            var gamesDetailViewModel = new GamesDetailViewModel
            {
                Id = game.Id,
                Title = game.Title,
                DeveloperId = game.Developer.Id,
                DeveloperName = game.Developer.Name,
                Rating = game.Rating

            };

            return View(gamesDetailViewModel);
        }

    }
}