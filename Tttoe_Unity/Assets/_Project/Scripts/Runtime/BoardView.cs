using com.tttoe.runtime.Interfaces;
using UnityEngine;

namespace com.tttoe.runtime
{
    public class BoardView : MonoBehaviour, IBoardView
    {
        [SerializeField] private TileView[] _tiles;
        [field: SerializeField] public int Size { get; private set; } = 3;

        public void UpdateTile(BoardTilePosition position, TileOccupation occupation)
        {
            GetTile(position).SetState(occupation);
        }

        private TileView GetTile(BoardTilePosition position)
        {
            return _tiles[position.Row * Size + position.Column];
        }
    }
}