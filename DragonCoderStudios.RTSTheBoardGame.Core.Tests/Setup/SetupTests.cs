using DragonCoderStudios.RTSTheBoardGame.Core.Cards;
using DragonCoderStudios.RTSTheBoardGame.Core.Engine;
using DragonCoderStudios.RTSTheBoardGame.Core.Faction;
using DragonCoderStudios.RTSTheBoardGame.Core.Map;
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
                "Player 2",
                "Player 3",
                "Player 4",
                "Player 5",
                "Player 6",
            };

        public readonly List<FactionDescription> PLAYER_FACTIONS =
            new List<FactionDescription>
            {
                FactionDescription.XXChaKingdome(),
                FactionDescription.XXChaKingdome(),
                FactionDescription.XXChaKingdome(),
                FactionDescription.XXChaKingdome(),
                FactionDescription.XXChaKingdome(),
                FactionDescription.XXChaKingdome()
            };

        public readonly List<PlayerColor> PLAYER_COLORS =
            new List<PlayerColor>
            {
                PlayerColor.BLUE,
                PlayerColor.RED,
                PlayerColor.GREEN,
                PlayerColor.BLACK,
                PlayerColor.YELLOW,
                PlayerColor.WHITE
            };

        public Game Setup(int players)
        {
            return new Game(
                PLAYER_NAMES.Take(players).ToList(),
                PLAYER_FACTIONS.Take(players).ToList());
        }

        public Game SetupWithColorsAssigned(int players)
        {
            var g = Setup(players);

            g.AssingColorChoices(PLAYER_COLORS.Take(players).ToList());

            return g;
        }
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
            var g = SetupWithColorsAssigned(3);

            g.BeginMapSetup();

            var tiles = g.Map.Tiles.Where(t => !t.Placed).ToList();

            Assert.True(
                g.Map.Tiles.Count() == 24, 
                $"Total is incorrect, found {g.Map.Tiles.Count()}");

            AssertForPlayers(tiles.ToList(), g.Players, 8, 6, 2);
        }

        [Fact]
        public void FourPlayerAmountsCorrect()
        {
            var g = SetupWithColorsAssigned(4);

            g.BeginMapSetup();

            var tiles = g.Map.Tiles.Where(t => !t.Placed).ToList();

            Assert.True(
                g.Map.Tiles.Count() == 32,
                $"Total is incorrect, found {g.Map.Tiles.Count()}");

            AssertForPlayers(tiles.ToList(), g.Players, 8, 5, 3);
        }

        [Fact]
        public void FivePlayerAmountsCorrect()
        {
            var g = SetupWithColorsAssigned(5);

            g.BeginMapSetup();

            var tiles = g.Map.Tiles.Where(t => !t.Placed).ToList();

            Assert.True(
                g.Map.Tiles.Count() == 30,
                $"Total is incorrect, found {g.Map.Tiles.Count()}");

            AssertForPlayers(tiles.ToList(), g.Players, 6, 4, 2);
        }

        [Fact]
        public void SixPlayerAmountsCorrect()
        {
            var g = SetupWithColorsAssigned(6);

            g.BeginMapSetup();

            var tiles = g.Map.Tiles.Where(t => !t.Placed).ToList();

            Assert.True(
                g.Map.Tiles.Count() == 30,
                $"Total is incorrect, found {g.Map.Tiles.Count()}");

            AssertForPlayers(tiles.ToList(), g.Players, 5, 3, 2);
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

        private void AssertForPlayers(List<MapTile> tiles, List<Player> players, int playerTotal, int playerBlue, int playerRed)
        {
            for (var pIdx = 0; pIdx < players.Count(); pIdx++)
            {
                Assert.True(
                    tiles
                        .Where(t => t.PlacedBy == players[pIdx])
                        .Count() == playerTotal,
                    $"Player {pIdx + 1} not dealt {playerTotal} tiles.");

                var blueCount = tiles
                        .Where(t => t.PlacedBy == players[pIdx] && t.Category == Core.Map.PlanetCategory.BLUE)
                        .Count();
                Assert.True(
                    blueCount == playerBlue,
                    $"Player {pIdx + 1} not dealt {playerBlue} blue tiles. Found {blueCount}.");

                Assert.True(
                    tiles
                        .Where(t => t.PlacedBy == players[pIdx] && t.Category == PlanetCategory.RED)
                        .Count() == playerRed, $"Player {0 + 1} not dealt {playerRed} red tiles.");
            }
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
