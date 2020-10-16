using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform.DTO;

namespace winform.GUI
{
    public partial class trangchu : Form
    {
        public trangchu()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            //Thêm dữ liệu cho loại tour
            List<itemLoaiTour> list = new List<itemLoaiTour>();
            for (int i = 0; i < 20; i++)
            {
                itemLoaiTour item = new itemLoaiTour();
                item.Maloai = "123";
                item.Tenloai = "321";
                panelLoai.Controls.Add(item);
            }

            //Địa điểm
            dataGridViewDiadiem.DataSource = BUS.DiaDiemBUS.getAll();
            
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            
                button.Name = "button";
                button.HeaderText = "Button";
                button.Text = "Button";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.dataGridViewDiadiem.Columns.Add(button);

            //Thêm dữ liệu cho quản lý tour
            gridTour.DataSource = BUS.TourBUS.getAllTour();
            //Dữ liệu cho loại tour
            cbLoaitour.DataSource = BUS.LoaiTourBUS.getAll();
            cbLoaitour.DisplayMember = "tenloai";
            cbLoaitour.ValueMember = "maloai";
            cbLoaitour.SelectedIndex = 0;
            //Dữ liệu cho địa điểm
            foreach (DiaDiemDTO item in BUS.DiaDiemBUS.getAll())
            {
                listDiadiem.Items.Add(item.toString());
            }

        }
        
        private void btnInsertLoai_Click(object sender, EventArgs e)
        {
            ThemLoai them = new ThemLoai();
            them.ShowDialog();
        }

        private void btnThemDiadiem_Click(object sender, EventArgs e)
        {
            ThemLoai them = new ThemLoai();
            them.ShowDialog();
        }

        private void gridTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = sender as DataGridView;
            
            //Lấy mã tour và mã loại từ dòng đang được chọn
            String matour = data.CurrentRow.Cells[0].Value.ToString();
            String tentour= data.CurrentRow.Cells[1].Value.ToString();
            String maloai= data.CurrentRow.Cells[2].Value.ToString();

            //Hiển thị thông tin tour
            txtMatour.Text = matour;
            txtTentour.Text = tentour;
            //loại tour
            cbLoaitour.SelectedValue = maloai;

            //Hiển thị danh sách địa điểm
            foreach (ChiTietTourDTO item in BUS.ChiTietTourBUS.getTourDetailById(matour))
            {
            }

        }
    }
}
