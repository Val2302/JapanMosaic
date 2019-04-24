namespace JapanMosaic
{
    enum CellsStates
    {
        clean = 0,
        mark = 1
    }

    public class JapanMosaic
    {
        private CellsStates[ , , ] cellsVariants;
        private CellsStates[ , ] solve;
        private int rowCount;
        private int colCount;
        private int numCount;

        public JapanMosaic ( int[ , ] condition )
        {
            
        }
    }
}
