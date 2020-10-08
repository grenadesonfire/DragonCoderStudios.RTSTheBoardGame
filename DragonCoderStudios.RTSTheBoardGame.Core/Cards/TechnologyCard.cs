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
        private ColorTechnologyCard() { }

        public static ColorTechnologyCard CarrierII()
        {
            return new ColorTechnologyCard
            {
                Name = "Carrier II"
            };
        }

        public static ColorTechnologyCard CruiserII()
        {
            return new ColorTechnologyCard
            {
                Name = "Carrier II"
            };
        }

        public static ColorTechnologyCard DestroyerII()
        {
            return new ColorTechnologyCard { Name = "DestroyerII" };
        }
        public static ColorTechnologyCard DreadnoughtII()
        {
            return new ColorTechnologyCard { Name = "DreadnoughtII" };
        }
        public static ColorTechnologyCard FighterII()
        {
            return new ColorTechnologyCard { Name = "FighterII" };
        }
        public static ColorTechnologyCard InfantryII()
        {
            return new ColorTechnologyCard { Name = "InfantryII" };
        }
        public static ColorTechnologyCard PDSII()
        {
            return new ColorTechnologyCard { Name = "PDSII" };
        }
        public static ColorTechnologyCard WarSun()
        {
            return new ColorTechnologyCard { Name = "WarSun" };
        }
        public static ColorTechnologyCard AntimassDeflectors()
        {
            return new ColorTechnologyCard { Name = "AntimassDeflectors" };
        }
        public static ColorTechnologyCard AssaultCannon()
        {
            return new ColorTechnologyCard { Name = "AssaultCannon" };
        }
        public static ColorTechnologyCard DacxiveAnimators()
        {
            return new ColorTechnologyCard { Name = "DacxiveAnimators" };
        }
        public static ColorTechnologyCard DuraniumArmor()
        {
            return new ColorTechnologyCard { Name = "DuraniumArmor" };
        }
        public static ColorTechnologyCard GravitationLaserSystem()
        {
            return new ColorTechnologyCard { Name = "GravitationLaserSystem" };
        }
        public static ColorTechnologyCard GravityDrive()
        {
            return new ColorTechnologyCard { Name = "GravityDrive" };
        }
        public static ColorTechnologyCard HyperMetabolism()
        {
            return new ColorTechnologyCard { Name = "HyperMetabolism" };
        }
        public static ColorTechnologyCard IntegratedEconomy()
        {
            return new ColorTechnologyCard { Name = "IntegratedEconomy" };
        }
        public static ColorTechnologyCard LightWaveDeflector()
        {
            return new ColorTechnologyCard { Name = "LightWaveDeflector" };
        }
        public static ColorTechnologyCard MagenDefenseGrid()
        {
            return new ColorTechnologyCard { Name = "MagenDefenseGrid" };
        }
        public static ColorTechnologyCard NeuralMotivator()
        {
            return new ColorTechnologyCard { Name = "NeuralMotivator" };
        }
        public static ColorTechnologyCard PlasmaScoring()
        {
            return new ColorTechnologyCard { Name = "PlasmaScoring" };
        }
        public static ColorTechnologyCard SarweenTools()
        {
            return new ColorTechnologyCard { Name = "SarweenTools" };
        }
        public static ColorTechnologyCard TransitDiodes()
        {
            return new ColorTechnologyCard { Name = "TransitDiodes" };
        }
        public static ColorTechnologyCard X89BacterialWeapon()
        {
            return new ColorTechnologyCard { Name = "X89BacterialWeapon" };
        }

        public static ColorTechnologyCard SpaceDockII()
        {
            return new ColorTechnologyCard { Name = "Space Dock II" };
        }

        public static ColorTechnologyCard FleetLogistics()
        {
            return new ColorTechnologyCard { Name = "Fleet Logistics" };
        }
    }
}
