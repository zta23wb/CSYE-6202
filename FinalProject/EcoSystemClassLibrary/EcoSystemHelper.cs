using EcoSystemLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;

namespace EcoSystemClassLibrary
{
    public static class EcoSystemHelper
    {
        private static EcoSystem business;

        private static string connectionString = @"Data Source = DESKTOP-IT2IGLD\SQLEXPRESS; Initial Catalog = FinalProject;Integrated Security=SSPI";

        private static string[] roleComboList = new[] { "Patient", "Doctor", "Nurse" };

        public static string[] GetRoleComboList()
        {
            return roleComboList;
        }

        public static bool FindStringInGivenTable(string tableName, string columnName, string myString)
        {
            bool exists = false;
            string result = String.Empty;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectString = "select " + columnName + " from " + tableName + " where " + columnName + " = '" + myString + "'";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(selectString, con))
                {
                    result = (string)cmd.ExecuteScalar();
                }
                con.Close();
            }
            if (result != null)
            {
                exists = true;
            }
            return exists;
        }

        public static string FindUserRole(string a, string b)
        {
            string userRole = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter cmd;
                cmd = new SqlDataAdapter("select * from UserAccountTable where username='" + a + "' and password='" + b + "'", connection);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    userRole = dt.Rows[0]["Role"].ToString();
                }
                connection.Close();
            }
            return userRole;
        }

        public static string GetConnectionString()
        {
            //connectionString = @"Data Source = DESKTOP-IT2IGLD\SQLEXPRESS; Initial Catalog = FinalProject;Integrated Security=SSPI";
            return connectionString;
        }

        public static bool IsFieldFilled(string a)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a))
            {
                return false;
            }
            return true;
        }

        public static bool IsTwoFieldsFilled(string a, string b)
        {
            if (IsFieldFilled(a) == false)
            {
                return false;
            }

            if (IsFieldFilled(b) == false)
            {
                return false;
            }

            return true;
        }

        public static bool IsThreeFieldsFilled(string a, string b, string c)
        {
            if (String.IsNullOrEmpty(a) == true || String.IsNullOrEmpty(b) == true || String.IsNullOrEmpty(c) == true)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(a) == true || String.IsNullOrWhiteSpace(b) == true || String.IsNullOrWhiteSpace(c) == true)
            {
                return false;
            }

            return true;
        }

        public static bool IsFiveFieldsFilled(string a, string b, string c, string d, string e)
        {
            if (String.IsNullOrEmpty(a) == true || String.IsNullOrEmpty(b) == true || String.IsNullOrEmpty(c) == true
                || String.IsNullOrEmpty(d) == true || String.IsNullOrEmpty(e) == true)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(a) == true || String.IsNullOrWhiteSpace(b) == true || String.IsNullOrWhiteSpace(c) == true
                || String.IsNullOrWhiteSpace(d) == true || String.IsNullOrWhiteSpace(e) == true)
            {
                return false;
            }
            return true;
        }

        public static bool IsFourFieldsFilled(string a, string b, string c, string d)
        {
            if (String.IsNullOrEmpty(a) == true || String.IsNullOrEmpty(b) == true || String.IsNullOrEmpty(c) == true
                || String.IsNullOrEmpty(d) == true)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(a) == true || String.IsNullOrWhiteSpace(b) == true || String.IsNullOrWhiteSpace(c) == true
                || String.IsNullOrWhiteSpace(d) == true)
            {
                return false;
            }
            return true;
        }

        public static void RemoveRowFromTable(string tableName, string keyValue, int myKeyValue)
        {
            SqlTransaction trans = null;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "DELETE FROM " + tableName + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con, trans);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    //cmd.Connection.Open();
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }catch(SqlException ex)
                {
                    if(trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
                }
           
        }

        public static void RemoveHealthProfessionFromTable(Enterprise enterprise, UserAccount useraccount)
        {
            RemoveRowFromTable("UserAccountTable", "UserID", useraccount.UserAccountID);
        }

        public static void RemoveAppointmentFromTable(Enterprise enterprise, Appointment appointment)
        {
            RemoveRowFromTable("AppointmentTable", "AppointmentID", appointment.AppointmentID);
        }

        public static void RemoveEnterpriseAdminFromBusiness(int userID)
        {
            RemoveRowFromTable("UserAccountTable", "UserID", userID);
        }

        public static void RemoveEnterpriseFromBusinessClass(int b)
        {
            RemoveRowFromTable("EnterpriseTable", "EnterpriseID", b);
        }

        public static void AddEnterpriseIntoBusinessClass(Enterprise e)
        {
            AddEnterpriseIntoTable(e);
        }

        public static void AddEnterpriseIntoTable(Enterprise e)
        {
            SqlTransaction trans = null;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO EnterpriseTable values (@Name, @Location)", con))
                    {
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("Name", e.Name);
                        cmd.Parameters.AddWithValue("Location", e.Location);
                        //cmd.Connection.Open();

                        trans.Commit();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }catch(Exception ex)
                {
                    if(trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
                }
            
        }

        public static void EditEnterpriseAdminInBusiness(UserAccount ua)
        {
            EditTwoParametersInTable("UserAccountTable", "UserID", ua.UserAccountID, "Password", "Name", ua.Password, ua.Name);

        }

        public static void EditTwoParametersInTable(string tableName, string keyValue, int myKeyValue, string pOne, string pTWo, string myPone, string myPtwo)
        {
            SqlTransaction trans = null;
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    string atPone = "@" + pOne;
                    string atPtwo = "@" + pTWo;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pOne + " = " + atPone + ", " + pTWo + "= " + atPtwo + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPone, myPone);
                    cmd.Parameters.AddWithValue(atPtwo, myPtwo);
                    //cmd.Connection.Open();
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }catch(SqlException ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
        }

        public static void EditUserInBusiness(UserAccount useraccount, string password, string name)
        {
            EditTwoParametersInTable("UserAccountTable", "UserID", useraccount.UserAccountID, "Password", "Name", useraccount.Password, useraccount.Name);
        }

        public static void EditEnterpriseFromBusinessClass(Enterprise enterprise, string name, string location)
        {
            EditTwoParametersInTable("EnterpriseTable", "EnterpriseID", enterprise.EnterpriseID, "Name", "Location", name, location);
        }

        public static bool IsInputLegitDouble(string s)
        {
            try
            {
                double d = Double.Parse(s);
                if (d < 0.0)
                {
                    return false;
                }
                return true;
            } catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void EditOneStringOneDoubleInTable(string tableName, string keyValue, int myKeyValue, string pOne, string pTWo, string myPone, double myPtwo)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    string atPone = "@" + pOne;
                    string atPtwo = "@" + pTWo;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pOne + " = " + atPone + ", " + pTWo + "= " + atPtwo + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPone, myPone);
                    cmd.Parameters.AddWithValue(atPtwo, myPtwo);
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }catch(SqlException ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
        }

        public static void EditOneStringInTable(string tableName, string keyValue, int myKeyValue, string pOne, object myPone)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    string atPone = "@" + pOne;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pOne + " = " + atPone + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPone, myPone);
                    
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    
                }catch(SqlException ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
        }

        public static void EditOneDoubleInTable(string tableName, string keyValue, int myKeyValue, string pOne, object myPone)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    trans = con.BeginTransaction();

                    string atPone = "@" + pOne;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pOne + " = " + atPone + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPone, myPone);
                    cmd.Transaction = trans;
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }catch (SqlException ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
        }

        public static void EditOneIntInTable(string tableName, string keyValue, int myKeyValue, string pOne, int myPone)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    trans = con.BeginTransaction();
                    string atPone = "@" + pOne;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pOne + " = " + atPone + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPone, myPone);
                    cmd.Connection.Open();
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
        }

        public static void EditOneStringOneIntInTable(string tableName, string keyValue, int myKeyValue, string pOne, string pTWo, string myPone, int myPtwo)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    string atPone = "@" + pOne;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pOne + " = " + atPone + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPone, myPone);
                    cmd.Transaction = trans;
                    
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (SqlException ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlTransaction transTwo = null;
                try {
                    con.Open();
                    transTwo = con.BeginTransaction();
                    string atPtwo = "@" + pTWo;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pTWo + " = " + atPtwo + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Transaction = transTwo;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPtwo, myPtwo);
                    transTwo.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (SqlException ex)
                {
                    if (transTwo != null)
                    {
                        transTwo.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static void EditThreeStringInTable(string tableName, string keyValue, int myKeyValue, string pOne, string pTWo, string pThree, string myPone, string myPtwo, string myPthree)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    trans = con.BeginTransaction();
                    string atPone = "@" + pOne;
                    string atPtwo = "@" + pTWo;
                    string atPthree = "@" + pThree;
                    string atKeyValue = "@" + keyValue;
                    string CmdString = "UPDATE " + tableName + " SET " + pOne + " = " + atPone + ", " + pTWo + "= " + atPtwo + ", " + pThree + "= " + atPthree + " WHERE " + keyValue + " = " + atKeyValue;
                    SqlCommand cmd = new SqlCommand(CmdString, con);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue(atKeyValue, myKeyValue);
                    cmd.Parameters.AddWithValue(atPone, myPone);
                    cmd.Parameters.AddWithValue(atPtwo, myPtwo);
                    cmd.Parameters.AddWithValue(atPthree, myPthree);
                    cmd.Connection.Open();
                    trans.Commit();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
        }

        public static void AddNewUserInTable(string tableName, string pOne, string pTwo, string pThree, string pFour, string pFive,
            string myPone, string myPtwo, string myPthree, string myPfour, int myPfive)
        {
            string atPone = "@" + pOne;
            string atPtwo = "@" + pTwo;
            string atPthree = "@" + pThree;
            string atPfour = "@" + pFour;
            string atPfive = "@" + pFive;

            string cmdString = "INSERT INTO " + tableName + " (" +
                pOne + ", " + pTwo + ", " + pThree + ", " + pFour + ", " + pFive + ") VALUES (" +
                atPone + ", " + atPtwo + ", " + atPthree + ", " + atPfour + ", " + atPfive + ")";
            SqlTransaction trans = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try {
                    trans = conn.BeginTransaction();
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = cmdString;
                        comm.Transaction = trans;
                        comm.Connection.Open();
                        comm.Parameters.AddWithValue(atPone, myPone);
                        comm.Parameters.AddWithValue(atPtwo, myPtwo);
                        comm.Parameters.AddWithValue(atPthree, myPthree);
                        comm.Parameters.AddWithValue(atPfour, myPfour);
                        comm.Parameters.AddWithValue(atPfive, myPfive);
                        trans.Commit();
                        comm.ExecuteNonQuery();
                        comm.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                conn.Close();
            }
        }

        public static EcoSystem GetInstance()
        {
            business = null;
            business = new EcoSystem();
            LoadEnterpriseIntoBusiness(business);
            LoadUserAccountIntoBusiness(business);
            LoadAppointmentTableIntoBusiness(business);
            return business;
        }

        public static UserAccount AuthenticateUser(EcoSystem e, string a, string b)
        {
            return e.AuthenticateUser(a, b);
        }

        private static void LoadEnterpriseIntoBusiness(EcoSystem Business)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT * FROM EnterpriseTable", con);
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Enterprise enterprise = Business.EnterpriseDirectory.AddEnterprise();
                    enterprise.EnterpriseID = Convert.ToInt32(reader["EnterpriseID"].ToString());
                    enterprise.Name = reader["Name"].ToString();
                    enterprise.Location = reader["Location"].ToString();
                }
                reader.Close();
                cmd.Connection.Close();
                con.Close();
            }
        }

        private static void LoadUserAccountIntoBusiness(EcoSystem Business)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                foreach (Enterprise enterprise in Business.EnterpriseDirectory.EnterpriseList)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountTable WHERE EnterpriseID = " + enterprise.EnterpriseID, con);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID)
                        {
                            UserAccount userAccount = enterprise.UserAccountDirectory.AddUserAccount();
                            userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                            userAccount.Username = reader["Username"].ToString();
                            userAccount.Password = reader["Password"].ToString();
                            userAccount.Role = reader["Role"].ToString();
                            userAccount.EnterpriseID = enterprise.EnterpriseID;
                            userAccount.Name = reader["Name"].ToString();
                            if (userAccount.Role.Equals("Patient"))
                            {
                                LoadPatientTableIntoBusiness(Business, enterprise, userAccount);
                            }
                        }
                    }
                    cmd.Connection.Close();
                }
                con.Close();
            }
        }

        private static void LoadPatientTableIntoBusiness(EcoSystem Business, Enterprise enterprise, UserAccount userAccount)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PatientProfileTable WHERE UserID = " + userAccount.UserAccountID, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID)
                    {
                        Patient patient = enterprise.patientDirectory.AddPatient();
                        patient.Name = userAccount.Name;
                        patient.UserAccountID = userAccount.UserAccountID;
                        if (!reader.IsDBNull(1))
                        {
                            string ageString = reader["Age"].ToString();
                            if (ageString != null)
                            {
                                patient.Age = Convert.ToInt32(ageString);
                            }
                        }
                        if (!reader.IsDBNull(2))
                        {
                            string bloodString = reader["BloodType"].ToString();
                            if (bloodString != null)
                            {
                                patient.BloodType = bloodString;
                            }
                        }
                        if (!reader.IsDBNull(3))
                        {
                            string enterpriseIDString = reader["EnterpriseID"].ToString();
                            if (enterpriseIDString != null)
                            {
                                patient.EnterpriseID = Convert.ToInt32(enterpriseIDString);
                            }
                        }
                    }
                }
                cmd.Connection.Close();
                con.Close();
            }
        }

        private static void LoadAppointmentTableIntoBusiness(EcoSystem Business)
        {
            foreach (Enterprise enterprise in Business.EnterpriseDirectory.EnterpriseList)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AppointmentTable WHERE EnterpriseID = " + enterprise.EnterpriseID, con);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Appointment appointment = enterprise.AppointmentQueue.AddAppointment();
                        appointment.AppointmentID = Convert.ToInt32(reader["AppointmentID"].ToString());
                        appointment.EnterpriseID = Convert.ToInt32(reader["EnterpriseID"].ToString());
                        appointment.Doctor = enterprise.UserAccountDirectory.SearchUser(Convert.ToInt32(reader["DoctorID"]));
                        appointment.Nurse = enterprise.UserAccountDirectory.SearchUser(Convert.ToInt32(reader["NurseID"]));
                        appointment.Patient = enterprise.patientDirectory.SearchPatient(Convert.ToInt32(reader["PatientID"]));
                        appointment.Name = "Appointment" + appointment.AppointmentID;
                        if (reader["Reason"] != DBNull.Value)
                        {
                            appointment.Reson = reader["Reason"].ToString();
                        }
                        if (reader["Cost"] != DBNull.Value)
                        {
                            appointment.Cost = Convert.ToDouble(reader["Cost"].ToString());
                        }
                        appointment.RequestDate = Convert.ToDateTime(reader["RequestDate"].ToString());

                    }
                    cmd.Connection.Close();
                    con.Close();
                }
            }
        }

        public static List<UserAccount> GetEnterpriseAdminFromBusiness()
        {
            List<UserAccount> returnList = new List<UserAccount>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string adminString = "@Role";
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountTable WHERE Role = " + adminString, con);
                cmd.Parameters.AddWithValue(adminString, "Enterprise Administrator");
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    UserAccount userAccount = new UserAccount();
                    userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                    userAccount.Username = reader["Username"].ToString();
                    userAccount.Password = reader["Password"].ToString();
                    userAccount.Role = reader["Role"].ToString();
                    userAccount.EnterpriseID = Convert.ToInt32(reader["EnterpriseID"].ToString());
                    userAccount.Name = reader["Name"].ToString();
                    returnList.Add(userAccount);
                }
                cmd.Connection.Close();
                con.Close();
            }
            return returnList;
        }


        public static List<Enterprise> GetEnterpriseFromTable()
        {
            List<Enterprise> returnList = new List<Enterprise>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT * FROM EnterpriseTable", con);
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Enterprise enterprise = new Enterprise();
                    enterprise.EnterpriseID = Convert.ToInt32(reader["EnterpriseID"].ToString());
                    enterprise.Name = reader["Name"].ToString();
                    enterprise.Location = reader["Location"].ToString();
                    returnList.Add(enterprise);
                }
                reader.Close();
                cmd.Connection.Close();
                con.Close();
            }
            return returnList;
        }

        public static List<UserAccount> GetHealthProfessionUserFromEnterprise(Enterprise enterprise)
        {
            List<UserAccount> returnList = new List<UserAccount>();
            foreach(UserAccount ua in enterprise.UserAccountDirectory.UserAccountList)
            {
                bool isAdmin = ua.Role.Equals("Enterprise Administrator");
                if(isAdmin == false)
                {
                    returnList.Add(ua);
                }
            }
            return returnList;
        }

        public static UserAccountDirectory GetHealthProfessionUserFromTable(Enterprise enterprise)
        {
            UserAccountDirectory ud = new UserAccountDirectory();
            List<UserAccount> returnList = new List<UserAccount>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountTable WHERE EnterpriseID = " + enterprise.EnterpriseID, con);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID 
                        && reader["Role"].ToString().Equals("System Administration") == false
                        && reader["Role"].ToString().Equals("Enterprise Administrator") == false)
                        {
                            UserAccount userAccount = enterprise.UserAccountDirectory.AddUserAccount();
                            userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                            userAccount.Username = reader["Username"].ToString();
                            userAccount.Password = reader["Password"].ToString();
                            userAccount.Role = reader["Role"].ToString();
                            userAccount.EnterpriseID = enterprise.EnterpriseID;
                            userAccount.Name = reader["Name"].ToString();
                        returnList.Add(userAccount);
                        }
                    }
                    cmd.Connection.Close();
                con.Close();
            }
            ud.UserAccountList = returnList;
            return ud;
        }

        public static AppointmentQueue GetAppointmentQueueFromTable(Enterprise enterprise)
        {
            AppointmentQueue aq = new AppointmentQueue();
            List<Appointment> returnList = new List<Appointment>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM AppointmentTable WHERE EnterpriseID = " + enterprise.EnterpriseID, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID)
                    {
                        Appointment appointment = new Appointment();
                        appointment.AppointmentID = Convert.ToInt32(reader["AppointmentID"].ToString());
                        appointment.EnterpriseID = Convert.ToInt32(reader["EnterpriseID"].ToString());
                        appointment.Doctor = FindUserFromTable(enterprise, (Convert.ToInt32(reader["DoctorID"])));
                        appointment.Nurse = FindUserFromTable(enterprise, (Convert.ToInt32(reader["NurseID"])));
                        appointment.Patient = FindPatientFromTable(enterprise, (Convert.ToInt32(reader["PatientID"])));
                        appointment.Patient.Name = FindUserFromTable(enterprise, (Convert.ToInt32(reader["PatientID"]))).Name;
                        appointment.Name = "Appointment" + appointment.AppointmentID;
                        if (reader["Reason"] != DBNull.Value)
                        {
                            appointment.Reson = reader["Reason"].ToString();
                        }
                        if (reader["Cost"] != DBNull.Value)
                        {
                            appointment.Cost = Convert.ToDouble(reader["Cost"].ToString());
                        }
                        appointment.RequestDate = Convert.ToDateTime(reader["RequestDate"].ToString());
                        returnList.Add(appointment);
                    }
                }
                cmd.Connection.Close();
                con.Close();
            }
            aq.AppointmentList = returnList;
            return aq;
        }

        public static void AddUserIntoBusiness(UserAccount ua, Enterprise enterprise)
        {
            if(ua.Role.Equals("Patient"))
            {
                AddPatientIntoBusiness(enterprise, ua);
            }

        }

        public static void AddUserIntoTable(string username, string password, string role, int enterpriseID, string name)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO UserAccountTable values (@Username, @Password, @Role, @EnterpriseID, @Name)", con, trans))
                    {
                        
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("Username", username);
                        cmd.Parameters.AddWithValue("Password", password);
                        cmd.Parameters.AddWithValue("Role", role);
                        cmd.Parameters.AddWithValue("EnterpriseID", enterpriseID);
                        cmd.Parameters.AddWithValue("Name", name);
                        trans.Commit();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    
                }
                catch (SqlException ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
                con.Close();
            }
        }

        public static void DeleteReasonOfAppointmentInTable(Appointment appointment)
        {
            EditOneStringInTable("AppointmentTable", "AppointmentID", appointment.AppointmentID, "Reason", DBNull.Value);
        }

        public static void DeleteCostOfAppointmentInTable(Appointment appointment)
        {
            EditOneDoubleInTable("AppointmentTable", "AppointmentID", appointment.AppointmentID, "Cost", DBNull.Value);
        }

        public static void EditReasonInAppointment(Appointment appointment, string reason)
        {
            EditOneStringInTable("AppointmentTable", "AppointmentID", appointment.AppointmentID, "Reason", appointment.Reson);
        }

        public static void EditCostInAppointment(Appointment appointment, double cost)
        {
            EditOneDoubleInTable("AppointmentTable", "AppointmentID", appointment.AppointmentID, "Cost", appointment.Cost);
        }

        public static bool IfAddAppointmentInputIsLegit(string birthdate, string cost)
        {
            if(IfInputIsLegitDouble(cost) == false)
            {
                return false;
            }
            if(IfInputIsLegitBirthDate(birthdate) == false)
            {
                return false;
            }
            return true;

        }

        private static bool IfInputIsLegitDouble(string cost)
        {
            try
            {
                double legitCost = Double.Parse(cost);
                if (legitCost < 0.0)
                {
                    return false;
                }
                return true;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool IfInputIsLegitBirthDate(string birthDate)
        {
            try
            {
                DateTime DOB = DateTime.Parse(birthDate);
                if(DateTime.Now.CompareTo(DOB) <0)
                {
                    return false;
                }
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void AddAppointmentToTable(Enterprise enterprise, Appointment appointment, Patient patient)
        {
 
            UpdatePatientInfoInTable(patient);
            AddRowWithEightParametersIntoTable("AppointmentTable", "EnterpriseID", "DoctorID", "NurseID", "PatientID", "Name", "Reason", "Cost", "RequestDate",
                enterprise.EnterpriseID, appointment.Doctor.UserAccountID, appointment.Nurse.UserAccountID, patient.UserAccountID, appointment.Name, appointment.Reson, appointment.Cost, appointment.RequestDate);
            appointment.AppointmentID = GetPrimaryKeyInTable("AppointmentTable", "Name", appointment.Name, "AppointmentID");
        }

        public static int CalculateAge(DateTime patientDOB)
        {
            int yearNow = DateTime.Now.Year;
            int yearOfPatient = patientDOB.Year;
            return yearNow - yearOfPatient;
        }

        public static void AddRowWithEightParametersIntoTable(string tableName, string pOne, string pTwo, string pThree, string pFour, string pFive,
            string pSix, string pSeven, string pEight, int myPone, int myPtwo, int myPthree, int myPfour, string myPfive, string myPsix, double myPseven,
            DateTime myPeight)
        {
            
            string atPone = "@" + pOne;
            string atPtwo = "@" + pTwo;
            string atPthree = "@" + pThree;
            string atPfour = "@" + pFour;
            string atPfive = "@" + pFive;
            string atPsix = "@" + pSix;
            string atPseven = "@" + pSeven;
            string atPeight = "@" + pEight;

            string cmdString = "INSERT INTO " + tableName + " (" +
                pOne + ", " + pTwo + ", " + pThree + ", " + pFour + ", " + pFive + ", " + pSix + ", " + pSeven + ", " + pEight + ") VALUES (" +
                atPone + ", " + atPtwo + ", " + atPthree + ", " + atPfour + ", " + atPfive + ", " + atPsix + ", " + atPseven + ", " + atPeight + ")";
            SqlTransaction trans = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        
                        comm.CommandText = cmdString;
                        comm.Transaction = trans;
                        
                        comm.Parameters.AddWithValue(atPone, myPone);
                        comm.Parameters.AddWithValue(atPtwo, myPtwo);
                        comm.Parameters.AddWithValue(atPthree, myPthree);
                        comm.Parameters.AddWithValue(atPfour, myPfour);
                        comm.Parameters.AddWithValue(atPfive, myPfive);
                        comm.Parameters.AddWithValue(atPsix, myPsix);
                        comm.Parameters.AddWithValue(atPseven, myPseven);
                        comm.Parameters.AddWithValue(atPeight, myPeight.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                        trans.Commit();
                        comm.ExecuteNonQuery();
                        comm.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        
    }

        public static void UpdatePatientInfoInTable(Patient patient)
        {
            int patientID = patient.UserAccountID;
            EditOneStringOneIntInTable("PatientProfileTable", "UserID", patientID, "BloodType", "Age", patient.BloodType, patient.Age);
        }

        public static int GetPrimaryKeyInTable(string tableName, string uniqueColumn, string myUniqueValue, string targetColumn)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string atUniqueColumn = "@" + uniqueColumn;
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + tableName + " WHERE " + uniqueColumn + "= " + atUniqueColumn, con);
                cmd.Parameters.AddWithValue(atUniqueColumn, myUniqueValue);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(reader[uniqueColumn].ToString().Equals(myUniqueValue))
                    {
                        return (int) reader[targetColumn];
                    }
                }
                cmd.Connection.Close();
            }
            return -1;
        }

        public static void AddPatientIntoBusiness(Enterprise enterprise, UserAccount ua)
        {
            AddPatientIntoTable(enterprise.EnterpriseID, ua.UserAccountID);
        }

        public static void AddPatientIntoTable(int enterpriseID, int userID)
        {
            SqlTransaction trans = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try {
                    con.Open();
                    trans = con.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO PatientProfileTable (EnterpriseID, UserID) Values (@EnterpriseID, @UserID)", con))
                    {
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("@EnterpriseID", enterpriseID);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        
                        trans.Commit();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }


        public static UserAccountDirectory GetNurseUserAccountFromTable(Enterprise enterprise)
        {
            UserAccountDirectory ud = new UserAccountDirectory();
            List<UserAccount> returnList = new List<UserAccount>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountTable WHERE EnterpriseID = " + enterprise.EnterpriseID, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID &&
                        reader["Role"].ToString().Equals("Nurse"))
                    {
                        UserAccount userAccount = enterprise.UserAccountDirectory.AddUserAccount();
                        userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                        userAccount.Username = reader["Username"].ToString();
                        userAccount.Password = reader["Password"].ToString();
                        userAccount.Role = reader["Role"].ToString();
                        userAccount.EnterpriseID = enterprise.EnterpriseID;
                        userAccount.Name = reader["Name"].ToString();
                        returnList.Add(userAccount);
                    }
                }
                cmd.Connection.Close();
            }
            ud.UserAccountList = returnList;
            return ud;
        }

        public static PatientDirectory GetPatientFromTable(Enterprise enterprise)
        {
            PatientDirectory pd = new PatientDirectory();
            List<Patient> returnList = new List<Patient>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountTable WHERE EnterpriseID = " + enterprise.EnterpriseID, con);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID
                        && reader["Role"].ToString().Equals("Patient"))
                        {
                            UserAccount userAccount = new UserAccount();
                            userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                            userAccount.Username = reader["Username"].ToString();
                            userAccount.Password = reader["Password"].ToString();
                            userAccount.Role = reader["Role"].ToString();
                            userAccount.EnterpriseID = enterprise.EnterpriseID;
                            userAccount.Name = reader["Name"].ToString();
                        returnList.Add(GetPatientFromTableWithUserID(enterprise, userAccount));
                        }
                    }
                    cmd.Connection.Close();
            }
            pd.PatientList = returnList;
            return pd;
        }

        private static Patient GetPatientFromTableWithUserID(Enterprise enterprise, UserAccount userAccount)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PatientProfileTable WHERE UserID = " + userAccount.UserAccountID, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID)
                    {
                        Patient patient = new Patient();
                        patient.Name = userAccount.Name;
                        patient.UserAccountID = userAccount.UserAccountID;
                        if (!reader.IsDBNull(1))
                        {
                            string ageString = reader["Age"].ToString();
                            if (ageString != null)
                            {
                                patient.Age = Convert.ToInt32(ageString);
                            }
                        }
                        if (!reader.IsDBNull(2))
                        {
                            string bloodString = reader["BloodType"].ToString();
                            if (bloodString != null)
                            {
                                patient.BloodType = bloodString;
                            }
                        }
                        if (!reader.IsDBNull(3))
                        {
                            string enterpriseIDString = reader["EnterpriseID"].ToString();
                            if (enterpriseIDString != null)
                            {
                                patient.EnterpriseID = Convert.ToInt32(enterpriseIDString);
                            }
                        }
                        return patient;
                    }
                }
                cmd.Connection.Close();
            }
            return null;
        }

        public static UserAccountDirectory GetDoctorUserAccountFromTable(Enterprise enterprise)
        {
            UserAccountDirectory ud = new UserAccountDirectory();
            List<UserAccount> returnList = new List<UserAccount>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountTable WHERE EnterpriseID = " + enterprise.EnterpriseID, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["EnterpriseID"]) == enterprise.EnterpriseID &&
                        reader["Role"].ToString().Equals("Doctor"))
                    {
                        UserAccount userAccount = enterprise.UserAccountDirectory.AddUserAccount();
                        userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                        userAccount.Username = reader["Username"].ToString();
                        userAccount.Password = reader["Password"].ToString();
                        userAccount.Role = reader["Role"].ToString();
                        userAccount.EnterpriseID = enterprise.EnterpriseID;
                        userAccount.Name = reader["Name"].ToString();
                        returnList.Add(userAccount);
                    }
                }
                cmd.Connection.Close();
            }
            ud.UserAccountList = returnList;
            return ud;
        }

        private static UserAccount FindUserFromTable(Enterprise enterprise, int userID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM UserAccountTable WHERE UserID = " + userID, con);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["UserID"]) == userID)
                        {
                            UserAccount userAccount = new UserAccount();
                            userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                            userAccount.Username = reader["Username"].ToString();
                            userAccount.Password = reader["Password"].ToString();
                            userAccount.Role = reader["Role"].ToString();
                            userAccount.EnterpriseID = enterprise.EnterpriseID;
                            userAccount.Name = reader["Name"].ToString();

                        return userAccount;
                        }
                    }
                    cmd.Connection.Close();
                
            }
            return null;
        }

        private static Patient FindPatientFromTable(Enterprise enterprise, int userID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PatientProfileTable WHERE UserID = " + userID, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["UserID"]) == userID)
                    {
                        Patient userAccount = new Patient();
                        userAccount.UserAccountID = Convert.ToInt32(reader["UserID"].ToString());
                        userAccount.EnterpriseID = enterprise.EnterpriseID;
                        if (reader["BloodType"] != DBNull.Value)
                        {
                            userAccount.BloodType = reader["BloodType"].ToString();
                        }
                        if (reader["Age"] != DBNull.Value)
                        {
                            userAccount.Age = Convert.ToInt32(reader["Age"].ToString());
                        }
                        return userAccount;
                    }
                }
                cmd.Connection.Close();

            }
            return null;
        }

        public static EnterpriseDirectory GetEnterpriseDirectoryFromTable()
        {
            EnterpriseDirectory ed = new EnterpriseDirectory();
            List<Enterprise> returnList = new List<Enterprise>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT * FROM EnterpriseTable", con);
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Enterprise enterprise = new Enterprise();
                    enterprise.EnterpriseID = Convert.ToInt32(reader["EnterpriseID"].ToString());
                    enterprise.Name = reader["Name"].ToString();
                    enterprise.Location = reader["Location"].ToString();
                    returnList.Add(enterprise);
                }
                reader.Close();
                cmd.Connection.Close();
            }
            ed.EnterpriseList = returnList;
            return ed;
        }
    }
}
