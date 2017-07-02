using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Airstream.Feedback.Database
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DatabaseConnection()
        {
            Initialize();
        }

        //Initialize database
        private void Initialize()
        {
            try
            {
                server = "localhost"; //IP of database server (or localhost)
                database = "rfid_db";
                uid = "root";
                password = "MrMiller7";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
            }
            catch(MySqlException e)
            {
                MessageBox.Show("Error connecting to the database: " + e.ToString());
            }
  

        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public  bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Use for Inserting, Updating or Deleting from db 
        public void InsertUpdateDelete(string query)
        {
            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                catch(MySqlException e)
                {
                    MessageBox.Show("Values were not added to the database: + " + e.ToString());
                }

            }
        }

        /// <summary>
        ///  Return the result of a count query
        /// </summary>
        /// <param name="query"> The query to be executed </param>
        /// <returns></returns>
        public int Count(string query)
        {
            int Count = -1; // this will be returned if there is an error

            //Open Connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Mysql Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //ExecuteScalar will return one value
                    Count = int.Parse(cmd.ExecuteScalar() + "");

                    //close Connection
                    this.CloseConnection();

                    return Count;
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("There was an error when Counting data: " + e.ToString());
                    return Count;
                }

            }
            else
            {
                return Count;
            }
        }



        //General select statement
        /// <summary>
        /// Return a multi-dimensional string which contains the data of the db query result in list[COLUMN][ROW] format
        /// </summary>
        /// <param name="query"></param>
        /// <param name="columnNames"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<string>[] Select(string query, List<string> columnNames, List<string>[] list)
        {

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        for (int i = 0; i < list.Length; i++)
                        {
                            list[i].Add(dataReader[columnNames[i]] + "");

                        }
                    }
                    dataReader.Close();
                    this.CloseConnection();
                    return list;
                }
                catch
                {
                    return list; // return empty list 
                }

            }
            else
            {
                return list;
            }
        }


        public List<string>[] SelectFromRFID(string query)
        {

            List<string> columnNames = new List<string>();
            columnNames.Add("rfid_number");
            columnNames.Add("customer_name");
            columnNames.Add("occupation");
            columnNames.Add("company");
            columnNames.Add("relativeImagePath");


            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();


            return Select(query, columnNames, list);


        }


        public List<string>[] SelectFromFeedback(string query)
        {
            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            List<string> columnNames = new List<string>();
            columnNames.Add("feedbackID");
            columnNames.Add("feedbackQ");
            columnNames.Add("feedbackAnswer");
            return Select(query, columnNames, list);

        }

        public List<string>[] SelectFromFeedbackQs(string query)
        {
            //Create a list to store the result
            List<string>[] list = new List<string>[8];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();
            list[7] = new List<string>();

            List<string> columnNames = new List<string>();
            columnNames.Add("questionID");
            columnNames.Add("yOrNo");
            columnNames.Add("question");
            columnNames.Add("optionA");
            columnNames.Add("optionB");
            columnNames.Add("optionC");
            columnNames.Add("optionD");
            columnNames.Add("optionE");


            return Select(query, columnNames, list);

        }


        public List<string>[] SelectFromDYK(string query)
        {
            //Create a list to store the result
            List<string>[] list = new List<string>[7];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();

            List<string> columnNames = new List<string>();
            columnNames.Add("questionID");
            columnNames.Add("question");
            columnNames.Add("optionA");
            columnNames.Add("optionB");
            columnNames.Add("optionC");
            columnNames.Add("optionD");
            columnNames.Add("answer");

            return Select(query, columnNames, list);

        }

        public List<string>[] SelectFromWhatsInside(string query)
        {
            //Create a list to store the result
            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();


            List<string> columnNames = new List<string>();
            columnNames.Add("dataID");
            columnNames.Add("item");
            columnNames.Add("data");
            columnNames.Add("technical_specs");
            columnNames.Add("filepath");

            return Select(query, columnNames, list);

        }



    }
}
