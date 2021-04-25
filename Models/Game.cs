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
        private PieceType currentPlayer = PieceType.Black;

        // 贏家
        private PieceType winner = PieceType.None;
        public PieceType Winner { get => winner; }

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
            var piece = board.PlaceAPiece(x, y, currentPlayer);
            if(piece != null)
            {
                // 確認是否獲勝
                CheckWinner();

                if (currentPlayer == PieceType.Black)
                {
                    currentPlayer = PieceType.White;
                }
                else
                {
                    currentPlayer = PieceType.Black;
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

        /// <summary>
        /// 判斷是否獲勝
        /// </summary>
        private void CheckWinner()
        {
            int currentX = board.LastPiecePoint.X;
            int currentY = board.LastPiecePoint.Y;

            int count;
            int verticalCount = 1;
            int horizontalCount = 1;
            int upSlashCount = 1;
            int downSlashCount = 1;

            for (int xDir = -1; xDir <= 1; xDir += 1) 
            {
                count = 1;
                for (int yDir = -1;yDir <=1; yDir += 1)
                {
                    if (xDir == 0 && yDir == 0) continue;

                    while (verticalCount < 5 && horizontalCount < 5 && upSlashCount < 5 && downSlashCount < 5)
                    {
                        int targetX = currentX + count * xDir;
                        int targetY = currentY + count * yDir;
                        if (
                            targetX < 0 || targetX >= Board.MaxCount ||
                            targetY < 0 || targetY >= Board.MaxCount ||
                            board.GetCurrentPieceType(targetX, targetY) != currentPlayer
                          ) break;

                        // 水平線計數
                        if((xDir == -1 && yDir == 0) || (xDir == 1 && yDir == 0))
                        {
                            horizontalCount += 1;
                        }

                        // 垂直線計數
                        if ((xDir == 0 && yDir == 1) || (xDir == 0 && yDir == -1))
                        {
                            verticalCount += 1;
                        }

                        // 左上到右下線計數
                        if ((xDir == -1 && yDir == -1) || (xDir == 1 && yDir == 1))
                        {
                            upSlashCount += 1;
                        }

                        // 右下到左上線計數
                        if ((xDir == -1 && yDir == 1) || (xDir == 1 && yDir == -1))
                        {
                            downSlashCount += 1;
                        }

                        count++;
                    }
                }
            }

            if (verticalCount == 5 || horizontalCount == 5 || upSlashCount == 5 || downSlashCount == 5)
                winner = currentPlayer;
        }
    }
}
