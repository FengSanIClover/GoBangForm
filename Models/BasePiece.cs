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
        public BasePiece(int x,int y)
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(50, 50);
            this.Location = new Point(x, y);
        }
    }
}
