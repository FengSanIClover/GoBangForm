using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoBang.Models
{
    /// <summary>
    /// 棋子基底類別
    /// </summary>
    public abstract class BasePiece : PictureBox
    {
        private const int baseSize = 50;

        public BasePiece(int x,int y)
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(baseSize, baseSize);
            this.Location = new Point(x - baseSize / 2, y - baseSize / 2);
        }
    }
}
