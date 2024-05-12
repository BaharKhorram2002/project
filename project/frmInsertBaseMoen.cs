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
    public partial class frmInsertBaseMoen : Form
    {
        ////// لیستی از تمامی حروف انگلیسی
        public List<char> list;
        //////
        public string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
        public MessageBoxOptions options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
        public frmInsertBaseMoen()
        {
            InitializeComponent();

            ////////////////////////////////////////////////////////////////////////////////////
            ////////// تنظیمات combobox
            cmbcode.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcode.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbcode.AutoCompleteSource = AutoCompleteSource.ListItems;

            //////////  خواندن کدها از جدول و نمایش در کومبوباکس
            //var strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            var query = "select Tcode from [dbo].[پایه-کل] where TMstate=N'دارد'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var temp = reader.GetInt32(0);
                if (temp.ToString().Length == 1)
                {
                    cmbcode.Items.Add("0" + temp.ToString());
                }
                else
                cmbcode.Items.Add(temp.ToString());

            }

            var list2 = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToList(); // لیست حروف کوچک انگلیسی
            var list1 = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList(); // لیست حروف بزرگ انگلیسی
            foreach (var item in list1) // اضافه کردن حروف بزرگ به حروف کوچک در قالب یک لیست
            {
                list2.Add(item);
            }

            list = list2;

            ////////////////// غیر فعال کردن امکان نوشتن 
            ///
            /*
            txtcodemoen.ReadOnly = true;
            txttitlem.ReadOnly = true;
            btnadd.Enabled = false;
            */


        }

        ////**********////دکمه افزودن
        int flag_error = 0; // اگر خطایی در هر مرحله رخ دهد این فلگ برابر یک شده و از افزودن مقادیر به جدول جلوگیری میکند  
        private void btnadd_Click(object sender, EventArgs e)
        {
            int flagEnable = 1;//بررسی نهایی خالی نبودن فیلدها
            // عدد یک به معنی فعال و عدد 0 به معنی غیرفعال بودن و بروز خطا است
            if (cmbcode.Text.Length == 0)
            {
                MessageBox.Show(" کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                //cmbcode.ResetText();
                cmbcode.Focus();
                flagEnable = 0;
            }
            else if (txtcodemoen.Text.Length == 0)
            {
                MessageBox.Show(" کد معین را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                //txtcodemoen.ResetText();
                txtcodemoen.Focus();
                flagEnable = 0;
            }
            else if (txttitlem.Text.Length < 3 || txttitlem.Text.Length > 30)
            {
                MessageBox.Show("عنوان معین باید حداقل 3 و حداکثر 30 کاراکتر داشته باشد" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                flagEnable = 0;
                txttitlem.ResetText();
                txttitlem.Focus();
            }


            if (flagEnable == 1)
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                var query = "insert into [dbo].[پایه-معین] (TcodeW ,TcodeM,TtitleM) values (@codew,@codem,@titlem)";
                SqlCommand cmd = new SqlCommand(query, con);

                var temp = 0;
                if (flag_error != 1) // دستورات مربوط به درج در جدول تنها زمانی اجرا شوند که خطایی در اعتبار سنجی رخ نداده باشد
                {
                    cmd.Parameters.AddWithValue("@codew", cmbcode.Text);

                    cmd.Parameters.AddWithValue("@codem", txtcodemoen.Text);

                    cmd.Parameters.AddWithValue("@titlem", txttitlem.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception er)
                    {

                        temp = 1;

                        if (er.Message.Contains("Violation of PRIMARY KEY constraint"))
                        {
                            repMCodeDetect(cmbcode.Text);
                            txtcodemoen.ResetText();
                            txtcodemoen.Focus();
                        }
                        else
                        {
                            MessageBox.Show(er.Message);
                        }
                    }
                    if (temp == 0) temp = 2;
                }

                con.Close();
                if (temp == 2)
                    MessageBox.Show(" عملیات افزودن با موفقیت انجام شد" + "! ","عملیات موفق",MessageBoxButtons.OK,MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, options);


                cmbcode.ResetText();
                txttitlem.ResetText();
                txtcodemoen.ResetText();
                lbltitlew.ResetText();
                cmbcode.Focus();
            }

            
        }

        ///////**********//////انتخاب کد کل
        private void cmbcode_TextUpdate(object sender, EventArgs e)
        {
            flag_error = 0;
            //////////////////////////////////  ایجاد لیستی از حروف بزرگ و کوچک انگلیسی
            ///
            int flag_message = 1;  //فلگ بررسی انگلیسی یا فارسی و عددی بودن
                                   // درصورتی که مقدار آن صفر باشد، به معنی انگلیسی بودن متن است
                                   //در صورتی که مقدار آن غیر صفر باشد، عددی یا فارسی است
                                   //این امکان برای جبران مشکل نمایش فونت فارسی و انگلیسی باهم و جابه جایی ناخواسته کلمات طراحی شده


            if(cmbcode.Text.Length!=0)
            try
            {
                int.Parse(cmbcode.Text);
            }
            catch
            {
                MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.ResetText();
                cmbcode.Focus();
            }


            ////////////////////////////////
            /*
            if (cmbcode.Text.Length > 2) //// در صورتی که کدی با طول بیش از 2 وارد شود
            {
                lbltitlew.ResetText();
                MessageBox.Show("!" + " طول کد نباید بیش از 2 رقم باشد", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbcode.ResetText();
                flag_error = 1;
            }*/

            if (cmbcode.Text.Length == 2) ///// در صورتی که طول کد وارد شده دو باشد، اعتبار سنجی لازم و ذخیره سازیهای مربوط را انجام میدهیم
            {

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                ///// تشخیص کاراکتری یا عدد بودن مقدار وارد شده در کومبو باکس
                int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
                try
                {
                    int.Parse(cmbcode.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagerr = 1;
                    flag_error = 1;
                }
                ////// تنها در صورتی که مقدار وراد شده عددی بود ادامه فرایند بررسی و افزودن انجام شود
                if (flagerr != 1)
                {
                    //// خواندن عنوان کد وارد شده در صورت داشتن معین
                    var query = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text + "and TMstate=N'دارد'";//کدهایی که معین دارند

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var title = "";



                    if (reader.Read() && flagerr != 1)
                    {
                        //title = reader.GetString(0);
                        title = reader.GetValue(0).ToString();
                    }

                    lbltitlew.Text = title;
                    reader.Close();

                    ///////// در صورتی که کد وجود دارد و معین ندارد
                    if (title == "" && flag_error != 1 && flagerr != 1) ///////// اگر عنوان دارای معین نباشد متغیر تایتل خالی باقی میماند
                    {
                        var query1 = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text + "and TMstate=N'ندارد'"; //کدهایی که معین ندارند
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        SqlDataReader reader1 = cmd1.ExecuteReader();



                        if (reader1.Read())
                        {
                            title = reader1.GetString(0);

                        }

                        //foreach (var item in list) // بررسی انگلیسی بودن
                        //    if (title.Contains(item) && title != "") flag_message = 0;
                        if (title != "")
                        {
                            MessageBox.Show(" این کد با عنوان \"" + title + "\" دارای معین نیست " + "!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                            cmbcode.ResetText();
                            flagerr = 1;
                        }
                        

                        /*
                        if (flag_message != 0 && title != "") // اگر انگلیسی نباشد
                        {
                            MessageBox.Show("!" + " این کد با عنوان \"" + title + "\" دارای معین نیست ", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbcode.ResetText();
                            flagerr = 1;
                        }
                        else if (flag_message == 0 && title != "") // اگر فارسی نباشد
                        {
                            MessageBox.Show("!" + " دارای معین نیست \"" + title + "\" این کد با عنوان", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbcode.ResetText();
                            flagerr = 1;
                        }*/

                        // lbltitlew.Text = title;
                        reader1.Close();
                    }


                    if (title == "" && flagerr != 1)
                    {
                        MessageBox.Show( "این کد تعریف نشده است" + "!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        flag_error = 1;
                        flagerr = 1;
                        cmbcode.ResetText();
                        cmbcode.Focus();
                    }

                    if (flagerr != 1) txtcodemoen.Focus();
                }


                con.Close();
            }
            else
            {
                lbltitlew.ResetText();
            }


            

        }



        private void cmbcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag_error = 0;
            /////////////////////////////////

            if (cmbcode.Text.Length > 2) //// در صورتی که کدی با طول بیش از 2 وارد شود
            {
                lbltitlew.ResetText();
                MessageBox.Show(" طول کد باید 2 رقم باشد" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.ResetText();
                flag_error = 1;
            }

            if (cmbcode.Text.Length == 2) ///// در صورتی که طول کد وارد شده دو باشد، اعتبار سنجی لازم و ذخیره سازیهای مربوط را انجام میدهیم
            {
                //var strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                //// خواندن عنوان کد وارد شده در صورت داشتن معین
                var query = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text + "and TMstate=N'دارد'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                var title = "";
                if (reader.Read())
                {
                    title = reader.GetString(0);
                }

                lbltitlew.Text = title;
                reader.Close();

                con.Close();
            }

        }

        //تابع بررسی تکراری بودن کد معین
        public int repMCodeDetect(string codeW)
        {
            int returnval = 0;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select TcodeM,TtitleM from [dbo].[پایه-معین] where TcodeW=" + codeW;
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int flagRep = 0;
            string title="";
            while (reader.Read())
            {
                var tempcode = reader.GetInt32(0);
                var tempTitle = reader.GetString(1);
                if (tempcode == int.Parse(txtcodemoen.Text))
                {
                    flagRep = 1;
                    title = tempTitle;
                    returnval = 1;
                }
            }

            if (flagRep == 1)
            {
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
                MessageBox.Show(" این کد با عنوان \"" + title + "\" قبلا ثبت شده است "+"!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodemoen.ResetText();
                txtcodemoen.Focus();
            }

            reader.Close();
            con.Close();
            return returnval;

        }
        ////////////////////////////////

        int flagSecond = 0;
        private void cmbcode_Leave(object sender, EventArgs e)
        {
            if (cmbcode.Text.Length == 0 && (txtcodemoen.Focused || txttitlem.Focused || btnadd.Focused))
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                cmbcode.Focus();
            }
            else
            if (cmbcode.Text.Length == 1)
            {
                cmbcode.Text = "0" + cmbcode.Text;

                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                ///// تشخیص کاراکتری یا عدد بودن مقدار وارد شده در کومبو باکس
                int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                                 //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
                try
                {
                    int.Parse(cmbcode.Text);
                }
                catch
                {
                    MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flagerr = 1;
                    flag_error = 1;
                }
                ////// تنها در صورتی که مقدار وراد شده عددی بود ادامه فرایند بررسی و افزودن انجام شود
                if (flagerr != 1)
                {
                    //// خواندن عنوان کد وارد شده در صورت داشتن معین
                    var query = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text + "and TMstate=N'دارد'";//کدهایی که معین دارند

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var title = "";



                    if (reader.Read() && flagerr != 1)
                    {
                        //title = reader.GetString(0);
                        title = reader.GetValue(0).ToString();
                    }

                    lbltitlew.Text = title;
                    reader.Close();
                    int flag_message=1;
                    ///////// در صورتی که کد وجود دارد و معین ندارد
                    if (title == "" && flag_error != 1 && flagerr != 1) ///////// اگر عنوان دارای معین نباشد متغیر تایتل خالی باقی میماند
                    {
                        var query1 = "select Ttitle from [dbo].[پایه-کل] where Tcode=" + cmbcode.Text + "and TMstate=N'ندارد'"; //کدهایی که معین ندارند
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        SqlDataReader reader1 = cmd1.ExecuteReader();



                        if (reader1.Read())
                        {
                            title = reader1.GetString(0);

                        }
/*
                        foreach (var item in list) // بررسی انگلیسی بودن
                            if (title.Contains(item) && title != "") flag_message = 0;

                        if (flag_message != 0 && title != "") // اگر انگلیسی نباشد
                        {
                            MessageBox.Show("!" + " این کد با عنوان \"" + title + "\" دارای معین نیست ", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbcode.ResetText();
                            cmbcode.Focus();
                            flagerr = 1;
                            flag_error = 1;
                        }
                        else if (flag_message == 0 && title != "") // اگر فارسی نباشد
                        {
                            MessageBox.Show("!" + " دارای معین نیست \"" + title + "\" این کد با عنوان", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cmbcode.ResetText();
                            cmbcode.Focus();
                            flagerr = 1;
                            flag_error = 1;
                        }
                        */
                        MessageBox.Show(" این کد با عنوان \"" + title + "\" دارای معین نیست " + "!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        cmbcode.ResetText();
                        cmbcode.Focus();
                        flagerr = 1;
                        flag_error = 1;
                        // lbltitlew.Text = title;
                        reader1.Close();
                    }


                    if (title == "" && flagerr != 1)
                    {
                        MessageBox.Show( "این کد تعریف نشده است" + "!" , " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        flag_error = 1;
                        cmbcode.ResetText();
                        cmbcode.Focus();
                    }

                    if (flagerr != 1 && flag_error != 1) txtcodemoen.Focus();
                }


                con.Close();
            }

            if (cmbcode.Text.Length != 2 && cmbcode.Text.Length !=1 && cmbcode.Text.Length !=0)
            {
                lbltitlew.ResetText();
                MessageBox.Show(" طول کد نباید بیش از 2 رقم باشد" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                flag_error = 1;
                cmbcode.Focus();

            }
            //else if(cmbcode.Text.Length = 0)
            else if(flag_error!=1 && cmbcode.Text.Length != 0)
            {
                txtcodemoen.Focus();
                
               
            }
            

        }


////**********///// کد معین

        public int counter = 0;
        public void txtcodemoen_Leave(object sender, EventArgs e)
        {
            int flagErrorStatus = 0;
            // هنگام ترک این فیلد اگر به فیلد پیشین بازگردیم به معنای انجام دوباره کار بوده و
            // اعتبار سنجی غیر فعال میشود تا مشکلی در اصلاح فیلد پیشین پیش نیاید
            /*
            if(counter > 1)
            {
                counter = 0;
            }*/

            if (txtcodemoen.Text.Length == 2) txtcodemoen.Text = "0" + txtcodemoen.Text;
            else if (txtcodemoen.Text.Length == 1) txtcodemoen.Text = "00" + txtcodemoen.Text;

            if (cmbcode.Focused)
            {
                
                
            }
            else
            {
                if (txtcodemoen.Text.Length != 3 && !cmbcode.Focused && txtcodemoen.Text.Length != 0)
                {
                    MessageBox.Show(" کد معین باید 3 رقم باشد" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flag_error = 1;
                    flagErrorStatus = 1;
                    txtcodemoen.ResetText();
                    txtcodemoen.Focus();
                    counter++;
                }




                if (txtcodemoen.Text.Length == 3)
                {
                    //// بخش مربوط به تکراری نبودن کد معین
                    flagErrorStatus = repMCodeDetect(cmbcode.Text);
                    counter++;
                    //flagErrorStatus = 1;

                }

                if (flagErrorStatus != 1) //در صورت عدم بروز خطا در این بخش فیلد عنوان معین فعال میشود
                {
                    // txttitlem.ReadOnly = false;

                    if (txtcodemoen.Text.Length == 0 && counter==0 && (txttitlem.Focused || btnadd.Focused))
                    {
                        MessageBox.Show(" کد معین را وارد کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        flag_error = 1;
                        flagErrorStatus = 1;
                        txtcodemoen.ResetText();
                        txtcodemoen.Focus();
                    }
                    else if(txtcodemoen.Text.Length!=0 )
                    {
                        txttitlem.Focus();
                        counter++;
                    }
                    


                }
            }

            

        }


        private void txtcodemoen_TextChanged(object sender, EventArgs e)
        {
            flag_error = 0;
            if (txtcodemoen.Text.Length > 3)
            {
                MessageBox.Show(" کد معین باید 3 رقم باشد" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                flag_error = 1;
                txtcodemoen.ResetText();
                txtcodemoen.Focus();
            }

            int flagerr = 0; //// فلگی برای تشخیص وارد شدن حروف به جای عدد
                             //// در صورت ورود کارکتر حروف به جای عدد فلگ برابر یک خواهد بود
/*
            foreach (var temp in list)
            {
                if (txtcodemoen.Text.Contains(temp))
                {
                    flagerr = 1;
                }
            }
            */
            try //// اگر مقدار وارد شده هر کاراکنری به جز عدد داشته باشد فرمت کد نادرست است
            {
                if (txtcodemoen.Text.Length != 0)
                {
                    var temp = int.Parse(txtcodemoen.Text);
                }
            }
            catch
            {
                flagerr = 1;
            }

            if (flagerr == 1)
            {
                MessageBox.Show(" فرمت کد صحیح نیست" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                flag_error = 1;
                //flagErrorStatus = 1;
                txtcodemoen.ResetText();
                txtcodemoen.Focus();

            }

            if (txtcodemoen.Text.Length == 3)
            {
                txttitlem.Focus();
            }


        }

////**********////عنوان معین
        int flagState = 0;

        private void txttitlem_Leave(object sender, EventArgs e)
        {
            int flagError = 0; // فلگی برای بررسی لزوم فعال سازی دکمه افزودن
            int flagBTNEnable = 1; //اجازه فعال بودن یا نبودن دکمه افزودن

            if (cmbcode.Focused || txtcodemoen.Focused)
            {

            }
            else
            {
                if (txttitlem.Text.Length < 3 || txttitlem.Text.Length > 30)
                {
                    MessageBox.Show(" عنوان معین باید حداقل 3 و حداکثر 30 کاراکتر داشته باشد "+"!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    flag_error = 1;
                    flagError = 1;
                    txttitlem.ResetText();
                    txttitlem.Focus();
                }
            }

            
        }

        private void txttitlem_TextChanged(object sender, EventArgs e)
        {
            flag_error = 0;
            


        }

        private void cmbcode_Enter(object sender, EventArgs e)
        {
            counter = 0;
            lbltitlew.ResetText();
            txtcodemoen.ResetText();
        }

        private void txttitlem_Enter(object sender, EventArgs e)
        {
            counter = 0;
        }

        private void btnadd_Enter(object sender, EventArgs e)
        {
            counter = 0;
        }

        private void txtcodemoen_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
