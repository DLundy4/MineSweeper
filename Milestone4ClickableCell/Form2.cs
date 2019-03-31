using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone4ClickableCell
{
    public partial class Form2 : Form
    {
        public static Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        int flagToggleCount = 0;

        public Form2(int gridSize)
        {
            InitializeComponent();
            populateGrid();
            myBoard = new Board(gridSize);
            myBoard.CreateActiveBombs();
            myBoard.MarkAllLiveNeighborCounts();
        }

        public void populateGrid()
        {
            //this function will fill the panel1 control with buttons
            int buttonSize = panel1.Width / myBoard.Size; //calculate the width of each button on the grid
            panel1.Height = panel1.Width; //set the grid to be square

            //nested loop. Create buttons and place them in the panel
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    //make each button square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += Grid_Button_Click; //Add the same click event to each button
                    panel1.Controls.Add(btnGrid[r, c]); //place button on the panel
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c); //position it in x, y

                    //the tag attribute will hold the row and colum number into a string
                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Cornsilk)
            {
                (sender as Button).BackgroundImage = 
            }

            // get the row and column nubmer of the button just clicked.
            String[] strArr = (sender as Button).Tag.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            Cell currentCell = myBoard.theGrid[r, c];
            currentCell.Visited = true;

            floodFill(r, c);

            (sender as Button).Text = Convert.ToString(currentCell.LiveNeighbors);

            // reset the background color of all buttons to the default (original) color.
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].BackColor = default(Color);
                }
            }

                   //set the background color of the clicked button to something different.
                   (sender as Button).BackColor = Color.Cornsilk;
        }

        public void floodFill(int r, int c)
        {
            myBoard.theGrid[r, c].Visited = true;
            btnGrid[r, c].Text = Convert.ToString(myBoard.theGrid[r, c].LiveNeighbors);
            if (myBoard.theGrid[r, c].LiveNeighbors == 0)
            {
                if (isValid(r + 1, c) && myBoard.theGrid[r + 1, c].Visited == false)
                    floodFill(r + 1, c);
                if (isValid(r - 1, c) && myBoard.theGrid[r - 1, c].Visited == false)
                    floodFill(r - 1, c);
                if (isValid(r, c + 1) && myBoard.theGrid[r, c + 1].Visited == false)
                    floodFill(r, c + 1);
                if (isValid(r, c - 1) && myBoard.theGrid[r, c - 1].Visited == false)
                    floodFill(r, c - 1);
                if (isValid(r + 1, c + 1) && myBoard.theGrid[r + 1, c + 1].Visited == false)
                    floodFill(r + 1, c + 1);
                if (isValid(r - 1, c - 1) && myBoard.theGrid[r - 1, c - 1].Visited == false)
                    floodFill(r - 1, c - 1);
                if (isValid(r + 1, c - 1) && myBoard.theGrid[r + 1, c - 1].Visited == false)
                    floodFill(r + 1, c - 1);
                if (isValid(r - 1, c + 1) && myBoard.theGrid[r - 1, c + 1].Visited == false)
                    floodFill(r - 1, c + 1);
            }
        }

        private bool isValid(int r, int c)
        {
            return r >= 0 && c >= 0 && r < myBoard.Size && c < myBoard.Size;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            this.Hide();
            F1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flagToggleCount++;
            if (flagToggleCount % 2 == 0)
            {
                (sender as Button).BackColor = Color.Empty;
            }
            else
            {
                (sender as Button).BackColor = Color.Cornsilk;
            }
        }
    }
}
