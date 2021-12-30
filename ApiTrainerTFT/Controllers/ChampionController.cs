using AT.Data.Models;
using AT.Services.Contracts.Champion;
using AT.Services.Contracts.Traits;
using AT.Services.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace ApiTrainerTFT.Controllers
{
    [Route("champion")]
    public class ChampionController : Controller
    {
        private readonly ChampionService _championService;

        public ChampionController(TrainerTftDbContext context)
        {
            _championService = new ChampionService(context);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult AddChampions([FromBody] List<AddChampionRequest> request)
        {
            _championService.AddChampions(request);
            return Ok();
        }

        [HttpPost]
        [Route("gettraits")]
        public IActionResult GetTraits([FromBody] GetTrait request)
        {
            var traits = _championService.GetTraits(request.ChampionIds);
            var json = JsonSerializer.Serialize(traits);
            return Ok(json);
        }

        [HttpPost]
        [Route("addtraits")]
        public IActionResult AddTraits([FromBody] List<AddTraitRequest> request)
        {
            _championService.AddTraits(request);
            return Ok();
        }

        [HttpPost]
        [Route("refreshShop")]
        public IActionResult GetDeck([FromBody] GetDeckRequest request)
        {
            var shopOffer = _championService.RefreshShop(request.ChampionsOnTheBoard,request.Percentage);
            var json = JsonSerializer.Serialize(shopOffer);
            return Ok(json);
        }

        [HttpGet]
        [Route("getChampions")]
        public IActionResult GetAllChampions()
        {
            var champions = _championService.GetChampions();
            var json = JsonSerializer.Serialize(champions);
            return Ok(json);
        }

    }
}
