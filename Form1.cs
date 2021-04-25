using GoBang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoBang
{
    public partial class Form1 : Form
    {
        // 下一個棋子顏色
        private PieceType nextType = PieceType.Black;
        // 棋盤動作類別
        private Board board;

        public Form1()
        {
            InitializeComponent();
            board = new Board();
            this.MouseDown += MouseDownEvent;
            this.MouseMove += MouseMoveEvent;
        }

        /// <summary>
        /// 滑鼠點選事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDownEvent(object sender, MouseEventArgs e) 
        {
            BasePiece piece = board.PlaceAPiece(e.X, e.Y, nextType);
            if(piece != null)
            {
                this.Controls.Add(piece);

                if (nextType == PieceType.Black)
                {
                    nextType = PieceType.White;

                    return;
                }

                if (nextType == PieceType.White)
                {
                    nextType = PieceType.Black;
                }
            }
        }

        /// <summary>
        /// 滑鼠移動事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            } else
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
