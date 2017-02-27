using System;
using System.Collections.Generic;

namespace OOGasTetris
{
	public class TetrominoFactory
	{
		private const bool _ = false;
		private const bool X = true;

		private static List<bool[,]> IBLOCK = new List<bool[,]> () {new bool[4, 4] {
				{ _, X, _, _ },
				{ _, X, _, _ },
				{ _, X, _, _ },
				{ _, X, _, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ X, X, X, X },
			}
		};

		private static List<bool[,]> OBLOCK = new List<bool[,]> () { new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ _, X, X, _ },
				{ _, X, X, _ },
			}
		};

		private static List<bool[,]> LBLOCK = new List<bool[,]> () { new bool[4, 4] {
				{ _, _, _, _ },
				{ _, X, _, _ },
				{ _, X, _, _ },
				{ _, X, X, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ _, X, X, X },
				{ _, X, _, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, X, X, _ },
				{ _, _, X, _ },
				{ _, _, X, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ _, _, _, X },
				{ _, X, X, X },
			},
		};

		private static List<bool[,]> JBLOCK = new List<bool[,]> () { new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, X, _ },
				{ _, _, X, _ },
				{ _, X, X, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ X, X, X, _ },
				{ _, _, X, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, X, X, _ },
				{ _, X, _, _ },
				{ _, X, _, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ X, _, _, _ },
				{ X, X, X, _ },
			},
		};

		private static List<bool[,]> SBLOCK = new List<bool[,]> () { new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ _, _, X, X },
				{ _, X, X, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, X, _ },
				{ _, _, X, X },
				{ _, _, _, X },
			},
		};

		private static List<bool[,]> ZBLOCK = new List<bool[,]> () { new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ _, X, X, _ },
				{ _, _, X, X },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, X },
				{ _, _, X, X },
				{ _, _, X, _ },
			},
		};

		private static List<bool[,]> TBLOCK = new List<bool[,]> () { new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, _ },
				{ _, _, X, _ },
				{ _, X, X, X },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, _, _, X },
				{ _, _, X, X },
				{ _, _, _, X },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, X, X, X },
				{ _, _, X, _ },
				{ _, _, _, _ },
			}, new bool[4, 4] {
				{ _, _, _, _ },
				{ _, X, _, _ },
				{ _, X, X, _ },
				{ _, X, _, _ },
			},
		};

		private static Random random = new Random ();

		public static Tetromino getRandomBlock ()
		{
			int i = random.Next (0, 7);
			List<bool[,]> pattern = IBLOCK;

			switch (i) {
			case 0:
				pattern = IBLOCK;
				break;
			case 1:
				pattern = OBLOCK;
				break;
			case 2:
				pattern = JBLOCK;
				break;
			case 3:
				pattern = LBLOCK;
				break;
			case 4:
				pattern = ZBLOCK;
				break;
			case 5:
				pattern = SBLOCK;
				break;
			case 6:
				pattern = TBLOCK;
				break;
			}

			return new Tetromino (IBLOCK);
		}
	}
}

