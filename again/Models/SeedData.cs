using again.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace again.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new againContext(
                serviceProvider.GetRequiredService<DbContextOptions<againContext>>()))
            {
                // Look for any movies.
                if (context.Game.Any())
                {
                    return;   // DB has been seeded
                }

                context.Game.AddRange(
                    new Game
                    {
                        Title = "Codenames",
                        Description = "In Codenames, two teams compete to see who can make contact with all of their agents first. Spymasters give one-word clues that can point to multiple words on the board. Their teammates try to guess words of the right color while avoiding those that belong to the opposing team. And everyone wants to avoid the assassin.",
                        MinPlayer = 2,
                        MaxPlayer = 8,
                        ImgPath = "https://cf.geekdo-images.com/original/img/MJ6MNz8-_rb1C2VUTnYBTYOiiy0=/0x0/pic2582929.jpg",
                        ThumbPath = ""
                    },
                    new Game
                    {
                        Title = "Blood Rage",
                        Description = "Life is Battle; Battle is Glory; Glory is ALL.In Blood Rage, each player controls their own Viking clan’s warriors, leader, and ship.Ragnarök has come, and it’s the end of the world!It’s the Vikings’ last chance to go down in a blaze of glory and secure their place in Valhalla at Odin’s side!For a Viking there are many pathways to glory. You can invade and pillage the land for its rewards, crush your opponents in epic battles, fulfill quests, increase your clan's stats, or even die gloriously either in battle or from Ragnarök, the ultimate inescapable doom.",
                        MinPlayer = 2,
                        MaxPlayer = 5,
                        ImgPath = "https://cf.geekdo-images.com/imagepage/img/op_BYsCGVw_PftIoCa-OWucsUFc=/fit-in/900x600/filters:no_upscale()/pic2439223.jpg",
                        ThumbPath = ""
                    },
                    new Game
                    {
                        Title = "Lost Cities",
                        Description = "The object the game is to gain points by mounting profitable archaeological expeditions to the different sites represented by the 5 colors. On a player's turn they must always first play one card, either to an expedition or by discarding it to the appropriate discard pile, and then draw one card. There is a separate discard pile for each color and a player may draw the top card of any discard pile or the top card of the deck. Cards played to expeditions must be in ascending order but they need not be consecutive.",
                        MinPlayer = 2,
                        MaxPlayer = 2,
                        ImgPath = "https://cf.geekdo-images.com/imagepage/img/kNOK3IkwYIeoOQAeOMhOH9U7z88=/fit-in/900x600/filters:no_upscale()/pic2606107.jpg",
                        ThumbPath = ""
                    },
                    new Game
                    {
                        Title = "Patch Work",
                        Description = "In Patchwork, two players compete to build the most aesthetic (and high-scoring) patchwork quilt on a personal 9x9 game board. To start play, lay out all of the patches at random in a circle and place a marker directly clockwise of the 2-1 patch. Each player takes five buttons — the currency/points in the game — and someone is chosen as the start player.",
                        MinPlayer = 2,
                        MaxPlayer = 2,
                        ImgPath = "https://cf.geekdo-images.com/imagepage/img/P-mb1HCtL_bAK0Knq_LR86Hxzdw=/fit-in/900x600/filters:no_upscale()/pic2270442.jpg",
                        ThumbPath = ""
                    },
                    new Game
                    {
                        Title = "Cosmic Encounter",
                        Description = "Build a galactic empire... In the depths of space, the alien races of the Cosmos vie with each other for control of the universe. Alliances form and shift from moment to moment, while cataclysmic battles send starships screaming into the warp. Players choose from dozens of alien races, each with its own unique power to further its efforts to build an empire that spans the galaxy.",
                        MinPlayer = 3,
                        MaxPlayer = 5,
                        ImgPath = "https://cf.geekdo-images.com/imagepage/img/jAVGM9IeOy7dxdAr2ssJx8BbrGg=/fit-in/900x600/filters:no_upscale()/pic1521633.jpg",
                        ThumbPath = ""
                    },
                    new Game
                    {
                        Title = "Captain Sonar",
                        Description = "At the bottom of the ocean, no one will hear you scream! In Captain Sonar, you and your teammates control a state-of-the-art submarine and are trying to locate an enemy submarine in order to blow it out of the water before they can do the same to you. Every role is important, and the confrontation is merciless. Be organized and communicate because a captain is nothing without his crew: the Chief Mate, the Radio Operator, and the Engineer.",
                        MinPlayer = 6,
                        MaxPlayer = 8,
                        ImgPath = "https://cf.geekdo-images.com/original/img/MJ6MNz8-_rb1C2VUTnYBTYOiiy0=/0x0/pic2582929.jpg",
                        ThumbPath = ""
                    }
                );
                context.SaveChanges();

                context.Player.AddRange(
                    new Player { Name = "Ryan" },
                    new Player { Name = "Eleanor" },
                    new Player { Name = "Andrea" }
                );
                context.SaveChanges();

                context.Library.AddRange(

                    new Library { PlayerID = 1, GameID = 2 },
                    new Library { PlayerID = 1, GameID = 3 },
                    new Library { PlayerID = 1, GameID = 4 },
                    new Library { PlayerID = 2, GameID = 5 },
                    new Library { PlayerID = 2, GameID = 6 },
                    new Library { PlayerID = 2, GameID = 7 }
                    );
                context.SaveChanges();
            }

        }
    }
}