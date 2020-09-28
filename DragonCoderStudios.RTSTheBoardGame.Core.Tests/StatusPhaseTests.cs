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
            Assert.True(false);
        }

        [Fact]
        public void Draw2ObjectiveCards()
        {
            Assert.True(false);
        }

        [Fact]
        public void RemoveUnusedCommandPoints()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlayersRegainCommandPoints()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlayersRedistributeCommandPoints()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlayersReadyCards()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlayersRepairDamagedUnits()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlayersReturnStrategyCards()
        {
            Assert.True(false);
        }
    }
}
