using System;
using System.Collections.Generic;

namespace OOGasTetris
{
	public class Tetromino
	{
		private int i;
		private int j;
		List<bool[,]> pattern;
		private int position;

		public Tetromino (List<bool[,]> pattern)	
		{
			this.pattern = pattern;
			this.i = 1;
			this.j = 2;
			this.position = 0;
		}

		public bool[,] getActualRotation(){
			return pattern [position];
		}


		public bool[,] getNextRotation(){
			int next = position == pattern.Count - 1 ? 0 : position + 1;

			return pattern [next];
		}

		public int getI(){
			return i;
		}

		public int getJ(){
			return j;
		}

		public void moveDown(){
			i++;
		}

		public void moveRight(){
			j++;
		}

		public void moveLeft(){
			j--;
		}
			

		public void rotateRight(){
			position = position == pattern.Count - 1 ? 0 : position + 1;
		}

		public void rotateLeft(){
			position = position == 0 ? pattern.Count - 1 : position - 1;
		}
	}
}

