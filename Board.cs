using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        private Cell[,] _cells;
        private int _matrixSize;

        public Board(int matrixSize)
        {
            _matrixSize = matrixSize;
            _cells = new Cell[_matrixSize, _matrixSize];

            InitializeCells();
        }

        public int MatrixSize
        {
            get
            {
                return _matrixSize;
            }
        }

        public Cell[,] Cells
        {
            get
            {
                return _cells;
            }
        }

        public Cell this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= _matrixSize ||
                    column < 0 || column >= _matrixSize)
                    return null;
                return _cells[row, column];
            }
        }

        private void InitializeCells()
        {
            for (int i = 0; i < _matrixSize; i++)
                for (int j = 0; j < _matrixSize; j++)
                    _cells[i, j] = new Cell();

            for (int i = 0; i < _matrixSize; i++)
                for (int j = 0; j < _matrixSize; j++)
                    _cells[i, j].NeighbourCells = GetCellsNeighbours(i, j);
        }

        private IEnumerable<Cell> GetCellsNeighbours(int row, int column)
        {
            var neighbours = new List<Cell>();

            neighbours.Add(this[row - 1, column - 1]);
            neighbours.Add(this[row - 1, column]);
            neighbours.Add(this[row - 1, column + 1]);
            neighbours.Add(this[row, column - 1]);
            neighbours.Add(this[row, column + 1]);
            neighbours.Add(this[row + 1, column - 1]);
            neighbours.Add(this[row + 1, column]);
            neighbours.Add(this[row + 1, column + 1]);

            return neighbours.Where(cell => cell != null);
        }
    }
}