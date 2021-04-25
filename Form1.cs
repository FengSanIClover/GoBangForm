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

        private PieceType nextType = PieceType.Black;

        public Form1()
        {
            InitializeComponent();

            this.MouseDown += MouseDownEvent;
        }

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

    }
}
