using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.StrategyCards
{
    public class StrategyCard
    {
        public string Title { get; protected set; }

        public int Order { get; set; }

        public Action<Game, Player> Primary { get; protected set; }

        public Action<Game, Player> Secondary { get; protected set; }

        private StrategyCard() { }

        public static StrategyCard LeadershipCard()
        {
            var card = new StrategyCard();

            card.Title = "Leadership";

            card.Order = 1;

            card.Primary = 
                (g, p) =>
                {
                    for(var idx=0;idx<3;idx++) p.CommandTokens.Add(new Tokens.CommandToken(p));

                    //Spend influence to gain tokens
                };

            card.Secondary =
                (g, p) =>
                {
                    //Spend influence to gain tokens
                };

            return card;
        }

        public static StrategyCard DiplomacyCard()
        {
            var card = new StrategyCard();

            card.Title = "Diplomacy";

            card.Order = 2;

            card.Primary =
                (g, p) =>
                {
                    //Choose 1 system other than Mec Rex system that contains a planet
                    //  you control; each other player places a command token from his 
                    //  reinforcements in the chosen system. Then, ready each exhausted
                    //  planet you control in that system.
                };

            card.Secondary =
                (g, p) =>
                {
                    //Spend 1 token from your strategy pool to ready up to 2 exhausted planets you control.
                };

            return card;
        }
    }
}
