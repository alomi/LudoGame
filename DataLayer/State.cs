using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static Ludo.LogicLayer.Util;
using System;
using Exceptions;
using System.IO;

namespace Ludo.DataLayer
{
    public class State
    {
        private int playerTurn, playerNum;
        private Dictionary<int, List<int>> pieceMap;
        
        public int PlayerTurn { get => playerTurn; set => playerTurn = value; }
        public Dictionary<int, List<int>> PieceMap { get => pieceMap; set => pieceMap = value; }
        public int PlayerNum { get => playerNum; set => playerNum = value; }

        public State() { }

        /* Private constructor used to create a new state */
        private State(int playerTurn, int playerNum, Dictionary<int, List<int>> pieceMap)
        {
            this.playerTurn = playerTurn;
            this.playerNum = playerNum;
            this.pieceMap = pieceMap;
        }

        public void SetPlayerNum(int playerNum)
        {
            this.playerNum = playerNum;
        }

        public void SaveGame(int playerTurn, Dictionary<int, List<int>> pieceMap)
        {
            this.playerTurn = playerTurn;
            this.pieceMap = pieceMap;
            
            WriteState();
        }

        private void WriteState()
        {
            XDocument srcTree = new XDocument
            (
                new XElement
                (
                    "Root",
                    new XComment("### The player who is going to start after save ###"),
                    new XElement("playerturn", (PlayerTurn + 1)),
                    
                    new XComment("### List of piecepositions on the board for each Player ###")
                )
            );

            for (int i = 0; i < PlayerNum; i++)
            {
                XElement players = new XElement("players");
                XElement player = new XElement("player", new XAttribute("key", (i + 1)));

                for (int j = 0; j < pieceMap[i].Count; j++)
                {
                    player.Add(new XElement("piece", new XAttribute("name", (j + 1)), pieceMap[i][j]));
                }
                players.Add(player);
                srcTree.Root.Add(players);
            }

            srcTree.Save("../../DataLayer/SavedStates/root.xml");

        }

        public State LoadGame()
        {
            try
            {
                XDocument file;
                try
                {
                    file = XDocument.Load("../../DataLayer/SavedStates/root.xml");
                }
                catch (FileNotFoundException)
                {
                    throw new CouldNotReadFileException();
                }

                var game = from r in file.Descendants("Root")
                           select new
                           {
                               playerTurn = r.Element("playerturn").Value
                           };

                int nextPlayer = 0;
                foreach (var item in game)
                {
                    nextPlayer = Convert.ToInt32(item.playerTurn) - 1;
                }

                int numPlayers = 0;
                Dictionary<int, List<int>> newPieceMap = new Dictionary<int, List<int>>();

                foreach (XElement player in file.Descendants("player"))
                {
                    numPlayers++;
                    int playerNum = Convert.ToInt32(player.Attribute("key").Value);
                    List<int> pieces = new List<int>();
                    foreach (XElement piece in player.Descendants("piece"))
                    {
                        int piecePos = Convert.ToInt32(piece.Value);
                        pieces.Add(piecePos);
                    }
                    newPieceMap.Add((playerNum - 1), pieces);
                }

                /* Call to private constructor */
                return new State(nextPlayer, numPlayers, newPieceMap);
            }
            catch (CouldNotReadFileException)
            {
                return new State(0, 0, null);
            }
        }


        public State StartState(bool load, int playerNum)
        {
            if (load)
            {
                return LoadGame();
            }
            else
            {
                pieceMap = new Dictionary<int, List<int>>();

                for (int i = 0; i < playerNum; i++)
                {
                    pieceMap.Add(i, new List<int> { -1, -1, -1, -1 });
                }

                playerTurn = 0;

                this.playerNum = playerNum;

                return new State(playerTurn, playerNum, pieceMap);
            }
        }
    }
}
