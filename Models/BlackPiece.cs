using System;
using System.Collections.Generic;
using System.Text;

namespace GoBang.Models
{
    /// <summary>
    /// 黑棋類別
    /// </summary>
    public class BlackPiece : BasePiece
    {
        public BlackPiece(int x, int y) : base(x, y) 
        {
            this.Image = Properties.Resources.black;
        }

        /// <summary>
        /// 取得棋子顏色
        /// </summary>
        /// <returns></returns>
        public override PieceType GetPieceType()
        {
            return PieceType.Black;
        }
    }
}
