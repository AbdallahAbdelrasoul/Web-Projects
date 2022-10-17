using DGVPrinterHelper;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccApp
{
    /// <page can be>
    /// 28 rows without the header
    /// </summary>
    public partial class Form3 : Form
    {
        string prev_right = "" , prev_left = "" ;
        public Form3()
        {
            InitializeComponent();
            advancedDataGridView1.EnableHeadersVisualStyles = false;
            advancedDataGridView1.Visible = false;
    
            foreach( Button b in this.Controls.OfType<Button>())
            {
                b.Visible = false;
            }
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        
        private int fill_rows(int n)
        {
            while ( n < 29)
            {
               n = advancedDataGridView1.Rows.Add();
               advancedDataGridView1.Rows[n].Cells[2].Value = " ";
            }
            return n; 
        }

        private int get_sum(int c , int r1, int r2)
        {
            int sum = 0;
            for(int i = r1; i < r2; i++)
            {
                string val;
                if (advancedDataGridView1.Rows[i].Cells[c].Value != null)
                {
                    val = advancedDataGridView1.Rows[i].Cells[c].Value.ToString();
                    sum += int.Parse(val);
                }
            }
            return sum; 
        }

        /// <summary> الجمعية ومراكزها
        /// مقبوضات ومدفوعات
        /// </summary>
        private void الجمعيةومشاريعهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = "الجمعية ومشاريعها";
        }
        private void المقبوضاتوالمدفوعات1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button1);
            TLPanel1.Controls.Add(button2);
            TLPanel1.Controls.Add(button3);
            TLPanel1.Controls.Add(button4);
            label1.Text = "المقبوضات والمدفوعات من 1/1/2020 إلى 31/12/2020";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_1();
            label2.Text = "1";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_1();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_2();
            label2.Text = "2";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_1();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_2();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_3();
            label2.Text = "3";

        }
        private void button4_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_1();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_2();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_3();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_4();
            label2.Text = "4";

        }

        private void FillDataGrid_1()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "رصيد أول المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصندوق";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ البنوك";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ بنك الجمعية";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ بنك الصيدلية";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ المصرف المتحد";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ شهادات الأستثمار";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات المركز الرئيسي";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات المركز الرئيسي";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "السيارة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مسجد عثمان";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مسجد مجد الإسلام";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اشتراكات الاعضاء";
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. السيارة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حق انتفاع النظارات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "تبرع عيني";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مرتبات وأجور";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد محضارات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "تأمينات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد دار المناسبات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. مياه ونور وتليفون";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التبرعات النقدية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "اعانات ثابته";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "عائد الحساب الجاري";
            advancedDataGridView1.Rows[n].Cells[5].Value = "اعانات متغيرة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "إشتراك مقابر";
            advancedDataGridView1.Rows[n].Cells[5].Value = "زكاة رمضان";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايجارات محصلة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيانة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المدينين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المدينين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الدائنين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الدائنين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المخزن";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المخزن";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23);

            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[5].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }
        private void FillDataGrid_2()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[0].Value = prev_right;
            
            advancedDataGridView1.Rows[n].Cells[5].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[3].Value = prev_left;
            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات المستشفى";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات المستشفى";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التبرعات العينية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مصروفات الرنين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد الرنين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مصروفات المقطعية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد المقطعية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مستلزمات طبيه";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد العيادات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. الأطباء";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "عائد شهادات الاستثمار";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مرتبات العاملين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المدينين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "التأمينات";
            
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. رسم المخ";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيانة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. مياة ونور";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "مطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. أمن وحراسة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "أجهزة طبية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الأثاث";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "أجهزة كهربائية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "العدد الأدوات";
            
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المدينين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 1);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات الصيدلية";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات الصيدلية";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المبيعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المشتريات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "خصم نقدي";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المرتيات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيانة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. مياة ونور";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 6000;// get_sum(4, 1,6);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[5].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }
        private void FillDataGrid_3()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[0].Value = prev_right;

            advancedDataGridView1.Rows[n].Cells[5].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[3].Value = prev_left;
            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
            
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات العلاج الطبيعي";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات العلاج الطبيعي";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد العلاج الطبيعي";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مكافأة الأطباء";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "مرتبات العاملين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيانة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 6000;// get_sum(4, 1,6);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "العدد والالات";
            advancedDataGridView1.Rows[n].Cells[3].Value = "2644";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات المشغل";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات المشغل";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مبيعات المشغل";
            advancedDataGridView1.Rows[n].Cells[5].Value = "خامات المشغل";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "تفصيل خارجي";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مستلزمات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المرتبات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "التأمينات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 6000;// get_sum(4, 1,6);

            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات حضانة عثمان";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات حضانة عثمان";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اشتراكات الأطفال";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المرتبات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. غاز";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 6000;// get_sum(4, 1,6);


            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[5].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }
        private void FillDataGrid_4()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[0].Value = prev_right;

            advancedDataGridView1.Rows[n].Cells[5].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[3].Value = prev_left;
            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات ح.مجد الإسلام";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات ح.مجد الإسلام";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اشتراكات الأطفال";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المرتبات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "التأمينات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 6000;// get_sum(4, 1,6);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الاثاث";
            advancedDataGridView1.Rows[n].Cells[3].Value = "300";

            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مقبوضات م الثقافي الديني";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مدفوعات م الثقافي الديني";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد المساجد";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مصروفات المساجد";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد الدعوة والقراءات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مصروفات دعوة وقراءات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 6000;// get_sum(1, 1,6);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 6000;// get_sum(4, 1,6);

            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "ارصدة اخر المدة";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصندوق";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "حـ/ بنك الجمعية";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "حـ/ بنك الصيدلية";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "حـ/ المصرف المتحد";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 6000;// get_sum(4, 1,6);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();

            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }

        /// <summary> الجمعية ومراكزها
        /// ايرادات ومصروفات
        /// </summary>

        private void الايراداتوالمصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button5);
            TLPanel1.Controls.Add(button6);
            TLPanel1.Controls.Add(button7);

            label1.Text = "الايرادات والمصروفات من 1/1/2020 إلى 31/12/2020";

        }

        private void FillDataGrid_5()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات المركز الرئيسي";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات المركز الرئيسي";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مسجد عثمان";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد السيارة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مسجد مجد الإسلام";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "السيارة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "اشتراكات الاعضاء";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "التبرعات النقدية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مرتبات وأجور";
            advancedDataGridView1.Rows[n].Cells[5].Value = "حق انتفاع النظارات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "تأمينات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "تبرع عيني";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. مياه ونور وتليفون";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد محاضرات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اعانات ثابته";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد دار المناسبات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اعانات متغيرة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "عائد الحساب الجاري";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "زكاة رمضان";
            advancedDataGridView1.Rows[n].Cells[5].Value = "إشتراك مقابر";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصيانة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايجارات محصلة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المطبوعات";
            
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات المستشفى";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات المستشفى";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات الرنين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "التبرعات العينية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات المقطعية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد الرنين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مستلزمات طبية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد المقطعية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد العيادات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصيانة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. مياة ونور";
            advancedDataGridView1.Rows[n].Cells[5].Value = "عائد شهادات الاستثمار";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اجور الأطباء";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مرتبات العاملين";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التأمينات";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. رسم المخ";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. أمن وحراسة";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[5].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }
        private void FillDataGrid_6()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[0].Value = prev_right;

            advancedDataGridView1.Rows[n].Cells[5].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[3].Value = prev_left;
            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات علاج طبيعي";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات علاج طبيعي";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مكافأة الأطباء";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد العلاج الطبيعي";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مرتبات العاملين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصيانة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);
            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات حضانة عمان";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات حضانة عثمان";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المرتبات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "اشتراكات الأطفال";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. غاز";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);
            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات حـ/ مجد الإسلام";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات حـ/ مجد الإسلام";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المرتبات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "اشتراكات الأطفال";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التأمينات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);
            n = advancedDataGridView1.Rows.Add();

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[5].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }
        private void FillDataGrid_7()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[0].Value = prev_right;

            advancedDataGridView1.Rows[n].Cells[5].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[3].Value = prev_left;
            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات م الثقافي الديني";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات م الثقافي الديني";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات المساجد";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد المساجد";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات الدعوة والقاراءات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد الدعوة والقاراءات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);
            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاستهلاكات";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. مباني";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أثاث";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. سيارة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. الات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. الة تصوير";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. المفروشات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أجهزة كهربائية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أجهزة طبية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أجهزة كمبيوتر";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "فائض العام الحالي";
            advancedDataGridView1.Rows[n].Cells[0].Value = "7500356";

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_5();
            label2.Text = "5";

        }
        private void button6_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_5();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_6();
            label2.Text = "6";

        }
        private void button7_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_5();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_6();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_7();
            label2.Text = "7";

        }

        /// <summary> الجمعية ومراكزها
        /// المتاجرة
        /// </summary>
        private void FillDataGrid_8()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "بضاعة اول المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصيدلية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المشغل";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مشتريات العام";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "مبيعات العام";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصيدلية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيدلية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المشغل";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المشغل";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 2600; //get_sum(3, 9, 23);

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "بضاعة اخر المدة";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيدلية";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المشغل";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 1500; //get_sum(1 , 9,23

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مجمل الربح";
            advancedDataGridView1.Rows[n].Cells[0].Value = "1657726";

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();

            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }
        private void المتاجرةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button8.Visible = true;
            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button8);

            label1.Text = "المتاجرة من 1 / 1 / 2020 إلى 31 / 12 / 2020";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_8();
            label2.Text = "8";

        }

        /// <summary> الجمعية ومراكزها
        /// ارباح وخسائر
        /// </summary>
        /// 
        private void button9_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_9();
            label2.Text = "9";

        }
        private void FillDataGrid_9()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "مجمل الربح";
            advancedDataGridView1.Rows[n].Cells[3].Value = "1657726";

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات الصيدلية";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات الصيدلية";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المرتبات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "خصم نقدي";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المطبوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. مياة ونور";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصيانة";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 1500; //get_sum(1 , 9,23

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات المشغل";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات المشغل";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المرتبات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "تفصيل خارجي";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التأمينات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = 1500; //get_sum(1 , 9,23

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاستهلاكات";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. الات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. اثاث";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. مباني";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = 1500; //get_sum(1 , 9,23

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "فائض الفتره الحالية";
            advancedDataGridView1.Rows[n].Cells[0].Value = "1258971";


            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }
        private void أرباحوخسائرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button9.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button9);

            label1.Text = "الأرباح والخسائر من 1 / 1 / 2020 إلى 31 / 12 / 2020";

        }

        /// <summary> الجمعية ومراكزها
        /// الميزانية العمومية
        /// </summary> 
        private void الميزانيةالعموميةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button10.Visible = true;
            button11.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button10);
            TLPanel1.Controls.Add(button11);

            label1.Text = "الميزانية العمومية في 31 / 12 / 2020";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_10();
            label2.Text = "10";
        }
        private void FillDataGrid_10()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أراضي الجمعية";
            advancedDataGridView1.Rows[n].Cells[0].Value = "13463";
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض الأعوام السابقة";
            advancedDataGridView1.Rows[n].Cells[4].Value = "66232604";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض العام الحالي";
            advancedDataGridView1.Rows[n].Cells[4].Value = "8759327";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مباني";
            advancedDataGridView1.Rows[n].Cells[1].Value = "14903957";
            advancedDataGridView1.Rows[n].Cells[3].Value = 
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[4].Value.ToString())
                + int.Parse(advancedDataGridView1.Rows[n - 1].Cells[4].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "رأس مال الصيدلية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "5080";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 2 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n-1].Cells[1].Value.ToString()) * 2)/100, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = advancedDataGridView1.Rows[n - 1].Cells[4].Value;
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الأثاث";
            advancedDataGridView1.Rows[n].Cells[1].Value = "471397";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاضافات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "3695";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = 
                int.Parse(advancedDataGridView1.Rows[n-2].Cells[1].Value.ToString())
                + int.Parse(advancedDataGridView1.Rows[n-1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[1].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[5].Value = "الدائنين";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المركز الرئيسي";
            advancedDataGridView1.Rows[n].Cells[4].Value = "55342";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[5].Value = "المستشفى";
            advancedDataGridView1.Rows[n].Cells[4].Value = "5500";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "السيارة";
            advancedDataGridView1.Rows[n].Cells[1].Value = "74532";
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n-2, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10%";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = 
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "عدد والات ومعدات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "392170";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاضافات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "14230";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[1].Value = get_sum(1, n-2, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الة تصوير";
            advancedDataGridView1.Rows[n].Cells[1].Value = "3580";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المفروشات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "25855";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 25%";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 25) /100, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                  int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                  - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;


            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[5].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }
            
        private void button11_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_10();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_11();
            label2.Text = "11";
        }
        private void FillDataGrid_11()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[0].Value = prev_right;

            advancedDataGridView1.Rows[n].Cells[5].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[3].Value = prev_left;
            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجهزة طبية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "12455316";
           
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاضافات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "1069640";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                + int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[1].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجهزة كهربائية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "157041";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاضافات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "81800";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                + int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[1].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10%";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجهزة كمبيوتر";
            advancedDataGridView1.Rows[n].Cells[1].Value = "16216";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 25%";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) *25 / 100, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المدينين";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المستشفى";
            advancedDataGridView1.Rows[n].Cells[1].Value = "427173";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = advancedDataGridView1.Rows[n-1].Cells[1].Value;
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "بضاعة اخر المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المركز الرئيسي";
            advancedDataGridView1.Rows[n].Cells[1].Value = "955293";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصيدلية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "534980";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المشغل";
            advancedDataGridView1.Rows[n].Cells[1].Value = "28630";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 3, n);
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "النقدية";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصندوق";
            advancedDataGridView1.Rows[n].Cells[1].Value = "89226";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ بنك الجمعية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "42989614";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ بنك الصيدلية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "530354";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ المصرف المتحد";
            advancedDataGridView1.Rows[n].Cells[1].Value = "1600627";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 4, n);
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }

        /// <summary> المركز الرئيسي  
        /// المدفوعات والمقبوضات
        /// </summary> 
        private void المركزالرئيسيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = "المركز الرئيسي";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_12();
            label2.Text = "12";

        }
        private void FillDataGrid_12()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "رصيد أول المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ الصندوق";
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ البنوك";
            
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n-2,n);
            
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد السيارة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مسجد عثمان";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مسجد مجد الإسلام";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اشتراكات الاعضاء";
            advancedDataGridView1.Rows[n].Cells[5].Value = "السيارة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حق انتفاع النظارات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايجارات محصلة";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مرتبات وأجور";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد محضارات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "تأمينات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد دار المناسبات";
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. مياه ونور وتليفون";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التبرعات النقدية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "اعانات ثابته";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التبرعات العينية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "اعانات متغيرة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "عائد الحساب الجاري";
            advancedDataGridView1.Rows[n].Cells[5].Value = "زكاة رمضان";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "إشتراك مقابر";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيانة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 12, n);

            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 12, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المدينين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المدينين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الدائنين";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الدائنين";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المخزن";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المخزن";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ تمويل الجمعية";
            advancedDataGridView1.Rows[n].Cells[5].Value = "حـ/ تمويل الجمعية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 4, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 4, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "رصيد اخر المدة";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصندوق";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "البنك";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 2, n);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }
        private void المقبوضاتوالمدفوعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button12.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button12);

            label1.Text = "المقبوضات والمدفوعات من 1/1/2020 إلى 31/12/2020";
        }

        /// <summary> المركز الرئيسي
        /// ايرادات ومصروفات
        /// </summary>
        private void الايراداتوالمصروفاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button13.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button13);

            label1.Text = "الايرادات والمصروفات من 1/1/2020 إلى 31/12/2020";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_13();
            label2.Text = "13";

        }
        private void FillDataGrid_13()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مصروفات الجمعية";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايرادات الجمعية";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاستهلاكات";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. مباني";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أثاث";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. سيارة";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س.عدد والات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. الة تصوير";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. المفروشات";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أجهزة كهربائية";
            
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 7, n);

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "فائض العام الحالي";
            advancedDataGridView1.Rows[n].Cells[0].Value = "7500356";

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }

        /// <summary> المركز الرئيسي
        /// الميزانية العمومية
        /// </summary>
        private void button14_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_14();
            label2.Text = "14";
        }
        private void الميزانيةالعموميةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button14.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button14);

            label1.Text = "الميزانية العمومية في 31 / 12 / 2020";
        }
        private void FillDataGrid_14()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أراضي الجمعية";
            advancedDataGridView1.Rows[n].Cells[0].Value = "13463";
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض الأعوام السابقة";
            advancedDataGridView1.Rows[n].Cells[4].Value = "732147";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض العام الحالي";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1313778";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مباني";
            advancedDataGridView1.Rows[n].Cells[1].Value = "2869025";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n-2 , n );
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 2 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 2) / 100, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الأثاث";
            advancedDataGridView1.Rows[n].Cells[1].Value = "124086";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الدائنين";
            advancedDataGridView1.Rows[n].Cells[4].Value = "55342";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[3].Value = advancedDataGridView1.Rows[n - 1].Cells[4].Value;
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "السيارات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "74532";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10%";
            advancedDataGridView1.Rows[n].Cells[1].Value =
                int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10;
            advancedDataGridView1.Rows[n].Cells[5].Value = "تمويل الجمعية للمشاريع";
            advancedDataGridView1.Rows[n].Cells[4].Value = "44952604";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[3].Value = advancedDataGridView1.Rows[n - 1].Cells[4].Value;
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "عدد والات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "2709";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10), MidpointRounding.AwayFromZero);


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الة تصوير";
            advancedDataGridView1.Rows[n].Cells[1].Value = "1475";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[1].Value =
                int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المفروشات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "13488";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 25%";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 25) / 100, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                  int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                  - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجهزة كهربائية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "2215";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10%";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 1 / 10,MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                  int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                  - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المخزن";
            advancedDataGridView1.Rows[n].Cells[1].Value = "955293";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = advancedDataGridView1.Rows[n - 1].Cells[1].Value;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الصندوق";
            advancedDataGridView1.Rows[n].Cells[1].Value = "89226";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ بنك الجمعية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "42989614";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 2, n);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }
        
        /// <summary> المستشفى  
        /// المدفوعات والمقبوضات
        /// </summary> 
        private void المستشفىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = "المستشفى";
        }
        private void المقبوضاتوالمدفوعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button15.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button15);

            label1.Text = "المقبوضات والمدفوعات من 1/1/2020 إلى 31/12/2020";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_15();
            label2.Text = "15";
        }
        private void FillDataGrid_15()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "رصيد أول المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "897000";
            advancedDataGridView1.Rows[n].Cells[2].Value = "شهادات الاستثمار";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "596084";
            advancedDataGridView1.Rows[n].Cells[2].Value = "المصرف المتحد";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "31001609";
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ تمويل الجمعية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n -3, n);
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. الأطباء";
            advancedDataGridView1.Rows[n].Cells[4].Value = "9324457";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "عائد شهادات الاستثمار";
            advancedDataGridView1.Rows[n].Cells[1].Value = "107543";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مرتبات العاملين";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1351276";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "التأمينات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "101906";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 3, n); ;
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 3, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. رسم المخ";
            advancedDataGridView1.Rows[n].Cells[4].Value = "223428";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "التبرعات العينية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "9590";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مصروفات الرنين";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1198155";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد الرنين";
            advancedDataGridView1.Rows[n].Cells[1].Value = "9429803";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مصروفات المقطعية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "337392";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد المقطعية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "2890312";
            advancedDataGridView1.Rows[n].Cells[5].Value = "مستلزمات طبية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1857064";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ايراد العيادات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "14722263";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "951127";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "284877";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الصيانة";
            advancedDataGridView1.Rows[n].Cells[4].Value = "3053162";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. مياة ونور";
            advancedDataGridView1.Rows[n].Cells[4].Value = "918356";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "مطبوعات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "148177";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. أمن وحراسة";
            advancedDataGridView1.Rows[n].Cells[4].Value = "141382";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 9, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 9, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المدينين";
            advancedDataGridView1.Rows[n].Cells[1].Value = "1220265";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المدينين";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1555026";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 1, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 1, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "أجهزة طبية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1069640";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "الأثاث";
            advancedDataGridView1.Rows[n].Cells[4].Value = "3395";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "أجهزة كهربائية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "81800";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "العدد والالات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "11586";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 4, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "رصيد اخر المدة";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المصرف المتحد";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1600627";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "حـ/ تمويل الجمعية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "37231390";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 2, n);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }

        /// <summary> المستشفى  
        ///  ايرادات ومصروفات
        /// </summary>
        private void الايراداتوالمصروفاتToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button16.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button16);

            label1.Text = "الايرادات والمصروفات من 1/1/2020 إلى 31/12/2020";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_16();
            label2.Text = "16";
        }
        private void FillDataGrid_16()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجور وتأمينات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "1453182";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد الرنين";
            advancedDataGridView1.Rows[n].Cells[4].Value = "9429803";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. عمومية ةإدارية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "8828243";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد المقطعية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "2890312";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجور الأطباء";
            advancedDataGridView1.Rows[n].Cells[1].Value = "9324457";
            advancedDataGridView1.Rows[n].Cells[5].Value = "ايراد العيادات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "14722263";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "284877";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "عائد شهادات الاستثمار";
            advancedDataGridView1.Rows[n].Cells[4].Value = "107543";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "التبرعات العينية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "9590";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 6, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 6, n);

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاستهلاكات";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "228063";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. مباني";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "28039";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أثاث";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "1325569";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أجهزة طبية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "3092";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. المفروشات";


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "39677";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س.عدد والات";
        

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "210";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. الة تصوير";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "3751";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أجهزة كمبيوتر";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "23566";
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. أجهزة كهربائية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 8, n);

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "فائض العام الحالي";
            advancedDataGridView1.Rows[n].Cells[0].Value = "6186539";

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }


        /// <summary> المستشفى  
        /// الميزانية العمومية
        /// </summary>
        private void button17_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_17();
            label2.Text = "17" ;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_17();
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_18();
            label2.Text = "18";
        }
        private void الميزانيةالعموميةToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button17.Visible = true;
            button18.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button17);
            TLPanel1.Controls.Add(button18);

            label1.Text = "الميزانية العمومية في 31 / 12 / 2020";
        }
        private void FillDataGrid_17()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مباني و إنشاءات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "11403150";
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض الأعوام السابقة";
            advancedDataGridView1.Rows[n].Cells[4].Value = "57016326";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض العام الحالي";
            advancedDataGridView1.Rows[n].Cells[4].Value = "6186539";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = get_sum(1, n - 2, n);
            advancedDataGridView1.Rows[n].Cells[1].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 2, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 2 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 2) / 100, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الأثاث";
            advancedDataGridView1.Rows[n].Cells[1].Value = "276994";
            advancedDataGridView1.Rows[n].Cells[5].Value = "الدائنين";
            advancedDataGridView1.Rows[n].Cells[3].Value = "5500";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اضافات العام";
            advancedDataGridView1.Rows[n].Cells[1].Value = "3395";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = get_sum(1, n - 2, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجهزة طبية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "12186055";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اضافات العام";
            advancedDataGridView1.Rows[n].Cells[1].Value = "1069640";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = get_sum(1, n - 2, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المفروشات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "12367";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 25 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 0.25), MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "عدد والات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "385185";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اضافات العام";
            advancedDataGridView1.Rows[n].Cells[1].Value = "11586";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = get_sum(1, n - 2, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10), MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الة تصوير";
            advancedDataGridView1.Rows[n].Cells[1].Value = "2105";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10), MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            
            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[5].Value = "ما بعده";
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }
        private void FillDataGrid_18()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[0].Value = prev_right;

            advancedDataGridView1.Rows[n].Cells[5].Value = "ما قبله";
            advancedDataGridView1.Rows[n].Cells[3].Value = prev_left;
            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجهزة كمبيوتر";
            advancedDataGridView1.Rows[n].Cells[1].Value = "15003";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) *0.25, MidpointRounding.AwayFromZero);
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 25 %";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "أجهزة كهربائية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "153862";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "اضافات العام";
            advancedDataGridView1.Rows[n].Cells[1].Value = "81800";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                + int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[1].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10%";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) / 10, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المدينين";
            advancedDataGridView1.Rows[n].Cells[0].Value = "427173";
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ تمويل الجمعية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "37231390";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المصرف المتحد";
            advancedDataGridView1.Rows[n].Cells[1].Value = "1600627";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 2, n);
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }


        /// <summary> الصيدلية
        /// المدفوعات والمقبوضات
        /// </summary>
        private void الصيدليةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label3.Text = "الصيدلية";
        }
        private void button19_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_19();
            label2.Text = "19";
        }
        private void المقبوضاتوالمدفوعاتToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button19.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button19);

            label1.Text = "المقبوضات والمدفوعات من 1/1/2020 إلى 31/12/2020";
        }
        private void FillDataGrid_19()
        {

            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "رصيد أول المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "7815205";
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ تمويل الجمعية";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[1].Value = "500274";
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ البنك";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 2, n);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المبيعات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "6399885";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المشتريات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "4902104";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 1, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 1, n);


            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "2253";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المرتبات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "303557";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "خصم نقدي";
            advancedDataGridView1.Rows[n].Cells[1].Value = "190919";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المرتبات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "530";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المطبوعات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "55";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "139502";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "م. مياة ونور";
            advancedDataGridView1.Rows[n].Cells[4].Value = "114091";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 5, n); ;
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 5, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "رصيد اخر المدة";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "حـ/ تمويل الجمعية";
            advancedDataGridView1.Rows[n].Cells[4].Value = "8918343";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "حـ/ البنك";
            advancedDataGridView1.Rows[n].Cells[4].Value = "530354";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 2, n);

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();

            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }

        /// <summary> الصيدلية
        /// المتـــاجرة
        /// </summary>
        private void المتاجرةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button20.Visible = true;
            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button20);

            label1.Text = "المتاجرة من 1 / 1 / 2020 إلى 31 / 12 / 2020";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_20();
            label2.Text = "20";
        }
        private void FillDataGrid_20()
        {

            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "بضاعة اول المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;
            advancedDataGridView1.Rows[n].Cells[0].Value = "414558";

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "المشتريات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "4902104";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المبيعات";
            advancedDataGridView1.Rows[n].Cells[3].Value = "6399885";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 1, n);

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[3].Value = "534980";
            advancedDataGridView1.Rows[n].Cells[5].Value = "بضاعة اخر المدة";
            advancedDataGridView1.Rows[n].Cells[5].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مجمل الربح";
            advancedDataGridView1.Rows[n].Cells[0].Value = "1618203";

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();

            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }
        
        /// <summary> الصيدلية
        /// ارباح وخسائر
        ///
        private void button21_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_21();
            label2.Text = "21";
        }
        private void الأرباحوالخسائرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button21.Visible = true;

            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button21);

            label1.Text = "الأرباح والخسائر من 1 / 1 / 2020 إلى 31 / 12 / 2020";
        }
        private void FillDataGrid_21()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[5].Value = "مجمل الربح";
            advancedDataGridView1.Rows[n].Cells[3].Value = "1618203";

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مرتبات وتأمينات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "303557";
            advancedDataGridView1.Rows[n].Cells[5].Value = "خصم نقدي";
            advancedDataGridView1.Rows[n].Cells[4].Value = "190919";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "م. عمومية وادارية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "254178";
            advancedDataGridView1.Rows[n].Cells[5].Value = "المتنوعات";
            advancedDataGridView1.Rows[n].Cells[4].Value = "2253";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n-2, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n-2, n);

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الاستهلاكات";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. مباني";
            advancedDataGridView1.Rows[n].Cells[1].Value = "4700";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س. اثاث";
            advancedDataGridView1.Rows[n].Cells[1].Value = "3688";

       
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n-2, n);
            
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "فائض العام الحالي";
            advancedDataGridView1.Rows[n].Cells[0].Value = "1245252";


            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;

        }

        /// <summary> الصيدلية
        /// الميزانيةالعمومية
        ///
        private void الميزانيةالعموميةToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Visible = true;
            button22.Visible = true;
            
            TLPanel1.Controls.Clear();
            TLPanel1.Controls.Add(button22);
            
            label1.Text = "الميزانية العمومية في 31 / 12 / 2020";
        }
        private void button22_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.Rows.Clear();
            advancedDataGridView1.Refresh();
            FillDataGrid_22();
            label2.Text = "22";
        }
        private void FillDataGrid_22()
        {
            int n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "مباني و إنشاءات";
            advancedDataGridView1.Rows[n].Cells[1].Value = "234979";
            advancedDataGridView1.Rows[n].Cells[5].Value = "رأس المال";
            advancedDataGridView1.Rows[n].Cells[3].Value = "5080";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 2 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 2) / 100, MidpointRounding.AwayFromZero);

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                 int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                 - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "الأثاث";
            advancedDataGridView1.Rows[n].Cells[1].Value = "36882";
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض الاعوام السابقه ";
            advancedDataGridView1.Rows[n].Cells[4].Value = "8996818";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "س 10 %";
            advancedDataGridView1.Rows[n].Cells[1].Value = Math.Round(
                (double.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString()) * 10) / 100, MidpointRounding.AwayFromZero);
            advancedDataGridView1.Rows[n].Cells[5].Value = "فائض العام الحالي ";
            advancedDataGridView1.Rows[n].Cells[4].Value = "1245252";
           
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value =
                int.Parse(advancedDataGridView1.Rows[n - 2].Cells[1].Value.ToString())
                - int.Parse(advancedDataGridView1.Rows[n - 1].Cells[1].Value.ToString());
            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(4, n - 2, n);
            advancedDataGridView1.Rows[n].Cells[3].Style.BackColor = Color.LightGreen;

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "بضاعة اخر المدة";
            advancedDataGridView1.Rows[n].Cells[0].Value = "534980";

            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "رصيد اخر المدة";
            advancedDataGridView1.Rows[n].Cells[2].Style.BackColor = Color.LightGray;

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ تمويل الجمعية";
            advancedDataGridView1.Rows[n].Cells[1].Value = "8918343";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[2].Value = "حـ/ البنك";
            advancedDataGridView1.Rows[n].Cells[1].Value = "530354";

            n = advancedDataGridView1.Rows.Add();
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(1, n - 2, n);
            advancedDataGridView1.Rows[n].Cells[0].Style.BackColor = Color.LightGreen;

            n = fill_rows(n);
            advancedDataGridView1.Rows[n].Cells[0].Value = get_sum(0, 0, advancedDataGridView1.RowCount - 2);
            prev_right = advancedDataGridView1.Rows[n].Cells[0].Value.ToString();


            advancedDataGridView1.Rows[n].Cells[3].Value = get_sum(3, 0, advancedDataGridView1.RowCount - 2); ;
            prev_left = advancedDataGridView1.Rows[n].Cells[3].Value.ToString();

            advancedDataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
        }


        // طباعة

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    advancedDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    DGVPrinter printer = new DGVPrinter();
        //    printer.Title = "جمعية مجد الإسلام الخيرية                                                                                  " +
        //        label3.Text+"\nناصية شارع احمد حلمي-ميدان مجد الإسلام\n المسجلة برقم 2062 الساحل";
        //    printer.TitleAlignment = StringAlignment.Far;
        //    printer.TitleBorder = new Pen(Color.Black, 2);
        //    printer.TitleSpacing = 5;
        //    printer.TitleFont = new Font("Simplified Arabic", 16, FontStyle.Bold, GraphicsUnit.Pixel);

        //    printer.SubTitle = label1.Text ;
        //    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
        //    printer.SubTitleAlignment = StringAlignment.Center;
        //    printer.SubTitleBorder = new Pen(Color.Black,1);
        //    printer.SubTitleSpacing = 5;
        //    printer.SubTitleFont = new Font("Simplified Arabic", 16, FontStyle.Bold, GraphicsUnit.Pixel);

        //    // set page number
        //    printer.PageText = label2.Text;
        //    printer.PageNumbers = true;
        //    printer.PageNumberInHeader = true;
        //    printer.PageNumberAlignment = StringAlignment.Center;
        //    printer.PageNumberFont = new Font("Simplified Arabic", 20, FontStyle.Bold, GraphicsUnit.Pixel);

        //    printer.PorportionalColumns = true;
        //    printer.HeaderCellAlignment = StringAlignment.Near;

        //    printer.Footer = "المدير المالي                   المحاسب القانوني                    أمين الصندوق                    رئيس مجلس الإدارة";
        //    printer.FooterSpacing = 0;
        //    printer.FooterAlignment = StringAlignment.Center;
        //    printer.FooterFont = new Font("Simplified Arabic", 16, FontStyle.Bold, GraphicsUnit.Pixel);

        //    printer.PrintDataGridView(advancedDataGridView1);
        //    advancedDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //}

    }
}
