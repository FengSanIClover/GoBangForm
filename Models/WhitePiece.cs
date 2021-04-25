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
    }
}
