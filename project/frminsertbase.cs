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
    public partial class frminsertbasem : Form
    {
        public frminsertbasem()
        {
            InitializeComponent();
        }

//// public parameters
        
        int flag_moen; // مقدار 0 نشان دهنده مداشتن معین و مقدار 1 نشان دهنده داشتن معین است
        int flag_credDebt;  // اگر برابر 0 باشد بدهکار و اگر 1 باشد بستانکار است

        int flagtitle = 0;  // پرچمی برای اجازه فعال سازی اعتبارسنجی فیلد عنوان، چون بدون درست بودن مقدار آن فیلد نمیتوان آن را ترک کرد
        //پس در صورت انتخاب نوشتن از ابتدا پس از ارور عنوان به این فلگ نیازمندیم

        public string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
        public MessageBoxOptions options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
        //////////////////////////////////////
        /// validations and flags
        private void btnadd_Click(object sender, EventArgs e)
        {
            int flag_error = 0; // اگر خطایی در هر مرحله رخ دهد این فلگ برابر یک شده و از افزودن مقادیر به جدول جلوگیری میکند

//// code ......
            var codew1 = (txtcodw.Text);


            //// title ......

            string title = txttitle.Text;
            int flagTitleCheck = 0;
            if (txttitle.Text.Length == 0)
            {
                MessageBox.Show(" عنوان را مشخص کنید " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txttitle.Focus();
                flagTitleCheck = 1;
            }


            /*
                var t = title.Trim(); 
                int len = t.Length;
                if (len ==0)
                {
                    MessageBox.Show("!" + " فیلد عنوان نمی‌تواند خالی باشد ");
                    flag_error = 1;
                }
            */

//// moen ......
            int flag_moenError = 0; // فلگی برای تعیین وجود خطا و استفاده در پیام خطای ترکیبی وضعیت معین و ماهیت

            if (rdbhas.Checked) //اگر معین داشته باشد - اگر "دارد" انتخاب شده باشد
            {
                flag_moen = 1;
            }
            else  //اگر "دارد" انتخاب نشده باشد
            {
                if (rdbdhave.Checked) // اگر "ندارد" انتخاب شده باشد
                {
                    flag_moen = 0;
                }
                else // اگر هیچکدام انتخاب نشده باشند
                {
                    //    MessageBox.Show("!" + " وضعیت معین را مشخص کنید");
                    flag_error = 1;
                    flag_moenError = 1;

                }
            }


////ماهیت .......`
            ///
            int flag_natureError = 0; // فلگی برای تعیین وجود خطا و استفاده در پیام خطای ترکیبی وضعیت معین و ماهیت

            if (rdbcreditor.Checked)  // اگر بستانکار انتخاب شد
                {
                    flag_credDebt = 1; // فلگ بستانکار 
                }
                else
                {
                    if (rdbdebtor.Checked) // اگر بدهکار انتخاب شده باشد
                    {
                        flag_credDebt = 0; //فلگ بدهکار
                    } else // اگر هیچکدام انتخاب نشده باشند
                    {
                        flag_natureError = 1;
                        flag_error = 1;
                    }
                }

/////////// پیغام ترکیبی تشخیص خالی بودن ماهیت و وضعیت .......

            if (flag_moenError == 1 && flagTitleCheck!=1) //اگر در بخش معین خطای عدم انتخاب داشتیم
            {
                if (flag_natureError == 1) // اگر هم در بخش معین و هم در وضعیت مشکل عدم انتخاب داشتیم
                {
                    MessageBox.Show("فیلدهای وضعیت معین و ماهیت را تکمیل کنید " + "!", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                }
                else // اگر فقط در بخش معین مشکل عدم انتخاب داشتیم
                {
                    MessageBox.Show( "فیلد وضعیت معین را تکمیل کنید " + "!", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                }
            }
            else if(flag_moenError != 1 && flagTitleCheck != 1) // اگر در بخش معین مشکل عدم انتخاب نداشتیم
            {
                if (flag_natureError == 1) // اگر فقط در وضعیت مشکل عدم انتخاب داشتیم
                {
                    MessageBox.Show("فیلد ماهیت را تکمیل کنید " + "!", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                }
            }
           


  /////////////////////////////////////////////////////
 /// storing in DB

            
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            var query = "insert into [dbo].[پایه-کل] (Tcode,Ttitle,TMstate,nature) values (@code,@title,@state,@nature)";
            SqlCommand cmd = new SqlCommand(query , con);

            cmd.Parameters.AddWithValue("@code", codew1);  // اعتبار سنجی ترک فیلد اجازه عبور با اشتباه را نمی‌دهد بنابراین نیازی به شرط فلگ ارور نیست
            cmd.Parameters.AddWithValue("@title", title);
            if (flag_error != 1 && flagTitleCheck!=1) // دستورات مربوط به درج در جدول تنها زمانی اجرا شوند که خطایی در اعتبار سنجی رخ نداده باشد
            {   
                if (flag_moen == 0)
                {
                    string a = "ندارد";
                    cmd.Parameters.AddWithValue("@state", a);
                }else
                if (flag_moen == 1)
                {
                    string a = "دارد";
                    cmd.Parameters.AddWithValue("@state", a);
                }

                if (flag_credDebt == 0)
                {
                    string cd = "بدهکار";
                    cmd.Parameters.AddWithValue("@nature", cd);
                }else
                if (flag_credDebt == 1)
                {
                    string cd = "بستانکار";
                    cmd.Parameters.AddWithValue("@nature", cd);
                }

                var temp = 0;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception er)
                {

                    temp = 1;
                    
                    if (er.Message.Contains("Violation of PRIMARY KEY constraint"))
                    {
                        MessageBox.Show(" کد تکراری است" + "!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    }
                    else
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                

                con.Close();
                if (temp != 1)
                {
                    MessageBox.Show(" عملیات افزودن با موفقیت انجام شد" + "!", "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, options);
                    txtcodw.ResetText();
                    txttitle.ResetText();
                    rdbcreditor.Checked = false;
                    rdbdebtor.Checked = false;
                    rdbdhave.Checked = false;
                    rdbhas.Checked = false;
                    txtcodw.Focus();
                }
                   
            }
           
        }






        private void txtcodw_Leave(object sender, EventArgs e)
        {
            //// این بخش برای اعتبار سنجی فیلد کد کل است
            //// بخش اعتبار سنجی این فیلد را به دو قسمت تقسیم میکنیم
            ////قسمت اول آن مربوط به خالی نبودن و رعایت طول مجاز کد است 
            ////قسمت دوم مربوط به تکراری نبودن کد است
            //// اگر اشکالی در بخش اول صحت سنجی یافت شود تکراری بودن بررسی نخواهد شد چراکه داده اشتباه است و باید مجدد وارد شود

 ///// بررسی ورود درست اطلاعات توسط کاربر - بخش اول
            var code1w = (txtcodw.Text);
            int flag_errorstate = 0; // اگر خطای اعتبار سنجی در بخش اول وجود داشتته باشد این فلگ برابر یک میشود


            if(txtcodw.Text=="0"|| txtcodw.Text == "00")
            {
                MessageBox.Show(" کد صفر مجاز به ثبت شدن نیست ", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
            }

            if (txtcodw.Text.Length == 1) txtcodw.Text = "0" + txtcodw.Text;
            if (txtcodw.Text.Length != 2 && txtcodw.TextLength != 0)
            {
                MessageBox.Show(" کد نباید بیش از 2 رقم باشد ", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodw.Focus();
                txtcodw.Clear();
                flag_errorstate = 1;
            }
            if (txtcodw.Text.Length == 2)
            {
                    try
                    {
                        int codew1 = int.Parse(code1w); //تبدیل تکست به عدد و بررسی خطای ورود کاراکتر به جای عدد

                    }
                    catch
                    {
                        MessageBox.Show(" فرمت کد کل نادرست است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                        txtcodw.Focus();
                        txtcodw.Clear();
                        flag_errorstate = 1;
                    }

                
             }

            flagtitle = 1; // پرچمی برای اجازه فعال سازی اعتبارسنجی فیلد عنوان



////// بررسی تکراری نبودن کد - بخش دوم ............

            if (flag_errorstate != 1 && txtcodw.Text.Length!=0) // در صورت ورود صحیح اطلاعات تکراری بودن کد چک می‌شود
            {
                int flag_errorstate1 = 0; //////////////   فلگ محلی برای فعال سازی پیامها با مقدار یک در صورت وجود خطا
                var code = txtcodw.Text;
                SqlConnection con = new SqlConnection(strcon);
                con.Open();


                var query2 = " select Tcode from [dbo].[پایه-کل]  ";

                SqlCommand cmd = new SqlCommand(query2, con);



                List<int> templist = new List<int>(); // آرایه برای ذخیره مقادیر فیلدهای کد کل

                SqlDataReader reader = cmd.ExecuteReader();
                // این دستور با توجه به کوئری نوشته شده کدهای کل را از جدول میخواند


                while (reader.Read()) // افزودن تک تک کدها به یک لیست موقت برای انجام عملیات اعتبار سنجی(تکراری نبودن) فیلد
                {
                    var temp = reader.GetInt32(0);
                    templist.Add(temp);
                    
                }



                foreach (var t in templist) // مقایسه تک تک عناصر لیست برای تشخیص تکراری بودن یا نبودن مقدار کد
                {
                    if (int.Parse(code) == t)
                    {
                        flag_errorstate1 = 1;
                        //txtcodw.Clear();
                        //txtcodw.Focus();
                    }

                }
                reader.Close();


                var query = " select Ttitle from [dbo].[پایه-کل] where Tcode = " + code;
                SqlCommand titlecmd = new SqlCommand(query, con);
                SqlDataReader readertitle = titlecmd.ExecuteReader();

                /////////////////////////////
                int flag_message = 0;  //فلگ بررسی انگلیسی یا فارسی و عددی بودن
                // درصورتی که مقدار آن صفر باشد، به معنی انگلیسی بودن متن است
                //در صورتی که مقدار آن غیر صفر باشد، عددی یا فارسی است
                //این امکان برای جبران مشکل نمایش فونت فارسی و انگلیسی باهم و جابه جایی ناخواسته کلمات طراحی شده

                var list = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToList();
                var list1 = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList();
                foreach (var item in list1)
                {
                    list.Add(item);
                }


                ////////////////////////////////

                string title = "empty";
                if (readertitle.Read())
                {
                    title = readertitle.GetString(0);

                }


                foreach (var item in list)
                {
                    if (title.Contains(item.ToString()))
                    {
                        flag_message += 1;
                    }

                }


                if (flag_errorstate1 == 1)
                {
                    MessageBox.Show("  این کد قبلا برای عنوان " + "\"" + title + "\"" +  " ثبت شده است " + "!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txtcodw.ResetText();
                    txtcodw.Focus();
                    
                }

                reader.Close();


                con.Close();



            }
           
            
        }



        private void txttitle_Leave(object sender, EventArgs e)
        {
            if (txttitle.Text.Length != 0)
            {
                if (txttitle.Text.Length > 50 || txttitle.Text.Length < 3)
                {
                    MessageBox.Show( " عنوان باید حداقل سه کاراکتر و حداکثر 50 کاراکتر داشته باشد" + "!" , "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txttitle.ResetText();
                    txttitle.Focus();
                }
            }
            /*
            if(txttitle.Text.Length>50 || txttitle.Text.Trim().Length == 0|| txttitle.Text.Length < 3)
            {    // بررسی خالی بودن فیلد با حذف فاصله از متن + بررسی اینکه طول رشته بین 3 تا 50 باشد
                
                if (flagtitle != 0) {

                    if (txttitle.Text.Length > 50)
                    {
                        MessageBox.Show("!" + " طول رشته‌ی وارد شده در عنوان زیاد است");
                        txttitle.Focus();
                    }
                    else
                    {
                        txttitle.Focus();
                        DialogResult res = new DialogResult();
                        res = MessageBox.Show("!" + " عنوان باید حداقل سه کاراکتر و حداکثر 50 کاراکتر داشته باشد" + "\n" + "آیا می‌خواهید نوشتن فرم را از ابتدا آغاز کنید؟", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.Yes)
                        {
                            txtcodw.Clear();
                            txttitle.Clear();
                            flagtitle = 0;  // غیر فعال سازی اعتبار سنجی فیلد عنوان برای اینکه بتوانیم بدون مشکل به فیلد کد کل بازگردیم
                            // چرا که قبلا(خط بررسی طول رشته) کدی نوشتیم که از ترک این فیلد با مقدار خالی یا غیر صحیح جلو گیری کند
                            txtcodw.Focus();
                        }
                        else
                        {
                            txttitle.Focus();
                        }

                     }

                }////////


            }*/
                
            
        }

        private void txtcodw_TextChanged(object sender, EventArgs e)
        {
            if (txtcodw.TextLength > 2)
            {
                MessageBox.Show(" کد نباید بیش از 2 رقم باشد " + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodw.Focus();
                txtcodw.Clear();
            }

            else
            if(txtcodw.Text.Length!=0)
            try
            {
                int.Parse(txtcodw.Text);
            }
            catch
            {
                MessageBox.Show(" فرمت کد کل نادرست است" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodw.ResetText();
                txtcodw.Focus();
            }

            if (txtcodw.Text.Length == 2)
            {
                txttitle.Focus();
            }
        }

        private void txttitle_Enter(object sender, EventArgs e)
        {
            if (txtcodw.TextLength == 0)
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodw.Focus();
            }
        }

        private void btnadd_Enter(object sender, EventArgs e)
        {
            if (txtcodw.TextLength == 0)
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodw.Focus();
            }
        }

        private void gpboxmoen_Enter(object sender, EventArgs e)
        {
            if (txtcodw.TextLength == 0)
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodw.Focus();
            }
        }

        private void gpboxcd_Enter(object sender, EventArgs e)
        {
            if (txtcodw.TextLength == 0)
            {
                MessageBox.Show(" ابتدا کد کل را وارد کنید" + "!", "خطای اعتبار سنجی", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtcodw.Focus();
            }
        }
    }
}
