using DragonCoderStudios.RTSTheBoardGame.Core.Faction;
using DragonCoderStudios.RTSTheBoardGame.Core.Tokens;
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

    public class Faction
    {
        public FactionDescription Description { get; set; }
        public PromissaryNote PromissaryNote { get; set; }



        public void Initialize(Player p)
        {
            PromissaryNote = new PromissaryNote(p);
        }
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
        
        public Game(List<string> Playernames, List<FactionDescription> Factions)
        {
            Players = Playernames.Select(p => new Player(p)).ToList();

            for(var idx=0;idx<Playernames.Count;idx++)
            {
                Players[idx].Faction = new Faction { Description = Factions[idx] };

                //Setup Control Tokens
                Players[idx].InitializeTokens(17, 16);
                Players[idx].Faction.Initialize(Players[idx]);
            }

            Players.FirstOrDefault().IsSpeaker = true;
        }
    }
}
