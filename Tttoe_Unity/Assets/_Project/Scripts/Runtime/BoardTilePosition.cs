namespace com.tttoe.runtime
{
    public struct BoardTilePosition
    {
        public int Row;
        public int Column;
    
        public BoardTilePosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int ToSingleDimensionIndex(int boardSize)
        {
            return Row * boardSize + Column;
        }

        public string GetPositionString()
        {
            return string.Format("Tile position {0}:{1}", Row, Column);
        }
    }
}