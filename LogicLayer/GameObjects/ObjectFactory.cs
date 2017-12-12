using DataTransfer;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Ludo.LogicLayer.GameObjects
{
    public class ObjectFactory
    {

        public GameObject CreateGameObject(Object[] args)
        {
            string obj = (string) args[0];

            switch (obj)
            {
                case "board":
                    int playerNum = (int)args[1];
                    int boardSize = (int)args[2];
                    Dictionary<int, Piece[]> pieces = (Dictionary<int, Piece[]>)args[3];
                    Dictionary<int, List<int>> pieceMap = (Dictionary<int, List<int>>)args[4];
                    return CreateBoard(playerNum, boardSize, pieces, pieceMap);

                case "dice":
                    return CreateDice();

                default:
                    throw new ObjectCreationException();
            }
        }

        public GameObject[] CreateGameObjects(Object[] args)
        {
            string obj = (string)args[0];
            switch (obj)
            {
                case "piece":
                    int q = (int)args[1];
                    int color = (int)args[2];
                    return CreatePieces(q, color);

                default:
                    throw new ObjectCreationException();
            }
        }

        private Piece[] CreatePieces(int numberOfPieces, int color)
        {
            // create multiple pieces
            Piece[] pieces = new Piece[numberOfPieces];
            for (int i = 0; i < numberOfPieces; i++)
            {
                pieces[i] = new Piece(color, i);
            }
            return pieces;
        }

        private Board CreateBoard(int playerNum, int boardSize, Dictionary<int, Piece[]> pieces, Dictionary<int, List<int>> pieceMap)
        {
            // create tiles
            Tile[] tiles = new Tile[405]; // statisk strl
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Tile();
            }

            // create nests
            Dictionary<int, Nest> nests = new Dictionary<int, Nest>();
            
            for (int i = 0; i < playerNum; i++)
            {
                Nest nest = new Nest(i * (boardSize / pieces.Count), i, pieces[i]);
                nests.Add(i, nest);

                // add nest for every piece
                for (int j = 0; j < pieces[i].Length; j++)
                {
                    pieces[i][j].SetNest(nest);
                }
            }

            return new Board(new BoardData(boardSize, tiles, nests, pieceMap));
        }

        private Dice CreateDice()
        {
            return new Dice();
        }
    }
}
