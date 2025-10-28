namespace WinFormsApp1
{
    using Microsoft.Data.Sqlite;
    using System.Data;
    using System.Data.SQLite;


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string conn_str = "Data Source=Students.db;";

            using (SqliteConnection conn = new SqliteConnection(conn_str))
            {
                conn.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Students (Name TEXT, Age TEXT, Class TEXT);";

                SqliteCommand command = new SqliteCommand(sql, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("Таблица создана успешно.");

                InsertUser(this.ST_name.Text, this.ST_Age.Text, this.ST_Class.Text);
            }
        }

        private void DisplayData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetStudents();
        }

        private void InsertUser(string userName, string userAge, string userClass)
        {
            string conn_str = "Data Source=Students.db;";

            using (SqliteConnection connection = new SqliteConnection(conn_str))
            {
                connection.Open();

                string sql = "INSERT INTO Students (Name, Age, Class) VALUES (@Name, @Age, @Class)";
                SqliteCommand command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", userName);
                command.Parameters.AddWithValue("@Age", userAge);
                command.Parameters.AddWithValue("@Class", userClass);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Данные внесены успешно.");
        }

        private DataTable GetStudents()
        {
            DataTable dt = new DataTable();
            string conn_str = "Data Source=Students.db;";

            using (var connection = new SqliteConnection(conn_str))
            {
                connection.Open();
                string sql = "SELECT * FROM Students";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }

                return dt;
            }
        }

    }
}
