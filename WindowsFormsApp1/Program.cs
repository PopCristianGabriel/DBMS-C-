﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1;
namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

         
        [STAThread]
        static void Main()
        {
            //DESKTOP-97SDQ88

            SqlConnection dbConn;
            SqlDataAdapter daCustomers, daOrders;
            DataSet ds;
            SqlCommandBuilder cb;
            BindingSource bsCustomers, bsOrders;
            string connectionString =
            "Data Source=(local);Initial Catalog=Robots;"
            + "Integrated Security=true";
            dbConn = new SqlConnection(connectionString);

            execute_first_stored_procedure(dbConn);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(dbConn));








        }

        private static void execute_first_stored_procedure(SqlConnection dbConn)
        {
           
        }

       
       
    }
}
