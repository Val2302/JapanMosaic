using System;
using static System.Console;

namespace JapanMosaic
{
	class Program
	{
		static void Main ( string[ ] args )
		{
			var conditionString = new[ ] {
			   //1234567890
				"   4  42  ",
				" 03    422",
				" 14 997543",
				" 1  776  5",
				" 1 5  555 ",
				"  2 443 55",
				"  34 445 5",
				"1  5 4578 ",
				"25 6336 8 ",
				"3 975 7863",
				"   87 87  ",
				" 69 9 9 30",
				"3 8  9963 ",
				"4678    2 ",
				"34 5  5 1 "
			};

			var condition = Convert( conditionString );
			var japanMosaic = new JapanMosaic( condition );
			japanMosaic.Solve( );
			japanMosaic.Show( );

			ReadKey( );
		}

		static ECellsStates[ , ] Convert ( string[ ] text )
		{
			var rowCount = text.Length;
			var colCount = text[ 0 ].Length;
			var cellStates = new ECellsStates[ rowCount, colCount ];
			int i, j;

			for ( i = 0; i < rowCount; i++ )
			{
				for ( j = 0; j < colCount; j++ )
				{
					if ( text[ i ][ j ] == ' ' )
					{
						cellStates[ i, j ] = ECellsStates.none;
					}
					else
					{
						cellStates[ i, j ] = ( ECellsStates ) Enum.GetValues( typeof( ECellsStates ) ).GetValue( System.Convert.ToInt32( text[ i ][ j ].ToString( ) ) + 1 );
					}
				}
			}

			return cellStates;
		}


	}
}
