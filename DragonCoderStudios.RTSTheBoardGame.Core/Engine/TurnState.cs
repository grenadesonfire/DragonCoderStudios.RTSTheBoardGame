using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Engine
{
    public enum Phase {
        Strategic = 0,
        Tactical,
        Status,
        Political
    }

    public class PlayerTurnState
    {
        public Player Player { get; set; }

    }

    public class TurnState
    {
    }
}
