using QuanLyTour.BUS;
using QuanLyTour.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTour.GUI
{
    public partial class Gia : Form
    {
        List<GiaBUS> list;
        public Gia(TourBUS tour)
        {
            InitializeComponent();
            this.list =GiaDAO.getGiaByTour(tour);
        }

        private void Gia_Load(object sender, EventArgs e)
        {
            grid_gia.DataSource = list;
        }
    }
}
