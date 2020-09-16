using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Engine
{
    public class Ship
    {
        public Player Owner { get; set; }
    }

    public class Planets
    {
        public Player Owner { get; set; }
        public List<Ship> ShipsInOrbit { get; set; }
    }

    public class Game
    {
        public List<Player> Players { get; }

        public Game(List<string> Playernames)
        {
            Players = Playernames.Select(p => new Player(p));
        }
    }
}
