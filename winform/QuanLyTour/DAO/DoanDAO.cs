﻿using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class DoanDAO
    {
        public static List<DoanBUS> getAll()
        {
            List<DoanBUS> list = new List<DoanBUS>();
            String query = "select * from Doan";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DoanBUS doan = new DoanBUS();
                    doan.MaDoan = reader["maDoan"].ToString();
                    doan.TenDoan = reader["tenDoan"].ToString();
                    doan.NgayBatDau = DateTime.Parse(reader["ngayBatDau"].ToString());
                    doan.NgayKetThuc = DateTime.Parse(reader["ngayKetThuc"].ToString());
                    
                    list.Add(doan);
                }
                reader.Close();
                connection.close();
            }
            return list;
        }
    }
}
