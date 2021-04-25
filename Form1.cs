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
        // 遊戲類別
        private Game game;

        public Form1()
        {
            InitializeComponent();
            game = new Game();
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
            BasePiece piece = game.PlaceAPiece(e.X, e.Y);
            if(piece != null)
            {
                this.Controls.Add(piece);

                if(game.Winner == PieceType.Black)
                {
                    MessageBox.Show("黑色贏了");
                }

                if (game.Winner == PieceType.White)
                {
                    MessageBox.Show("白色贏了");
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
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            } else
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
