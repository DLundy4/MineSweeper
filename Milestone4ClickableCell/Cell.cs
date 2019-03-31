using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone4ClickableCell
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool Visited { get; set; }
        public int LiveNeighbors { get; set; }
        public bool Live { get; set; }
        public bool hasNeighbor { get; set; }

        //constructor
        public Cell(int r, int c)
        {
            RowNumber = r;
            ColumnNumber = c;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
            hasNeighbor = false;
        }

    }
}