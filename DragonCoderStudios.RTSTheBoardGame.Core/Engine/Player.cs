using DragonCoderStudios.RTSTheBoardGame.Core.Cards;
using DragonCoderStudios.RTSTheBoardGame.Core.Faction;
using DragonCoderStudios.RTSTheBoardGame.Core.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Engine
{
    public enum PlayerColor
    {
        BLUE,
        GREEN,
        YELLOW,
        RED,
        WHITE,
        BLACK
    }

    public class ColorFaction
    {
        public PlayerColor PlayerColor { get; set; }
        public List<ColorTechnologyCard> TechnologyCards { get; set; }
        public List<PromissaryNote> PromissaryNotes { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }

        public int VictoryPoints { get; set; }

        public int InitiativeOrder { get; set; }

        public bool IsSpeaker { get; set; }

        public FactionDescription Faction { get; set; }

        public List<CommandToken> CommandTokens { get; set; }
        public List<ControlToken> ControlTokens { get; set; }

        public ColorFaction Color { get; set; }

        public Player(string name)
        {
            Name = name;
            VictoryPoints = 0;
        }
    }
}
