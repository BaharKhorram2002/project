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
    public partial class frmKholaseVaziatW : Form
    {
        public frmKholaseVaziatW()
        {
            InitializeComponent();
            
            
            
        }
        ////////////
        public string strcon = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=finalProject;Integrated Security=True";
        public MessageBoxOptions options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
        ///////////
        //


        /////////////////////////////////////////////////////////////////////////////////
        private int remaining(string date, char fT)
        {
            string tableName = "[dbo].[سند-کل]";
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
            
            string strcmd = "";
            if (fT == 'F') { strcmd = "select Tprice, Tnature from " + tableName + " where  Tdate != '" + date + "' and Tdate between '" + minDate + "' and '" + date + "'"; }
            else if (fT == 'T') strcmd = "select Tprice, Tnature from " + tableName + " where Tdate between '" + minDate + "' and '" + date + "'";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int sum = 0;
            while (reader.Read())
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
        /////////////////////////////////////////////////////////////////////////////
        public int pricem = 0;
        public void tblM(int codew,string fd , string td)
        {
            pricem = 0;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string strcmd = "select Tprice, Tnature from [dbo].[سند-معین] where Tcode>"+codew*1000+" and Tcode<"+(codew+1)*1000+" and Tdate between '"+fd+"' and '"+td+"'";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                var temp = int.Parse(reader.GetValue(0).ToString());
                var tempN = reader.GetString(1);
                if (tempN == "بدهکار")
                {
                    temp = -temp;
                }
                pricem = pricem + temp;
            }

            reader.Close();
            con.Close();

        }

        public int PreviousRemaining = 0;
        public void PRem(int codew, string tabletype, string fdate)
        {
            PreviousRemaining = 0;
            string codeMoen = "0" ,uppcode="";
            int upperCode = 0;
            string strcmd = "";
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string table = "",code="";
            if(tabletype == "W")
            {
                table = "[dbo].[سند-کل]";
                code = "TcodeW";
                strcmd = "select Tprice, Tnature from " + table + " where " + code + "= " + codew + " and Tdate <'" + fdate + "' ";

            }
            else if (tabletype == "M")
            {
                table = "[dbo].[سند-معین]";
                code = "Tcode";
                upperCode = codew + 1;
                upperCode = upperCode * 1000;
                codew = codew * 1000;
                codeMoen = codew.ToString();
                uppcode = upperCode.ToString();
                if (codeMoen.Length == 4) codeMoen = "0" + codeMoen;
                if (uppcode.Length == 4) uppcode = "0" + uppcode;
                strcmd = "select Tprice, Tnature from " + table + " where " + code + ">= " + codeMoen +" and "+ code +"<"+uppcode+ " and Tdate <'" + fdate + "' ";

            }
            
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
                else if(t2 == "بستانکار")
                {
                    PreviousRemaining = PreviousRemaining + t1;
                }
            }
            reader.Close();
            con.Close();
        
        }

        public int priceW = 0;
        public void tblW(int codew, string fd , string td)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            priceW = 0;
            string strcmd = "select Tprice, Tnature from [dbo].[سند-کل] where TcodeW=" + codew + " and Tdate between '" + fd + "' and '" + td + "'";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                var temp = int.Parse(reader.GetString(0));
                var tempN = reader.GetString(1);
                if (tempN == "بدهکار")
                {
                    temp = -temp;
                }
                priceW = priceW + temp;
            }

            reader.Close();
            con.Close();
        }

        public List<string> lst = new List<string>();
        //public List<string> lstcodenature = new List<string>();
        public void codelist()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "select * from [dbo].[پایه-کل]";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var temp = reader.GetInt32(0);
                string tem = reader.GetString(2);
                string t = reader.GetString(3);
                string t2 = reader.GetString(1);
                lst.Add(temp + "*" +tem+"*"+t+"*"+t2);
               // -lstcodenature.Add()
                
            }
            reader.Close();
            con.Close();
        }

        public void temptable()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string str = "drop table if exists [dbo].[tmptable] ";
            SqlCommand cmd2 = new SqlCommand(str, con);
            string strcmd = "create table tmptable( [\"ردیف\"] int IDENTITY(1,1),  [\"کد کل\"] int, [\"عنوان\"'] nvarchar(20), [\"معین\"] nvarchar(7), [\"ماهیت\"] nvarchar(20), [\"مانده اول دوره\"] nvarchar(50)," +
                "[\"بدهکار\"] nvarchar(50), [\"بستانکار\"] nvarchar(50), [\"مانده پایان دوره\"] nvarchar(50));";
            
            SqlCommand cmd = new SqlCommand(strcmd, con);
            cmd2.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            con.Close();

        }

        public void addtemp(int codeW, string M , string debtor, string creditor, string remainder,string prRemaining,string nature,string title)
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            string strcmd = "insert into tmptable([\"کد کل\"],[\"عنوان\"'],[\"معین\"],[\"ماهیت\"],[\"مانده اول دوره\"],[\"بدهکار\"]," +
                "[\"بستانکار\"],[\"مانده پایان دوره\"]) values (@cW,@title, @m, @n, @prem, @deb, @cred, @rem)";
            
            SqlCommand cmd = new SqlCommand(strcmd, con);
            
            cmd.Parameters.AddWithValue("@cW", codeW);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@m", M);
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

        public void clearDGV()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            string strcmd = "delete from [dbo].[tmptable]";
            //string strcmd2 = "select * from [dbo].[tmptable]";
            //string strcmd2 = "drop table [dbo].[tmptable] ";
            //SqlCommand cmd = new SqlCommand(strcmd2, con);
            SqlCommand cmd = new SqlCommand(strcmd, con);
            cmd.ExecuteNonQuery();
           // SqlCommand cmd2 = new SqlCommand

            SqlDataAdapter sda = new SqlDataAdapter(strcmd, con);
            DataTable dtable = new DataTable();
            sda.Fill(dtable);
            datagridview.DataSource = dtable;
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


                if (tempState == "دارد")
                {
                    if (messageEnable == 1)
                        MessageBox.Show("انتخاب این کد مجاز نیست" + "!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    returnval = 1;

                }




                //title = tempTitle;
                //returnval = 1;

            }

            if (flagMatch != 1)
            {
                if (messageEnable == 1)
                    MessageBox.Show(" کد وارد شده تعریف نشده است" + "!", " خطای اعتبارسنجی کد", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                returnval = 1;

            }

            reader.Close();
            con.Close();
            return returnval;

        }
        ////////////////////////////////




        public int flag = 0;
        /////////////////////////////////////////////////////////////////////////////
        private void btnshow_Click(object sender, EventArgs e)
        {
            
            
            datagridview.Columns.Clear();
            int flagEnable = 1;
            //datagridview.Rows.Clear();
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

            string fd = "", fm = "", fy, td = "", tm = "", ty;
            if (txtboxFday.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxFday.Focus();

            }
            else if (txtboxFmonth.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxFmonth.Focus();
            }
            else if (txtboxFyear.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxFyear.Focus();
            }
            else if (txtboxTday.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxTday.Focus();
            }
            else if (txtboxTmonth.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                txtboxTmonth.Focus();
            }
            else if (txtboxTyear.Text.Length == 0)
            {
                flagEnable = 1;
                MessageBox.Show(" بازه را به طور کامل مشخص کنید " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show( "بازه نامعتبر است" + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txtboxFyear.ForeColor = Color.Red;
                    txtboxTyear.ForeColor = Color.Red;
                    flagEnable = 1;
                }
                else if (int.Parse(tm) < int.Parse(fm) && int.Parse(ty) == int.Parse(fy))
                {
                    MessageBox.Show("بازه نامعتبر است" + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txtboxFmonth.ForeColor = Color.Red;
                    txtboxTmonth.ForeColor = Color.Red;
                    flagEnable = 1;
                }
                else if (int.Parse(td) < int.Parse(fd) && int.Parse(ty) == int.Parse(fy) && int.Parse(tm) == int.Parse(fm))
                {
                    MessageBox.Show("بازه نامعتبر است" + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                        //MessageBox.Show("!" + "بازه نامعتبر است", "خطای اعتبار سنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        flagEnable = 1;
                        //fKabise = 0;
                    }
                    ///// اگر باقی مانده تقسیم یک سال بر 4 برابر 3 باشد آن سال کبیسه است

                    else if (int.Parse(fm) == 12)
                    {
                        if (rf == 3)//سال کبیسه است
                        {

                            if (int.Parse(fd) > 30)
                            {
                                //txtboxFyear.ForeColor = Color.Green;
                                txtboxFmonth.ForeColor = Color.Red;
                                txtboxFday.ForeColor = Color.Red;
                                // MessageBox.Show("!" + "بازه نامعتبر است", "خطای اعتبار سنجی سال کبیسه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                flagEnable = 1;
                                //fKabise = 1;
                            }
                            else
                            {
                                if (flagEnable != 1)
                                    flagEnable = 0;
                                //fKabise = 0;
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
                                //MessageBox.Show("!" + "بازه نامعتبر است", "خطای اعتبار سنجی سال کبیسه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                flagEnable = 1;
                                //fKabise = 1;
                            }
                            else
                            {
                                if (flagEnable != 1)
                                    flagEnable = 0;
                                //fKabise = 0;
                            }
                        }
                    }
                    // if (!(fKabise == 0 && flagEnable == 1))
                    if ((int.Parse(tm) > 6 && int.Parse(tm) < 12) && int.Parse(td) > 30 && flagEnable == 0)
                    {

                        txtboxTmonth.ForeColor = Color.Red;
                        txtboxTday.ForeColor = Color.Red;
                        //MessageBox.Show("!" + "بازه نامعتبر است", "خطای اعتبار سنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        flagEnable = 1;
                        //fKabise = 0;
                    }
                    else if (int.Parse(tm) == 12)
                    {

                        if (rt == 3) // سال کبیسه است
                        {

                            if (int.Parse(td) > 30)
                            {
                                //txtboxTyear.ForeColor = Color.Green;
                                txtboxTmonth.ForeColor = Color.Red;
                                txtboxTday.ForeColor = Color.Red;
                                //MessageBox.Show("!" + "بازه نامعتبر است", "خطای اعتبار سنجی سال کبیسه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                flagEnable = 1;
                                //fKabise = 1;
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
                                if (flagEnable != 1)
                                    flagEnable = 0;
                                //fKabise = 0;
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

            List<string> lstCodePrice = new List<string>();
            List<string> resultlist = new List<string>();
            if (flagEnable == 0)
            {
                foreach (var tmp in lst)
                {
                    int flagWM = 0;// حالت بی طرف
                    var a0 = tmp.Split('*')[0];////code
                    var a1 = tmp.Split('*')[1];/////MW
                    var a2 = tmp.Split('*')[2];/////nature
                    var title = tmp.Split('*')[3];

                    if (a1 == "دارد")
                    {
                        PRem(int.Parse(a0), "M", fromDate);
                        tblM(int.Parse(a0), fromDate, ToDate);
                        lstCodePrice.Add(a0 + "*" + pricem + "*" + a1);
                        flagWM = 1;//معین دارد
                    }
                    else if (a1 == "ندارد")
                    {
                        PRem(int.Parse(a0), "W", fromDate);
                        tblW(int.Parse(a0), fromDate, ToDate);
                        lstCodePrice.Add(a0 + "*" + priceW + "*" + a1);
                        flagWM = 2;//معین ندارد

                    }



                    string rem, deb = "", cred = "";
                    int temp = 0;

                    if (flagWM == 1)//معین دارد
                    {
                        temp = pricem;
                        ////پیش فرض بستانکار
                        deb = "0";
                        cred = pricem.ToString();
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
                    }
                    else if (flagWM == 2) // معین ندارد
                    {
                        temp = priceW;
                        ////پیش فرض بستانکار
                        deb = "0";
                        cred = priceW.ToString();
                        if (priceW < 0)
                        {
                            deb = (-priceW).ToString();
                            cred = "0";
                        }
                        else if (priceW == 0)
                        {
                            deb = "0";
                            cred = "0";
                        }
                    }



                    var t = temp + PreviousRemaining;
                    if (t < 0)
                    {
                        rem = (Math.Abs(t)).ToString()/* + " بدهکار "*/;
                    }
                    else if (t > 0)
                    {
                        rem = (Math.Abs(t)).ToString() /*+ " بستانکار "*/;
                    }
                    else rem = "0";

                    int PR = PreviousRemaining;
                    if (PR < 0) PR = Math.Abs(PR);

                    resultlist.Add(a0 + "*" + a1 + "*" + deb + "*" + cred + "*" + rem + "*" + PR + "*" + a2 + "*" + title);
                    //lblPRemaining.Text = rem;

                }

                temptable();
                // datagridview.AllowDrop = true;
                datagridview.Columns.Clear();
                clearDGV();

                foreach (var item in resultlist)
                {
                    string[] it = item.Split('*');
                    addtemp(int.Parse(it[0]), it[1], it[2], it[3], it[4], it[5], it[6], it[7]);
                }


                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string strcmd = "select * from  tmptable ";
                string strcmd2 = "drop table [dbo].[tmptable] ";
                SqlCommand cmd = new SqlCommand(strcmd2, con);
                SqlDataAdapter sda = new SqlDataAdapter(strcmd, con);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                datagridview.DataSource = dtable;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            datagridview.Columns.Clear();
            
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
                MessageBox.Show(" فرمت فیلد روز نادرست است " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show( " عدد وارد شده برای روز صحیح نیست " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                MessageBox.Show( " فرمت فیلد ماه نادرست است " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show( " عدد وارد شده برای ماه صحیح نیست " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
                    txt.ResetText();
                    txt.Focus();
                }
            }
        }

        private void txtboxTday_TextChanged(object sender, EventArgs e)
        {
            //txtboxFday.ForeColor = Color.Black;
            //txtboxFmonth.ForeColor = Color.Black;
           // txtboxFyear.ForeColor = Color.Black;
            txtboxTday.ForeColor = Color.Black;
            txtboxTmonth.ForeColor = Color.Black;
            txtboxTyear.ForeColor = Color.Black;

            TextBox txt = txtboxTday;

            int flagError = 0;
            flagError = NumCheck(txt.Text);
            if (flagError == 1 && txt.Text.Length != 0)
            {
                MessageBox.Show(" فرمت فیلد روز نادرست است " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show( " عدد وارد شده برای روز صحیح نیست " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                MessageBox.Show(" فرمت فیلد ماه نادرست است " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show(" عدد وارد شده برای ماه صحیح نیست " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                MessageBox.Show( " فرمت فیلد سال نادرست است " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show( " عدد وارد شده برای سال صحیح نیست " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                MessageBox.Show(" فرمت فیلد سال نادرست است " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
                    MessageBox.Show( " عدد وارد شده برای سال صحیح نیست " + "!", " خطای اعتبارسنجی ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, options);
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
