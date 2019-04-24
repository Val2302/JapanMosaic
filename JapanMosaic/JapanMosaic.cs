using System;
using static System.Console;

namespace JapanMosaic
{
	public enum ECellsStates
	{
		none = ' ',
		fill = '█',
		num0 = '0',
		num1 = '1',
		num2 = '2',
		num3 = '3',
		num4 = '4',
		num5 = '5',
		num6 = '6',
		num7 = '7',
		num8 = '8',
		num9 = '9'
	}

	public class JapanMosaic
	{
		public const int NumCount = 9;
		private ECellsStates[ , , ] cellsVariants;
		private ECellsStates[ , ] solve;
		private int RowCount => solve.GetLength( 0 );
		private int ColCount => solve.GetLength( 1 );

		public JapanMosaic ( ECellsStates[ , ] condition )
		{
			if ( condition is null || condition.Length == 0 )
			{
				throw new ArgumentException( @"In constructor JapanMosaic argument ""condition"" is null or length it '=' 0" );
			}

			solve = condition;
			cellsVariants = new ECellsStates[ NumCount, RowCount, ColCount ];

			int i, j;
			int prevI, prevJ, nextI, nextJ;
			ECellsStates cellState;
			var floorsIndexes = new int[ RowCount, ColCount ];

			for ( i = 0; i < RowCount; i++ )
			{
				for ( j = 0; j < ColCount; j++ )
				{
					cellState = condition[ i, j ];

					if ( cellState != ECellsStates.none )
					{
						prevI = i - 1;
						prevJ = j - 1;
						nextI = i + 1;
						nextJ = j + 1;

						switch ( 0 )
						{
							case 0 when prevI > -1 && prevJ > -1:
								markedCell( prevI, prevJ );
								break;
							case 0 when prevI > -1:
								markedCell( prevI, j );
								break;
							case 0 when prevI > -1 && nextJ < ColCount:
								markedCell( prevI, nextJ );
								break;
							case 0 when prevJ > -1:
								markedCell( i, prevJ );
								break;
							case 0 when nextJ < ColCount:
								markedCell( i, nextJ );
								break;
							case 0 when nextI < RowCount && prevJ > -1:
								markedCell( nextI, prevJ );
								break;
							case 0 when nextI < RowCount:
								markedCell( nextI, j );
								break;
							case 0 when nextI < RowCount && nextJ < ColCount:
								markedCell( nextI, prevJ );
								break;
							default:
								markedCell( i, j );
								break;
						}
					}
				}
			}

			void markedCell ( int row, int col )
			{
				var floorIndex = floorsIndexes[ row, col ];
				cellsVariants[ floorIndex, row, col ] = cellState;
				floorsIndexes[ row, col ]++;
			}
		}

		public string Show ( )
		{
			var text = string.Empty;
			int k;

			for ( k = 0; k < NumCount; k++ )
			{
				WriteLine( ArrayConverter.Convert( Slice( ), e => ( char ) e ) + "\n" );
			}

			return text;

			ECellsStates[ , ] Slice ( )
			{
				int i, j;
				var slice = new ECellsStates[ RowCount, ColCount ];

				for ( i = 0; i < RowCount; i++ )
				{
					for ( j = 0; j < ColCount; j++ )
					{
						slice[ i, j ] = cellsVariants[ k, i, j ];
					}
				}

				return slice;
			}
		}
	}
}