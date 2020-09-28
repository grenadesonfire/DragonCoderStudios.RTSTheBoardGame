using DragonCoderStudios.RTSTheBoardGame.Core.Cards;
using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace DragonCoderStudios.RTSTheBoardGame.Core.Tests
{
    public class SetupTests
    {
        public readonly List<string> PLAYER_NAMES =
            new List<string>{
                "Player 1",
                "Player 2"
            };
        
        // Step 1
        [Fact]
        public void SpeakerAssignedAndLimitedToOne()
        {
            var g = new Game(PLAYER_NAMES);

            Assert.True(g.Players.Where(p => p.IsSpeaker).Count() == 1, "There can only be one speaker.");
        }

        // Step 2
        [Fact]
        public void AssignFactionSheets()
        {
            var g = new Game(PLAYER_NAMES);

            Assert.True(g.Players.Where(p => p.Faction != null).Count() == 0, "Each player must have a faction assigned.");
        }

        // Step 3
        [Fact]
        public void PlayerStartingComponentsCorrect()
        {
            var g = new Game(PLAYER_NAMES);

            foreach(var p in g.Players)
            {
                Assert.True(p.Faction.HomeTile != null, "Must have a home tile available.");
                Assert.True(p.Faction.HomeTile.Neighbors.Where(mt => mt == null).Count() == 6, "Home tile should be unassigned.");

                Assert.True(p.ControlTokens.Count() == 17, "Not enough control tokens.");
                Assert.True(p.CommandTokens.Count() == 17, "Not enough control tokens.");
                Assert.True(p.Faction.PromissaryNote != null, "Not enough control tokens.");
                Assert.True(p.Faction.TechnologyCards.Count() == 2, "Not enough control tokens.");
            }
        }

        // Step 4
        [Fact]
        public void ColorsAssigned()
        {
            var g = new Game(PLAYER_NAMES);

            Assert.True(g.Players.Where(p => p.Color == null).Count() == 0, "Every player should have something assigned.");

            Assert.True(
                g.Players.Where(p => p.Color.TechnologyCards.Count() != 25).Count() == 0,
                "Should have 25 cards available.");

            Assert.True(
                g.Players.Where(p => p.Color.PromissaryNotes.Count() != 4).Count() == 0,
                "Should have 4 promissary notes for the color.");

            //Assert that player has 5 notes after shuffle on play area
            //Assert that player has 27 tech cards after shuffling tech and color together.
        }

        //Step 5
        [Fact]
        public void PlayAreaHasPlanetCardSetup()
        {
            Assert.True(false);
        }

        // Step 6 Create Game Board
        [Fact]
        public void ThreePlayerAmountsCorrect()
        {
            Assert.True(false);
        }

        [Fact]
        public void FourPlayerAmountsCorrect()
        {
            Assert.True(false);
        }

        [Fact]
        public void FiveePlayerAmountsCorrect()
        {
            Assert.True(false);
        }

        [Fact]
        public void SixPlayerAmountsCorrect()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlacingFollowsTurnOrder()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlacingTileFollowsRingRules()
        {
            Assert.True(false);
        }

        [Fact]
        public void AnnommalyTilesCantTouch()
        {
            Assert.True(false);
        }

        [Fact]
        public void AnomalyTilesTouchIfLastTwoSpots()
        {
            Assert.True(false);
        }

        [Fact]
        public void FivePlayerGameBonusesApplied()
        {
            Assert.True(false);
        }

        [Fact]
        // Step 7
        public void CustodianTilePlaced()
        {
            Assert.True(false);
        }

        [Fact]
        // Step 8
        public void ActionCardDeck()
        {
            Assert.True(false);
        }

        [Fact]
        public void StageIObjectiveDeck()
        {
            Assert.True(false);
        }

        [Fact]
        public void StageIIObjectiveDeck()
        {
            Assert.True(false);
        }

        [Fact]
        public void SecretObjectiveDeck()
        {
            Assert.True(false);
        }

        [Fact]
        // Step 9
        public void CheckTokenSupply()
        {
            // Trade good, Fighter, Infantry
            Assert.True(false);
        }

        [Fact]
        // Step 10
        public void StrategyCardsSetup()
        {
            Assert.True(false);
        }

        [Fact]
        // Step 11
        public void FactionSpecificStartup()
        {
            // Might have to check individually
            Assert.True(false);
        }

        [Fact]
        public void PlaceStartingUnitsInHomeWorld()
        {
            Assert.True(false);
        }

        [Fact]
        public void PlayerCommandTokens()
        {
            // Check Command Token Count
            // Tactic Pool / Fleet pool / Strategy pool
            Assert.True(false);
        }

        [Fact]
        // Step 12
        public void SecretObjectivesAssigned()
        {
            Assert.True(false);
        }

        [Fact]
        public void VictoryPointTrackReset()
        {
            Assert.True(false);
        }

        [Fact]
        public void StageObjectivesDealt()
        {
            Assert.True(false);
        }

        [Fact]
        public void FirstStageIObjectivesRevealed()
        {
            Assert.True(false);
        }
    }
}
