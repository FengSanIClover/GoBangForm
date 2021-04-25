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
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new BlackPiece(100, 100));
            this.Controls.Add(new WhitePiece(200, 200));
        }

    }
}
