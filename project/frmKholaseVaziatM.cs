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
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.IO;

namespace project
{
    public partial class frmKholaseVaziatM : Form
    {
        public frmKholaseVaziatM()
        {
            InitializeComponent();

            cmbcode.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbcode.AutoCompleteSource = AutoCompleteSource.ListItems;


            lbltitle.Text = "";
        }
        ////////////
        public string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
        public MessageBoxOptions options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
        ///////////
        private void btnclear_Click(object sender, EventArgs e)
        {
            datagridview.Columns.Clear();

        }


        /////////////////////////////////////////////////////////////////////////////

        public List<string> lst = new List<string>();
        public string nature = "";
        //public List<string> lstcodenature = new List<string>();
        public void codelist()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select * from [dbo].[پایه-کل] where TMstate = N'دارد'";

            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var temp = reader.GetInt32(0);////codew
                //string tem = reader.GetString(2);/////TMstate
                string nature = reader.GetString(3);////nature
                //string title = reader.GetString(1);////title
                lst.Add(temp + "*" + nature);
                if(temp.ToString().Length==1)
                cmbcode.Items.Add("0"+temp.ToString());
                else cmbcode.Items.Add(temp.ToString());
                // -lstcodenature.Add()

            }
            reader.Close();
            con.Close();
        }
        ////////////////////////////////////////////////////////////////////////////
        public string title = "";
        public void gettitle(int codewm)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd2 = "select TtitleM from [dbo].[پایه-معین] where TcodeW = " + codewm / 1000 + " and TcodeM = " + codewm % 1000;
            SqlCommand cmd2 = new SqlCommand(strcmd2, con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                title = reader2.GetString(0);
            }
            reader2.Close();
            con.Close();
        }


        public int pricem = 0;
        public void tblM(int codewm, string fd, string td)
        {
            pricem = 0;

            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string strcmd = "select Tprice, Tnature from [dbo].[سند-معین] where Tcode=" + codewm + " and Tdate between '" + fd + "' and '" + td + "'";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var temp = int.Parse(reader.GetValue(0).ToString());//price
                var tempN = reader.GetString(1);//nature
                if (tempN == "بدهکار")
                {
                    temp = -temp;
                }
                pricem = pricem + temp;
            }

            reader.Close();
            con.Close();

        }

        public int PreviousRemaining;
        public void PRem(int codewm, string fdate)
        {
            PreviousRemaining = 0;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string table = "[dbo].[سند-معین]";
            string code = "Tcode";

            string strcmd = "select Tprice, Tnature from " + table + " where " + code + " = " + codewm + "and Tdate <'" + fdate + "' ";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var t1 = int.Parse(reader.GetString(0));//price
                var t2 = reader.GetString(1);//nature
                if (t2 == "بدهکار")
                {
                    PreviousRemaining = PreviousRemaining - t1;
                }
                else if (t2 == "بستانکار")
                {
                    PreviousRemaining = PreviousRemaining + t1;
                }
            }
            reader.Close();
            con.Close();

        }


        ////////////////////////////////////////////////////////////////////////////

        public void temptable()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string str = "drop table if exists [dbo].[tmptable] ";
            SqlCommand cmd2 = new SqlCommand(str, con);
            string strcmd = "create table tmptable( [\"ردیف\"] int IDENTITY(1,1),  [\"کد معین\"] int, [\"عنوان\"'] nvarchar(20), [\"ماهیت\"] nvarchar(20), [\"مانده اول دوره\"] nvarchar(50)," +
                "[\"بدهکار\"] nvarchar(50), [\"بستانکار\"] nvarchar(50), [\"مانده پایان دوره\"] nvarchar(50));";

            SqlCommand cmd = new SqlCommand(strcmd, con);
            cmd2.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            con.Close();

        }

        public void addtemp(int codeW, string debtor, string creditor, string remainder, string prRemaining, string nature, string title)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "insert into tmptable([\"کد معین\"],[\"عنوان\"'],[\"ماهیت\"],[\"مانده اول دوره\"],[\"بدهکار\"]," +
                "[\"بستانکار\"],[\"مانده پایان دوره\"]) values (@cW,@title, @n, @prem, @deb, @cred, @rem)";

            SqlCommand cmd = new SqlCommand(strcmd, con);

            cmd.Parameters.AddWithValue("@cW", codeW);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@n", nature);
            cmd.Parameters.AddWithValue("@deb", debtor);
            cmd.Parameters.AddWithValue("@cred", creditor);
            cmd.Parameters.AddWithValue("@rem", remainder);
            cmd.Parameters.AddWithValue("@prem", prRemaining);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }


            con.Close();

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

        ////////////////////////////////
        //تابع بررسی وجود و یا مجاز بودن  کد وارد شده
        public int CodeCheck(string codeW, int messageEnable)
        {
            // فلگ messageEnable
            // برای مواقعی که تنها بررسی تکراری بودن لازم است و نمایش پیام ضرورتی ندارد در نظر گرفته شده است
            // اگر مقدار آن برابر یک باشد پیامها فعال بوده و نمایش داده خواهند شد و در غیر این صورت پیامها فعال نخواند شد
            int returnval = 0;
            string code = ""; //کد کل
            string codeM = "";// کد معین در صورت انتخاب صورتحستب معین
            
             code = codeW;
            
            


            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            
            string strcmd = "select Ttitle,TMstate from [dbo].[پایه-کل] where Tcode=" + codeW;
            
            SqlCommand cmd = new SqlCommand(strcmd, con);

            SqlDataReader reader = cmd.ExecuteReader();

            int flagMatch = 0;
            //string title = "";
            while (reader.Read())
            {
                flagMatch = 1;
                //var tempcode = reader.GetValue(0).ToString();
                var tempTitle = reader.GetString(0);
                var tempState = reader.GetString(1);


                if (tempState == "ندارد")
                {
                    if (messageEnable == 1)
                        MessageBox.Show( "انتخاب این کد مجاز نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    returnval = 1;

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



        public int codeM;
        public List<int> lstcodeM = new List<int>();
        public void getcodeM(int codew)
        {
            codeM = 0;
            lstcodeM.Clear();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select distinct TcodeM from [dbo].[پایه-معین] where TcodeW=" + codew;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                codeM = reader.GetInt32(0);
                lstcodeM.Add(codeM);
               
            }

            reader.Close();
            con.Close();

        }

        ////////////////////////////////////////////////////////////////////////////
        public int flag = 0;
        private void btnshow_Click(object sender, EventArgs e)
        {
            datagridview.Columns.Clear();
            if (flag == 0)
            {
                codelist();
                flag = 1;
            }


            txtboxFday.ForeColor = Color.Black;
            txtboxFmonth.ForeColor = Color.Black; ;
            txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;

            int flagEnable = 1;

            string fd = "", fm = "", fy, td = "", tm = "", ty;
            

            if (cmbcode.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" ابتدا کد را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.Focus();
            }
            else if (txtboxFday.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                MessageBox.Show( " بازه را به طور کامل مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    
                    txtboxFyear.ForeColor = Color.Red;
                    txtboxTyear.ForeColor = Color.Red;
                    MessageBox.Show( "بازه نامعتبر است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagEnable = 1;
                }
                else if (int.Parse(tm) < int.Parse(fm) && int.Parse(ty) == int.Parse(fy))
                {
                    
                    txtboxFmonth.ForeColor = Color.Red;
                    txtboxTmonth.ForeColor = Color.Red;
                    MessageBox.Show("بازه نامعتبر است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagEnable = 1;
                }
                else if (int.Parse(td) < int.Parse(fd) && int.Parse(ty) == int.Parse(fy) && int.Parse(tm) == int.Parse(fm))
                {
                    
                    txtboxFday.ForeColor = Color.Red;
                    txtboxTday.ForeColor = Color.Red;
                    MessageBox.Show("بازه نامعتبر است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                                FKerror = 1;
                                
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
                            
                            if (int.Parse(td) > 29)
                            {
                                txtboxTyear.ForeColor = Color.Green;
                                txtboxTmonth.ForeColor = Color.Red;
                                txtboxTday.ForeColor = Color.Red;
                                FKerror = 1;
                                

                                flagEnable = 1;
                                
                            }
                            else
                            {
                                if (flagEnable != 1)
                                    flagEnable = 0;
                                
                            }
                        }
                    }


                    if (flagEnable == 1 && FKerror == 1)
                    {
                        MessageBox.Show("بازه نامعتبر است" + "!" + "\n" + "(رنگ سبز نشان دهنده سال غیر کبیسه است)", "خطای اعتبار سنجی سال کبیسه", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    }
                    else if (flagEnable == 1)
                    {
                        MessageBox.Show("بازه نامعتبر است" + "!", "خطای اعتبار سنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    }






                }

                fromDate = fy + "-" + fm + "-" + fd;
                ToDate = ty + "-" + tm + "-" + td;
            }

            if (flagEnable == 0)
            {
                if (cmbcode.Text.Length != 0)
                {

                    int codew = int.Parse(cmbcode.Text);
                    List<string> lstCodePrice = new List<string>();
                    List<string> resultlist = new List<string>();
                    getcodeM(codew);
                    foreach (var item in lstcodeM)
                    {

                        gettitle(codew * 1000 + item);
                        string nat = nature;
                        var a0 = item;////code

                        PRem(codew * 1000 + a0, fromDate);



                        tblM(codew * 1000 + a0, fromDate, ToDate);
                        lstCodePrice.Add(a0 + "*" + pricem);


                        string rem, deb = "", cred = "";
                        int temp = pricem;



                        if (pricem > 0)
                        {
                            deb = "0";
                            cred = pricem.ToString();
                        }
                        else
                        if (pricem < 0)
                        {
                            deb = (-pricem).ToString();
                            cred = "0";
                        }
                        else if (pricem == 0)
                        {
                            deb = "0";
                            cred = "0";
                        }


                        var t = temp + PreviousRemaining;
                        if (t == 0)
                        {
                            rem = "0";
                        }
                        else rem = (Math.Abs(t)).ToString();

                        foreach (var i in lst)
                        {
                            if (i.Split('*')[0] == codew.ToString())
                            {
                                nature = i.Split('*')[1];
                            }
                        }

                        resultlist.Add(a0 + "*" + deb + "*" + cred + "*" + rem + "*" + Math.Abs(PreviousRemaining) + "*" + nature + "*" + title);
                        
                    }

                    temptable();

                    datagridview.Columns.Clear();
                    
                    foreach (var item in resultlist)
                    {
                        string[] it = item.Split('*');
                        addtemp(int.Parse(it[0]), it[1], it[2], it[3], it[4], it[5], it[6]);
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    string strcmd = "select * from  tmptable ";
                    string strcmd2 = "drop table [dbo].[tmptable] ";

                    SqlDataAdapter sda = new SqlDataAdapter(strcmd, con);
                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);
                    datagridview.DataSource = dtable;

                    SqlCommand cmd = new SqlCommand(strcmd2, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                else
                {
                    MessageBox.Show("ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                }
            }
            
        }



        private void cmbcode_Enter(object sender, EventArgs e)
        {
            
            datagridview.Columns.Clear();
            cmbcode.Items.Clear();
            codelist();

        }

        private void cmbcode_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbltitle.Text = reader.GetString(0);
            }
            reader.Close();
            con.Close();
        }

        private void btnsavepdf_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbcode_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void cmbcode_Leave(object sender, EventArgs e)
        {
            int error = 0, fNotExist = 0;
            if (cmbcode.Text.Length != 0)
            {
                string[] temp;

                if (cmbcode.Text.Length == 1)
                {
                    cmbcode.Text = "0" + cmbcode.Text;
                }
                else if (cmbcode.Text.Length > 2)
                {
                    MessageBox.Show( " طول کد کل حداکثر باید دو رقم باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcode.ResetText();
                    cmbcode.Focus();
                }
                else if (cmbcode.Text.Length == 0 && btnshow.Focused)
                {
                    MessageBox.Show(" ابتدا کد را وارد کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcode.ResetText();
                }

                
                cmbcode_TextUpdate(sender, e);


                if (error != 1 && cmbcode.Text.Length != 0)
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();
                    string strcmd = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text;
                    
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
                    MessageBox.Show( " فرمت فیلد کد نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcode.ResetText();
                    cmbcode.Focus();
                }


            }
        }

        private void cmbcode_TextUpdate(object sender, EventArgs e)
        {
            lbltitle.ResetText();

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
                int flag = CodeCheck(cmbcode.Text, 1);
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
            if (flagError == 1 && txt.Text.Length != 0)
            {
                MessageBox.Show( " فرمت فیلد روز نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txt.ResetText();
                txt.Focus();
            }
            else if (flagError != 1 && txt.Text.Length == 2)
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
                    MessageBox.Show( " عدد وارد شده برای روز صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                MessageBox.Show( " فرمت فیلد ماه نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show( " عدد وارد شده برای ماه صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                MessageBox.Show( " فرمت فیلد روز نادرست است "+ "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
            //txtboxFday.ForeColor = Color.Black;
            //txtboxFmonth.ForeColor = Color.Black;
            //txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;

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
                MessageBox.Show( " فرمت فیلد سال نادرست است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show(" عدد وارد شده برای سال صحیح نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
