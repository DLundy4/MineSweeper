using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone4ClickableCell
{
    public class Board
    {
        //the board is square usually 8x8
        public int Size { get; set; }

        //the 2d array of cell objects
        public Cell[,] theGrid;

        //constructor
        public Board(int s)
        {
            Size = s;
            //we must initialize the array to avoid Null Exception errors
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

       /* public void floodFill(int r, int c)
        {
            theGrid[r, c].Visited = true;
            if (theGrid[r, c].LiveNeighbors == 0)
            {
                if (isValid(r + 1, c) && theGrid[r + 1, c].Visited == false)
                    floodFill(r + 1, c);
                if (isValid(r - 1, c) && theGrid[r - 1, c].Visited == false)
                    floodFill(r - 1, c);
                if (isValid(r, c + 1) && theGrid[r, c + 1].Visited == false)
                    floodFill(r, c + 1);
                if (isValid(r, c - 1) && theGrid[r, c - 1].Visited == false)
                    floodFill(r, c - 1);
                if (isValid(r + 1, c + 1) && theGrid[r + 1, c + 1].Visited == false)
                    floodFill(r + 1, c + 1);
                if (isValid(r - 1, c - 1) && theGrid[r - 1, c - 1].Visited == false)
                    floodFill(r - 1, c - 1);
                if (isValid(r + 1, c - 1) && theGrid[r + 1, c - 1].Visited == false)
                    floodFill(r + 1, c - 1);
                if (isValid(r - 1, c + 1) && theGrid[r - 1, c + 1].Visited == false)
                    floodFill(r - 1, c + 1);
            }
        }

        private bool isValid(int r, int c)
        {
            return r >= 0 && c >= 0 && r < Size && c < Size;
        }

    */

        public void MarkAllLiveNeighborCounts()
        {
            for (int r = 0; r < this.Size; r++)
            {
                for (int c = 0; c < this.Size; c++)
                {
                    try
                    {
                        if (theGrid[r + 1, c + 1].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                    try
                    {
                        if (theGrid[r + 1, c].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                    try
                    {
                        if (theGrid[r + 1, c - 1].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                    try
                    {
                        if (theGrid[r, c - 1].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                    try
                    {
                        if (theGrid[r, c + 1].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                    try
                    {
                        if (theGrid[r - 1, c + 1].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                    try
                    {
                        if (theGrid[r - 1, c].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                    try
                    {
                        if (theGrid[r - 1, c - 1].Live)
                        {
                            theGrid[r, c].hasNeighbor = true;
                            theGrid[r, c].LiveNeighbors++;
                        }
                    }
                    catch (System.SystemException) { }
                }
            }
        }

        public void CreateActiveBombs()
        {
            Random random = new Random();
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    int rgn = random.Next(100);

                    if (rgn < 25)
                    {
                        theGrid[r, c].Live = true;

                        try { theGrid[r - 1, c - 1].hasNeighbor = true; }
                        catch (System.SystemException) { }
                        try { theGrid[r - 1, c].hasNeighbor = true; }
                        catch (System.SystemException) { }
                        try { theGrid[r - 1, c + 1].hasNeighbor = true; }
                        catch (System.SystemException) { }
                        try { theGrid[r, c + 1].hasNeighbor = true; }
                        catch (System.SystemException) { }
                        try { theGrid[r, c - 1].hasNeighbor = true; }
                        catch (System.SystemException) { }
                        try { theGrid[r + 1, c - 1].hasNeighbor = true; }
                        catch (System.SystemException) { }
                        try { theGrid[r + 1, c].hasNeighbor = true; }
                        catch (System.SystemException) { }
                        try { theGrid[r + 1, c + 1].hasNeighbor = true; }
                        catch (System.SystemException) { }
                    }
                }
            }
        }
    }
}