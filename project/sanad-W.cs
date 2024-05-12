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
    public partial class frmsanad_W : Form
    {
        public frmsanad_W()
        {
            InitializeComponent();

 ////////////////////////////////////////////////////////////////////////////////////
 ////////// تنظیمات combobox
            cmbcode.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcode.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbcode.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTHesabW.DropDownStyle = ComboBoxStyle.DropDown;
            cmbTHesabW.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTHesabW.AutoCompleteSource = AutoCompleteSource.ListItems;

            readCmbW();



            var list2 = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToList(); // لیست حروف کوچک انگلیسی
            var list1 = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList(); // لیست حروف بزرگ انگلیسی
            foreach (var item in list1) // اضافه کردن حروف بزرگ به حروف کوچک در قالب یک لیست
            {
                list2.Add(item);
            }

            List = list2;


        }

        public List<char> List = new List<char>();
        public string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
        public MessageBoxOptions options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;

        public int flagEnableAdd = 1;

        //تابع دو کاربرد دارد یکی برای پر کردن لیست کئمبوباکس
        //و دیگری برای بررسی موجود بود کد
        public void readCmbW()
        {
            //////////  خواندن کدها از جدول و نمایش در کومبوباکس

            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            var query = "select Tcode from [dbo].[پایه-کل] where TMstate=N'ندارد'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int i = 0;
                var temp = reader.GetInt32(i);
                if(temp.ToString().Length==1)
                cmbcode.Items.Add("0" + temp.ToString());
                else cmbcode.Items.Add(temp.ToString());
                i++;
            }
            reader.Close();
            con.Close();
        }

        ///////////////////////////////////////////
        /// تابعی برای تعیین تعداد رکوردهای موحود در جدول و دادن شماره ردیف
        public int RowNum = 0;
        private void RowGetter()
        {
            RowNum = 0;
            
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcommand = "select count(tbl.Trow)  from [dbo].[سند-کل]" + " as tbl";
            SqlCommand cmd = new SqlCommand(strcommand, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            if (reader.Read())
            {
                count = reader.GetInt32(0);
            }

            RowNum = count/2 + 1;
        }


        ///////// تابع خواندن تاریخ و زمان در لحظه از روی سیستم
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

            string [] t = dt.ToString().Split(' ');

            if (t[2] == "PM")
            {
                string[] time = t[1].Split(':');
                time[0] = (int.Parse(time[0]) + 12).ToString();
                t[1] = time[0].ToString() + ":" + time[1].ToString() + ":" + time[2].ToString();
            }
            time = t[1];



        }
        //////////////////////

        public string nature = "" , natureT = "";
        public void getnature(string code , char TH)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select nature from [dbo].[پایه-کل] where Tcode=" + code;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if(TH == '0')
                nature = reader.GetString(0);
                else if(TH == '1')
                natureT = reader.GetString(0);
            }

            reader.Close();
            con.Close();
        }

        /////////////////////
        public int rem = 0;
        public int remshow = 0;
        public int rem1 = 0;
        public int rem2 = 0;
        public int count = 0;
        int flagnaturecheck = 1;
        public void getRem(char TH)
        {
            string natu = "";
            if (TH == '0')
                natu = nature;
            else if (TH == '1')
                natu = natureT;

            rem = 0;
            /*
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select Tprice, Tnature from [dbo].[سند-کل] where TcodeW=" + code;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            */
            string tmp = "";
            if (rdbcreditor.Checked) tmp = rdbcreditor.Text;
            else if (rdbdebtor.Checked) tmp = rdbdebtor.Text;
            /*
            while (reader.Read())
            {
                string n = reader.GetString(1);
                string p = reader.GetString(0);

                int pval = int.Parse(p);

            }*/

            int price = int.Parse(txtprice.Text);
            if (natu == tmp)
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
                        //rem1 -= price;//در مرحله قبل که مانده کافی بود محاسبات انجام شده بود اما حال که 
                        // طرف حساب مانده کافی ندارد باید به حالت پیشین برگردد
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

            count++;
            /*
            reader.Close();
            con.Close();*/
        }

        /////////////////////////////////

        public void getremshow(string code, string nature)
        {
            remshow = 0;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select Tprice, Tnature from [dbo].[سند-کل] where TcodeW=" + code;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            //int count = 1;
            while (reader.Read())
            {
                string n = reader.GetString(1);
                string p = reader.GetString(0);

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



        private void btnadd_Click(object sender, EventArgs e)
        {
            int flagCheck = 0;
            

            if (txtprice.Text.Length == 0)
            {
                MessageBox.Show( " مبلغ را وارد کنید" +"!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtprice.Focus();
                flagCheck = 1;
            }
            else if (txtdescription.Text.Length == 0)
            {
                MessageBox.Show(" فیلد شرح سند را تکمیل کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtdescription.Focus();
                flagCheck = 1;
            }
            else
            if (cmbTHesabW.Text.Length == 0)
            {
                MessageBox.Show(" کد طرف حساب را مشخص کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbTHesabW.Focus();
                flagCheck = 1;
            }
            count = 0;
            RowGetter();
            if (flagEnableAdd == 1)
            {
                if (flagCheck == 0)
                {
                    if (rdbcreditor.Checked || rdbdebtor.Checked)
                    {
                        

                        getnature(cmbcode.Text,'0');
                        getRem('0');
                        
                        if (flagnaturecheck == 1)
                        {
                            getDateTime();

                            getnature(cmbTHesabW.Text,'1');
                            getRem('1');
                            


                            if (flagnaturecheck == 1)
                            {
                                SqlConnection con = new SqlConnection(strcon);
                                con.Open();
                                var query = "insert into [dbo].[سند-کل] (TcodeW, Tprice, Tnature, Tdes, Trow, Tdate, Ttime,TtHesab) values (@codew,@price,@nature,@des,@row,@date,@time,@tHesab)";
                                SqlCommand cmd = new SqlCommand(query, con);

                                


                                cmd.Parameters.AddWithValue("@codew", cmbcode.Text);
                                cmd.Parameters.AddWithValue("@price", txtprice.Text);

                                string naturelocal = "";
                                if (rdbcreditor.Checked) { naturelocal = rdbcreditor.Text; }
                                else if (rdbdebtor.Checked) { naturelocal = rdbdebtor.Text; }
                                if (nature.Length != 0)
                                {
                                    cmd.Parameters.AddWithValue("@nature", naturelocal);
                                }

                               

                                cmd.Parameters.AddWithValue("@des", txtdescription.Text);
                                cmd.Parameters.AddWithValue("@row", RowNum.ToString());
                                cmd.Parameters.AddWithValue("@date", date);
                                cmd.Parameters.AddWithValue("@time", time);
                                cmd.Parameters.AddWithValue("@tHesab", "0");

                                var temp = 0;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception er)
                                {
                                    temp = 1;
                                    if (er.Message.Contains("Violation of PRIMARY KEY constraint"))
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                    else
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }

                               

                                SqlCommand cmd1 = new SqlCommand(query, con);
                                cmd1.Parameters.AddWithValue("@codew", cmbTHesabW.Text);

                                cmd1.Parameters.AddWithValue("@price", txtprice.Text);
                                if (rdbdebtor.Checked) { naturelocal = rdbcreditor.Text; }
                                else if (rdbcreditor.Checked) { naturelocal = rdbdebtor.Text; }
                                if (nature.Length != 0)
                                {
                                    cmd1.Parameters.AddWithValue("@nature", naturelocal);
                                }

                                cmd1.Parameters.AddWithValue("@des", txtdescription.Text);
                                cmd1.Parameters.AddWithValue("@row", RowNum.ToString());
                                cmd1.Parameters.AddWithValue("@date", date);
                                cmd1.Parameters.AddWithValue("@time", time);
                                cmd1.Parameters.AddWithValue("@tHesab", "1");

                                temp = 0;
                                try
                                {
                                    cmd1.ExecuteNonQuery();
                                }
                                catch (Exception er)
                                {

                                    temp = 1;

                                    if (er.Message.Contains("Violation of PRIMARY KEY constraint"))
                                    {
                                        MessageBox.Show(er.Message);

                                    }
                                    else
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }


                                con.Close();

                                lblrem.Text = (rem1).ToString() + " - (" + " ماهیت : " + nat + ")";
                                lblTrem.Text = (rem2).ToString() + " - (" + " ماهیت : " + natT + ")";

                                if (temp != 1)
                                {
                                    MessageBox.Show(" عملیات افزودن با موفقیت انجام شد" + "!", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, options);
                                    cmbcode.ResetText();
                                    txtprice.ResetText();
                                    rdbcreditor.Checked = false;
                                    rdbdebtor.Checked = false;
                                    txtdescription.ResetText();
                                    cmbTHesabW.ResetText();
                                    lblrem.ResetText();
                                    lbltitlew.ResetText();
                                    lblTrem.ResetText();
                                    cmbcode.Focus();
                                }
                                 

                            }
                            else if(flagnaturecheck==0)
                            {
                                MessageBox.Show(" موجودی کافی نیست " + "!","خطای اعتبارسنجی" , MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                                cmbcode.ResetText();
                                txtprice.ResetText();
                                rdbcreditor.Checked = false;
                                rdbdebtor.Checked = false;
                                txtdescription.ResetText();
                                cmbTHesabW.ResetText();
                                lblrem.ResetText();
                                lbltitlew.ResetText();
                                lblTrem.ResetText();
                                cmbcode.Focus();
                            }

                        }
                        else if (flagnaturecheck == 0)
                        {
                            MessageBox.Show(" موجودی کافی نیست " + "!", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                            cmbcode.ResetText();
                            txtprice.ResetText();
                            rdbcreditor.Checked = false;
                            rdbdebtor.Checked = false;
                            txtdescription.ResetText();
                            cmbTHesabW.ResetText();
                            lblrem.ResetText();
                            lbltitlew.ResetText();
                            lblTrem.ResetText();
                            cmbcode.Focus();
                        }


                    }
                    else
                    {
                        MessageBox.Show(" ماهیت را مشخص کنید" + "!", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        gpbox.Focus();
                    }
                }
                
            }
            else
            {

            }
        }


        
        private void cmbcode_Leave(object sender, EventArgs e)
        {
            if (cmbcode.Text.Length == 1) cmbcode.Text = "0" + cmbcode.Text;
            if (cmbcode.Text.Length != 0)
            {
                if (cmbcode.Text.Length == 1 || cmbcode.Text.Length == 2)
                {
                    int tempERR = CodeCheck(cmbcode.Text,1);
                    
                    if (tempERR == 1)
                    {
                        cmbcode.ResetText();
                        cmbcode.Focus();
                    }
                    else
                    {
                        cmbcode_TextChanged(sender, e);

                        getnature(cmbcode.Text,'0');
                        nat = nature;
                        /*var t = cmbcode.Text;
                        if (t.Length == 2) t = "0" + t;*/
                        getremshow(cmbcode.Text, nat);
                        rem1 = remshow;
                        lblrem.Text = remshow.ToString() + " - (" + " ماهیت : " + nat + ")";
                    }
                }
                else
                {
                    MessageBox.Show(" کد کل باید حداکثر دو رقمی باشد"+"!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    cmbcode.ResetText();
                    cmbcode.Focus();
                }
                
                
            }
            else if(cmbTHesabW.Focused || txtdescription.Focused || txtprice.Focused || gpbox.Focused || btnadd.Focused)
            {
                MessageBox.Show(" ابتدا کد کل را انتخاب کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.Focus(); 
            }
            
        }

        public string nat = "", natT = "";
        
        private void cmbcode_TextChanged(object sender, EventArgs e)
        {

            ////////////////////////////////
            if (cmbcode.Text.Length > 2)
            {
                MessageBox.Show(" طول کد باید حداکثر 2 باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.ResetText();
                cmbcode.Focus();
            }

            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
            if(cmbcode.Text.Length!=0)
            try
            {
                int.Parse(cmbcode.Text);
            }
            catch
            {
                MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                flagerr = 1;
                
                //cmbcode.Focus();
                
            }

            //flagerr=
            //if (cmbcode.Text.Length == 1) cmbcode.Text = "0" + cmbcode.Text;
            if (cmbcode.Text.Length == 2 && flagerr!=1)
            {
                
                getnature(cmbcode.Text,'0');
                nat = nature;
                //var t = cmbcode.Text;
                //if (t.Length == 2) t = "0" + t;
                getremshow(cmbcode.Text, nat);
                rem1 = remshow;

                int flagCodeCHeck = CodeCheck(cmbcode.Text, 0); 
                if(flagCodeCHeck!=1)
                lblrem.Text = remshow.ToString() + " - (" + " ماهیت : " + nat + ")";

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                var query = "select Ttitle from [dbo].[پایه-کل] where Tcode="+cmbcode.Text+ "and TMstate=N'ندارد'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                var title = "";
                if (reader.Read())
                {
                    title=reader.GetString(0);
                }

                lbltitlew.Text = title;
                reader.Close();

                con.Close();

            }
            if (flagerr == 1)
            {
                cmbcode.ResetText();
                cmbcode.Focus();
            }
        }

        private void cmbTHesabW_SelectedIndexChanged(object sender, EventArgs e)
        {
            getnature(cmbTHesabW.Text,'1');
            natT = natureT;
            var t = cmbTHesabW.Text;
            getremshow(t, natT);
            rem2 = remshow;
            if(cmbcode.Text!=cmbTHesabW.Text)
            lblTrem.Text = remshow.ToString() + " - (" + " ماهیت : " + natT + ")";
        }

        private void cmbcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbcode.Text.Length == 1) cmbcode.Text = "0" + cmbcode.Text;
            
            getnature(cmbcode.Text,'0');
            nat = nature;
            var t = cmbcode.Text;
            if (t.Length == 2) t = "0" + t;
            getremshow(cmbcode.Text, nat);
            rem1 = remshow;
            lblrem.Text = remshow.ToString() + " - (" + " ماهیت : " + nat + ")";
        }

        private void cmbcode_Enter(object sender, EventArgs e)
        {
            //cmbcode.ResetText();
            lblTrem.ResetText();
            lblrem.ResetText();
            lbltitlew.ResetText();
            cmbTHesabW.ResetText();
        }
        
        ///////////////////////////////////////
        //تابع بررسی وجود و یا مجاز بودن ثبت سند برای کد کل وارد شده
        public int CodeCheck(string codeW, int messageEnable)
        {
            // فلگ messageEnable
            // برای مواقعی که تنها بررسی تکراری بودن لازم است و نمایش پیام ضرورتی ندارد در نظر گرفته شده است
            // اگر مقدار آن برابر یک باشد پیامها فعال بوده و نمایش داده خواهند شد و در غیر این صورت پیامها فعال نخواند شد
            int returnval = 0;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select Ttitle,TMstate from [dbo].[پایه-کل] where Tcode=" + codeW;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int flagMatch = 0;
            string title="";
            while (reader.Read())
            {
                flagMatch = 1;
                //var tempcode = reader.GetValue(0).ToString();
                var tempTitle = reader.GetString(0);
                var tempState = reader.GetString(1);

                if (tempState == "دارد")
                {
                    if(messageEnable==1)
                    MessageBox.Show(" ثبت سند کل برای این کد مجاز نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    returnval = 1;
                    
                }


                //title = tempTitle;
                //returnval = 1;
            
            }

            if (flagMatch != 1)
            {
                if(messageEnable==1)
                MessageBox.Show(" کد وارد شده تعریف نشده است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                returnval = 1;
                /*
                int flag_message=1;
                foreach (var item in list) // بررسی انگلیسی بودن
                    if (title.Contains(item) && title != "") flag_message = 0;

                if (flag_message != 0 && title != "") // اگر انگلیسی نباشد
                {
                    MessageBox.Show("!" + " این کد با عنوان \"" + title + "\" قبلا ثبت شده است ", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else if (flag_message == 0 && title != "") // اگر فارسی نباشد
                {
                    MessageBox.Show("!" + " قبلا ثبت شده است \"" + title + "\" این کد با عنوان", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }*/
                
                
            }

            reader.Close();
            con.Close();
            return returnval;

        }
        ////////////////////////////////



        private void cmbcode_TextUpdate(object sender, EventArgs e)
        {
            //if (cmbcode.Text.Length == 1) cmbcode.Text = "0" + cmbcode.Text;
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
            if (cmbcode.Text.Length != 0)
            {
                try
                {
                    int.Parse(cmbcode.Text);
                }
                catch
                {
                    MessageBox.Show( " فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagerr = 1;

                    //cmbcode.Focus();

                }

                /*
                if (flagerr != 1 && cmbcode.Text.Length == 1)
                {
                    flagerr = CodeCheck(cmbcode.Text);

                }*/


                if (flagerr != 1 && cmbcode.Text.Length == 2)
                {
                    flagerr = CodeCheck(cmbcode.Text,1);
                    
                    //cmbcode.ResetText();
                    //cmbcode.Focus();
                }
                /*
                foreach (var item in cmbcode.Items)
                {
                    if (cmbcode.Text == item.ToString())
                    {
                        flagerr = 1;
                            //MessageBox.Show("!" + " کد وارد شده تعریف نشده یا دارای معین بوده و مجاز به ثبت سند کل نیست", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                    }
                            
                }*/
            }
                

            if (flagerr == 1)
            {
                cmbcode.ResetText();
                cmbcode.Focus();
            }
            else if(cmbcode.Text.Length==2)
            {
                txtprice.Focus();
            }
            /*
            if (cmbcode.Text.Length > 2)
            {
                
            }*/
        }

        private void cmbTHesabW_TextUpdate(object sender, EventArgs e)
        {
            

            if (cmbTHesabW.Text.Length == 0) lblTrem.ResetText();
            //if (cmbTHesabW.Text.Length == 1) cmbTHesabW.Text = "0" + cmbTHesabW.Text;
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
            if (cmbTHesabW.Text.Length != 0)
            {
                try
                {
                    int.Parse(cmbTHesabW.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagerr = 1;


                }

                if (flagerr != 1 && cmbTHesabW.Text.Length == 2)
                {
                    flagerr = CodeCheck(cmbTHesabW.Text,1);
                    //cmbTHesabW.ResetText();
                    //cmbTHesabW.Focus();

                }
                if (cmbTHesabW.Text.Length == 2 && flagerr!=1)
                {
                    if (cmbTHesabW.Text == cmbcode.Text)
                    {
                        MessageBox.Show( " کد طرف حساب نباید با کد کل برابر باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        flagerr = 1;
                    }
                }


                if (flagerr == 1)
                {
                    cmbTHesabW.ResetText();
                    cmbTHesabW.Focus();
                    lblTrem.ResetText();
                }
                
            }
        }

        private void cmbTHesabW_TextChanged(object sender, EventArgs e)
        {
            ////////////////////////////////
            

            if (cmbTHesabW.Text.Length == 0) lblTrem.ResetText();
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود

            if(cmbTHesabW.Text.Length > 2)
            {
                MessageBox.Show(" طول کد باید حداکثر 2 باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbTHesabW.ResetText();
                cmbTHesabW.Focus();
            }

            if (cmbTHesabW.Text.Length == 2)
            {
                if (cmbTHesabW.Text == cmbcode.Text)
                {
                    MessageBox.Show(" کد طرف حساب نباید با کد کل برابر باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagerr = 1;
                }
            }

            if (cmbTHesabW.Text.Length != 0 && flagerr!=1)
                try
                {
                    int.Parse(cmbTHesabW.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagerr = 1;

                    //cmbTHesabW.Focus();

                }

            //flagerr=
            //if (cmbTHesabW.Text.Length == 1) cmbTHesabW.Text = "0" + cmbTHesabW.Text;
            if (cmbTHesabW.Text.Length == 2 && flagerr != 1)
            {

                getnature(cmbTHesabW.Text,'0');
                natT = nature;
                //var t = cmbTHesabW.Text;
                //if (t.Length == 2) t = "0" + t;
                getremshow(cmbTHesabW.Text, natT);
                rem2 = remshow;

                int flagCodeCheck = CodeCheck(cmbTHesabW.Text, 0);
                if(flagCodeCheck!=1)
                lblTrem.Text = remshow.ToString() + " - (" + " ماهیت : " + nat + ")";

                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                var query = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbTHesabW.Text + "and TMstate=N'ندارد'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                var title = "";
                if (reader.Read())
                {
                    title = reader.GetString(0);
                }

                //lbltitlew.Text = title;
                reader.Close();

                con.Close();

            }
            if (flagerr == 1)
            {
                cmbTHesabW.ResetText();
                cmbTHesabW.Focus();
                lblTrem.ResetText();
            }
        }

        private void cmbTHesabW_Leave(object sender, EventArgs e)
        {
            if (cmbTHesabW.Text.Length == 1) cmbTHesabW.Text = "0" + cmbTHesabW.Text;
            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود

            if (flagerr != 1 && cmbTHesabW.Text.Length == 1)
            {
                flagerr = CodeCheck(cmbTHesabW.Text, 1);
                

            }
            if (flagerr != 1 && cmbTHesabW.Text.Length == 2)
            {
                flagerr = CodeCheck(cmbTHesabW.Text, 1);
                

            }
            if (flagerr == 1)
            {
                cmbTHesabW.ResetText();
                cmbTHesabW.Focus();
                lblTrem.ResetText();
            }

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            if(txtprice.Text.Length!=0)
                try
                {
                    int.Parse(txtprice.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txtprice.ResetText();
                    txtprice.Focus();
                }
        }

        private void frmsanad_W_Load(object sender, EventArgs e)
        {

        }

        private void cmbTHesabW_Enter(object sender, EventArgs e)
        {
            cmbTHesabW.Items.Clear();
            lblTrem.ResetText();
            if (cmbcode.Text.Length == 0)
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                var query = "select Tcode from [dbo].[پایه-کل] where TMstate=N'ندارد' and Tcode!=" + cmbcode.Text;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    var temp = reader.GetInt32(0);
                    if(temp.ToString().Length==1)
                    cmbTHesabW.Items.Add("0" + temp.ToString());
                    else cmbTHesabW.Items.Add(temp.ToString());

                }
                reader.Close();
                con.Close();
            }
            
        }
    }
}