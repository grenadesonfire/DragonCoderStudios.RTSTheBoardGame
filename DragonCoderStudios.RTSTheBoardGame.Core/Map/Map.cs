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
    public class MapTile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TileType Type { get; set; }
        public HexCoords Coordinates { get; set; }
        public int Resources { get; set; }
        public int Influence { get; set; }
        public bool IsSpent { get; set; }
        public Player Owner { get; set; }
        public MapTile[] Neighbors { get; set; } = new MapTile[6];
    }

    public class MapLayout
    {
        private List<MapTile> MapPieces { get; set; }
    }

    public class MapFactory
    {

    }
}
