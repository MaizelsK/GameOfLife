using System;
using System.Linq;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public bool WillBeAlive { get; set; }
        public IEnumerable<Cell> NeighbourCells { get; set; }

        public void Reborn()
        {
            IsAlive = true;
        }

        public void NextGeneration()
        {
            int aliveNeighboursCount = NeighbourCells.Where(cell => cell.IsAlive).Count();

            if (IsAlive)
                WillBeAlive = !(aliveNeighboursCount > 3 || aliveNeighboursCount < 2);
            else
                WillBeAlive = aliveNeighboursCount == 3;
        }
    }
}