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
		}

		public ECellsStates[ , ] Solve ( )
		{
			cellsVariants = new ECellsStates[ NumCount, RowCount, ColCount ];

			GenerateCellsVariants( );
			ClearZeroCells( );
			FindSolve( );

			return solve;

			void FindSolve ( )
			{
				var towersHeights = new int[ RowCount, ColCount ];
				int i, j, k;

				for ( i = 0; i < RowCount; i++ )
				{
					for ( j = 0; j < ColCount; j++ )
					{
						for ( k = 0; k < NumCount; k++ )
						{
							if ( cellsVariants[ k, i, j ] != ECellsStates.none )
							{
								towersHeights[ i, j ]++;
							}
						}
					}
				}

				WriteLine( ArrayConverter.Convert( towersHeights ) );
			}

			void GenerateCellsVariants ( )
			{
				int i, j;
				int prevI, prevJ, nextI, nextJ;
				ECellsStates cellState;
				var floorsIndexes = new int[ RowCount, ColCount ];

				GenerateDefaultValues( );

				for ( i = 0; i < RowCount; i++ )
				{
					for ( j = 0; j < ColCount; j++ )
					{
						cellState = solve[ i, j ];

						if ( cellState != ECellsStates.none )
						{
							prevI = i - 1;
							prevJ = j - 1;
							nextI = i + 1;
							nextJ = j + 1;

							if ( prevI > -1 )
							{
								if ( prevJ > -1 )
								{
									markedCell( prevI, prevJ );
								}

								markedCell( prevI, j );

								if ( nextJ < ColCount )
								{
									markedCell( prevI, nextJ );
								}
							}

							if ( prevJ > -1 )
							{
								markedCell( i, prevJ );
							}

							markedCell( i, j );

							if ( nextJ < ColCount )
							{
								markedCell( i, nextJ );
							}

							if ( nextI < RowCount )
							{
								if ( prevJ > -1 )
								{
									markedCell( nextI, prevJ );
								}

								markedCell( nextI, j );

								if ( nextJ < ColCount )
								{
									markedCell( nextI, nextJ );
								}
							}
						}
					}
				}

				void GenerateDefaultValues()
				{
					int k;
					
					for ( k = 0; k < NumCount; k++ )
					{
						for ( i = 0; i < RowCount; i++ )
						{
							for ( j = 0; j < ColCount; j++ )
							{
								cellsVariants[ k, i, j ] = ECellsStates.none;
							}
						}
					}
				}

				void markedCell ( int row, int col )
				{
					if ( cellState != ECellsStates.num0 )
					{
						//var floorIndex = floorsIndexes[ row, col ];
						var floorIndex = int.Parse( ( ( char ) cellState ).ToString() ) - 1;
						cellsVariants[ floorIndex, row, col ] = cellState;
						floorsIndexes[ row, col ]++;
					}

					//var floorIndex = floorsIndexes[ row, col ];

				}
			}

			void ClearZeroCells ( )
			{
				int prevI, prevJ, nextI, nextJ;
				int i, j, k;

				for ( i = 0; i < RowCount; i++ )
				{
					for ( j = 0; j < ColCount; j++ )
					{
						if ( solve[ i, j ] == ECellsStates.num0 )
						{
							for ( k = 0; k < NumCount; k++ )
							{
								prevI = i - 1;
								prevJ = j - 1;
								nextI = i + 1;
								nextJ = j + 1;

								if ( prevI > -1 )
								{
									if ( prevJ > -1 )
									{
										cellsVariants[ k, prevI, prevJ ] = ECellsStates.none;
									}

									cellsVariants[ k, prevI, j ] = ECellsStates.none;

									if ( nextJ < ColCount )
									{
										cellsVariants[ k, prevI, nextJ ] = ECellsStates.none;
									}
								}

								if ( prevJ > -1 )
								{
									cellsVariants[ k, i, prevJ ] = ECellsStates.none;
								}

								cellsVariants[ k, i, j ] = ECellsStates.none;

								if ( nextJ < ColCount )
								{
									cellsVariants[ k, i, nextJ ] = ECellsStates.none;
								}

								if ( nextI < RowCount )
								{
									if ( prevJ > -1 )
									{
										cellsVariants[ k, nextI, prevJ ] = ECellsStates.none;
									}

									cellsVariants[ k, nextI, j ] = ECellsStates.none;

									if ( nextJ < ColCount )
									{
										cellsVariants[ k, nextI, nextJ ] = ECellsStates.none;
									}
								}
							}
						}
					}
				}
			}
		}

		public string Show ( )
		{
			var text = string.Empty;
			int k;

			for ( k = 0; k < NumCount; k++ )
			{
				WriteLine( ArrayConverter.Convert( Slice( cellsVariants, k ), e => ( char ) e ) );
			}

			return text;

			ECellsStates[ , ] Slice ( ECellsStates[ , , ] arr, int floor )
			{
				int i, j;
				var slice = new ECellsStates[ RowCount, ColCount ];

				for ( i = 0; i < RowCount; i++ )
				{
					for ( j = 0; j < ColCount; j++ )
					{
						slice[ i, j ] = cellsVariants[ floor, i, j ];
					}
				}

				return slice;
			}
		}
	}
}