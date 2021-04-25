using System;
using System.Collections.Generic;
using System.Text;

namespace GoBang.Models
{
    /// <summary>
    /// 白棋類別
    /// </summary>
    public class WhitePiece : BasePiece
    {
        public WhitePiece(int x,int y):base(x,y)
        {
            this.Image = Properties.Resources.white;
        }

        /// <summary>
        /// 取得棋子顏色
        /// </summary>
        /// <returns></returns>
        public override PieceType GetPieceType()
        {
            return PieceType.White;
        }
    }
}
