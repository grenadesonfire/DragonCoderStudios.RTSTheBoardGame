using System;
using System.Collections.Generic;
using System.Linq;
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
        public Player Player { get; private set; }

        public PlayerTurnState(Player p)
        {
            Player = p;
        }
    }

    public class TurnState
    {
        public int TurnCounter { get; set; }
        public Phase CurrentPhase { get; private set; }
        public Game Parent { get; private set; }
        public List<PlayerTurnState> PlayerStates { get; private set; }
        public bool GameOver { get; private set; }
        public List<Player> Victors { get; private set; }

        public TurnState(Game p)
        {
            Parent = p;

            PlayerStates = Parent.Players.OrderBy(p => p.InitiativeOrder).Select(p => new PlayerTurnState(p)).ToList();
        }

        public void AdvanceToPhase(Phase nextPhase)
        {
            if (CurrentPhase == nextPhase) throw new Exception("Illegal duplicate of phase.");

            CurrentPhase = nextPhase;

            switch (nextPhase)
            {
                case Phase.Status:
                    RunStatusPhasePrep();
                    break;
            }
        }

        public void RunStatusPhasePrep()
        {
            ScoreInInitiativeOrder();
        }

        public void ScoreInInitiativeOrder()
        {
            if(PlayerStates.Any(ps => ps.Player.VictoryPoints >= 10))
            {
                Victors = PlayerStates.Where(ps => ps.Player.VictoryPoints >= 10).Select(ps => ps.Player).ToList();
                GameOver = true;
                return;
            }
        }
    }
}
