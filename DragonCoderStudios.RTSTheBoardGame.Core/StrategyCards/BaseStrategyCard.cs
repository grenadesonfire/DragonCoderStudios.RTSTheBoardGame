using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.StrategyCards
{
    public abstract class BaseStrategyCard
    {
        public string Title { get; protected set; }

        public bool PrimaryAbilityUsed { get; set; }

        public abstract void Primary();

        public abstract void Secondary();
    }

    public class Card1 : BaseStrategyCard
    {
        public Card1()
        {
            Title = "1 Name";
        }

        public override void Primary()
        {
            // Gain 3 Command Points
            // Spend any ammount of influence to gain 1 command Point for every 3 influence spent this way.
        }

        public override void Secondary()
        {
            // Spend any ammount of influence to gain 1 command Point for every 3 influence spent this way.
        }
    }

    public class Card2 : BaseStrategyCard
    {
        public Card2()
        {
            Title = "2 Name";
        }

        public override void Primary()
        {
            //Choose 1 system, other than the Throne World system, 
            //    that contains a planet you control; 
            //each other player places 1 Command Point from their Command Pool in this system.
            //    Then, ready each exhausted planet you control in that system.
        }

        public override void Secondary()
        {
            // Spend any ammount of influence to gain 1 command Point for every 3 influence spent this way.
        }
    }

    public class Card3 : BaseStrategyCard
    {
        public Card3()
        {
            Title = "3 Name";
        }

        public override void Primary()
        {
            //Choose a player other than the speaker.That player becomes the speaker.
            //Draw 2 action cards.
            //Look at the top 2 cards of the agenda deck.Place each card on the top or bottom of the deck in any order.

        }

        public override void Secondary()
        {
            // Spend 1 Command Point from Command Pool to draw 2 action cards.
        }
    }

    public class Card4 : BaseStrategyCard
    {
        public Card4()
        {
            Title = "4 Name";
        }

        public override void Primary()
        {
            //Place 1 planetary defense network or 1 space station on a planet you control
            //Place 1 planetary defense network on a planet you control.
        }

        public override void Secondary()
        {
            // Spend 1 Command Point from Command Pool and activate any system you control; 
            // you may place either 1 planetary defense network or 1 space station on a planet you control in that system
        }
    }

    public class Card5 : BaseStrategyCard
    {
        public Card5()
        {
            Title = "5 Name";
        }

        public override void Primary()
        {
            //Gain 3 trade goods
            //Replenish your commodities
            //Choose any number of other players.Those players may use the secondary ability of this strategy card without spending a Command Point.
        }

        public override void Secondary()
        {
            //Spend 1 Command Point from Command Pool to replenish your commodities
        }
    }

    public class Card6 : BaseStrategyCard
    {
        public Card6()
        {
            Title = "6 Name";
        }

        public override void Primary()
        {
            //Remove 1 of your Command Points from the Game Board; then gain 1 Command Point.
            //Redistribute any number of your Command Points
        }

        public override void Secondary()
        {
            //Spend 1 Command Point from Command Pool to use the Production ability of your Home System 
        }
    }

    public class Card7 : BaseStrategyCard
    {
        public Card7()
        {
            Title = "7 Name";
        }

        public override void Primary()
        {
            //Research 1 technology
            //Spend 6 resources to research 1 technology
        }

        public override void Secondary()
        {
            //Spend 1 Command Point from Command Pool and 4 resources to research 1 technology
        }
    }

    public class Card8 : BaseStrategyCard
    {
        public Card8()
        {
            Title = "8 Name";
        }

        public override void Primary()
        {
            //Immediately score 1 public objective if you fulfill its requirements.
            //Gain 1 victory point if you hold the Throne World; otherwise, draw 1 secret objective.
        }

        public override void Secondary()
        {
            //Spend 1 Command Point from Command Pool to draw 1 secret objective.
        }
    }
}
