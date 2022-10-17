using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccApp
{
    public partial class Form2 : Form
    {

        private static SqlCon sqlCon = new SqlCon();
        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
        }

        private void get_Table_2()
        {
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Table_2 " +
                    "Order by CASE ISNUMERIC([رقم القيد]) WHEN 1 THEN [رقم القيد] " +
                    "ELSE CAST(Right([رقم القيد], LEN(0)) AS int) END";
                cmd.ExecuteNonQuery();
                con.Close();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable: dt);

                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = sqlCon.CreateConnection();
            get_nashat();
            get_Table_2();
            get_summation(9);
            get_total();
            dataGridView1.EnableHeadersVisualStyles = false;

        }

        private void get_nashat()
        {
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select DISTINCT نشاط from Table_1";
                cmd.ExecuteNonQuery();
                con.Close();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable: dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add((dr["نشاط"].ToString()));
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e) // Relaod
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            get_Table_2();
            get_summation(9);
            get_total();
        }

        private void get_total()
        {
            float sum = 0;
            for (int r = 0; r < dataGridView1.Rows.Count - 1; r++)
            {
                if (dataGridView1.Rows[r].Cells[8].Value.ToString() != "")
                {
                    sum += float.Parse(dataGridView1.Rows[r].Cells[8].Value.ToString());
                }
            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value = sum.ToString();

        }

        private void get_summation(int colIndex)
        {
            for (int c = colIndex ; c < dataGridView1.ColumnCount; c++)
            {
                float sum = 0;
                for (int r = 0; r < dataGridView1.Rows.Count - 1; r++)
                {
                    if (dataGridView1.Rows[r].Cells[c].Value.ToString() != "")
                    {
                        sum += float.Parse(dataGridView1.Rows[r].Cells[c].Value.ToString());
                    }
                }
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[c].Value = sum.ToString();
            }
            colorCols(colIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getHesab();
        }

        private void getHesab()
        {
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select حساب from Table_1 where نشاط =N'" + comboBox1.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable: dt);
                comboBox2.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["حساب"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)// Hesab Filter
        {
            try
            {
                string hesab_m = comboBox2.SelectedItem.ToString() + " مدين";
                string hesab_d = comboBox2.SelectedItem.ToString() + " دائن";
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select [" + hesab_d + "] , [" + hesab_m + "] from Table_2 " +
                    "Where [" + hesab_d + "] != '' or [" + hesab_m + "] != '' " +
                    "Order by CASE ISNUMERIC([رقم القيد]) WHEN 1 THEN [رقم القيد] " +
                    "ELSE CAST(Right([رقم القيد], LEN(0)) AS int) END";
                cmd.ExecuteNonQuery();
                con.Close();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable: dt);

                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                get_Hesab_summation();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void get_Hesab_summation()
        {
            float sum = 0;
            for (int c = 0; c < dataGridView1.ColumnCount; c++)
            {
                sum = 0;
                for (int r = 0; r < dataGridView1.Rows.Count - 1; r++)
                {
                    if (dataGridView1.Rows[r].Cells[c].Value.ToString() != "")
                    {
                        sum += float.Parse(dataGridView1.Rows[r].Cells[c].Value.ToString());
                    }
                }
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[c].Value = sum.ToString();
                colorCols(0);
            }
        }

        private void MyFilter(string filterString)
        {
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Table_2 where " + filterString;
                cmd.ExecuteNonQuery();
                con.Close();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable: dt);

                dataGridView1.DataSource = dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            MyFilter(dataGridView1.FilterString);
            get_summation(9);
            get_total();
            HesabaOfKead();

        }

        private void HesabaOfKead()
        {
            int r = dataGridView1.RowCount - 1;
            for (int c = 9; c < dataGridView1.ColumnCount; c++)
            {
                if( dataGridView1.Rows[r].Cells[c].Value.ToString() == "0")
                {
                    dataGridView1.Columns[c].Visible = false;
                }
            }
            
        }

        private void colorCols(int colIndex)
        {
            if (dataGridView1.ColumnCount >= 8)// الإجمالي
            {
                dataGridView1.Columns[8].DefaultCellStyle.ForeColor = Color.Green; 
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[8].Style.ForeColor = Color.Green;
            }
            //dataGridView1.EnableHeadersVisualStyles = false;
            for (int c = colIndex; c < dataGridView1.ColumnCount-1; c += 2)// الحساب
            {
                //headers
                //dataGridView1.Columns[c].HeaderCell.AdjustCellBorderStyle; 
                dataGridView1.Columns[c].HeaderCell.Style.BackColor = Color.LightCoral;
                dataGridView1.Columns[c+1].HeaderCell.Style.BackColor = Color.LightBlue;
                //columns
                dataGridView1.Columns[c].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView1.Columns[c + 1].DefaultCellStyle.ForeColor = Color.Blue;
            }
            dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.BackColor = Color.Bisque;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using(XLWorkbook workbook = new XLWorkbook())
                        {
                            dt = (DataTable)dataGridView1.DataSource;
                            workbook.Worksheets.Add(dt , "اليومية الأمريكية");
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("تم النسخ إلى EXcel ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }
    }
}
