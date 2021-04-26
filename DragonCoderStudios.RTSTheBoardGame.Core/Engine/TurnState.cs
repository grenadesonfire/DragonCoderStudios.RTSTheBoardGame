using DragonCoderStudios.RTSTheBoardGame.Core.StrategyCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Engine
{
    public enum Phase {
        Strategy = 0,
        Action,
        Status,
        Agenda
    }

    public class PlayerTurnState
    {
        public Player Player { get; private set; }

        public StrategyCard StrategyChoice { get; set; }

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

        public List<StrategyCard> AvailableCards { get; private set; }

        public bool GameOver { get; private set; }

        public List<Player> Victors { get; private set; }

        public TurnState(Game p)
        {
            Parent = p;

            PlayerStates = Parent.Players.OrderBy(p => p.InitiativeOrder).Select(p => new PlayerTurnState(p)).ToList();

            AvailableCards =
                new List<StrategyCard>
                {
                    StrategyCard.LeadershipCard(),
                    StrategyCard.DiplomacyCard(),
                    StrategyCard.DiplomacyCard(),
                    StrategyCard.DiplomacyCard(),
                    StrategyCard.DiplomacyCard(),
                    StrategyCard.DiplomacyCard(),
                    StrategyCard.DiplomacyCard(),
                    StrategyCard.DiplomacyCard()
                };
        }

        public void PickStrategyCard(Player p1, StrategyCard p2)
        {
            var state = PlayerStates.FirstOrDefault(ps => ps.Player == p1);

            state.StrategyChoice = p2;

            AvailableCards.Remove(p2);

            if(!PlayerStates.Any(ps => ps.StrategyChoice == null))
            {
                CurrentPhase = Phase.Action;
            }
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
