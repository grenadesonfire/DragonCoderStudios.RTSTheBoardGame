using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Cards
{
    public enum TechnologyClass
    {
        Biotic,
        Warfare,
        Propulsion,
        Cybernetic
    }
    public class TechnologyCard
    {
        public string Name { get; set; }
        public TechnologyClass[] PreRequisites { get; set; }
        public string Effect { get; set; }
    }

    public class FactionTechnologyCard : TechnologyCard
    {
        public static FactionTechnologyCard NullificationField()
        {
            return new FactionTechnologyCard
            {
                Name = "Nullification Field",
                Effect = "After another player activates a system that contains 1 or more of your ships, you may exhaust this card and spend 1 token from your strategy pool; immediately end that player's turn.",
                PreRequisites = new TechnologyClass[] { TechnologyClass.Cybernetic, TechnologyClass.Cybernetic }
            };
        }

        public static FactionTechnologyCard InstinctTraining()
        {
            return new FactionTechnologyCard
            {
                Name = "Instinct Training",
                PreRequisites = new TechnologyClass[] { TechnologyClass.Biotic }
            };
        }
    }

    public class ColorTechnologyCard: TechnologyCard
    {

    }
}
