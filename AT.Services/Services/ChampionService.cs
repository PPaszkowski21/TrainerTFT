using AT.Data.Models;
using AT.Services.Contracts.Champion;
using AT.Services.Contracts.Traits;
using AT.Services.Helpers;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AT.Services.Services
{
    public class ChampionService
    {
        private readonly TrainerTftDbContext _context;
        public ChampionService(TrainerTftDbContext context)
        {
            _context = context;
        }
        public HttpStatusCode AddTraits(List<AddTraitRequest> request)
        {
            foreach (var trait in request)
            {
                Trait traitToAdd = new Trait
                {
                    Type = trait.Type,
                    Description = trait.Description,
                    Key = trait.Key,
                    Name = trait.Name,
                };

                _context.Traits.Add(traitToAdd);

                foreach (var set in trait.Sets)
                {
                    TraitSets traitSet = new TraitSets
                    {
                        Style = set.Style,
                        Key = trait.Key,
                        Max = set.Max,
                        Min = set.Min
                    };
                    _context.Sets.Add(traitSet);
                }
            }
            _context.SaveChanges();
            return HttpStatusCode.OK;
        }
        public HttpStatusCode AddChampions(List<AddChampionRequest> request)
        {
            foreach (var championRequest in request)
            {
                foreach (string trait in championRequest.Traits)
                {
                    ChampionTrait championTrait = new ChampionTrait
                    {
                        ChampionId = championRequest.ChampionId,
                        TraitKey = trait,
                    };
                    _context.ChampionTraits.Add(championTrait);
                }

                var championCard = ImageManager.GetImage(Constants.baseImagePathCard, championRequest.Name);
                var championAvatar = ImageManager.GetImage(Constants.baseImagePathAvatar, championRequest.Name);
                if (championCard == null || championAvatar == null)
                {
                    continue;
                }

                ChampionCard champion = new ChampionCard
                {
                    ChampionId = championRequest.ChampionId,
                    Name = championRequest.Name,
                    Cost = championRequest.Cost,
                    ShopCard = championCard,
                    Avatar = championAvatar

                };
                _context.ChampionCards.Add(champion);
            }
            _context.SaveChanges();

            return HttpStatusCode.OK;
        }
        public List<ChampionCard> GetChampions()
        {
            return _context.ChampionCards.ToList();
        }
        public List<TraitResponse> GetTraits(List<string> request)
        {
            List<TraitResponse> response = new List<TraitResponse>();
            var championTraits = _context.ChampionTraits.Where(x => request.Contains(x.ChampionId)).ToList();

            List<TraitManager> traitManagers = new List<TraitManager>();

            foreach (var trait in championTraits)
            {
                int index = traitManagers.FindIndex(x => x.TraitKey == trait.TraitKey);
                if (index == -1)
                {
                    var traitComplete = _context.Traits.FirstOrDefault(x => x.Key == trait.TraitKey);
                    TraitManager traitManager = new TraitManager(trait.TraitKey, traitComplete.Name);
                    traitManagers.Add(traitManager);
                }
                else
                {
                    traitManagers[index].Active++;
                }
            }

            foreach (var trait in traitManagers)
            {
                var setsForTrait = _context.Sets.Where(x => x.Key == trait.TraitKey).ToList();
                var set = setsForTrait.FirstOrDefault(x => x.Max >= trait.Active && x.Min <= trait.Active);

                if(set != null)
                {
                    var max = setsForTrait.Where(x => x.Min > set.Max).Select(x => x.Min).Min();
                    TraitResponse traitResponse = new TraitResponse
                    {
                        Active = trait.Active,
                        Name = trait.Name,
                        Style = set.Style,
                        Max = max,
                        Min = set.Min
                    };
                    response.Add(traitResponse);
                }
            }

            return response;
        }
        public List<ShopOfferChampionResponse> RefreshShop(List<ChampionOnTheBoardRequest> champions, double[] percentage)
        {
            var AllChampions = _context.ChampionCards.ToList();

            List<ChampionCard>[] ChampionPools = new List<ChampionCard>[5];
            for (int i = 0; i < 5; i++)
            {
                ChampionPools[i] = new List<ChampionCard>();
            }

            foreach (var champion in AllChampions)
            {
                var index = champions.FindIndex(x => x.ChampionId == champion.ChampionId);
                var copiesOnBoard = 0;
                if (index != -1)
                {
                    copiesOnBoard = champions[index].CopiesBought;
                }
                for (int i = 0; i < Constants.ChampionCopiesInDeck[champion.Cost-1] - copiesOnBoard; i++)
                {
                    ChampionPools[champion.Cost - 1].Add(champion);
                }    
            }

            var percentageForSpecifiedLvlOfChampion = new[]
            {
                ProportionValue.Create(percentage[0], 0),
                ProportionValue.Create(percentage[1], 1),
                ProportionValue.Create(percentage[2], 2),
                ProportionValue.Create(percentage[3], 3),
                ProportionValue.Create(percentage[4], 4)
            };

            var rand = new Random();
            var shopOffer = new List<ShopOfferChampionResponse>();

            for (int i = 0; i < 5; i++)
            {
                int whichPool = percentageForSpecifiedLvlOfChampion.ChooseByRandom();
                var championOffer = GetChampionFromPool(ChampionPools[whichPool], rand);
                var traitsKeys = _context.ChampionTraits.Where(x=>x.ChampionId == championOffer.ChampionId).Select(x=>x.TraitKey).ToList();
                List<Trait> traits = new List<Trait>();

                foreach (var trait in traitsKeys)
                {
                    traits.Add(_context.Traits.FirstOrDefault(x => x.Key == trait));

                }

                ShopOfferChampionResponse singleShopOffer = new ShopOfferChampionResponse
                {
                    Champion = championOffer,
                    Traits = traits, 
                };
                shopOffer.Add(singleShopOffer);
            }
            return shopOffer;
        }
        private ChampionCard GetChampionFromPool(List<ChampionCard> pool, Random rand)
        {
            if (pool.Count == 0)
            {
                return new ChampionCard();
            }
            var whichChampion = rand.Next(pool.Count);
            var championOffer = pool[whichChampion];
            pool.Remove(championOffer);
            return championOffer;
        }
    }
}
