using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class frmSoratHesabWM : Form
    {
        public frmSoratHesabWM()
        {
            InitializeComponent();


            cmbcode.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcode.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbcode.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        ////////////
        public string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
        public MessageBoxOptions options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
        ///////////
        private void cmbcode_Enter(object sender, EventArgs e)
        {
            btnclear_Click(sender, e);
            cmbcode.Items.Clear();
            if (rdbM.Checked)
            {
               
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string strcmd = "select TcodeW,TcodeM from [dbo].[پایه-معین]";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var temp = reader.GetInt32(0).ToString();
                    if(temp.ToString().Length == 1)
                    {
                        temp = "0" + temp;
                    }
                    var temp1 = reader.GetInt32(1).ToString();
                    if (temp1.ToString().Length == 1)
                    {
                        temp1 = "00" + temp1;
                    }
                    else if (temp1.ToString().Length == 2)
                    {
                        temp1 = "0" + temp1;
                    }
                    cmbcode.Items.Add(temp.ToString()+"-"+temp1.ToString());
                }

                reader.Close();
                con.Close();
            }
            else if (rdbW.Checked)
            {
                
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string strcmd = "select Tcode from [dbo].[پایه-کل] where TMstate ="+"N'ندارد'";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    var temp = reader.GetInt32(0).ToString();
                    if (temp.Length == 1) temp = "0" + temp;
                    cmbcode.Items.Add(temp);
                   
                }

                reader.Close();
                con.Close();
            }


        }


        /////////////////////// تابع چک غیر عددی بودن
        
        public int NumCheck(string str)
        {
            int returnval = 0;
            try
            {
                int.Parse(str);
            }
            catch
            {
                //MessageBox
                returnval = 1;
            }

            return returnval;
        }


        ///////////////////////////////////////
        //تابع بررسی وجود و یا مجاز بودن  کد وارد شده
        public int CodeCheck(string codeWM, int messageEnable, char wm)
        {
            // فلگ messageEnable
            // برای مواقعی که تنها بررسی تکراری بودن لازم است و نمایش پیام ضرورتی ندارد در نظر گرفته شده است
            // اگر مقدار آن برابر یک باشد پیامها فعال بوده و نمایش داده خواهند شد و در غیر این صورت پیامها فعال نخواند شد
            int returnval = 0;
            string code = ""; //کد کل
            string codeM = "";// کد معین در صورت انتخاب صورتحستب معین
            if (wm == 'w') // اگر صورتحساب کل مد نظر باشد
            {
                code = codeWM;
            }
            else if(wm == 'm') // اگر صورتحساب معین مد نظر باشد
            {
                code = codeWM.Split('-')[0];
                codeM = codeWM.Split('-')[1];
            }
            

            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "";
            if (wm == 'w')
            {
                strcmd = "select Ttitle,TMstate from [dbo].[پایه-کل] where Tcode=" + codeWM;
            }
            else if (wm == 'm')
            {
                strcmd = "select TtitleM from [dbo].[پایه-معین] where TcodeM=" + codeM + " and TcodeW=" + code;
            }
            SqlCommand cmd = new SqlCommand(strcmd, con);

            SqlDataReader reader = cmd.ExecuteReader();

            int flagMatch = 0;
            //string title = "";
            while (reader.Read())
            {
                flagMatch = 1;
                //var tempcode = reader.GetValue(0).ToString();
                var tempTitle = reader.GetString(0);

                if (wm == 'w')
                {
                    var tempState = reader.GetString(1);


                    if (tempState == "دارد")
                    {
                        if (messageEnable == 1)
                            MessageBox.Show("انتخاب این کد مجاز نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        returnval = 1;

                    }
                }



                //title = tempTitle;
                //returnval = 1;

            }

            if (flagMatch != 1)
            {
                if (messageEnable == 1)
                    MessageBox.Show(" کد وارد شده تعریف نشده است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                returnval = 1;

            }

            reader.Close();
            con.Close();
            return returnval;

        }
        ////////////////////////////////


        /////////////////////// تابع مخصوص محاسبه مبلغ مانده
        // رشته اول برای تاریخ پایان بازه، کارکتر یا آرگومان دوم برای تعیین نام جدول وکارکتر آخری
        //برای محاسبه نشدن تاریخ "از" در مانده قبلی است
        private int remaining(string date, char table, char fT)
        {
        
            string tableName = "";
            string codename = "";
            if (table == 'W')
            {
                tableName = "[dbo].[سند-کل]";
                codename = "TcodeW";

            }
            else if (table == 'M')
            {
                tableName = "[dbo].[سند-معین]";
                codename = "Tcode";
            }
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string strcmd1 = " select MIN(Tdate) from " + tableName;
            SqlCommand cmd1 = new SqlCommand(strcmd1, con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            string minDate = "";
            if (reader1.Read())
            {
                minDate = reader1.GetValue(0).ToString();
                
            }

            reader1.Close();
            /*
            string[] tmp;
            tmp = minDate.Split(' ');
            minDate = tmp[0];
            tmp = minDate.Split('/');
            minDate = tmp[2] + "-" + tmp[0] + "-" + tmp[1];*/
            //ERROR...

            ///////////
            string code = cmbcode.Text;
            
            if (cmbcode.Text.Length > 2)
            {
                string[] temp = cmbcode.Text.Split('-');
                code = temp[0]+temp[1];
            }
            code = int.Parse(code).ToString();
            string strcmd = "";
            if (fT == 'F') { strcmd = "select Tprice, Tnature from " + tableName + " where " + codename + "=" + code + "and Tdate != '"+ date +"' and Tdate between '" + minDate + "' and '" + date + "'"; }
            else if(fT == 'T') strcmd = "select Tprice, Tnature from " + tableName + " where " + codename + "=" + code + " and Tdate between '" + minDate + "' and '" + date + "'";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int sum = 0;
            while (reader.Read())//////////ERROR.....
            {
                var temp = reader.GetValue(1).ToString();
                var price = int.Parse(reader.GetValue(0).ToString());
                if (temp == "بستانکار")
                {
                    sum += price;
                }
                else if (temp == "بدهکار")
                {
                    price = -price;
                    sum += price;
                }
            }
            reader.Close();
            
            con.Close();
            return sum;
        }
        
        
        public int counter = 0;
        private void btnshow_Click(object sender, EventArgs e)
        {
            int flagEnable = 1;
            
            datagridview.Columns.Clear();
            txtboxFday.ForeColor = Color.Black;
            txtboxFmonth.ForeColor = Color.Black; 
            txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;


            string fd ="" , fm="" , fy , td="" , tm="" , ty ;

            if (!rdbM.Checked && !rdbW.Checked)
            {
                flagEnable = 1;
                MessageBox.Show(" ابتدا نوع صورتحساب را مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                groupBox1.Focus();
            }
            else if (cmbcode.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" کد را وارد کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.Focus();
            }
            else if (txtboxFday.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " +"!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxFday.Focus();

            }
            else if (txtboxFmonth.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxFmonth.Focus();
            }
            else if (txtboxFyear.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxFyear.Focus();
            }
            else if (txtboxTday.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxTday.Focus();
            }
            else if (txtboxTmonth.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxTmonth.Focus();
            }
            else if (txtboxTyear.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxTyear.Focus();
            }
            else flagEnable = 0;


            string fromDate = "";
            string ToDate = "";

            if (flagEnable == 0)
            {
                ty = txtboxTyear.Text;
                fy = txtboxFyear.Text;
                fm = int.Parse(txtboxFmonth.Text).ToString();
                td = int.Parse(txtboxTday.Text).ToString();
                tm = int.Parse(txtboxTmonth.Text).ToString();
                fd = int.Parse(txtboxFday.Text).ToString();
                if (int.Parse(txtboxFmonth.Text) < 10) fm = "0" + fm;
                if (int.Parse(txtboxFday.Text) < 10) fd = "0" + fd;
                if (int.Parse(txtboxTmonth.Text) < 10) tm = "0" + tm;
                if (int.Parse(txtboxTday.Text) < 10) td = "0" + td;

                if (int.Parse(ty) < int.Parse(fy))
                {
                    MessageBox.Show("بازه نامعتبر است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txtboxFyear.ForeColor = Color.Red;
                    txtboxTyear.ForeColor = Color.Red;
                    flagEnable = 1;
                }
                else if (int.Parse(tm) < int.Parse(fm) && int.Parse(ty) == int.Parse(fy))
                {
                    MessageBox.Show("بازه نامعتبر است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txtboxFmonth.ForeColor = Color.Red;
                    txtboxTmonth.ForeColor = Color.Red;
                    flagEnable = 1;
                }
                else if (int.Parse(td) < int.Parse(fd) && int.Parse(ty) == int.Parse(fy) && int.Parse(tm) == int.Parse(fm))
                {
                    MessageBox.Show("بازه نامعتبر است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txtboxFday.ForeColor = Color.Red;
                    txtboxTday.ForeColor = Color.Red;
                    flagEnable = 1;
                }
                else flagEnable = 0;

                
                int FKerror = 0;
                if (flagEnable == 0)
                {
                    int rt = int.Parse(ty) % 4;
                    int rf = int.Parse(fy) % 4;

                    
                    
                    if ((int.Parse(fm) > 6 && int.Parse(fm) < 12) && int.Parse(fd) > 30)
                    {

                        txtboxFmonth.ForeColor = Color.Red;
                        txtboxFday.ForeColor = Color.Red;
                        
                        flagEnable = 1;
                        
                    }
                    ///// اگر باقی مانده تقسیم یک سال بر 4 برابر 3 باشد آن سال کبیسه است

                    else if (int.Parse(fm) == 12)
                    {
                        if (rf == 3)//سال کبیسه است
                        {
                            
                            if (int.Parse(fd) > 30)
                            {
                               
                                txtboxFmonth.ForeColor = Color.Red;
                                txtboxFday.ForeColor = Color.Red;
                                
                                flagEnable = 1;
                                
                            }
                            else
                            {
                                if (flagEnable != 1)
                                    flagEnable = 0;
                                
                            }
                        }
                        else
                        {
                            
                            if (int.Parse(fd) > 29)
                            {
                                txtboxFyear.ForeColor = Color.Green;
                                txtboxFmonth.ForeColor = Color.Red;
                                txtboxFday.ForeColor = Color.Red;
                                FKerror= 1;
                                flagEnable = 1;
                                
                            }
                            else
                            {
                                if (flagEnable != 1)
                                    flagEnable = 0;
                               
                            }
                        }
                    }
                    
                    if ((int.Parse(tm) > 6 && int.Parse(tm) < 12) && int.Parse(td) > 30 && flagEnable == 0)
                    {

                        txtboxTmonth.ForeColor = Color.Red;
                        txtboxTday.ForeColor = Color.Red;
                        flagEnable = 1;
                        
                    }
                    else if (int.Parse(tm) == 12)
                    {

                        if (rt == 3) // سال کبیسه است
                        {

                            if (int.Parse(td) > 30)
                            {
                               
                                txtboxTmonth.ForeColor = Color.Red;
                                txtboxTday.ForeColor = Color.Red;
                                
                                flagEnable = 1;
                                
                            }
                            else
                            {
                                if (flagEnable != 1)
                                    flagEnable = 0;

                            }
                        }
                        else
                        {
                            //if(fKabise != 0)
                            //fKabise = 1;
                            if (int.Parse(td) > 29)
                            {
                                txtboxTyear.ForeColor = Color.Green;
                                txtboxTmonth.ForeColor = Color.Red;
                                txtboxTday.ForeColor = Color.Red;
                                FKerror = 1;
                                //MessageBox.Show("!" + "بازه نامعتبر است", "خطای اعتبار سنجی سال کبیسه", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                flagEnable = 1;
                                //fKabise = 0;
                            }
                            else
                            {
                                if(flagEnable != 1)
                                flagEnable = 0;
                                //fKabise = 0;
                            }
                        }
                    }


                    if (flagEnable == 1 && FKerror == 1)
                    {
                        MessageBox.Show("بازه نامعتبر است" + "!" + "\n" + "(رنگ سبز نشان دهنده سال غیر کبیسه است)" , "خطای اعتبار سنجی سال کبیسه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    }
                    else if (flagEnable == 1 )
                    {
                        MessageBox.Show("بازه نامعتبر است" + "!", "خطای اعتبار سنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    }



                }


                fromDate = fy + "-" + fm + "-" + fd;
                ToDate = ty + "-" + tm + "-" + td;
            }


            if (flagEnable == 0)
            {
                if (rdbW.Checked)
                {

                    lblPRemaining.Text = remaining(fromDate, 'W', 'F').ToString();
                    lblFRemaining.Text = remaining(ToDate, 'W', 'T').ToString();

                    int PRemain = int.Parse(lblPRemaining.Text);
                    int FRemain = int.Parse(lblFRemaining.Text);

                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    string strcmd = "select 0 as [ردیف] , Tdate as [تاریخ],  Ttime as [زمان], Tdes as [شرح], Tnature as [بدهکار], Tprice as [بستانکار], 'a' as [مانده] from [dbo].[سند-کل] where TcodeW= " + cmbcode.Text + " and Tdate between '" + fromDate + "' and '" + ToDate + "'";
                    

                    SqlDataAdapter sda = new SqlDataAdapter(strcmd, con);
                    DataTable dtable = new DataTable();

                    sda.Fill(dtable);
                    datagridview.DataSource = dtable;

                    
                    if (lblpnature.Text == "بدهکار")
                    {
                        PRemain = -Math.Abs(PRemain);
                    }
                    else PRemain = Math.Abs(PRemain);
                    string end = "0";
                    int sum = PRemain;
                    for (int i = 0; i < datagridview.Rows.Count - 1; i++)
                    {
                        datagridview.Rows[i].Cells["ردیف"].Value = i + 1;
                        string price = datagridview.Rows[i].Cells["بستانکار"].Value.ToString();
                        string NatureTmp = datagridview.Rows[i].Cells["بدهکار"].Value.ToString();
                        if (NatureTmp == "بدهکار")
                        {
                            datagridview.Rows[i].Cells["بدهکار"].Value = price;
                            datagridview.Rows[i].Cells["بستانکار"].Value = "-";
                            sum = sum - int.Parse(price);

                        }
                        else if (NatureTmp == "بستانکار")
                        {
                            datagridview.Rows[i].Cells["بستانکار"].Value = price;
                            datagridview.Rows[i].Cells["بدهکار"].Value = "-";
                            sum = sum + int.Parse(price);
                        }
                        if (sum < 0)
                        {
                            end = Math.Abs(sum).ToString() + " - " + " بدهکار";
                        }
                        else if (sum > 0)
                        {
                            end = Math.Abs(sum).ToString() + " - " + " بستانکار ";
                        }
                        else end = "0";
                        datagridview.Rows[i].Cells["مانده"].Value = end;

                    }

                    //int columnIndex = datagridview.Columns["tdate"].Index;
                    //datagridview.Columns.RemoveAt(columnIndex);

                    con.Close();


                }
                else if (rdbM.Checked)
                {
                    lblPRemaining.Text = remaining(fromDate, 'M', 'F').ToString();
                    lblFRemaining.Text = remaining(ToDate, 'M', 'T').ToString();

                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    string[] temp = cmbcode.Text.Split('-');
                    string strcmd = "select 0 as [ردیف] , Tdate as [تاریخ],  Ttime as [زمان], Tdes as [شرح], Tnature as [بدهکار], Tprice as [بستانکار], 'a' as [مانده] from [dbo].[سند-معین] where Tcode= " + temp[0] + temp[1] + " and Tdate between '" + fromDate + "' and '" + ToDate + "' ";
                    SqlCommand cmd = new SqlCommand(strcmd, con);

                    //string[] t1;

                    SqlDataAdapter sda = new SqlDataAdapter(strcmd, con);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);
                    datagridview.DataSource = dtable;

                    int PRemain = int.Parse(lblPRemaining.Text);
                    int FRemain = int.Parse(lblFRemaining.Text);

                    if (lblpnature.Text == "بدهکار")
                    {
                        PRemain = -Math.Abs(PRemain);
                    }
                    else PRemain = Math.Abs(PRemain);
                    string end = "0";
                    int sum = PRemain;

                    for (int i = 0; i < datagridview.Rows.Count - 1; i++)
                    {
                        //datagridview.Rows[i].Cells["ردیف"].Value = i + 1;
                        datagridview.Rows[i].Cells["ردیف"].Value = i + 1;
                        string price = datagridview.Rows[i].Cells["بستانکار"].Value.ToString();
                        string NatureTmp = datagridview.Rows[i].Cells["بدهکار"].Value.ToString();
                        if (NatureTmp == "بدهکار")
                        {
                            datagridview.Rows[i].Cells["بدهکار"].Value = price;
                            datagridview.Rows[i].Cells["بستانکار"].Value = "-";
                            sum = sum - int.Parse(price);

                        }
                        else if (NatureTmp == "بستانکار")
                        {
                            datagridview.Rows[i].Cells["بستانکار"].Value = price;
                            datagridview.Rows[i].Cells["بدهکار"].Value = "-";
                            sum = sum + int.Parse(price);
                        }
                        if (sum < 0)
                        {
                            end = Math.Abs(sum).ToString() + " - " + " بدهکار";
                        }
                        else if (sum > 0)
                        {
                            end = Math.Abs(sum).ToString() + " - " + " بستانکار ";
                        }
                        else end = "0";
                        datagridview.Rows[i].Cells["مانده"].Value = end;


                    }

                    //int columnIndex = datagridview.Columns["tdate"].Index;
                    //datagridview.Columns.RemoveAt(columnIndex);

                    con.Close();
                }

                var text1 = int.Parse(lblFRemaining.Text);
                if (text1 < 0)
                {
                    lblfnature.Text = "بدهکار";
                    lblFRemaining.Text = (-text1).ToString();
                }
                else if (text1 > 0)
                {
                    lblfnature.Text = "بستانکار";
                }
                else if (text1 == 0) lblfnature.Text = " ";

                var text2 = int.Parse(lblPRemaining.Text);
                if (text2 < 0)
                {
                    lblpnature.Text = "بدهکار";
                    lblPRemaining.Text = (-text2).ToString();
                }
                else if (text2 > 0)
                {
                    lblpnature.Text = "بستانکار";
                }
                else if (text2 == 0) lblpnature.Text = " ";
            }
            flagEnable = 0;
            
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            datagridview.Columns.Clear();
            lblfnature.ResetText();
            lblFRemaining.ResetText();
            lblpnature.ResetText();
            lblPRemaining.ResetText();

        }

        private void cmbcode_Leave(object sender, EventArgs e)
        {
            int error=0, fNotExist = 0;
            if (cmbcode.Text.Length != 0)
            {
                string[] temp;

                if (rdbM.Checked)
                {
                    if (cmbcode.Text.Contains('-'))
                    {
                        temp = cmbcode.Text.Split('-');
                        if (temp.Length == 2)
                        {
                            if (temp[0] == "")
                            {
                                error = 1;
                            }
                            else if (temp[1] == "")
                            {
                                error = 1;
                            }
                            else
                            {
                                int flag = 0;
                                flag = NumCheck(temp[0]);
                                if (flag != 1) flag = NumCheck(temp[1]);
                                if (flag != 1)
                                {
                                    if (temp[0].Length == 1)
                                    {
                                        temp[0] = "0" + temp[0];
                                    }
                                    else if (temp[0].Length > 2)
                                    {
                                        flag = 1;
                                    }
                                    // else CodeCheck

                                    if (temp[1].Length > 3)
                                    {
                                        // text too long

                                    }
                                    else if (temp[1].Length == 2)
                                    {
                                        temp[1] = "0" + temp[1];
                                    }
                                    else if (temp[1].Length == 1)
                                    {
                                        temp[1] = "00" + temp[1];
                                    }
                                    if (temp[0].Length == 2 && temp[1].Length == 3)
                                    {
                                        cmbcode.Text = temp[0] + "-" + temp[1];
                                    }
                                    cmbcode_TextUpdate(sender, e);

                                    if (flag == 1) error = 1;
                                }
                                else //flag=1
                                {
                                    error = 1;
                                }
                            }
                        }
                        else
                        {
                            error = 1;
                        }
                    }
                    else
                    {
                        error = 1;
                    }
                }
                else if (rdbW.Checked)
                {
                    if (cmbcode.Text.Length == 1)
                    {
                        cmbcode.Text = "0" + cmbcode.Text;
                    }
                    else if (cmbcode.Text.Length > 2)
                    {
                        MessageBox.Show(" طول کد کل حداکثر باید دو رقم باشد " +"!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        cmbcode.ResetText();
                        cmbcode.Focus();
                    }
                    else if(cmbcode.Text.Length==0 && btnshow.Focused)
                    {
                        MessageBox.Show("!" + " ابتدا کد را وارد کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        cmbcode.ResetText();
                    }

                    cmbcode_TextUpdate(sender, e);
                }


                if (error != 1 && cmbcode.Text.Length != 0)
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    string strcmd = "";
                    if (rdbW.Checked)
                    {
                        strcmd = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text;
                    }
                    else if (rdbM.Checked)
                    {
                        string[] temp1 = cmbcode.Text.Split('-');
                        strcmd = "select TtitleM from [dbo].[پایه-معین] where TcodeM=" + temp1[1] + " and TcodeW=" + temp1[0];
                    }
                    else
                    {
                        MessageBox.Show("نوع صورتحساب را انتخاب کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        rdbW.Focus();
                    }
                    SqlCommand cmd = new SqlCommand(strcmd, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var temp1 = reader.GetString(0);
                        lbltitle.Text = temp1;
                    }

                    reader.Close();
                    con.Close();
                }
                else if (cmbcode.Text.Length != 0) // error=1
                {
                    MessageBox.Show(" فرمت فیلد کد نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcode.ResetText();
                    cmbcode.Focus();
                }


            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            cmbcode.ResetText();
            datagridview.Columns.Clear();
            lblfnature.ResetText();
            lblFRemaining.ResetText();
            lblpnature.ResetText();
            lblPRemaining.ResetText();
            lbltitle.ResetText();
        }

        private void cmbcode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbcode.Text.Length != 0)
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string strcmd = "";
                if (rdbW.Checked)
                {
                    strcmd = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text;
                }
                else if (rdbM.Checked)
                {
                    string[] temp = cmbcode.Text.Split('-');
                    strcmd = "select TtitleM from [dbo].[پایه-معین] where TcodeM=" + temp[1] + " and TcodeW=" + temp[0];
                }
                else
                {
                    MessageBox.Show("نوع صورتحساب را انتخاب کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    rdbW.Focus();
                }
                SqlCommand cmd = new SqlCommand(strcmd, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var temp = reader.GetString(0);
                    lbltitle.Text = temp;
                }

                reader.Close();
                con.Close();

            }
        }

        private void cmbcode_TextUpdate(object sender, EventArgs e)
        {
            lbltitle.ResetText();
            if (rdbW.Checked)
            {
                int error = 0;
                if (cmbcode.Text.Length != 0)
                {
                    error = NumCheck(cmbcode.Text);
                }
                
                if (error == 1)
                {
                    MessageBox.Show( " فرمت فیلد کد نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcode.ResetText();
                    cmbcode.Focus();
                }

                if (cmbcode.Text.Length == 2)
                {
                    int flag = CodeCheck(cmbcode.Text, 1, 'w');
                    if (flag == 1)
                    {
                        cmbcode.ResetText();
                        cmbcode.Focus();
                    }
                }

                else if (cmbcode.Text.Length > 2)
                {
                    MessageBox.Show(" طول کد کل حداکثر باید دو رقم باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcode.ResetText();
                    cmbcode.Focus();
                }

            }
            else if (rdbM.Checked)
            {
                int error = 0;
                int errorNotExist = 0;
                if (cmbcode.Text.Length != 0)
                {
                    string[] temp;

                    if (cmbcode.Text.Contains('-'))
                    {
                        temp = cmbcode.Text.Split('-');

                        if (temp.Length == 2 ) // previously: ==
                        {
                            //
                            if (cmbcode.Text.Length > 6)
                            {
                                MessageBox.Show( " طول مقدار وارد شده در فیلد کد زیاد است " +"."+ "\n" +  "طول مجاز با احتساب خط جدا کننده شش کاراکتر است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                                cmbcode.ResetText();
                                cmbcode.Focus();
                            }
                            else
                            {

                                if (temp[0] == "")
                                {
                                    error = 1;
                                }
                                else if (temp[1] == "" && cmbcode.Text.Length > 3)
                                {
                                    error = 1;
                                }
                                else
                                {
                                    int flag1 = 0, flag2 = 0;
                                    flag1 = NumCheck(temp[0]);
                                    if (flag1 == 1)
                                    {
                                        error = 1;
                                    }
                                    else if (temp[1] != "")
                                    {
                                        flag2 = NumCheck(temp[1]);
                                        if (flag2 == 1) error = 1;
                                    }
                                }
                            }
                            //
                            if (cmbcode.Text.Length >= 3)
                            {
                               
                                //
                            }
                            else
                            {
                               // error = 1;
                            }
                        }
                        else
                        {
                            error = 1;
                        }

                    }
                    else
                    {
                        if (cmbcode.Text.Length >= 3)
                        {
                            error = 1;
                        }
                        else // length<=3
                        {
                            error = NumCheck(cmbcode.Text);
                        }


                    }


                    if (error != 1)
                    {
                        if (cmbcode.Text.Length == 6)
                        {
                            errorNotExist = CodeCheck(cmbcode.Text, 0, 'm');
                        }
                    }
                    else
                    if (error == 1 && cmbcode.Text.Length!=0)
                    {
                        MessageBox.Show(" فرمت فیلد کد نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        cmbcode.ResetText();
                        cmbcode.Focus();
                    }

                    if (errorNotExist == 1)
                    {
                        MessageBox.Show( " کد وارد شده تعریف نشده است  " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        cmbcode.ResetText();
                        cmbcode.Focus();
                    }


                    //error = NumCheck();
                }
            }
        }

        private void txtboxFday_TextChanged(object sender, EventArgs e)
        {
            txtboxFday.ForeColor = Color.Black;
            txtboxFmonth.ForeColor = Color.Black;
            txtboxFyear.ForeColor = Color.Black;
            //txtboxTday.ForeColor = Color.Black;
            //txtboxTmonth.ForeColor = Color.Black;
            //txtboxTyear.ForeColor = Color.Black;

            TextBox txt = txtboxFday;
            
            int flagError = 0;
            flagError = NumCheck(txt.Text);
            if (flagError == 1 && txt.Text.Length!=0)
            {
                MessageBox.Show(" فرمت فیلد روز نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txt.ResetText();
                txt.Focus();
            }
            else if(flagError!=1 && txt.Text.Length == 2)
            {
                txtboxFmonth.Focus();
            }


        }

        private void txtboxFday_Leave(object sender, EventArgs e)
        {
            TextBox txt = txtboxFday;
            if (txt.Text.Length != 0)
            {
                if (int.Parse(txt.Text) > 31 || int.Parse(txt.Text) < 1)
                {
                    MessageBox.Show(" عدد وارد شده برای روز صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txt.ResetText();
                    txt.Focus();
                }
            }
        }

        private void txtboxFmonth_TextChanged(object sender, EventArgs e)
        {
            txtboxFday.ForeColor = Color.Black;
            txtboxFmonth.ForeColor = Color.Black;
            txtboxFyear.ForeColor = Color.Black;
            //txtboxTday.ForeColor = Color.Black;
            //txtboxTmonth.ForeColor = Color.Black;
            //txtboxTyear.ForeColor = Color.Black;

            TextBox txt = txtboxFmonth;

            int flagError = 0;
            flagError = NumCheck(txt.Text);
            if (flagError == 1 && txt.Text.Length != 0)
            {
                MessageBox.Show(" فرمت فیلد ماه نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txt.ResetText();
                txt.Focus();
            }
            else if (flagError != 1 && txt.Text.Length == 2)
            {
                txtboxFyear.Focus();
            }

        }

        private void txtboxFmonth_Leave(object sender, EventArgs e)
        {
            TextBox txt = txtboxFmonth;
            if (txt.Text.Length != 0)
            {
                if (int.Parse(txt.Text) > 12 || int.Parse(txt.Text) < 1)
                {
                    MessageBox.Show(" عدد وارد شده برای ماه صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txt.ResetText();
                    txt.Focus();
                }
            }
        }

        private void txtboxTday_TextChanged(object sender, EventArgs e)
        {
            //txtboxFday.ForeColor = Color.Black;
            //txtboxFmonth.ForeColor = Color.Black;
            //txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;

            TextBox txt = txtboxTday;

            int flagError = 0;
            flagError = NumCheck(txt.Text);
            if (flagError == 1 && txt.Text.Length != 0)
            {
                MessageBox.Show(" فرمت فیلد روز نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txt.ResetText();
                txt.Focus();
            }
            else if (flagError != 1 && txt.Text.Length == 2)
            {
                txtboxTmonth.Focus();
            }
        }

        private void txtboxTday_Leave(object sender, EventArgs e)
        {
            /*
            txtboxFday.ForeColor = Color.Black;
            txtboxFmonth.ForeColor = Color.Black;
            txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;
            */
            TextBox txt = txtboxTday;
            if (txt.Text.Length != 0)
            {
                if (int.Parse(txt.Text) > 31 || int.Parse(txt.Text) < 1)
                {
                    MessageBox.Show(" عدد وارد شده برای روز صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txt.ResetText();
                    txt.Focus();
                }
            }
        }

        private void txtboxTmonth_TextChanged(object sender, EventArgs e)
        {
            //txtboxFday.ForeColor = Color.Black;
            //txtboxFmonth.ForeColor = Color.Black;
            //txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;

            TextBox txt = txtboxTmonth;

            int flagError = 0;
            flagError = NumCheck(txt.Text);
            if (flagError == 1 && txt.Text.Length != 0)
            {
                MessageBox.Show( " فرمت فیلد ماه نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txt.ResetText();
                txt.Focus();
            }
            else if (flagError != 1 && txt.Text.Length == 2)
            {
                txtboxTyear.Focus();
            }
        }

        private void txtboxTmonth_Leave(object sender, EventArgs e)
        {

            TextBox txt = txtboxTmonth;
            if (txt.Text.Length != 0)
            {
                if (int.Parse(txt.Text) > 12 || int.Parse(txt.Text) < 1)
                {
                    MessageBox.Show( " عدد وارد شده برای ماه صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txt.ResetText();
                    txt.Focus();
                }
            }
        }

        private void txtboxFyear_TextChanged(object sender, EventArgs e)
        {
            txtboxFday.ForeColor = Color.Black;
            txtboxFmonth.ForeColor = Color.Black;
            txtboxFyear.ForeColor = Color.Black;
            //txtboxTday.ForeColor = Color.Black;
            //txtboxTmonth.ForeColor = Color.Black;
            //txtboxTyear.ForeColor = Color.Black;

            TextBox txt = txtboxFyear;

            int flagError = 0;
            flagError = NumCheck(txt.Text);
            if (flagError == 1 && txt.Text.Length != 0)
            {
                MessageBox.Show( " فرمت فیلد سال نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txt.ResetText();
                txt.Focus();
            }
            else if (flagError != 1 && txt.Text.Length == 4)
            {
                txtboxTday.Focus();
            }
        }

        private void txtboxFyear_Leave(object sender, EventArgs e)
        {
            TextBox txt = txtboxFyear;
            if (txt.Text.Length != 0)
            {
                DateTime dt = new DateTime();
                dt = System.DateTime.Now;
                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
                var year = (persianCalendar.GetYear(dt)).ToString();

                if (int.Parse(txt.Text) > int.Parse(year) || int.Parse(txt.Text) < 1)
                {
                    MessageBox.Show( " عدد وارد شده برای سال صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txt.ResetText();
                    txt.Focus();
                }
            }
        }

        private void txtboxTyear_TextChanged(object sender, EventArgs e)
        {
            //txtboxFday.ForeColor = Color.Black;
            //txtboxFmonth.ForeColor = Color.Black;
            //txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;

            TextBox txt = txtboxTyear;

            int flagError = 0;
            flagError = NumCheck(txt.Text);
            if (flagError == 1 && txt.Text.Length != 0)
            {
                MessageBox.Show(" فرمت فیلد سال نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txt.ResetText();
                txt.Focus();
            }
            else if (flagError != 1 && txt.Text.Length == 4)
            {
                btnshow.Focus();
            }
        }

        private void txtboxTyear_Leave(object sender, EventArgs e)
        {
            TextBox txt = txtboxTyear;
            if (txt.Text.Length != 0)
            {
                DateTime dt = new DateTime();
                dt = System.DateTime.Now;
                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
                var year = (persianCalendar.GetYear(dt)).ToString();

                if (int.Parse(txt.Text) > int.Parse(year) || int.Parse(txt.Text) < 1)
                {
                    MessageBox.Show( " عدد وارد شده برای سال صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txt.ResetText();
                    txt.Focus();
                }
            }
        }

        private void btndateClear_Click(object sender, EventArgs e)
        {
            txtboxFday.ResetText();
            txtboxFmonth.ResetText();
            txtboxFyear.ResetText();
            txtboxTday.ResetText();
            txtboxTmonth.ResetText();
            txtboxTyear.ResetText();

        }
    }
}
