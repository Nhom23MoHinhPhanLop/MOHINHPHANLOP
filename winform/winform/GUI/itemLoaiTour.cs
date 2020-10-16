using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform.GUI
{
    public partial class itemLoaiTour : UserControl
    {
        public itemLoaiTour()
        {
            InitializeComponent();
        }
        #region Properties
        private String maloai;
        private String tenloai;

        [Category("Custom Props")]
        public String Maloai
        {
            get { return maloai; }
            set { maloai = value; lbMaloai.Text = value; }
        }

        [Category("Custom Props")]
        public String Tenloai
        {
            get { return tenloai; }
            set { tenloai = value; lbTenloai.Text = value; }
        }

        #endregion

        private void sua_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lbMaloai.Text + lbTenloai.Text);
        }

        private void xoa_Click(object sender, EventArgs e)
        {

        }
    }
}
