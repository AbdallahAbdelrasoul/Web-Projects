using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AccApp
{
    public partial class Form1 : Form
    {
        private static SqlCon sqlCon = new SqlCon();
        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = sqlCon.CreateConnection();
            get_nashat();
            get_RakmElkead();
        }

        private void get_RakmElkead()
        {
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 1 [رقم القيد] FROM Table_2" +
                                    " ORDER BY[رقم القيد] DESC; ";
                cmd.ExecuteNonQuery();
                con.Close();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable: dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox1.Text = (int.Parse( ( dr["رقم القيد"].ToString()) ) + 1 ).ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // تم 
        {
            if (!checkBalanc())
            {
                MessageBox.Show("!الإجمالي غير متساوي");
            }
            else if (!validateForm())
            {
                MessageBox.Show("!من فضلك تأكد من إدخال البيانات");
            }
            else
            {
                writeToDaily_table();
                resetForm();
                get_RakmElkead();
            }
        }

        private bool validateForm()
        {
            if(comboBox1.SelectedItem == null || comboBox3.SelectedItem == null 
                || textBox1.Text == "" || textBox3.Text == "")
            {
                return false;
            }
            else
            {
                return true; 
            }
        }

        private void writeToDaily_table()
        {
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [Table_2]" +
                    "([يوم],[شهر],[عام],[رقم القيد],[رقم اذن الصرف],[رقم اذن التوريد],[رقم الشيك],[شرح القيد],[الإجمالي])" +
                    "values('"+ dateTimePicker1.Value.Day.ToString()
                    + "','" + dateTimePicker1.Value.Month.ToString()
                    + "','" + dateTimePicker1.Value.Year.ToString()
                    + "','" + textBox1.Text /* رقم القيد */
                    + "','" + textBox2.Text /* رقم اذن الصرف */
                    + "','" + textBox4.Text /* رقم اذن التوريد */
                    + "','" + textBox5.Text /* رقم الشيك */
                    + "','" + textBox3.Text /* شرح القيد */
                    + "','" + KeadSum.ToString() /* الإجمالي */
                    + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                avoidNull();
                int exist = 1;
                string maden, daaen, maden_v, daaen_v = "";  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    maden_v = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    daaen_v = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    maden = dataGridView1.Rows[i].Cells[2].Value.ToString() + " مدين";
                    daaen = dataGridView1.Rows[i].Cells[3].Value.ToString() + " دائن";

                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() != "")
                    {
                        exist = checkIfExist(maden);
                       //MessageBox.Show("المدين موجود ؟ " + exist);

                        if (exist == 0)
                        {
                            insertHesab(dataGridView1.Rows[i].Cells[2].Value.ToString());
                            insertValue(maden_v, maden );
                        }
                        else if (exist > 0)
                        {
                            insertValue(maden_v, maden );
                        }
                        else
                        {
                            MessageBox.Show(" maden Error ");
                        }
                    }
                    else // دائن
                    {
                        exist = checkIfExist(daaen);
                        //MessageBox.Show("الدائن موجود ؟ " + exist);

                        if (exist == 0)
                        {
                            insertHesab(dataGridView1.Rows[i].Cells[3].Value.ToString()); 
                            insertValue(daaen_v, daaen);
                        }
                        else if (exist > 0)
                        {
                            insertValue(daaen_v, daaen);
                        }
                        else
                        {
                            MessageBox.Show(" da2en Error " );
                        }
                    }
                    
                }
                MessageBox.Show("تم تسجيل القيد بنجاح");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private int checkIfExist(string hesab)
        {
            int exist = -1; 
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "check_col";
                cmd.Parameters.AddWithValue("@Name", hesab);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@num_of_rows";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);
            
                cmd.ExecuteNonQuery();
                exist = int.Parse(outputParameter.Value.ToString());
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return exist;

        }

        private void insertHesab(string hesba)
        {
            try
            {
                string maden = hesba + " مدين";
                string daaen = hesba + " دائن";
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "alter table [Table_2] add [" + daaen + "] nvarchar(50) default NULL " +
                    "alter table [Table_2] add [" + maden + "] nvarchar(50) default NULL ";
                cmd.ExecuteNonQuery();
                con.Close();

               // MessageBox.Show("تمت اضافة الحساب كمدين ومدان");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void insertValue(string val , string hesab)
        {
            try
            {
                con = sqlCon.IsConnection(con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update [Table_2] " +
                    "set [" + hesab + "] ='" + val + "' " +
                    "where [رقم القيد] = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void avoidNull()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "";
                    }
                    if (dataGridView1.Rows[i].Cells[1].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[1].Value = "";
                    }
                    if (dataGridView1.Rows[i].Cells[2].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "";
                    }
                    if (dataGridView1.Rows[i].Cells[3].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[3].Value = "";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void resetForm()
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                KeadSum = 0; 
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public float KeadSum = 0;
        private bool checkBalanc()
        {
            bool valid = false;
            try
            {
                float sum1 = 0, sum2 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if(dataGridView1.Rows[i].Cells[2].Value != null && dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        sum1 += float.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    }
                    else
                    {
                        sum2 += float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                    
                }

                if (sum1 == sum2 && sum1 > 0 )
                {
                    valid = true;
                    KeadSum = sum1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return valid;
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
                cmd.CommandText = "select حساب from Table_1 where نشاط =N'" + comboBox1.SelectedItem.ToString()+"'";
                cmd.ExecuteNonQuery();
                con.Close();

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dataTable: dt);
                comboBox3.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox3.Items.Add(dr["حساب"].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                Rectangle r3 = dataGridView1.GetCellDisplayRectangle(3, -1, true);
                int w2 = dataGridView1.GetCellDisplayRectangle(2, -1, true).Width;
                r3.X += 1;
                r3.Y += 1;
                r3.Width = r3.Width + w2 - 2;
                r3.Height = r3.Height / 2 - 4;

                e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r3);
                e.Graphics.DrawString("البيان", dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r3, format);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                Rectangle rtHeader = dataGridView1.DisplayRectangle;
                rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
                dataGridView1.Invalidate(rtHeader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                Rectangle rtHeader = dataGridView1.DisplayRectangle;
                rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
                dataGridView1.Invalidate(rtHeader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 && e.ColumnIndex > -1)
                {
                    Rectangle r2 = e.CellBounds;
                    r2.Y += e.CellBounds.Height / 2;
                    r2.Height = e.CellBounds.Height / 2;
                    e.PaintBackground(r2, true);
                    e.PaintContent(r2);
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // اضافة حساب للجدول
        {
            try
            {
                if (comboBox3.SelectedItem != null)
                {
                    int n = dataGridView1.Rows.Add();

                    if (radioButton1.Checked == true)
                    {
                        dataGridView1.Rows[n].Cells[2].Value = comboBox3.SelectedItem.ToString();
                        dataGridView1.Rows[n].Cells[1].ReadOnly = true;
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        dataGridView1.Rows[n].Cells[3].Value = comboBox3.SelectedItem.ToString();
                        dataGridView1.Rows[n].Cells[0].ReadOnly = true;
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightBlue;
                    }

                }
                else
                {
                    MessageBox.Show("! من فضلك ادخل الحساب");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void رصيدالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void القوائمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_RakmElkead();
        }
    }
}
