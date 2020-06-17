using System;
using System.Collections.Generic;

using System.Data;

using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public SqlConnection dbcon;
        private TextBox textBoxRobotId;
        private TextBox textBoxRobotName;
        private TextBox textBoxIncrediblity;
        private TextBox textBoxScoreId;
        private Button buttonAddRobot;
        private Button buttonDeleteRobot;
        private Button buttonUpdateRobot;
        private Button button1;
        private Button buttonReadSmartRobots;
        private DataGridView dataGridScores;
        private DataGridView dataGridRobots;
        private Label label1;
        private Label label2;
        private Label Incrediblity;
        private Label label3;
        public SqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(SqlConnection dbcon)
        {
            InitializeComponent();
            this.dbcon = dbcon;



        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataSet dataSet = new DataSet();
            String querry = "Select * from Score";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(querry, this.dbcon);

            dataAdapter.Fill(dataSet);


            this.dataGridScores.DataSource = dataSet.Tables[0];



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void listViewScores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonReadSmartRobots_Click(object sender, EventArgs e)
        {



            String SID = this.dataGridScores.SelectedRows[0].Cells[0].Value.ToString();





            DataSet dataSetRobot = new DataSet();
            String querry = "Select * from IncredibleRobot";

            SqlDataAdapter dataAdapterRobot = new SqlDataAdapter(querry, this.dbcon);


            dataAdapterRobot.Fill(dataSetRobot);
            List<int> toRemove = new List<int>();
            int i = 0;
            while (i < dataSetRobot.Tables[0].Rows.Count)
            {

                if (dataSetRobot.Tables[0].Rows[i]["Score"].ToString() != SID)
                {

                    dataSetRobot.Tables[0].Rows.RemoveAt(i);
                }
                else
                {
                    i++;
                }


            }
            this.dataGridRobots.DataSource = dataSetRobot.Tables[0];




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddRobot_Click(object sender, EventArgs e)
        {
            String robotId = this.textBoxRobotId.Text;
            String robotName = this.textBoxRobotName.Text;
            String incredibility = this.textBoxIncrediblity.Text;
            String scoreId = this.textBoxScoreId.Text;



            String querry = "Insert into IncredibleRobot values(";
            SqlCommand addCommand = new SqlCommand(querry + robotId + "," + "'" + robotName + "'" + "," + incredibility + "," + scoreId + ");", this.dbcon);
            this.dbcon.Open();
            try
            {
                SqlDataReader reader = addCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.dbcon.Close();

                return;
            }
            MessageBox.Show("saved");
            this.dbcon.Close();


        }

        private void buttonDeleteRobot_Click(object sender, EventArgs e)
        {
            String robotId = this.textBoxRobotId.Text;
            String querry = "Delete from IncredibleRobot where RobotId=";
            SqlCommand deleteCommand = new SqlCommand(querry + robotId + ";", this.dbcon);
            this.dbcon.Open();
            SqlDataReader reader = deleteCommand.ExecuteReader();
            MessageBox.Show("deleted");
            this.dbcon.Close();
            reader.Close();
        }

        private void buttonUpdateRobot_Click(object sender, EventArgs e)
        {
            String robotId = this.textBoxRobotId.Text;
            String robotName = this.textBoxRobotName.Text;
            String incredibility = this.textBoxIncrediblity.Text;
            String scoreId = this.textBoxScoreId.Text;


            String querry = "update IncredibleRobot set RobotName =" ;
            String specialTreat = "Incredibility";
            SqlCommand updateCommand = new SqlCommand(querry + "'" + robotName + "'" + ", " + specialTreat + " = " + incredibility + ", Score = " + scoreId + " where RobotId = " + robotId + ";", this.dbcon);
            this.dbcon.Open();
            try
            {
                updateCommand.ExecuteNonQuery();
                // SqlDataReader reader = updateCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.dbcon.Close();
                // reader.Close();
                return;
            }
            MessageBox.Show("Updated");
            this.dbcon.Close();
            //  reader.Close();
        }

        private void InitializeComponent()
        {
            this.textBoxRobotId = new System.Windows.Forms.TextBox();
            this.textBoxRobotName = new System.Windows.Forms.TextBox();
            this.textBoxIncrediblity = new System.Windows.Forms.TextBox();
            this.textBoxScoreId = new System.Windows.Forms.TextBox();
            this.buttonAddRobot = new System.Windows.Forms.Button();
            this.buttonDeleteRobot = new System.Windows.Forms.Button();
            this.buttonUpdateRobot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonReadSmartRobots = new System.Windows.Forms.Button();
            this.dataGridScores = new System.Windows.Forms.DataGridView();
            this.dataGridRobots = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Incrediblity = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRobots)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxRobotId
            // 
            this.textBoxRobotId.Location = new System.Drawing.Point(874, 43);
            this.textBoxRobotId.Name = "textBoxRobotId";
            this.textBoxRobotId.Size = new System.Drawing.Size(111, 22);
            this.textBoxRobotId.TabIndex = 2;
            // 
            // textBoxRobotName
            // 
            this.textBoxRobotName.Location = new System.Drawing.Point(874, 94);
            this.textBoxRobotName.Name = "textBoxRobotName";
            this.textBoxRobotName.Size = new System.Drawing.Size(111, 22);
            this.textBoxRobotName.TabIndex = 3;
            // 
            // textBoxIncrediblity
            // 
            this.textBoxIncrediblity.Location = new System.Drawing.Point(874, 139);
            this.textBoxIncrediblity.Name = "textBoxIncrediblity";
            this.textBoxIncrediblity.Size = new System.Drawing.Size(111, 22);
            this.textBoxIncrediblity.TabIndex = 4;
            // 
            // textBoxScoreId
            // 
            this.textBoxScoreId.Location = new System.Drawing.Point(874, 190);
            this.textBoxScoreId.Name = "textBoxScoreId";
            this.textBoxScoreId.Size = new System.Drawing.Size(111, 22);
            this.textBoxScoreId.TabIndex = 5;
            this.textBoxScoreId.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // buttonAddRobot
            // 
            this.buttonAddRobot.Location = new System.Drawing.Point(874, 242);
            this.buttonAddRobot.Name = "buttonAddRobot";
            this.buttonAddRobot.Size = new System.Drawing.Size(111, 23);
            this.buttonAddRobot.TabIndex = 6;
            this.buttonAddRobot.Text = "Add";
            this.buttonAddRobot.UseVisualStyleBackColor = true;
            this.buttonAddRobot.Click += new System.EventHandler(this.buttonAddRobot_Click);
            // 
            // buttonDeleteRobot
            // 
            this.buttonDeleteRobot.Location = new System.Drawing.Point(874, 301);
            this.buttonDeleteRobot.Name = "buttonDeleteRobot";
            this.buttonDeleteRobot.Size = new System.Drawing.Size(111, 23);
            this.buttonDeleteRobot.TabIndex = 7;
            this.buttonDeleteRobot.Text = "Delete";
            this.buttonDeleteRobot.UseVisualStyleBackColor = true;
            this.buttonDeleteRobot.Click += new System.EventHandler(this.buttonDeleteRobot_Click);
            // 
            // buttonUpdateRobot
            // 
            this.buttonUpdateRobot.Location = new System.Drawing.Point(874, 352);
            this.buttonUpdateRobot.Name = "buttonUpdateRobot";
            this.buttonUpdateRobot.Size = new System.Drawing.Size(111, 23);
            this.buttonUpdateRobot.TabIndex = 8;
            this.buttonUpdateRobot.Text = "Update";
            this.buttonUpdateRobot.UseVisualStyleBackColor = true;
            this.buttonUpdateRobot.Click += new System.EventHandler(this.buttonUpdateRobot_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Get Scores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonReadSmartRobots
            // 
            this.buttonReadSmartRobots.Location = new System.Drawing.Point(433, 301);
            this.buttonReadSmartRobots.Name = "buttonReadSmartRobots";
            this.buttonReadSmartRobots.Size = new System.Drawing.Size(105, 23);
            this.buttonReadSmartRobots.TabIndex = 10;
            this.buttonReadSmartRobots.Text = "Get Robots";
            this.buttonReadSmartRobots.UseVisualStyleBackColor = true;
            this.buttonReadSmartRobots.Click += new System.EventHandler(this.buttonReadSmartRobots_Click);
            // 
            // dataGridScores
            // 
            this.dataGridScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridScores.Location = new System.Drawing.Point(12, 36);
            this.dataGridScores.Name = "dataGridScores";
            this.dataGridScores.RowHeadersWidth = 51;
            this.dataGridScores.RowTemplate.Height = 24;
            this.dataGridScores.Size = new System.Drawing.Size(316, 214);
            this.dataGridScores.TabIndex = 11;
            // 
            // dataGridRobots
            // 
            this.dataGridRobots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRobots.Location = new System.Drawing.Point(350, 36);
            this.dataGridRobots.Name = "dataGridRobots";
            this.dataGridRobots.RowHeadersWidth = 51;
            this.dataGridRobots.RowTemplate.Height = 24;
            this.dataGridRobots.Size = new System.Drawing.Size(292, 214);
            this.dataGridRobots.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(739, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(722, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Name";
            // 
            // Incrediblity
            // 
            this.Incrediblity.AutoSize = true;
            this.Incrediblity.Location = new System.Drawing.Point(709, 142);
            this.Incrediblity.Name = "Incrediblity";
            this.Incrediblity.Size = new System.Drawing.Size(78, 17);
            this.Incrediblity.TabIndex = 15;
            this.Incrediblity.Text = "Incredibility";
            this.Incrediblity.Click += new System.EventHandler(this.Incrediblity_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "ScoreID";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1072, 519);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Incrediblity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridRobots);
            this.Controls.Add(this.dataGridScores);
            this.Controls.Add(this.buttonReadSmartRobots);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonUpdateRobot);
            this.Controls.Add(this.buttonDeleteRobot);
            this.Controls.Add(this.buttonAddRobot);
            this.Controls.Add(this.textBoxScoreId);
            this.Controls.Add(this.textBoxIncrediblity);
            this.Controls.Add(this.textBoxRobotName);
            this.Controls.Add(this.textBoxRobotId);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRobots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void listViewScores_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void Incrediblity_Click(object sender, EventArgs e)
        {

        }
    }
}


