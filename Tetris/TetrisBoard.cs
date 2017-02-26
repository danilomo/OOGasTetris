using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace SquareChase
{
	public class TetrisBoard
	{
		private bool[,] board;
		private int ytop = 0;
		private int xtop = 0;
		private Texture2D bujaum;
		private int w;
		private int h;
		private Tetromino tetromino;
		private float timePerRow = 1f;
		private float timeInRow = 0f;


		public TetrisBoard (Texture2D bujaum)
		{
			board = new bool[27, 12];

			for (int i = 0; i < board.GetLength (0); i++) {
				for (int j = 0; j < board.GetLength (1); j++) {
					board [i, j] = j == 0 || i == 0 ||
					i == board.GetLength (0) - 1 || j == board.GetLength (1) - 1;					
				}
			}

			this.bujaum = bujaum;

			w = bujaum.Width;
			h = bujaum.Height;

		}

		public void drawBoard (SpriteBatch spriteBatch)
		{
			for (int i = 0; i < board.GetLength (0); i++) {
				for (int j = 0; j < board.GetLength (1); j++) {

					if (board [i, j]) {
						spriteBatch.Draw (bujaum, getCoords (i, j));
					}
				}
			}
			if (tetromino == null)
				return;

			bool[,] tetroMatrix = tetromino.getActualRotation ();

			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					if (tetroMatrix [i, j]) {
						spriteBatch.Draw (bujaum, 
							getCoords (i + tetromino.getI ()
								      , j + tetromino.getJ ()));
					}
				}
			}
		}



		private Vector2 getCoords (int i, int j)
		{			
			return new Vector2 ((float)xtop + j * w, (float)ytop + i * h);
		}

		public void newTetromino ()
		{
			tetromino = TetrominoFactory.getRandomBlock ();
			timeInRow = timePerRow;
		}

		public void updateTime (float time)
		{
			timeInRow -= time;
			Console.WriteLine (timeInRow);

			if (timeInRow < 0) {

				bool[,] nextBoard = tetromino.getActualRotation ();

				if (validMove (nextBoard, tetromino.getI () + 1, tetromino.getJ ())) {
					tetromino.moveDown ();

					timeInRow = timePerRow;
				} else {
					mergeTetromino ();

					newTetromino ();
				}
			}
		}

		public void handleInput (KeyboardState newState, KeyboardState oldState)
		{

			bool[,] nextBoard = tetromino.getActualRotation ();

			if (newState.IsKeyDown (Keys.Up) && !oldState.IsKeyDown (Keys.Up)) {
				nextBoard = tetromino.getNextRotation ();

				if (validMove (nextBoard, tetromino.getI (), tetromino.getJ ())) {
					tetromino.rotateRight ();
				}
			} else if (newState.IsKeyDown (Keys.Left) && !oldState.IsKeyDown (Keys.Left)) {
				if (validMove (nextBoard, tetromino.getI (), tetromino.getJ () - 1)) {
					tetromino.moveLeft ();
				}
			} else if (newState.IsKeyDown (Keys.Right) && !oldState.IsKeyDown (Keys.Right)) {
				if (validMove (nextBoard, tetromino.getI (), tetromino.getJ () + 1)) {
					tetromino.moveRight ();
				}
			}

			if (newState.IsKeyDown (Keys.Down)) {
				timePerRow = 0.03f;
			} else {
				timePerRow = 1f;
			}

		}

		private void setBujaum (MouseState mouseState)
		{

			int i = ((mouseState.Y -
			        (int)ytop) / h);

			int j = ((mouseState.X -
			        (int)xtop) / w);

			if (i >= 0 && i < board.GetLength (0) &&
			    j >= 0 && j < board.GetLength (1)) {
				board [i, j] = !board [i, j];
			}
		}

		private bool validMove (bool[,] mat, int i, int j)
		{
			for (int _i = 0; _i < 4; _i++) {
				for (int _j = 0; _j < 4; _j++) {
					if (mat [_i, _j] && board [_i + i, _j + j]) {
						return false;
					}
				}
			}

			return true;
		}

		private void mergeTetromino ()
		{
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {

					if (tetromino.getI () + i < board.GetLength (0) &&
					    tetromino.getJ () + j < board.GetLength (1)) {

						board [tetromino.getI () + i, tetromino.getJ () + j] =
						tetromino.getActualRotation () [i, j] ||
						board [tetromino.getI () + i, tetromino.getJ () + j];
					
					}
				}
			}

		}
	}
}

