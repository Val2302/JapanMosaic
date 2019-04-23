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
			var a = new[ ] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			var t = ArrayConverter.Convert( a, c => c % 2 == 0 ? 'T' : 'F' );
			WriteLine( t );
			ReadKey( );
		}
	}
}
