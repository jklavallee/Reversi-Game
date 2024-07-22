using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
	public partial class othelloFrm : Form
	{
		public othelloFrm()
		{
			InitializeComponent();
		}

		public static class Globals
		{
			public static int buttonClick, player0 = 0, player1 = 0, optionsLeft = 0, incr = 2; 
			public const int MAX_ROWS = 8, MAX_COLUMNS = 8, BOARD_SPACES = 64;
		}

		private void button_Click(object sender, EventArgs e)
		{
			Button[,] buttons = new Button[10, 10] {
				{ ba, ba, ba, ba, ba, ba, ba, ba, ba, ba }, { ba, b00, b01, b02, b03, b04, b05, b06, b07, ba }, 
				{ ba, b10, b11, b12, b13, b14, b15, b16, b17, ba }, { ba, b20, b21, b22, b23, b24, b25, b26, b27, ba }, 
				{ ba, b30, b31, b32, b33, b34, b35, b36, b37, ba }, { ba, b40, b41, b42, b43, b44, b45, b46, b47, ba }, 
				{ ba, b50, b51, b52, b53, b54, b55, b56, b57, ba }, { ba, b60, b61, b62, b63, b64, b65, b66, b67, ba }, 
				{ ba, b70, b71, b72, b73, b74, b75, b76, b77, ba }, { ba, ba, ba, ba, ba, ba, ba, ba, ba, ba} };

			Button clickedButton = (Button)sender;

			if (richTextBox3.Visible == true && richTextBox3.Text == "Game in progress.") { //if game has started
				if (clickedButton.BackColor == System.Drawing.Color.PaleGreen) { //if green clicked
					richTextBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption; //reset box
					Globals.buttonClick++; //adjust turn
					flip_pieces(clickedButton);
				
					if (Globals.buttonClick % 2 == 0) { //white turn
						clickedButton.Text = "⚪";
					}
					else if (Globals.buttonClick % 2 == 1) { //black turn
						clickedButton.Text = "⚫";
					}
					for (int i = 1; i < Globals.MAX_ROWS + 1; i++) {
						for (int j = 1; j < Globals.MAX_COLUMNS + 1; j++) {
							buttons[i, j].BackColor = System.Drawing.Color.White; //reset all buttons to white background
						}
					}
				}
				else if (clickedButton.BackColor == System.Drawing.Color.White && richTextBox3.Visible == true && 
					richTextBox3.Text == "Game in progress.") {
					richTextBox1.BackColor = System.Drawing.Color.OrangeRed; //if game is in session and invalid piece is clicked
				}
			show_options();
			}
			for (int i = 1; i < Globals.MAX_ROWS + 1; i++) { //keeping score
				for (int j = 1; j < Globals.MAX_COLUMNS + 1; j++) {
					if (buttons[i, j].BackColor == System.Drawing.Color.PaleGreen) {
						Globals.optionsLeft++;
					}
					if (buttons[i, j].Text == "⚪") {
						Globals.player1++;
                    }
					if (buttons[i, j].Text == "⚫") {
						Globals.player0++;
					}
				}
			}
			game_Stats();
			Globals.optionsLeft = 0; Globals.player0 = 0; Globals.player1 = 0;
		}

		private void start_Game(object sender, EventArgs e)
		{
			Button[,] buttons = new Button[10, 10] {
				{ ba, ba, ba, ba, ba, ba, ba, ba, ba, ba }, { ba, b00, b01, b02, b03, b04, b05, b06, b07, ba },
				{ ba, b10, b11, b12, b13, b14, b15, b16, b17, ba }, { ba, b20, b21, b22, b23, b24, b25, b26, b27, ba },
				{ ba, b30, b31, b32, b33, b34, b35, b36, b37, ba }, { ba, b40, b41, b42, b43, b44, b45, b46, b47, ba },
				{ ba, b50, b51, b52, b53, b54, b55, b56, b57, ba }, { ba, b60, b61, b62, b63, b64, b65, b66, b67, ba },
				{ ba, b70, b71, b72, b73, b74, b75, b76, b77, ba }, { ba, ba, ba, ba, ba, ba, ba, ba, ba, ba} };

			richTextBox3.Visible = true;
			richTextBox3.Text = "Game in progress.";
			beginButton.Text = "Restart Game";
			richTextBox1.Text = "Turn:\n\nBlack - Player 0\n\nSelect a higlighted piece.\n\nInstructions on Wiki.";
			for (int i = 1; i < Globals.MAX_ROWS + 1; i++) {
				for (int j = 1; j < Globals.MAX_COLUMNS + 1; j++) {
					buttons[i, j].BackColor = System.Drawing.Color.White;
					buttons[i, j].Text = " ";
				}
			}
			b33.Text = "⚫";
			b34.Text = "⚪";
			b43.Text = "⚪";
			b44.Text = "⚫";
			richTextBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			Globals.buttonClick = 0;
			show_options();
		}

		private void show_options()
		{
			Button[,] buttons = new Button[10, 10] {
				{ ba, ba, ba, ba, ba, ba, ba, ba, ba, ba }, { ba, b00, b01, b02, b03, b04, b05, b06, b07, ba },
				{ ba, b10, b11, b12, b13, b14, b15, b16, b17, ba }, { ba, b20, b21, b22, b23, b24, b25, b26, b27, ba },
				{ ba, b30, b31, b32, b33, b34, b35, b36, b37, ba }, { ba, b40, b41, b42, b43, b44, b45, b46, b47, ba },
				{ ba, b50, b51, b52, b53, b54, b55, b56, b57, ba }, { ba, b60, b61, b62, b63, b64, b65, b66, b67, ba },
				{ ba, b70, b71, b72, b73, b74, b75, b76, b77, ba }, { ba, ba, ba, ba, ba, ba, ba, ba, ba, ba} };

			for (int i = 1; i < Globals.MAX_ROWS + 1; i++) {
				for (int j = 1; j < Globals.MAX_COLUMNS + 1; j++) {
					if (Globals.buttonClick % 2 == 1) { //black turn
						if (buttons[i, j].Text == "⚪") {
							for (int a = -1; a <= 1; a++) {
								for (int b = -1; b <= 1; b++) {
									if (i + a <= 9 && j + b <= 9 && i + a >= -1 && j + b >= -1) {
										if (buttons[i + a, j + b].Text == "⚫") {
											show_inception(a, b, i, j);
										}
									}
								}
							}
						}
					}
					else if (Globals.buttonClick % 2 == 0) {//white turn
						if (buttons[i, j].Text == "⚫") {
							for (int a = -1; a <= 1; a++) {
								for (int b = -1; b <= 1; b++) {
									if (i + a < 9 && j + b < 9 && i + a > 0 && j + b > 0) {
										if (buttons[i + a, j + b].Text == "⚪") {
											show_inception(a, b, i, j);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void flip_pieces(Button clickedButton)
        {
			Button[,] buttons = new Button[10, 10] {
				{ ba, ba, ba, ba, ba, ba, ba, ba, ba, ba }, { ba, b00, b01, b02, b03, b04, b05, b06, b07, ba },
				{ ba, b10, b11, b12, b13, b14, b15, b16, b17, ba }, { ba, b20, b21, b22, b23, b24, b25, b26, b27, ba },
				{ ba, b30, b31, b32, b33, b34, b35, b36, b37, ba }, { ba, b40, b41, b42, b43, b44, b45, b46, b47, ba },
				{ ba, b50, b51, b52, b53, b54, b55, b56, b57, ba }, { ba, b60, b61, b62, b63, b64, b65, b66, b67, ba },
				{ ba, b70, b71, b72, b73, b74, b75, b76, b77, ba }, { ba, ba, ba, ba, ba, ba, ba, ba, ba, ba} };

			for (int x = 1; x < Globals.MAX_ROWS + 1; x++) {
				for (int y = 1; y < Globals.MAX_COLUMNS + 1; y++) {
					if (buttons[x, y] == clickedButton) { //sender in terms of array
						if (Globals.buttonClick % 2 == 0) { //white turn
							for (int a = -1; a <= 1; a++) {
								for (int b = -1; b <= 1; b++) {
									if (x + a < 9 && y + b < 9 && x + a > 0 && y + b > 0) { //on board
										if (buttons[x + a, y + b].Text == "⚫") { //first opposite piece
											flip_inception(a, b, x, y);
										}
									}
								}
							}
						}
						else if (Globals.buttonClick % 2 == 1) { //black turn
							for (int a = -1; a <= 1; a++) {
								for (int b = -1; b <= 1; b++) {
									if (x + a < 9 && y + b < 9 && x + a > 0 && y + b > 0) { //on board
										if (buttons[x + a, y + b].Text == "⚪") { //first opposite piece
											flip_inception(a, b, x, y);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void show_inception(int nextR, int nextC, int row, int column)
		{
			Button[,] buttons = new Button[10, 10] {
				{ ba, ba, ba, ba, ba, ba, ba, ba, ba, ba }, { ba, b00, b01, b02, b03, b04, b05, b06, b07, ba },
				{ ba, b10, b11, b12, b13, b14, b15, b16, b17, ba }, { ba, b20, b21, b22, b23, b24, b25, b26, b27, ba },
				{ ba, b30, b31, b32, b33, b34, b35, b36, b37, ba }, { ba, b40, b41, b42, b43, b44, b45, b46, b47, ba },
				{ ba, b50, b51, b52, b53, b54, b55, b56, b57, ba }, { ba, b60, b61, b62, b63, b64, b65, b66, b67, ba },
				{ ba, b70, b71, b72, b73, b74, b75, b76, b77, ba }, { ba, ba, ba, ba, ba, ba, ba, ba, ba, ba} };

			if (Globals.incr <= 8 && row + nextR * Globals.incr <= 8 && row + nextR * Globals.incr >= 1 && column + nextC * 
				Globals.incr <= 8 && column + nextC * Globals.incr >= 1) { //piece on board
				if (Globals.buttonClick % 2 == 1) { //black turn
					if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == "⚫") { //if next in row/column is black
						Globals.incr++;
						show_inception(nextR, nextC, row, column);
					}
					else if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == " ") { //if next is available
						buttons[row + Globals.incr * nextR, column + Globals.incr * nextC].BackColor = System.Drawing.Color.PaleGreen;
						Globals.incr = 2;
					}
					else
					{ Globals.incr = 2;}
				}
				else if (Globals.buttonClick % 2 == 0) { //white turn
					if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == "⚪") { //if next in row/column is white
						Globals.incr++;
						show_inception(nextR, nextC, row, column);
					}
					else if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == " ") { //if next available
						buttons[row + Globals.incr * nextR, column + Globals.incr * nextC].BackColor = System.Drawing.Color.PaleGreen;
						Globals.incr = 2;
					}
					else
					{ Globals.incr = 2;}
				}
			}
			else
			{ Globals.incr = 2;}
		}

		private void flip_inception(int nextR, int nextC, int row, int column)
		{
			Button[,] buttons = new Button[10, 10] {
				{ ba, ba, ba, ba, ba, ba, ba, ba, ba, ba }, { ba, b00, b01, b02, b03, b04, b05, b06, b07, ba },
				{ ba, b10, b11, b12, b13, b14, b15, b16, b17, ba }, { ba, b20, b21, b22, b23, b24, b25, b26, b27, ba },
				{ ba, b30, b31, b32, b33, b34, b35, b36, b37, ba }, { ba, b40, b41, b42, b43, b44, b45, b46, b47, ba },
				{ ba, b50, b51, b52, b53, b54, b55, b56, b57, ba }, { ba, b60, b61, b62, b63, b64, b65, b66, b67, ba },
				{ ba, b70, b71, b72, b73, b74, b75, b76, b77, ba }, { ba, ba, ba, ba, ba, ba, ba, ba, ba, ba} };

			if (Globals.incr <= 8 && row + nextR * Globals.incr <= 8 && row + nextR * Globals.incr >= 1 && column + nextC * 
				Globals.incr <= 8 && column + nextC * Globals.incr >= 1) {
				if (Globals.buttonClick % 2 == 0) { //white turn
					if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == "⚫") { //if next in row/column is black
						Globals.incr++;
						flip_inception(nextR, nextC, row, column);
					}
					else if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == "⚪") { //if next is end
						for (int i = 0; i < Globals.MAX_ROWS; i++) {
							if (row + nextR * (Globals.incr - i) <= 8 && column + nextC * (Globals.incr - i) <= 8 &&
								row + nextR * (Globals.incr - i) >= 1 && column + nextC * (Globals.incr - i) >= 1) {
								if (buttons[row + nextR * (Globals.incr - i), column + nextC * (Globals.incr - i)].Text == "⚫") {
									buttons[row + nextR * (Globals.incr - i), column + nextC * (Globals.incr - i)].Text = "⚪";
								}
							}
						}
						Globals.incr = 2;
					}
					else
					{ Globals.incr = 2;}
				}
				else if (Globals.buttonClick % 2 == 1) { //black turn
					if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == "⚪") { //if next in row/column is white
						Globals.incr++;
						flip_inception(nextR, nextC, row, column);
					}
					else if (buttons[row + nextR * Globals.incr, column + nextC * Globals.incr].Text == "⚫") { //if next is end
						for (int i = 0; i < Globals.MAX_ROWS; i++) { 
							if (row + nextR * (Globals.incr - i) <= 8 && column + nextC * (Globals.incr - i) <= 8 &&
								row + nextR * (Globals.incr - i) >= 1 && column + nextC * (Globals.incr - i) >= 1) {
								if (buttons[row + nextR * (Globals.incr - i), column + nextC * (Globals.incr - i)].Text == "⚪") {
									buttons[row + nextR * (Globals.incr - i), column + nextC * (Globals.incr - i)].Text = "⚫";
								}
							}
						}
						Globals.incr = 2;
					}
					else { Globals.incr = 2;}
				}
				else { Globals.incr = 2;}
			}
		}

		private void game_Stats()
        {
			if (Globals.optionsLeft == 0 && richTextBox3.Visible == true && richTextBox3.Text == "Game in progress.") { //end of game
				richTextBox3.Text = "   Game Over.";
				if (Globals.player0 < Globals.player1) {
					richTextBox1.Text = "\n\n\nWhite Wins.";
				}
				else if (Globals.player1 < Globals.player0) {
					richTextBox1.Text = "\n\n\nBlack Wins.";
				}
				else {
					richTextBox1.Text = "\n\n\nTie.";
				}
				beginButton.Text = "New Game";
			}
			else { //turn
				if (richTextBox3.Text == "Game in progress.") {
					if (Globals.buttonClick % 2 == 0 && Globals.buttonClick != 0) {
						richTextBox1.Text = "Turn:\n\nBlack - Player 0\n\nSelect a higlighted piece.\n\nInstructions on Wiki.";
					}
					else if (Globals.buttonClick % 2 == 1) {
						richTextBox1.Text = "Turn:\n\nWhite - Player 1\n\nSelect a higlighted piece.\n\nInstructions on Wiki.";
					}
				}
			}
		}
    }
}

