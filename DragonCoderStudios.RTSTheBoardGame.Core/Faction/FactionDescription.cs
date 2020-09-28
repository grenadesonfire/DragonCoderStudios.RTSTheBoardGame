using DragonCoderStudios.RTSTheBoardGame.Core.Cards;
using DragonCoderStudios.RTSTheBoardGame.Core.Map;
using DragonCoderStudios.RTSTheBoardGame.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Faction
{
    public class UnitDescription
    {
        public int Cost { get; set; }
        public int Combat { get; set; }
        public int Move { get; set; }
        public int Capacity { get; set; }
    }

    public class FlagShipDescription : UnitDescription
    {
        public string Name { get; set; }

        private FlagShipDescription() { }

        public static FlagShipDescription LonCara()
        {
            return new FlagShipDescription
            {
                Name = "LonCara Ssodu",
                Cost = 8,
                Combat = 7,
                Move = 1,
                Capacity = 3
            };
        }
    }

    public class CruiserDescription : UnitDescription { }
    public class DreadnoughtDescription : UnitDescription { }

    public class FactionDescription
    {
        public string Name { get; private set; }
        public int StartingCommodities { get; private set; }
        //    public FlagShipDescription FlagShip { get; private set; }
        //    public CruiserDescription Cruiser { get; private set; }
        //    public DreadnoughtDescription Dreadnought { get; private set; }
        //    public DestroyerDescription Destroyer { get; private set; }
        //    public WarSunDescription Warsun { get; private set; }
        //    public PDSDescription PDS { get; private set; }
        //    public CarrierDescription Carrier { get; private set; }
        //    public FighterDescription Figher { get; set; }
        //    public InfantryDescription Infantry { get; set; }
        //    public SpaceDockDescription SpaceDock { get; set; }
        public MapTile HomeTile { get; set; }
        public List<FactionTechnologyCard> TechnologyCards { get; set; }
        public PromissaryNote PromissaryNote { get; set; }
        //    private FactionDescription() { }

        //    public static FactionDescription XXChaKingdome()
        //    {
        //        return new FactionDescription
        //        {
        //            Name = "The XXCHA Kingdom",
        //            StartingCommodities = 4,
        //            FlagShip = FlagShipDescription.LonCara(),
        //            Cruiser = new CruiserDescription
        //            {
        //                Capacity = 0,
        //                Cost = 2,
        //                Combat = 7,
        //                Move = 2
        //            }
        //        }
        //    }
    }
}
