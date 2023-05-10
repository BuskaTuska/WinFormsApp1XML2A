using System.Data;
using System.IO;
namespace WinFormsApp1XML2A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("��������� �� ����.", "�������.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[4].Value = comboBox1.Text;
                if (comboBox1.Text == "True")
                {
                    comboBox2.Enabled = true;
                    dataGridView1.Rows[n].Cells[2].Value = comboBox2.Text;
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "-";
                    comboBox2.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = comboBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[4].Value = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("������ ������ ��� �����������.", "�������.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("������ ������ ��� ���������.", "�������.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("City");
                dt.Columns.Add("Language");
                dt.Columns.Add("Age");
                dt.Columns.Add("Programmer");
                ds.Tables.Add(dt);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Employee"].NewRow();
                    row["Name"] = r.Cells[0].Value;
                    row["City"] = r.Cells[1].Value;
                    row["Language"] = r.Cells[2].Value;
                    row["Age"] = r.Cells[3].Value;
                    row["Programmer"] = r.Cells[4].Value;
                    ds.Tables["Employee"].Rows.Add(row);
                }
                ds.WriteXml("D:\\Data.xml");
                MessageBox.Show("XML ���� ������ ��������.", "��������.");
            }
            catch
            {
                MessageBox.Show("��������� �������� XML ����.", "�������.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("�������� ���� ����� ��������� ������ �����.", "�������.");
            }
            else
            {
                if (File.Exists("D:\\Data.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("D:\\Data.xml");
                    foreach (DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Name"];
                        dataGridView1.Rows[n].Cells[1].Value = item["City"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Language"];
                        dataGridView1.Rows[n].Cells[3].Value = item["Age"];
                        dataGridView1.Rows[n].Cells[4].Value = item["Programmer"];
                    }
                }
                else
                {
                    MessageBox.Show("XML ���� �� ��������.", "�������.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("������� �����.", "�������.");
            }
        }
    }
}