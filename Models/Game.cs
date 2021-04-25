using System;
using System.Collections.Generic;
using System.Text;

namespace GoBang.Models
{
    /// <summary>
    /// 遊戲類別
    /// </summary>
    public class Game
    {
        // 下一個棋子顏色
        private PieceType nextPlayer = PieceType.Black;

        // 棋盤動作類別
        private Board board;

        public Game()
        {
            board = new Board();
        }

        /// <summary>
        /// 放置棋子方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public BasePiece PlaceAPiece(int x, int y)
        {
            var piece = board.PlaceAPiece(x, y, nextPlayer);
            if(piece != null)
            {
                if (nextPlayer == PieceType.Black)
                {
                    nextPlayer = PieceType.White;
                }
                else
                {
                    nextPlayer = PieceType.Black;
                }
            }

            return piece;
        }

        /// <summary>
        /// 判斷是否可以放置棋子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }
    }
}
