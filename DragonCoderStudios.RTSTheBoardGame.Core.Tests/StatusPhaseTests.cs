using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Tests
{
    public class StatusPhaseTests
    {
        [Fact]
        public void ScoreObjectivesInInitiativeOrder()
        {
            var g = new Game(new List<string> { "Player 1", "Player2" });

            g.Players[0].VictoryPoints = 10;

            g.CurrentTurn.AdvanceToPhase(Phase.Status);

            Assert.True(g.CurrentTurn.GameOver, "Game was not ended correctly.");

            Assert.True(g.CurrentTurn.Victors.Contains(g.Players[0]), "First player should be the victor.");
        }

        [Fact]
        public void NewObjectiveCardRevealed()
        {

        }

        [Fact]
        public void Draw2ObjectiveCards()
        {

        }

        [Fact]
        public void RemoveUnusedCommandPoints()
        {

        }

        [Fact]
        public void PlayersRegainCommandPoints()
        {

        }

        [Fact]
        public void PlayersRedistributeCommandPoints()
        {

        }

        [Fact]
        public void PlayersReadyCards()
        {

        }

        [Fact]
        public void PlayersRepairDamagedUnits()
        {

        }

        [Fact]
        public void PlayersReturnStrategyCards()
        {

        }
    }
}
