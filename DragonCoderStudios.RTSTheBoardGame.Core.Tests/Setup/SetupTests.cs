using DragonCoderStudios.RTSTheBoardGame.Core.Cards;
using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using DragonCoderStudios.RTSTheBoardGame.Core.Faction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Priority;

namespace DragonCoderStudios.RTSTheBoardGame.Tests.Setup
{
    public class BaseSetupTests
    {
        public readonly List<string> PLAYER_NAMES =
            new List<string>{
                "Player 1",
                "Player 2"
            };

        public readonly List<FactionDescription> PLAYER_FACTIONS =
            new List<FactionDescription>
            {
                FactionDescription.XXChaKingdome(),
                FactionDescription.XXChaKingdome(),
            };

        public readonly List<PlayerColor> PLAYER_COLORS =
            new List<PlayerColor>
            {
                PlayerColor.BLUE,
                PlayerColor.RED
            };
    }

    public class Stage01 : BaseSetupTests
    {
        // Step 1
        [Fact, Priority(1)]
        public void SpeakerAssignedAndLimitedToOne()
        {
            var g = new Game(PLAYER_NAMES, PLAYER_FACTIONS);

            Assert.True(g.Players.Where(p => p.IsSpeaker).Count() == 1, "There can only be one speaker.");
        }
    }
    public class Stage02 : BaseSetupTests
    {
        // Step 2
        [Fact, Priority(2)]
        public void AssignFactionSheets()
        {
            var g = new Game(PLAYER_NAMES, PLAYER_FACTIONS);

            Assert.True(g.Players.Where(p => p.Faction == null).Count() == 0, "Each player must have a faction assigned.");
        }
    }

    public class Stage03 : BaseSetupTests
    { 
        // Step 3
        [Fact]
        public void PlayerStartingComponentsCorrect()
        {
            var g = new Game(PLAYER_NAMES, PLAYER_FACTIONS);

            foreach(var p in g.Players)
            {
                Assert.True(p.Faction.Description.HomeTile != null, "Must have a home tile available.");
                Assert.True(p.Faction.Description.HomeTile.Neighbors.Where(mt => mt == null).Count() == 6, "Home tile should be unassigned.");

                Assert.True(p.ControlTokens.Count() == 17, $"Not enough control tokens for player {p.Name}.");
                Assert.True(p.CommandTokens.Count() == 16, "Not enough command tokens.");
                Assert.True(p.Faction.PromissaryNote != null, "Not enough promissary notes.");
                Assert.True(p.Faction.Description.TechnologyCards.Count() == 2, "Not enough techcards.");
            }
        }
    }

    public class Stage04 : BaseSetupTests
    {
        // Step 4
        [Fact]
        public void ColorsAssigned()
        {
            var g = new Game(PLAYER_NAMES, PLAYER_FACTIONS);

            g.AssingColorChoices(PLAYER_COLORS);

            Assert.True(g.Players.Where(p => p.Color == null).Count() == 0, "Every player should have something assigned.");

            var playerTechCardCount = g.Players.Where(p => p.Color.TechnologyCards.Count() != 25);
            Assert.True(
                playerTechCardCount.Count() == 0,
                $"Should have 25 cards available. Found {g.Players.FirstOrDefault(p => p.Color.TechnologyCards.Count() != 25)?.Color.TechnologyCards.Count()}");

            Assert.True(
                g.Players.Where(p => p.Color.PromissaryNotes.Count() != 4).Count() == 0,
                "Should have 4 promissary notes for the color.");
            //Assert that player has 5 notes after shuffle on play area
            //Assert that player has 27 tech cards after shuffling tech and color together.
        }
    }

    public class Stage05 : BaseSetupTests
    {
        //Step 5
        [Fact]
        public void PlayAreaHasPlanetCardSetup()
        {
            var g = new Game(PLAYER_NAMES, PLAYER_FACTIONS);

            g.AssingColorChoices(PLAYER_COLORS);

            foreach(var p in g.Players)
            {
                Assert.True(p.Faction.Description.HomeTile.FirstPlanet != null, "Should have a planet assigned");
            }
        }
    }

    public class Stage06 : BaseSetupTests
    {
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
    }

    public class Stage07 : BaseSetupTests
    {
        [Fact]
        // Step 7
        public void CustodianTilePlaced()
        {
            Assert.True(false);
        }
    }

    public class Stage08 : BaseSetupTests
    {
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
    }

    public class Stage09 : BaseSetupTests
    {
        [Fact]
        // Step 9
        public void CheckTokenSupply()
        {
            // Trade good, Fighter, Infantry
            Assert.True(false);
        }
    }

    public class Stage10 : BaseSetupTests
    {
        [Fact]
        // Step 10
        public void StrategyCardsSetup()
        {
            Assert.True(false);
        }
    }

    public class Stage11 : BaseSetupTests
    {
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
    }

    public class Stage12 : BaseSetupTests
    {
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
