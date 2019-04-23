using System;
using System.Linq;
using System.Text;

namespace JapanMosaic
{
	public static class ArrayConverter
	{
		private const int increment = 0;

		public static string Convert<T> ( T[ ] array, Func<T, char> convert = null )
		{
			if ( array is null )
			{
				throw new ArgumentNullException( @"In ArrayConverter.Convert() argument ""array"" is '=' null" );
			}

			var headerNumbers = GenerateHeaderNumbers( array.Length );
			var dataRow = convert is null ? GenerateRow( ) : GenerateConvertRow( );
			var bottomLine = GenerateBottomLine( array.Length );

			return headerNumbers + dataRow + bottomLine;

			string GenerateRow ( )
			{
				var row = "║ ║";

				foreach ( var item in array )
				{
					row += item + "│";
				}

				row = row.Substring( 0, row.Length - 1 ) + "║\n";

				return row;
			}

			string GenerateConvertRow ( )
			{
				var row = "║ ║";

				foreach ( var item in array )
				{
					row += convert( item ) + "│";
				}

				row = row.Substring( 0, row.Length - 1 ) + "║\n";

				return row;
			}
		}

		public static string Convert<T> ( T[ , ] array, Func<T, char> convert = null )
		{
			if ( array is null )
			{
				throw new ArgumentNullException( @"In ArrayConverter.Convert() argument ""array"" is '=' null" );
			}

			var headerNumbers = GenerateHeaderNumbers( array.Length );
			var dataRow = convert is null ? GenerateRows( ) : GenerateConvertRows( );
			var bottomLine = GenerateBottomLine( array.Length );

			return headerNumbers + dataRow + bottomLine;

			string GenerateRows ( )
			{
				var row = "║ ║";

				foreach ( var item in array )
				{
					row += item + "│";
				}

				row = row.Substring( 0, row.Length - 1 ) + "║\n";

				return row;
			}

			string GenerateConvertRows ( )
			{
				var row = "║ ║";

				foreach ( var item in array )
				{
					row += convert( item ) + "│";
				}

				row = row.Substring( 0, row.Length - 1 ) + "║\n";

				return row;
			}
		}

		private static string GenerateHeaderNumbers ( int length )
		{	
			var upperLine = "╔═";
			var middleLine = "║ ";
			var lowerLine = "╠═";

			for ( int i = 0; i < length; i++ )
			{
				upperLine += "╦═";
				middleLine += "║" + ( i + increment ) % 10;
				lowerLine += "╬═";
			}

			upperLine += "╗\n";
			middleLine += "║\n";
			lowerLine += "╣\n";

			return upperLine + middleLine + lowerLine;
		}

		private static string GenerateBottomLine ( int length )
		{	
			var line = "╚═";

			for ( int i = 0; i < length; i++ )
			{
				line += "╩═";
			}

			line += "╝\n";

			return line;
		}
	}
}
