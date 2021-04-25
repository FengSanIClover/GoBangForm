using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GoBang.Models
{
    /// <summary>
    /// 棋盤動作相關類別
    /// </summary>
    public class Board
    {
        /// <summary>
        /// 棋盤邊界距離
        /// </summary>
        private static readonly int OFFSET = 75;

        /// <summary>
        /// 棋盤間隔距離
        /// </summary>
        private static readonly int NODE_DISTANCE = 75;

        /// <summary>
        /// 棋子半徑距離
        /// </summary>
        private static readonly int NODE_RADIUS = 10;

        /// <summary>
        /// 未匹配到對應位置
        /// </summary>
        private static readonly Point NO_MATCH = new Point(-1, -1);

        /// <summary>
        /// 棋盤位置
        /// </summary>
        private static BasePiece[,] pieces = new BasePiece[9, 9];

        /// <summary>
        /// 最大座標位置
        /// </summary>
        public static readonly int MaxCount = 9;

        // 最後一顆棋子位置
        private static Point lastPiecePoint = NO_MATCH;
        public Point LastPiecePoint { get => lastPiecePoint; }

        /// <summary>
        /// 判斷是否可以放置棋子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool CanBePlaced(int x,int y)
        {
            // 找出最近的節點
            var closetNode = FindClosetNode(x, y);

            // 如果沒有就回傳 false
            if (closetNode == NO_MATCH)
                return false;

            // 判斷是否已經被放過棋子
            if (pieces[closetNode.X, closetNode.Y] != null)
                return false;

            return true;
        }

        /// <summary>
        /// 放置棋子方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public BasePiece PlaceAPiece(int x,int y, PieceType type)
        {
            // 找出最近的節點
            var closetNode = FindClosetNode(x, y);

            // 如果沒有就回傳 null
            if (closetNode == NO_MATCH)
                return null;

            // 判斷位置是否已經擺放棋子，若有則不給放
            if (pieces[closetNode.X, closetNode.Y] != null)
                return null;

            // 取得表單實際座標點
            Point formPoint = GetFormPoint(closetNode);

            // 根據型態判斷要擺放的顏色
            if (type == PieceType.Black)
                pieces[closetNode.X, closetNode.Y] = new BlackPiece(formPoint.X, formPoint.Y);

            if(type == PieceType.White)
                pieces[closetNode.X, closetNode.Y] = new WhitePiece(formPoint.X, formPoint.Y);

            // 紀錄最後一顆棋子位置
            lastPiecePoint = closetNode;

            return pieces[closetNode.X, closetNode.Y];
        }

        /// <summary>
        /// 將鄰近節點位置轉換為實際座標
        /// </summary>
        /// <param name="closetNode"></param>
        /// <returns></returns>
        private Point GetFormPoint(Point closetNode) 
        {
            var resPoint = new Point();

            // 實際位置  = 邊界 + 鄰近座標 * 間隔距離
            resPoint.X = OFFSET + closetNode.X * NODE_DISTANCE;
            resPoint.Y = OFFSET + closetNode.Y * NODE_DISTANCE;

            return resPoint;
        }

        /// <summary>
        /// 取得當前棋子顏色
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PieceType GetCurrentPieceType(int x,int y)
        {
            if (pieces[x, y] == null)
                return PieceType.None;

            return pieces[x, y].GetPieceType();
        }

        /// <summary>
        /// 找出最近的節點(二維)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Point FindClosetNode(int x, int y) 
        {
            // 判斷並取得 X 節點位置，是否存在或超出最大位置
            int indexX = FindClosetNode(x);
            if (indexX == -1 || indexX >= MaxCount)
                return NO_MATCH;

            // 判斷並取得 Y 座標位置，是否存在或超出最大位置
            int indexY = FindClosetNode(y);
            if (indexY == -1 || indexY >= MaxCount)
                return NO_MATCH;

            return new Point(indexX,indexY);
        }

        /// <summary>
        /// 找出最近的節點(一維)
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int FindClosetNode(int pos)
        {
            // 若距離為邊界上回傳 -1
            if (pos < OFFSET - NODE_RADIUS) return -1;

            // 減掉邊界距離
            pos -= OFFSET;

            // 取商數代表點位置
            var quotient = pos / NODE_DISTANCE;
            // 取餘數判斷為當前點或下一點位置
            var remainder = pos % NODE_DISTANCE;

            // 判斷餘數是否小於棋子半徑，表示為當前位置
            if (remainder <= NODE_RADIUS)
                return quotient;

            // 判斷餘數若大於 1 個間距 - 棋子半徑，表示為靠近下一個點位置
            if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;

            return -1;
        }
    }
}
