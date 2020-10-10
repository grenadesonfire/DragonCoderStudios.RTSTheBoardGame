using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public enum PlanetCategory
    {
        BLUE,
        RED,
        GREEN
    }

    public class PlanetDescription
    {
        public string Name { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
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
        /// <summary>
        /// Specific function of tile.
        /// </summary>
        public TileType Type { get; set; }
        /// <summary>
        /// Planets are blue, hazards are red.
        /// </summary>
        public PlanetCategory Category { get; set; }
        public HexCoords Coordinates { get; set; }
        public Player Owner { get; set; }
        public MapTile[] Neighbors { get; set; } = new MapTile[6];
        public PlanetDescription FirstPlanet { get; set; }
        public PlanetDescription SecondPlanet { get; set; }
        public Player PlacedBy { get; set; }
        public bool Placed { get; set; }
    }

    public class MapLayout
    {
        public List<MapTile> Tiles { get; private set; }

        public void BeginSetup(List<Player> players)
        {
            Tiles = new List<MapTile>();

            var blueCount = BlueTilesFor(players.Count());
            var redCount = RedTilesFor(players.Count());

            foreach (var p in players)
            {
                GenerateBlueTiles(blueCount, p);
                GenerateRedTiles(redCount, p);
            }
        }

        private void GenerateBlueTiles(int count, Player p)
        {
            for(var pIdx=0;pIdx < count; pIdx++)
            {
                Tiles.Add(
                    new MapTile
                    {
                        PlacedBy = p,
                        Type = TileType.Planet,
                        Category = PlanetCategory.BLUE,
                        FirstPlanet = new PlanetDescription() { Name = "Test Planet" }
                    });
            }
        }

        private void GenerateRedTiles(int count, Player p)
        {
            for(var pIdx = 0; pIdx < count; pIdx++)
            {
                Tiles.Add(
                    new MapTile
                    {
                        PlacedBy = p,
                        Type = TileType.AsteroidField,
                        Category = PlanetCategory.RED
                    });
            }
        }

        private int BlueTilesFor(int count)
        {
            return 9 - count;
        }

        private int RedTilesFor(int count)
        {
            return count == 4 ? 3 : 2;
        }
    }

    public class MapFactory
    {

    }
}
