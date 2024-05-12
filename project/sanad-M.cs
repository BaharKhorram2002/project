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
    public partial class frmsanad_M : Form
    {
        
        
        public frmsanad_M()
        {


            InitializeComponent();

            ////////////////////////////////////////////////////////////////////////////////////
            ////////// تنظیمات combobox
            
            cmbcodeW.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcodeW.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbcodeW.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbcodeM.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcodeM.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbcodeM.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTHesab.DropDownStyle = ComboBoxStyle.DropDown;
            cmbTHesab.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTHesab.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTHesabW.DropDownStyle = ComboBoxStyle.DropDown;
            cmbTHesabW.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTHesabW.AutoCompleteSource = AutoCompleteSource.ListItems;
            //////////  خواندن کدها از جدول و نمایش در کومبوباکس
            cmbWload();
            
            
            


        }

        public string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
        public MessageBoxOptions options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
        ///////////////////////////////////////////

        private void cmbWload() //// تابعی برای ست کردن مقادیر لیست کومبوباکس کل
        {
            
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string commandText = " select Tcode from [dbo].[پایه-کل] where TMstate=" + "N'دارد'";
            SqlCommand cmd = new SqlCommand(commandText, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int i = 0;
                var temp = reader.GetValue(i);
                if(temp.ToString().Length==1)
                cmbcodeW.Items.Add("0" + temp.ToString());
                else cmbcodeW.Items.Add(temp.ToString());
                i++;
            }

            reader.Close();
            con.Close();

        }


       
        private void cmbMload() //// تابعی برای ست کردن مقادیر لیست کومبوباکس معین
        {
            if (cmbcodeW.Text.Length != 0)
            {
                
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string commandText = " select TcodeM from [dbo].[پایه-معین] where TcodeW=" + cmbcodeW.Text;
                SqlCommand cmd = new SqlCommand(commandText, con);
                SqlDataReader reader = cmd.ExecuteReader();
                //int i = 0;
                while (reader.Read())
                {
                    
                    var temp = reader.GetValue(0);
                    if (temp.ToString().Length == 1)
                    {
                        cmbcodeM.Items.Add("00" + temp.ToString());
                    }
                    else if(temp.ToString().Length == 2)
                    {
                        cmbcodeM.Items.Add("0" + temp.ToString());
                    }
                    else
                    cmbcodeM.Items.Add(temp.ToString());
                    
                }
               

                reader.Close();
                con.Close();

            }
        }
        ////////////////////////////////////////
        
        public int Mcount(string codew)
        {
            int returnval = 0;
            if (cmbcodeW.Text.Length != 0)
            {
                
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string commandText = " select TcodeM from [dbo].[پایه-معین] where TcodeW=" + cmbcodeW.Text;
                SqlCommand cmd = new SqlCommand(commandText, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    var temp = reader.GetValue(0);
                    cmbcodeM.Items.Add(temp);
                    i++;
                }
                returnval = i;

                reader.Close();
                con.Close();

            }
            return returnval;
        }



        ///////////////////////////////////////
        //تابع بررسی وجود و یا مجاز بودن ثبت سند برای کد وارد شده
        public int CodeCheck(string codeWM, int messageEnable, char wm, char tarafHesab)
        {
            // فلگ messageEnable
            // برای مواقعی که تنها بررسی تکراری بودن لازم است و نمایش پیام ضرورتی ندارد در نظر گرفته شده است
            // اگر مقدار آن برابر یک باشد پیامها فعال بوده و نمایش داده خواهند شد و در غیر این صورت پیامها فعال نخواند شد
            int returnval = 0;
            string code = "";
            if (tarafHesab == 't')
            {
                code = cmbTHesabW.Text;
            }
            else
            {
                code = cmbcodeW.Text;
            }

            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "";
            if (wm == 'w')
            {
                strcmd = "select Ttitle,TMstate from [dbo].[پایه-کل] where Tcode=" + codeWM;
            }
            else if(wm=='m')
            {
                strcmd = "select TtitleM from [dbo].[پایه-معین] where TcodeM=" + codeWM+" and TcodeW="+code;
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


                    if (tempState == "ندارد")
                    {
                        if (messageEnable == 1)
                            MessageBox.Show(" ثبت سند معین برای این کد مجاز نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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

        ///////////////////////////////////////////
        /// تابعی برای تعیین تعداد رکوردهای موجود در جدول و دادن شماره ردیف
        public int RowNum = 0;
        private void RowGetter()
        {
            RowNum = 0;
            
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcommand = "select count(tbl.Trow)  from [dbo].[سند-معین]" + " as tbl";
            SqlCommand cmd = new SqlCommand(strcommand, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            if (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            if (RowNum == 0)
                RowNum = count + 1;
            else RowNum = count / 2 + 1;
        }
        /////////
        ////
        /////تابع خواندن تاریخ و زمان در لحظه از روی سیستم
        public string date = "";
        public string time = "";
        private void getDateTime()
        {
            date = "";
            time = "";

            DateTime dt = System.DateTime.Now;
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
            var year = (persianCalendar.GetYear(dt)).ToString();
            var month = (persianCalendar.GetMonth(dt)).ToString();
            var day = (persianCalendar.GetDayOfMonth(dt)).ToString();

            if (month.Length < 2) month = "0" + month;
            if (day.Length < 2) day = "0" + day;

            date = year + "-" + month + "-" + day;
            //date = year.ToString() + "/" + month.ToString() + "/" + day.ToString();

            string[] t = dt.ToString().Split(' ');

            if (t[2] == "PM")
            {
                string[] time = t[1].Split(':');
                time[0] = (int.Parse(time[0]) + 12).ToString();
                t[1] = time[0].ToString() + ":" + time[1].ToString() + ":" + time[2].ToString();
            }
            time = t[1];



        }

        
        public string nature = "";
        public string naturet = "";
        public string getnature(string code)
        {
            string na = "";
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select nature from [dbo].[پایه-کل] where Tcode=" + code;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                na = reader.GetString(0);
            }

            reader.Close();
            con.Close();
            return na;
        }


        public int rem = 0;
        public int remshow = 0;
        public int rem1 = 0;
        public int rem2 = 0;
        public int count = 0;
        public void getRem(string code)
        {
            rem = 0;
            string tmp = "";
            if (rdbcreditor.Checked) tmp = rdbcreditor.Text;
            else if (rdbdebtor.Checked) tmp = rdbdebtor.Text;
            
            int price = int.Parse(txtprice.Text);
            
            if (nature == tmp)
            {
                if (naturet == tmp)
                {
                    if (rem2 < price)
                    {
                        flagnaturecheck = 0;

                    }
                    else
                    {
                        flagnaturecheck = 1;
                        if (count == 1)
                        {
                            rem1 += price;
                            rem2 -= price;
                        }
                        
                    }
                }
                else //naturet!=tmp
                {
                    flagnaturecheck = 1;
                    if (count == 1)
                    {
                        rem1 += price;
                        rem2 += price;
                    }
                    
                }
            }
            else //nature!=tmp
            {
                if (rem1 < price)
                {
                    flagnaturecheck = 0;
                }
                else
                {
                    if (naturet == tmp)
                    {
                        if (rem2 < price)
                        {
                            flagnaturecheck = 0;
                        }
                        else
                        {
                            flagnaturecheck = 1;
                            if (count == 1)
                            {
                                rem1 -= price;
                                rem2 -= price;
                            }
                            
                        }
                    }
                    else//naturet!=tmp
                    {
                        flagnaturecheck = 1;
                        if (count == 1)
                        {
                            rem1 -= price;
                            rem2 += price;
                        }
                        
                    }
                }
            }
            count++;
            /*
            if (nature == tmp)
            {
                if (count == 0)
                {
                    flagnaturecheck = 1;
                    rem1 += price;
                }
                else if (count == 1)
                {
                    if (rem2 < price)
                    {
                        flagnaturecheck = 0;
                        rem1 -= price;
                    }
                    else
                    {
                        flagnaturecheck = 1;
                        rem2 -= price;
                    }
                }
            }
            else //// nature!=tmp
            {
                if (count == 0)
                {
                    if (rem1 < price)
                    {
                        flagnaturecheck = 0;
                        
                    }
                    else
                    {
                        flagnaturecheck = 1;
                        rem1 -= price;
                    }
                }
                else if (count == 1)
                {
                    flagnaturecheck = 1;
                    rem2 += price;
                }
            }

            count++;*/
           
        }


        public void getremshow(string code, string nature)
        {
            remshow = 0;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select Tprice, Tnature from [dbo].[سند-معین] where Tcode=" + code;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            //int count = 1;
            while (reader.Read())
            {
                string n = reader.GetString(1);
                string p = reader.GetString(0);

                // 
                //// error in rem!=0
                if (n != nature /*&& rem != 0*/)
                {
                    remshow = remshow - int.Parse(p);
                }
                else
                {
                    remshow = remshow + int.Parse(p);
                }

            }


            reader.Close();
            con.Close();
        }

                                                               
        public int flagnaturecheck = 1;
        public string nat = "", natT = "";

        private void btnadd_Click(object sender, EventArgs e)
        {
            
            count = 0;
            RowGetter();
            int flagCheck = 0;

            if (cmbcodeW.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeW.Focus();
                flagCheck = 1;
            }
            else if (cmbcodeM.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد معین را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeM.Focus();
                flagCheck = 1;
            }
            else
            if (txtprice.Text.Length == 0)
            {
                MessageBox.Show(" مبلغ را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtprice.Focus();
                flagCheck = 1;
            }
            else if (txtdescription.Text.Length == 0)
            {
                MessageBox.Show( " فیلد شرح سند را تکمیل کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtdescription.Focus();
                flagCheck = 1;
            }
            else
            if (cmbTHesabW.Text.Length == 0)
            {
                MessageBox.Show(" کد کل طرف حساب را مشخص کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbTHesabW.Focus();
                flagCheck = 1;
            }
            else if(cmbTHesab.Text.Length == 0)
            {
                MessageBox.Show(" کد معین طرف حساب را مشخص کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbTHesab.Focus();
                flagCheck = 1;
            }
            if (flagCheck != 1)
            {
                if (rdbcreditor.Checked || rdbdebtor.Checked)
                {
                    getDateTime();
                    
                    nature = getnature(cmbcodeW.Text);
                    getRem(cmbcodeW.Text + cmbcodeM.Text);

                    if (flagnaturecheck == 1)//دلیل اینکه دو بار شرط به صورت جداگانه نوشته شده این است که پس از فراخوانی
                                             //این توابع مقدار فلگ مورد بررسی ممکن است تغییر کند و سند زدن غیرمجاز باشد
                    {
                        naturet = getnature(cmbTHesabW.Text);
                        getRem(cmbTHesabW.Text + cmbTHesab.Text);
                    }

                    if (flagnaturecheck == 1)
                    {

                        SqlConnection con = new SqlConnection(strcon);
                        con.Open();
                        string commandText = " Insert into [dbo].[سند-معین] (Tcode, Tprice, Tnature, Tdes, Trow, Tdate, Ttime, TtHesab" +/*,Tdateshow*/") values (" +
                            "@codeM, @price, @nature, @description, @row, @date, @time, @tHesab)";
                        SqlCommand cmd = new SqlCommand(commandText, con);
                        string codem = cmbcodeM.Text;

                        if (cmbcodeM.Text.Length == 1)
                        {
                            codem = "00" + cmbcodeM.Text;
                        }
                        else if (cmbcodeM.Text.Length == 2)
                        {
                            codem = "0" + cmbcodeM.Text;
                        }

                        string codeW = cmbcodeW.Text;
                        if (codeW.Length == 1) codeW = "0" + codeW;

                        string code = codeW + codem; // کد پنج رقمی حاصل از به هم پیوستن کد کل و معین را ایجاد میکنیم
                        cmd.Parameters.AddWithValue("@codeM", code);
                        cmd.Parameters.AddWithValue("@price", txtprice.Text);

                        if (rdbcreditor.Checked)
                        {
                            cmd.Parameters.AddWithValue("@nature", rdbcreditor.Text);
                        }
                        else if (rdbdebtor.Checked)
                        {
                            cmd.Parameters.AddWithValue("@nature", rdbdebtor.Text);
                        }

                        var tHesab = "0";
                        cmd.Parameters.AddWithValue("@description", txtdescription.Text);
                        cmd.Parameters.AddWithValue("@row", RowNum.ToString());
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@time", time);
                        cmd.Parameters.AddWithValue("@tHesab", tHesab);


                        cmd.ExecuteNonQuery();
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception er)
                        {
                            if (er.Message.Contains("Violation of PRIMARY KEY constraint"))
                            {

                            }
                            else
                            {
                                MessageBox.Show(er.Message);
                            }
                        }


                        SqlCommand cmd1 = new SqlCommand(commandText, con);
                        string ThesabM = cmbTHesab.Text;



                        if (cmbTHesab.Text.Length == 1)
                        {
                            ThesabM = "00" + cmbTHesab.Text;
                        }
                        else if (cmbTHesab.Text.Length == 2)
                        {
                            ThesabM = "0" + cmbTHesab.Text;
                        }

                        string codeWT = cmbTHesabW.Text;
                        if (codeWT.Length == 1) codeWT = "0" + codeWT;

                        string cd = codeWT + ThesabM; // کد پنج رقمی حاصل از به هم پیوستن کد کل و معین را ایجاد میکنیم
                        cmd1.Parameters.AddWithValue("@codeM", cd);
                        cmd1.Parameters.AddWithValue("@price", txtprice.Text);


                        //string nature ="";
                        if (rdbdebtor.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@nature", rdbcreditor.Text);
                        }
                        else if (rdbcreditor.Checked)
                        {
                            cmd1.Parameters.AddWithValue("@nature", rdbdebtor.Text);
                        }

                        tHesab = "1";
                        cmd1.Parameters.AddWithValue("@description", txtdescription.Text);
                        cmd1.Parameters.AddWithValue("@row", RowNum.ToString());
                        cmd1.Parameters.AddWithValue("@date", date);
                        cmd1.Parameters.AddWithValue("@time", time);
                        cmd1.Parameters.AddWithValue("@tHesab", tHesab);


                        cmd1.ExecuteNonQuery();
                        try
                        {
                            cmd1.ExecuteNonQuery();
                        }
                        catch (Exception er1)
                        {
                            if (er1.Message.Contains("Violation of PRIMARY KEY constraint"))
                            {

                            }
                            else
                            {
                                MessageBox.Show(er1.Message);
                            }

                        }

                        lblrem.Text = (rem1).ToString() + " - (" + " ماهیت : " + nat + ")";
                        lblTrem.Text = (rem2).ToString() + " - (" + " ماهیت : " + natT + ")";

                        MessageBox.Show("سند با موفقیت ثبت شد" + "!", "عملیات موفق",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, options);
                        con.Close();
                        cmbcodeW.ResetText();
                        cmbcodeM.ResetText();
                        cmbTHesabW.ResetText();
                        cmbTHesab.ResetText();
                        txtdescription.ResetText();
                        txtprice.ResetText();
                        rdbcreditor.Checked = false;
                        rdbdebtor.Checked = false;
                        lbltitlew.ResetText();
                        lblrem.ResetText();
                        lblTrem.ResetText();
                        cmbcodeW.Focus();
                    }
                    else if (flagnaturecheck == 0)
                    {
                        MessageBox.Show(" موجودی کافی نیست " + "!","خطای موجودی",MessageBoxButtons.OK,MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    }
                    




                }

                else
                {
                    MessageBox.Show( " ماهیت را مشخص کنید" + "!" ,"خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    gpbox.Focus();
                }
            }

        }


        /////////////////////////////////////////////////تابعی برای نمایش عنوان روبه روی کد
        private void gettitle(char type)
        {
            
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string commandText;
            if (type == 'M')
            {
                commandText = " select TtitleM from [dbo].[پایه-معین] where TcodeM=" + cmbcodeM.Text;
                SqlCommand cmd = new SqlCommand(commandText, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var temp = reader.GetValue(0);
                    lbltitleM.Text = temp.ToString();
                }
                reader.Close();
                con.Close();

            }
            else if(type=='W')
            {
                commandText = "select Ttitle from [dbo].[پایه-کل] where Tcode = "+cmbcodeW.Text;
                SqlCommand cmd = new SqlCommand(commandText, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var temp = reader.GetValue(0);
                    lbltitlew.Text = temp.ToString();
                }
                reader.Close();
                con.Close();
            }
        }
        /////////////////////////////////////////////////


        private void cmbcodeW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcodeW.Text.Length == 2)
            {

                cmbcodeM.ResetText();
               // cmbcodeM.Items.Clear();
                //cmbMload();
                gettitle('W');
                
            }
           
        }

        private void cmbcodeW_TextChanged(object sender, EventArgs e)
        {
            if (cmbcodeW.Text.Length == 2)
            {
                cmbcodeM.ResetText();
                cmbcodeM.Items.Clear();
                if (CodeCheck(cmbcodeW.Text, 0, 'w', 's') != 1)
                {
                    cmbMload();
                    gettitle('W');
                }


            }
        }

        private void cmbcodeM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(CodeCheck(cmbcodeW.))
            gettitle('M');
            
            nature = getnature(cmbcodeW.Text);
            nat = nature;
            var t1 = cmbcodeW.Text;
            var t2 = cmbcodeM.Text;
            if (t2.Length == 1) t2 = "00" + t2;
            else if (t2.Length == 2) t2 = "0" + t2;
            getremshow(t1 + t2, nat);
            rem1 = remshow;
            lblrem.Text = remshow.ToString() + " - ("   + " ماهیت : "+nat+ ")" ;
        }


        private void cmbTHesabW_Enter(object sender, EventArgs e)
        {
            lblTrem.ResetText();
            cmbTHesab.Items.Clear();
            cmbTHesabW.Items.Clear();
            cmbTHesab.ResetText();
            if (cmbcodeW.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeW.Focus();
            }
            else if(cmbcodeM.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد معین را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeM.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string strcmd = " select distinct TcodeW from [dbo].[پایه-معین] ";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int i = 0;
                    var temp = reader.GetValue(i);
                    if (temp.ToString().Length == 1)
                    {
                        cmbTHesabW.Items.Add("0" + temp.ToString());
                    }
                    else
                    cmbTHesabW.Items.Add(temp.ToString());
                    //i++;
                }

                reader.Close();
                con.Close();
            }
            
        }

        private void cmbTHesab_Enter(object sender, EventArgs e)
        {
            cmbTHesab.Items.Clear();
            lblTrem.ResetText();

            // int fLoadEnable = 1; // فلگ فعال کردن دستورات لود آیتمهای کومبوباکس - عدد یک به معنی فعال بودن است
            if (cmbcodeW.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد کل را انتخاب کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeW.Focus();
            }
            else if (cmbcodeM.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد معین را انتخاب کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeM.Focus();
            }
            else
            if (cmbTHesabW.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد کل طرف حساب را انتخاب کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbTHesabW.Focus();
                //fLoadEnable = 0;

            }
            else
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string strcommand;
                if (cmbcodeW.Text == cmbTHesabW.Text)
                {
                    strcommand = "select TcodeM from [dbo].[پایه-معین] where TcodeW=" + cmbTHesabW.Text + " and TcodeM!=" + cmbcodeM.Text;
                }
                else
                {
                    strcommand = "select TcodeM from [dbo].[پایه-معین] where TcodeW=" + cmbTHesabW.Text;
                }

                SqlCommand cmd = new SqlCommand(strcommand, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int i = 0;
                    var temp = reader.GetValue(i);
                    if (temp.ToString().Length == 1)
                    {
                        cmbTHesab.Items.Add("00" + temp.ToString());
                    }
                    else if (temp.ToString().Length == 2)
                    {
                        cmbTHesab.Items.Add("0" + temp.ToString());
                    }
                    else
                        cmbTHesab.Items.Add(temp.ToString());
                    //i++;
                }

                reader.Close();
                con.Close();
            }
           
        }

        private void cmbcodeM_Enter(object sender, EventArgs e)
        {
            if (cmbcodeW.Text.Length != 0)
            {
                cmbcodeM.ResetText();
                cmbcodeM.Items.Clear();
                cmbMload();
            }
            else
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeW.Focus();
            }
            cmbTHesab.ResetText();
            cmbTHesabW.ResetText();
            
            lbltitleM.ResetText();
            lblrem.ResetText();
        }

        private void cmbcodeW_Enter(object sender, EventArgs e)
        {
            lbltitlew.ResetText();
            lbltitleM.ResetText();
            lblTrem.ResetText();
            lblrem.ResetText();
            cmbTHesab.ResetText();
            cmbTHesabW.ResetText();
            cmbcodeM.ResetText();
        }

        private void cmbTHesab_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            naturet = getnature(cmbTHesabW.Text);
            natT = naturet;
            var t1 = cmbTHesabW.Text;
            var t2 = cmbTHesab.Text;
            if (t2.Length == 1) t2 = "00" + t2;
            else if (t2.Length == 2) t2 = "0" + t2;
            getremshow(t1 + t2, natT);
            rem2 = remshow;
            lblTrem.Text = remshow.ToString() + " - (" + " ماهیت : " + natT + ")";
        }

        private void cmbcodeW_TextUpdate(object sender, EventArgs e)
        {

            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
            if (cmbcodeW.Text.Length != 0)
                try
                {
                    int.Parse(cmbcodeW.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);

                    flagerr = 1;
                }

            if (cmbcodeW.Text.Length > 2 && flagerr != 1)
            {
                flagerr = 1;
                MessageBox.Show(" طول کد باید حداکثر 2 باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);

            }

            if(cmbcodeW.Text.Length==2 && flagerr!=1)
            if (CodeCheck(cmbcodeW.Text, 1,'w','s') == 1)
            {
                flagerr = 1;
                    
            }
            else
            {
                cmbcodeM.Focus();
            }

            if (flagerr == 1)
            {
                cmbcodeW.ResetText();
                cmbcodeW.Focus();
            }


            if (cmbcodeW.Text.Length == 2 && flagerr!=1)
            {
                int flag = CodeCheck(cmbcodeW.Text, 0,'w','s');

                if (flag != 1)
                {
                    cmbcodeM.Focus();
                }
            }

        }
        
        private void cmbcodeW_Leave(object sender, EventArgs e)
        {
            
            
            if (cmbcodeW.Text.Length == 1) cmbcodeW.Text = "0" + cmbcodeW.Text;
            int flager = 0;
            int c = Mcount(cmbcodeW.Text);
            if (c == 0 && cmbcodeW.Text.Length != 0)
            {
                MessageBox.Show( " این کد کل هیچ کد معین تعریف شده‌ای ندارد "+ "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,options);
                flager = 1;
                cmbcodeW.ResetText();
                cmbcodeW.Focus();
            }

            if (cmbcodeW.Text.Length == 0 && flager==0 && (cmbcodeM.Focused || cmbTHesab.Focused || cmbTHesabW.Focused || txtdescription.Focused || txtprice.Focused || gpbox.Focused || btnadd.Focused || rdbcreditor.Focused ||rdbdebtor.Focused))
            {
                MessageBox.Show(" ابتدا کد کل را انتخاب کنید "+ "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeW.ResetText();
                cmbcodeW.Focus();
            }

            // چون اگر تک رقمی باشه به دو رقمی تبدیل میشه پس از شرط طول برابر 2 استفاده میکنیم
            if (cmbcodeW.Text.Length == 2 && flager == 0)
            {
                int flag = CodeCheck(cmbcodeW.Text, 1, 'w', 's');
                if (flag != 1) cmbcodeM.Focus();
                else //flag==1
                {
                    cmbcodeW.ResetText();
                    cmbcodeW.Focus();
                }
            }
            /*
            if (cmbcodeW.Text.Length == 1) cmbcodeW.Text = "0" + cmbcodeW.Text;
            if (cmbcodeW.Text.Length == 0)
            {
                MessageBox.Show("!" + " ابتدا کد کل را انتخاب کنید ", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbcodeW.ResetText();
                cmbcodeW.Focus();
            }

            // چون اگر تک رقمی باشه به دو رقمی تبدیل میشه پس از شرط طول برابر 2 استفاده میکنیم
            if (cmbcodeW.Text.Length == 2)
            {
                int flag = CodeCheck(cmbcodeW.Text, 1, 'w', 's');
                if (flag != 1)
                {
                    cmbcodeM.Focus(); 
                }
                
                else //flag==1
                {

                    cmbcodeW.ResetText();
                    cmbcodeW.Focus();
                }
            }*/

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
            if (txtprice.Text.Length != 0)
                try
                {
                    int.Parse(txtprice.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت مبلغ صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);

                    flagerr = 1;
                }

            if (flagerr == 1)
            {
                txtprice.ResetText();
                txtprice.Focus();
            }
        }

        private void cmbcodeM_Leave(object sender, EventArgs e)
        {
            if (cmbcodeM.Text.Length == 2) cmbcodeM.Text = "0" + cmbcodeM.Text;
            if (cmbcodeM.Text.Length == 1) cmbcodeM.Text = "00" + cmbcodeM.Text;

            if ((cmbcodeM.Text.Length == 0 || cmbcodeM.Text == "" )&& !cmbcodeW.Focused &&(cmbTHesab.Focused||cmbTHesabW.Focused||txtdescription.Focused||txtprice.Focused||btnadd.Focused))
            {
                MessageBox.Show(" ابتدا کد معین را انتخاب کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcodeM.ResetText();
                cmbcodeM.Focus();
            }

            

            // چون اگر تک رقمی باشه به دو رقمی تبدیل میشه پس از شرط طول برابر 2 استفاده میکنیم
            if (cmbcodeM.Text.Length == 3)
            {
                


                int flag = CodeCheck(cmbcodeM.Text, 1,'m','s');
                if (flag != 1)
                {
                    gettitle('M');

                    nature = getnature(cmbcodeW.Text);
                    nat = nature;
                    var t1 = cmbcodeW.Text;
                    var t2 = cmbcodeM.Text;
                    if (t2.Length == 1) t2 = "00" + t2;
                    else if (t2.Length == 2) t2 = "0" + t2;
                    getremshow(t1 + t2, nat);
                    rem1 = remshow;
                    lblrem.Text = remshow.ToString() + " - (" + " ماهیت : " + nat + ")";
                    //txtprice.Focus();
                }
                else //flag==1
                {
                    cmbcodeM.ResetText();
                    cmbcodeM.Focus();
                }
            }

        }

        private void cmbTHesabW_Leave(object sender, EventArgs e)
        {
            if (cmbTHesabW.Text.Length == 1) cmbTHesabW.Text = "0" + cmbTHesabW.Text;
            int flager = 0;
            int c = Mcount(cmbTHesabW.Text);
            if(c==1&& cmbTHesabW.Text == cmbcodeW.Text)
            {
                MessageBox.Show(" این کد کل تنها دارای یک کد معین تعریف شده است که به عنوان کد اصلی انتخاب شده است " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                flager = 1;
                cmbTHesabW.ResetText();
                cmbTHesabW.Focus();
            }

            // چون اگر تک رقمی باشه به دو رقمی تبدیل میشه پس از شرط طول برابر 2 استفاده میکنیم
            if (cmbTHesabW.Text.Length == 2 && flager == 0)
            {
                int flag = CodeCheck(cmbTHesabW.Text, 1, 'w', 't');
                if (flag != 1) cmbTHesab.Focus();
                else //flag==1
                {
                    cmbTHesabW.ResetText();
                    cmbTHesabW.Focus();
                }
            }


        }

        private void cmbcodeM_TextUpdate(object sender, EventArgs e)
        {
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود

            if (cmbcodeM.Text.Length != 0)
                try
                {
                    int.Parse(cmbcodeM.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagerr = 1;
                }

            if (cmbcodeM.Text.Length > 3 && flagerr != 1)
            {
                flagerr = 1;
                MessageBox.Show(" طول کد باید حداکثر 3 باشد "+ "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);

            }



            if (cmbcodeM.Text.Length == 3 && flagerr != 1)
                if (CodeCheck(cmbcodeM.Text, 1, 'm', 's') == 1)
                {
                    flagerr = 1;
                }
                else
                {
                    txtprice.Focus();
                }

            if (flagerr == 1)
            {
                cmbcodeM.ResetText();
                cmbcodeM.Focus();
            }

            /*
                        if (cmbcodeM.Text.Length == 3 && flagerr != 1)
                        {
                            int flag = CodeCheck(cmbcodeM.Text, 0,'m');

                            if (flag != 1)
                            {
                                txtprice.Focus();
                            }
                        }
            */

        }

        private void cmbTHesabW_TextUpdate(object sender, EventArgs e)
        {
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
            
            
            if(cmbTHesabW.Text.Length!=0)
            try
            {
                int.Parse(cmbTHesabW.Text);
            }
            catch
            {
                MessageBox.Show(" فرمت کد کل طرف حساب صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                flagerr = 1;
            }

            if (cmbTHesabW.Text.Length > 2 && flagerr != 1)
            {
                flagerr = 1;
                MessageBox.Show(" طول کد باید حداکثر 2 باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);

            }

            


            if (cmbTHesabW.Text.Length == 2 && flagerr!=1)
                if (CodeCheck(cmbTHesabW.Text, 1,'w','t') == 1)
                {
                    flagerr = 1;
                }
                else
                {
                    cmbTHesabW.Focus();
                }

            if (flagerr == 1)
            {
                cmbTHesabW.ResetText();
                cmbTHesabW.Focus();
            }

            


            if (cmbTHesabW.Text.Length == 2 && flagerr != 1)
            {
                int flag = CodeCheck(cmbTHesabW.Text, 0,'w','t');

                if (flag != 1)
                {
                    cmbTHesab.Focus();
                }
            }


        }

        private void cmbTHesab_TextUpdate(object sender, EventArgs e)
        {
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود

            if (cmbTHesab.Text.Length == 3)
            {
                if(cmbTHesab.Text.Length!=0)
                if (int.Parse(cmbcodeW.Text) == int.Parse(cmbTHesabW.Text))
                {
                    if (int.Parse(cmbcodeM.Text) == int.Parse(cmbTHesab.Text))
                    {
                        MessageBox.Show(" سند زدن روی کد یکسان امکان پذیر نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        cmbTHesab.ResetText();
                        cmbTHesab.Focus();
                    }
                }
            }



            
            if (cmbTHesab.Text.Length!=0)
            try
            {
                int.Parse(cmbTHesab.Text);
            }
            catch
            {
                    MessageBox.Show(" فرمت کد معین طرف حساب صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);

                    flagerr = 1;
            }

            if (cmbTHesab.Text.Length > 3 && flagerr != 1)
            {
                flagerr = 1;
                MessageBox.Show(" طول کد باید حداکثر 3 باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);

            }
            

            if (cmbTHesab.Text.Length == 3 && flagerr != 1)
                if (CodeCheck(cmbTHesab.Text, 1, 'm','t') == 1)
                {
                    flagerr = 1;
                }
               

            if (flagerr == 1)
            {
                cmbTHesab.ResetText();
                cmbTHesab.Focus();
            }

        }

        private void cmbTHesab_Leave(object sender, EventArgs e)
        {
            if (cmbTHesab.Text.Length == 1) cmbTHesab.Text = "00" + cmbTHesab.Text;
            if (cmbTHesab.Text.Length == 2) cmbTHesab.Text = "0" + cmbTHesab.Text;

            if (int.Parse(cmbcodeW.Text) == int.Parse(cmbTHesabW.Text))
            {
                if(cmbcodeM.Text.Length!=0)
                if (cmbcodeM.Text == cmbTHesab.Text)
                {
                    MessageBox.Show(" سند زدن روی کد یکسان امکان پذیر نیست " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcodeM.Text = "";
                    cmbTHesab.ResetText();
                    cmbTHesab.Focus();
                        
                }
            }

            int flag = 0;
            if (cmbTHesab.Text.Length != 0)
            {
                flag = CodeCheck(cmbTHesab.Text, 1, 'm','t');
            }

            if (cmbTHesab.Text.Length == 3 && flag != 1)
            {
                naturet = getnature(cmbTHesabW.Text);
                natT = naturet;
                var t1 = cmbTHesabW.Text;
                var t2 = cmbTHesab.Text;
                if (t2.Length == 1) t2 = "00" + t2;
                else if (t2.Length == 2) t2 = "0" + t2;
                getremshow(t1 + t2, natT);
                rem2 = remshow;
                lblTrem.Text = remshow.ToString() + " - (" + " ماهیت : " + natT + ")";
            }
            if (flag == 1)
            {
                cmbTHesab.ResetText();
                cmbTHesab.Focus();
            }

        }

        private void cmbTHesabW_TextChanged(object sender, EventArgs e)
        {/*
            if (cmbTHesabW.Text.Length == 2)
            {
                /*int count = 0;
                count = Mcount(cmbTHesabW.Text);
                if (count == 0)
                {
                    MessageBox.Show(" این کد کل دارای کد معین تعریف شده نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbTHesabW.ResetText();
                    cmbTHesabW.Focus();
                }
                else
                if (cmbTHesabW.Text == cmbTHesabW.Text && count == 1)
                {
                    MessageBox.Show( " این کد کل تنها دارای یک کد معین است که به عنوان کد اصلی انتخاب شده است"+ "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,options);
                    cmbTHesabW.ResetText();
                    cmbTHesabW.Focus();
                }
                

            }*/
        }

        private void cmbcodeM_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void cmbTHesab_TextChanged(object sender, EventArgs e)
        {
            if (cmbTHesab.Text.Length == 3)
            {
                naturet = getnature(cmbTHesabW.Text);
                natT = naturet;
                var t1 = cmbTHesabW.Text;
                var t2 = cmbTHesab.Text;
                if (t2.Length == 1) t2 = "00" + t2;
                else if (t2.Length == 2) t2 = "0" + t2;
                getremshow(t1 + t2, natT);
                rem2 = remshow;
                lblTrem.Text = remshow.ToString() + " - (" + " ماهیت : " + natT + ")";
            }
        }
    }
}
