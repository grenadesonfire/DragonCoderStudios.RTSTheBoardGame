using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Map
{
    /// <summary>
    /// https://catlikecoding.com/unity/tutorials/hex-map/part-1/
    /// </summary>
    public class HexCoords
    {
        public int X { get; set; }
        public int Z { get; set; }
        public int Y { get => -X - Z; }
    }

    public enum TileType
    {
        MecatorRex,
        Planet,
        AsteroidField,
        Supernova,
        Nebula,
        GravityRift,
        EmptySpace
    }

    public class PlanetDescription
    {
        public string Name { get; private set; }
        public int Value1 { get; private set; }
        public int Value2 { get; private set; }
        public bool IsExhausted { get; set; }

        public static PlanetDescription ArchonRen()
        {
            return new PlanetDescription
            {
                Name = "Archon Ren",
                Value1 = 2,
                Value2 = 3,
            };
        }

        public static PlanetDescription ArchonTau()
        {
            return new PlanetDescription
            {
                Name = "Archon Tau",
                Value1 = 1,
                Value2 = 1,
            };
        }
    }

    public class MapTile
    {
        public int Id { get; set; }
        public TileType Type { get; set; }
        public HexCoords Coordinates { get; set; }
        public Player Owner { get; set; }
        public MapTile[] Neighbors { get; set; } = new MapTile[6];
        public PlanetDescription FirstPlanet { get; set; }
        public PlanetDescription SecondPlanet { get; set; }
    }

    public class MapLayout
    {
        private List<MapTile> MapPieces { get; set; }
    }

    public class MapFactory
    {

    }
}
