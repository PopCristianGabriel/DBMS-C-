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

namespace practicExp
{
    public partial class Form1 : Form
    {

        SqlConnection dbConn;
        SqlDataAdapter daCard, daTransactions;
        DataSet ds;
        SqlCommandBuilder cbTransactions;
        BindingSource bsCard, bsPosts;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.daTransactions.Update(ds, "Transactions");
         
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            bsCard = new BindingSource();
            bsPosts = new BindingSource();

            dgvCards.DataSource = bsCard;
            dgvTransactions.DataSource = bsPosts;

            string connectionString =
            "Data Source=(local);Initial Catalog=practicExam;"
            + "Integrated Security=true";
            dbConn = new SqlConnection(connectionString);


            ds = new DataSet();
            daCard = new SqlDataAdapter("Select * from Card", dbConn);
            daTransactions = new SqlDataAdapter("Select * from Transactions", dbConn);
            cbTransactions = new SqlCommandBuilder(daTransactions);
           
            daCard.Fill(ds, "Card");
            daTransactions.Fill(ds, "Transactions");

            DataRelation dr = new DataRelation("CardTransactions",
                ds.Tables["Card"].Columns["CardId"],
                ds.Tables["Transactions"].Columns["CardId"]);

            ds.Relations.Add(dr);

            bsCard.DataSource = ds;
            bsCard.DataMember = "Card";

            bsPosts.DataSource = bsCard;
            bsPosts.DataMember = "CardTransactions";














        }
    }
}
