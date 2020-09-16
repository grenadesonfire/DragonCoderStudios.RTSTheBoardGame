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

        private TurnState _currentTurn;
        public TurnState CurrentTurn { 
            get
            {
                if(_currentTurn == null)
                {
                    _currentTurn = new TurnState(this);
                }

                return _currentTurn;
            }
        }
        
        public Game(List<string> Playernames)
        {
            Players = Playernames.Select(p => new Player(p)).ToList();
        }
    }
}
