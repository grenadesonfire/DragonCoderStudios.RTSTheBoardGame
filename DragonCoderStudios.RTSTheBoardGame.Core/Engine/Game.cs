using DragonCoderStudios.RTSTheBoardGame.Core.Faction;
using DragonCoderStudios.RTSTheBoardGame.Core.Map;
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

        public MapLayout Map { get; }

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

            Map = new MapLayout();
        }

        public void AssingColorChoices(List<PlayerColor> colors)
        {
            if (colors.Count() != Players.Count()) throw new Exception("Not enough colors chosen");

            for(var pIdx = 0; pIdx < Players.Count(); pIdx++)
            {
                Players[pIdx].AssignColor(colors[pIdx]);
            }
        }

        public void BeginMapSetup()
        {
            Map.BeginSetup(Players);
        }

        public void AssignHomeLocations()
        {
            for(var pIdx = 0; pIdx < Players.Count; pIdx++)
            {
                var homeCoords = GetHomeCoords(pIdx, Players.Count);

                Map.AddHomeTile(Players[pIdx].Faction.Description.HomeTile, Players[pIdx], homeCoords);
            }
        }

        private HexCoords GetHomeCoords(int playerIndex, int totalPlayers)
        {
            HexCoords[] threePlayerCoords =
                new HexCoords[]
                {
                    new HexCoords { X = -3, Z = 3 },
                    new HexCoords { X = 3, Z = 0 },
                    new HexCoords { X = 0, Z = -3 },
                };

            HexCoords[] fourPlayerCoords =
                new HexCoords[]
                {
                    new HexCoords { X = -1, Z = 3},
                    new HexCoords { X = 3, Z = -1},
                    new HexCoords { X = 1, Z = -3},
                    new HexCoords { X = -3, Z = 1}
                };

            HexCoords[] fivePlayerCoords =
                new HexCoords[]
                {
                    new HexCoords { X = -1, Z = 3},
                    new HexCoords { X = 3, Z = 0 },
                    new HexCoords { X = 3, Z = -3 },
                    new HexCoords { X = 0, Z = -3 },
                    new HexCoords { X = -3, Z = 1}
                };

            HexCoords[] sixPlayerCoords =
                new HexCoords[]
                {
                    new HexCoords { X = -3, Z = 3 },
                    new HexCoords { X = 0, Z = 3 },
                    new HexCoords { X = 3, Z = 0 },
                    new HexCoords { X = 3, Z = -3 },
                    new HexCoords { X = 0, Z = -3 },
                    new HexCoords { X = -3, Z = 0 },
                };

            switch (totalPlayers)
            {
                case 3:
                    if (playerIndex > threePlayerCoords.Length) throw new Exception("Too many players for three player game.");
                    return threePlayerCoords[playerIndex];
                case 4:
                    if (playerIndex > fourPlayerCoords.Length) throw new Exception("Too many players for four player game.");
                    return fourPlayerCoords[playerIndex];
                case 5:
                    if (playerIndex > fivePlayerCoords.Length) throw new Exception("Too many players for five player game.");
                    return fivePlayerCoords[playerIndex];
                case 6:
                    if (playerIndex > sixPlayerCoords.Length) throw new Exception("Too many players for six player game.");
                    return sixPlayerCoords[playerIndex];
                default:
                    throw new Exception("Unsupported number of players.");
            }
        }
    }
}
