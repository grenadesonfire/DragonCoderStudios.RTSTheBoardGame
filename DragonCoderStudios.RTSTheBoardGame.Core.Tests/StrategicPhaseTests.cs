using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using DragonCoderStudios.RTSTheBoardGame.Tests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Tests
{
    public class StrategicPhaseTests : BaseSetupTests
    {
        [Fact]
        public void PhaseChangeAfterChoicesMade()
        {
            var g = SetupWithSpacesBuilt(3);

            var turn = g.CurrentTurn;

            Assert.True(turn.CurrentPhase == Phase.Strategy, "Game should be in Strategy phase");
            Assert.True(turn.AvailableCards.Count == 8, "Not all strategy cards initialized.");

            foreach(var p in g.Players)
            {
                turn.PickStrategyCard(p, turn.AvailableCards.First());
            }

            Assert.True(turn.CurrentPhase == Phase.Action, "Game should be in Action phase.");
            Assert.True(turn.AvailableCards.Count() == 5, "Should have only five cards left in 3 player game.");
        }
    }
}
