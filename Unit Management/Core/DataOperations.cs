using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Unit_Management.Core
{

    class DataOperations
    {
        #region Core Data INI
        OracleConnection dbcon;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable DT;
        //Store Last Autoincrement Value of Executed Query
        private double LastID;
       



       // string connetionString = "User Id=ums;Password=ums;Data Source=103.245.205.241/unitdb;" + "Pooling=true;Min Pool Size=0;Max Pool Size=10;Connection Lifetime=120;Connection Timeout=60;" + "Incr Pool Size=1; Decr Pool Size=3";
       string connetionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=103.245.205.241)(Port=1555)))(CONNECT_DATA=(SERVICE_NAME=unitdb)));User Id=ums;Password=ums;"; 
        #endregion

        #region Core Data Operation
        public OracleConnection Connection()
        {

            dbcon = new OracleConnection(connetionString);
            dbcon.Open();
            return dbcon;
        }
        public double getLastInsertedID()
        {
            return LastID;
        }
        public DataTable query(string query)
        {
            OracleConnection dbcon = new OracleConnection();
            dbcon = Connection();
            DataTable dt = new DataTable(); 
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = dbcon;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.InitialLONGFetchSize = -1;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;

            da.Fill(dt);
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }
            return dt;
        }

        public DataTable select(string table_name, string column_name, string where = null, string order_by = null)
        {
            string query = "";
            DataTable dt = new DataTable();

            if (where == null && order_by == null)
            {
                query = "SELECT " + column_name + " FROM " + table_name;

            }
            else if (where != null && order_by == null)
            {
                query = "SELECT " + column_name + " FROM " + table_name + " WHERE " + where;


            }
            else if (where == null && order_by != null)
            {
                query = "SELECT " + column_name + " FROM " + table_name + " order by " + order_by;

            }
            else if (where != null && order_by != null)
            {
                query = "SELECT " + column_name + " FROM " + table_name + " WHERE " + where + " order by " + order_by;


            }
            else
            {
                query = null;
            }


            OracleConnection dbcon = new OracleConnection();
            dbcon = Connection();
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = dbcon;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.InitialLONGFetchSize = -1;
            OracleDataAdapter da = new OracleDataAdapter(cmd);

            da.Fill(dt);
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }

           


            return dt;
        }
        public OracleDataAdapter selectAdapter(string table_name, string column_name, string where = null, string order_by = null, string group_by = null)
        {
            string query = "";

            if (where == null && order_by == null)
            {
                query = "SELECT " + column_name + " FROM " + table_name +" " +group_by;

            }
            else if (where != null && order_by == null)
            {
                query = "SELECT " + column_name + " FROM " + table_name + " WHERE " + where + " " + group_by;


            }
            else if (where == null && order_by != null)
            {
                query = "SELECT " + column_name + " FROM " + table_name +  " " + group_by+" order by " + order_by;

            }
            else if (where != null && order_by != null)
            {
                query = "SELECT " + column_name + " FROM " + table_name + " WHERE " + where +" " + group_by +" order by " + order_by;


            }
            else
            {
                query = null;
            }

            OracleConnection dbcon = new OracleConnection();
            dbcon = Connection();
            if (dbcon.State == ConnectionState.Closed)
            {
                dbcon.Open();
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = dbcon;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);

           
            if (dbcon.State == ConnectionState.Open)
            {
                dbcon.Close();
            }

            return da;
        }
        public string insert(string table_name, Dictionary<string, string> data, bool ReturnBoolean = false)
        {
            LastID = 0;
            try
            {
                string query = null;

                string fieldNames = String.Join(",", data.Keys);
                string fieldValues = ":" + String.Join(",:", data.Keys);


                query = "INSERT INTO " + table_name + " (" + fieldNames + ") VALUES (" + fieldValues + ")";





                OracleConnection dbcon = new OracleConnection();
                dbcon = Connection();
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = dbcon;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

               
               
              
                foreach (string key in data.Keys)
                {
                    //if (CheckDate(data[key]))
                    //{
                    //    OracleParameter param = new OracleParameter();
                    //    param.ParameterName = key;
                    //    param.OracleDbType = OracleDbType.Date;
                    //    param.Value = data[key];
                    //    cmd.Parameters.Add(param);
                    //}
                    //else
                    //{
                        cmd.Parameters.Add(new OracleParameter(key, data[key]));

                    //    OracleParameter param = new OracleParameter();
                    //    param.ParameterName = key;
                    //    param.OracleDbType = OracleDbType.Long;
                    //    param.Value = data[key];
                    //    cmd.Parameters.Add(param);
                    //}

                    
                }



               
                cmd.ExecuteNonQuery();

                if (dbcon.State == ConnectionState.Open)
                {
                    dbcon.Close();
                }
                if (ReturnBoolean)
                {
                    return "true";
                }
                return "Record Saved Successfully!";
            }
            catch (MySqlException ex)
            {
                if (ReturnBoolean)
                {
                    return "false";
                }
                return ex.Message;
            }
          

        }

        public string update(string table_name, Dictionary<string, string> data, string where = null, bool ReturnBoolean = false)
        {
            try
            {
                string query = null;

                string fieldNames = String.Join(",", data.Keys);
                string fieldValues = ":" + String.Join(",:", data.Keys);


                List<string> updates = new List<string>();
                string value = null;
                foreach (string key in data.Keys)
                {

                    value = key;
                    updates.Add(value + "=:" + key + "");

                }

                value = String.Join(", ", updates.ToArray());
                if (where != null)
                {
                    query = "UPDATE " + table_name + " SET " + value + " WHERE " + where;


                }

                Debug.WriteLine(query);
                OracleConnection dbcon = new OracleConnection();
                dbcon = Connection();
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = dbcon;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;

                
                foreach (string key in data.Keys)
                {
                    cmd.Parameters.Add(key, data[key]);
                }



             
                cmd.ExecuteNonQuery();
                dbcon.Close();
                if (ReturnBoolean)
                {
                    return "true";
                }
                return "Record updated Successfully!";
            }
            catch (OracleException ex)
            {
                if (ReturnBoolean)
                {
                    return "false";
                }
                return ex.Message;
            }
          

        }
        //Delete Data From A Table 
        public string deleteData(string TableName,string Where)
        {
            try
            {
                if (TableName != "" || TableName != null)
                {
                    dbcon = Connection();
                    if (dbcon.State == ConnectionState.Closed)
                    {
                        dbcon.Open();
                    }
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = dbcon;


                    cmd.CommandText = "DELETE FROM " + TableName + " WHERE " + Where + "";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    dbcon.Close();
                    return "Record Deleted!";
                }
                else
                {
                    return "Invalid Table Name or Condition";
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    return "Can't delete this record. Child Record Exist.";
                }
                return ex.Message;
            }


        }
        public bool CheckDate(String date)
        {

            try
            {

                DateTime dt = DateTime.Parse(date);

                return true;

            }
            catch
            {

                return false;

            }

        }
        public string validateTextBox(TextBox textbox)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                return null;
            }
            else
            {
                return textbox.Text.Trim();
            }
        }
        public string validateTextBoxAsNumber(TextBox textbox)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                return "0";
            }
            else
            {
                return textbox.Text.Trim();
            }
        }
        public string validateDate(DateTimePicker dtpDate)
        {
            return dtpDate.Value.Date.ToString("yyyy-MM-dd HH:mm");
        }
        public bool onlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                return true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                return  true;
            }
            return false;
        }
        public string validateComBox(ComboBox combox, bool RetText = false)
        {
            if (combox.SelectedIndex == -1)//Nothing selected
            {
                return null;
            }
            else
            {
                if (!RetText)
                {
                    if (combox.SelectedValue == null)
                    {
                        return combox.SelectedItem.ToString();
                    }
                    else
                    {
                        return combox.SelectedValue.ToString();
                    }
                }
                else
                {
                    return combox.Text;
                }

            }
        }
        #endregion



        

        public string GetCurrentTimeStamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public DataTable DBGetRankList(string id = null)
        {
            DataTable data = null;
            if (id == null)
            {
                data = this.query("SELECT * FROM RANK_MASTER ORDER BY NAME");
            }
            else
            {
                data = this.query("SELECT * FROM RANK_MASTER WHERE CODE='"+id.Trim()+"' ORDER BY NAME");
            }
            return data;
        }
        public DataTable DBGetTradeList(string id = null)
        {
            DataTable data = null;
            if (id == null)
            {
                data = this.query("SELECT * FROM TRADE_MASTER ORDER BY NAME");
            }
            else
            {
                data = this.query("SELECT * FROM TRADE_MASTER WHERE CODE='" + id.Trim() + "' ORDER BY NAME");
            }
            return data;
        }
        public DataTable DBGetDivisialList(string id = null)
        {
            DataTable data = null;
            if (id == null)
            {
                data = this.query("SELECT * FROM DIVISIONS ORDER BY NAME");
            }
            else
            {
                data = this.query("SELECT * FROM DIVISIONS WHERE ID='" + id.Trim() + "' ORDER BY NAME");
            }
            return data;
        }
        public DataTable DBGetDistrictList(string id = null)
        {
            DataTable data = null;
            if (id == null)
            {
                data = this.query("SELECT * FROM DISTRICTS ORDER BY NAME");
            }
            else
            {
                data = this.query("SELECT * FROM DISTRICTS WHERE ID='" + id.Trim() + "' ORDER BY NAME");
            }
            return data;
        }
        public DataTable DBGetUpazilaList(string id = null)
        {
            DataTable data = null;
            if (id == null)
            {
                data = this.query("SELECT * FROM UPAZILAS ORDER BY NAME");
            }
            else
            {
                data = this.query("SELECT * FROM UPAZILAS WHERE ID='" + id.Trim() + "' ORDER BY NAME");
            }
            return data;
        }
        public DataTable DBGetCompanyList(string id = null)
        {
            DataTable data = null;
            if (id == null)
            {
                data = this.query("SELECT * FROM ORG_MASTER WHERE LEV =2 AND TYPE =3 ORDER BY NAME");
            }
            else
            {
                data = this.query("SELECT * FROM ORG_MASTER WHERE LEV =2 AND TYPE =3 AND CODE="+id.Trim()+" ORDER BY NAME");
            }
            return data;
        }
        public DataTable DBGetAllOfficers()
        {
            DataTable data = null;
           
                data = this.query("SELECT CODE,FIRST_NAME || ' '|| LAST_NAME  NAME FROM VW_ARMY_MASTER_INFO WHERE LENGTH(regexp_replace(ARMY_NO,'[[:alpha:]]')) + LENGTH(regexp_replace(ARMY_NO,'[[:digit:]]')) = LENGTH(ARMY_NO)");
            
            return data;
        }
        public string DBGetMarksGradeCode(string Marks)
        {
            string CODE = null;
            DataTable DT = query("SELECT CODE,GRADE FROm MARKS_GRADE WHERE " + Marks + " BETWEEN FROM_MARKS AND TO_MARKS");
            foreach (DataRow row in DT.Rows)
            {
                CODE = row["CODE"].ToString();
            }
            return CODE;
        }
        public string base64ImageEncode(string path)
        {
            Image image;
            using (image = Image.FromFile(path))
            {
                image = ScaleImage(image, 152, 189);
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, ImageFormat.Jpeg);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public Image DBLoadImage(string imageString)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(imageString);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
        public string DBGetArmyMasterInfoIDByArmyNo(string ARMY_NO)
        {
            string CODE = null;
            DataTable DT= query("SELECT CODE FROM ARMY_MASTER_INFO WHERE ARMY_NO='" + ARMY_NO + "'");
            foreach (DataRow row in DT.Rows)
            {
                CODE= row["CODE"].ToString();
            }
            return CODE;
        }
        public DataTable DBGetUnitList()
        {
           
            DataTable DT = query("SELECT * FROM ORG_MASTER WHERE \"TYPE\" =3 ORDER BY NAME");

            return DT;
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
