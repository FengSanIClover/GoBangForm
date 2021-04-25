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
        /// <summary>
        /// 棋子類別列舉
        /// </summary>
        private enum PieceType
        {
            Black = 0,
            White = 1
        }

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
            if(nextType == PieceType.Black) 
            {
                this.Controls.Add(new BlackPiece(e.X, e.Y));
                nextType = PieceType.White;

                return;
            }

            if(nextType == PieceType.White)
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y));
                nextType = PieceType.Black;
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
