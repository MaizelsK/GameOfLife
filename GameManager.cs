using System;
using System.Threading;

namespace GameOfLife
{
    public class GameManager
    {
        private Board _gameBoard;
        private int _generationsCount;

        public GameManager(int generationsCount)
        {
            _generationsCount = generationsCount;
            _gameBoard = new Board(50);
        }

        public void Start()
        {
            ConfigureBoardCells();

            for (int i = 0; i < _generationsCount; i++)
            {
                PrintCells();
                NextGeneration();
                Thread.Sleep(400);
                Console.Clear();
            }
        }

        private void PrintCells()
        {
            Console.WriteLine();

            for (int i = 0; i < _gameBoard.MatrixSize; i++)
            {
                for (int j = 0; j < _gameBoard.MatrixSize; j++)
                {
                    Console.Write(_gameBoard[i, j].IsAlive ? "X " : "0 ");
                    _gameBoard[i, j].NextGeneration();
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void ConfigureBoardCells()
        {
            _gameBoard[9, 9].Reborn();
            _gameBoard[10, 10].Reborn();
            _gameBoard[11, 8].Reborn();
            _gameBoard[11, 9].Reborn();
            _gameBoard[11, 10].Reborn();
        }

        private void NextGeneration()
        {
            for (int i = 0; i < _gameBoard.MatrixSize; i++)
                for (int j = 0; j < _gameBoard.MatrixSize; j++)
                    _gameBoard[i, j].IsAlive = _gameBoard[i, j].WillBeAlive;
        }
    }
}