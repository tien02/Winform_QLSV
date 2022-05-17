using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLSV_Winform_App
{
    public partial class Form1 : Form
    {

        string conStr = "Server=DESKTOP-GTJ76OT\\SQLEXPRESS;Database=LOP;Trusted_Connection=True;";
        private SqlConnection con;
        private SqlDataAdapter adapter;
        private SqlCommand command;
        private DataSet ds;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Show(object sender, EventArgs e)
        {
            string sqlStr = "SELECT * FROM TENLOP";
            adapter = new SqlDataAdapter(sqlStr, con);

            ds = new DataSet();
            adapter.Fill(ds, "TENLOP");
            dt = ds.Tables["TENLOP"];

            dgvLop.AutoGenerateColumns = false;
            dgvLop.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conStr);
            con.Open();

            Show(sender, e);

            con.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (textBoxMaLop.Text == "" || textBoxMaLop.Text == null || txtTenLop.Text == "" || txtTenLop.Text == null)
            {
                MessageBox.Show("Khung đang trống, hãy chắc chắn rằng cả 2 khung đã được điền đầy đủ");
            }
            else
            {
                string queryString = "INSERT INTO TENLOP (MALOP,TENLOP) VALUES ('" + textBoxMaLop.Text + "', '" + txtTenLop.Text + "')";
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                Show(sender, e);
                textBoxMaLop.Text = "";
                txtTenLop.Text = "";
            }
        }

        private void dgvLop_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            textBoxMaLop.Text = dt.Rows[row]["MaLop"].ToString();
            txtTenLop.Text = dt.Rows[row]["TenLop"].ToString();
        }

        private void textBoxMaLop_TextChanged(object sender, EventArgs e)
        {

        }

        //private void buttonSua_Click(object sender, EventArgs e)
        //{
        //    if (textBoxMaLop.Text == "" || textBoxMaLop.Text == null || txtTenLop.Text == "" || txtTenLop.Text == null)
        //    {
        //        MessageBox.Show("Khung đang trống, hãy chắc chắn rằng cả 2 khung đã được điền đầy đủ");
        //    }
        //    else
        //    {
        //        string queryString = "UPDATE TENLOP SET  ('" + textBoxMaLop.Text + "', '" + txtTenLop.Text + "')";
        //        using (SqlConnection connection = new SqlConnection(conStr))
        //        {
        //            SqlCommand command = new SqlCommand(queryString, connection);
        //            command.Connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //        Show(sender, e);
        //        textBoxMaLop.Text = "";
        //        txtTenLop.Text = "";
        //    }
        //}
    }
}
