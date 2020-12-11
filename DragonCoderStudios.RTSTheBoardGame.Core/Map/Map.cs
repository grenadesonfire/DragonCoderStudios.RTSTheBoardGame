using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Map
{
    /// <summary>
    /// https://catlikecoding.com/unity/tutorials/hex-map/part-1/
    /// https://www.redblobgames.com/grids/hexagons/
    /// 
    /// 
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

    public struct TilePlacementChoice
    {
        public List<HexCoords> PlaceableLocations { get; set; }
        public MapTile MyProperty { get; set; }
    }

    public class MapLayout
    {
        public List<MapTile> Tiles { get; private set; }

        public void BeginSetup(List<Player> players)
        {
            Tiles = new List<MapTile>();

            Tiles.Add(
                new MapTile
                {
                    Category = PlanetCategory.GREEN,
                    Placed = true,
                    Coordinates = new HexCoords { X = 0, Z = 0 },
                    Type = TileType.MecatorRex,
                });

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

        public void AddHomeTile(MapTile tile, Player p, HexCoords coords)
        {
            if (Tiles.Any(t => t.Coordinates != null && t.Coordinates.X == coords.X && t.Coordinates.Z == coords.Z)) throw new Exception("Tile already located here.");

            tile.Coordinates = coords;
            tile.Placed = true;
            Tiles.Add(tile);
            tile.PlacedBy = p;
        }

        public bool PlaceTile(MapTile tile, List<Player> players, int pIdx, HexCoords coords)
        {
            if (tile == null) return false;
            var prevPlayer = players[(pIdx + players.Count() - 1) % players.Count()];

            // Check the previous player has placed enough.
            //if (Tiles.Count(t => t.PlacedBy == prevPlayer) != Tiles.Count(t => players[pIdx] == t.PlacedBy)) return false;
            var prev = PlacedByPlayer(prevPlayer);
            var now = PlacedByPlayer(players[pIdx]);
            if (pIdx == 0 && PlacedByPlayer(prevPlayer) != PlacedByPlayer(players[pIdx])) return false;
            else if (pIdx != 0 && prev <= now) return false;

            var placed = Tiles.Count(t => t.Placed);
            var distance = DistanceFromCenter(coords);

            //Center is always mecator rex.
            if (distance == 0) return false;
            //Check if first ring complete
            if (placed <= players.Count + 1 + 6 && distance > 1) return false;
            //Check if second ring complete
            if (placed <= players.Count + 1 + 6 + 12 && distance > 2) return false;
            //Check three player
            //Now reject anything greater than 3 distance.
            if (distance > 3) return false;

            if (Tiles.Any(t => t.Coordinates != null && t.Coordinates.X == coords.X && t.Coordinates.Z == coords.Z)) return false;

            tile.Placed = true;
            tile.Coordinates = coords;

            return true;
        }

        public MapTile NextAvailableTile(List<Player> players, int playerIdx)
        {
            return Tiles.FirstOrDefault(t => !t.Placed && t.PlacedBy == players[playerIdx]);
        }

        public List<HexCoords> AvailableSpots(MapTile tile)
        {
            var ret = new List<HexCoords>();

            for(int z = -3; z <= 3; z++)
            {
                for(int x = -3; x <= 3; x++)
                {
                    if (x == 0 && z == 0) continue;

                    ret.Add(new HexCoords { X = x, Z = z });
                }
            }

            return ret;
        }

        private int DistanceFromCenter(HexCoords coords)
        {
            return (Math.Abs(coords.X) + Math.Abs(coords.Y) + Math.Abs(coords.Z)) / 2;
        }

        private int PlacedByPlayer(Player p) => Tiles.Count(t => t.Placed && t.PlacedBy == p);
    }

    public class MapFactory
    {

    }
}
