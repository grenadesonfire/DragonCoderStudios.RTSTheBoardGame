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

        public ColorFaction(PlayerColor color)
        {
            PlayerColor = color;
            TechnologyCards = new List<ColorTechnologyCard>();
            PromissaryNotes = new List<PromissaryNote>();
        }
    }

    public class Player
    {
        public string Name { get; set; }

        public int VictoryPoints { get; set; }

        public int InitiativeOrder { get; set; }

        public bool IsSpeaker { get; set; }

        public Faction Faction { get; set; }

        public List<CommandToken> CommandTokens { get; set; }
        public List<ControlToken> ControlTokens { get; set; }

        public ColorFaction Color { get; set; }

        public Player(string name)
        {
            Name = name;
            VictoryPoints = 0;
        }

        public void InitializeTokens(int controlTokens, int commandTokens)
        {
            ControlTokens = new List<ControlToken>();
            for (var idx = 0; idx < controlTokens; idx++) ControlTokens.Add(new ControlToken(this));
            CommandTokens = new List<CommandToken>();
            for (var idx = 0; idx < commandTokens; idx++) CommandTokens.Add(new CommandToken(this));
        }

        public void AssignColor(PlayerColor color)
        {
            Color = new ColorFaction(color);
        }
    }
}
