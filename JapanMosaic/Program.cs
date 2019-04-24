using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace JapanMosaic
{
	class Program
	{
		static void Main ( string[ ] args )
		{
			var conditionString = new[] {
				"  343 0",
				"25 76  ",
				"4 7  1 ",
				"4678764"
			};

			var condition = Convert( conditionString );

			new JapanMosaic( condition ).Show( );

			ReadKey( );
		}

		static ECellsStates[ , ] Convert ( string[] text )
		{
			var rowCount = text.Length;
			var colCount = text[ 0 ].Length;
			var cellStates = new ECellsStates[ rowCount, colCount ];
			int i, j;

			for ( i = 0; i < rowCount; i++ )
			{
				for ( j = 0; j < colCount; j++ )
				{
					if ( text[i][j] == ' ' )
					{
						cellStates[ i, j ] = ECellsStates.none;
					}
					else
					{
						cellStates[ i, j ] = (ECellsStates) Enum.GetValues( typeof( ECellsStates ) ).GetValue( System.Convert.ToInt32( text[ i ][ j ].ToString() ) + 1 );
					}
				}
			}

			return cellStates;
		}
	}
}
