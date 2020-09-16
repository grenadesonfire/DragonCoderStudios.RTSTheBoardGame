using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Engine
{
    public class Player
    {
        public string Name { get; set; }

        public int VictoryPoints { get; set; }

        public int InitiativeOrder { get; set; }

        public Player(string name)
        {
            Name = name;
            VictoryPoints = 0;
        }
    }
}
