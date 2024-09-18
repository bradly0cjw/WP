namespace Hello_World
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            studentDataGridView.Rows.Add("111590453", "Bradly");
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello, " + IDTextBox.Text + " " + nameTextBox.Text);
            if(IDTextBox.Text=="")
            {
                MessageBox.Show("Please enter ID");
            }else if (nameTextBox.Text == "")
            {
                MessageBox.Show("Please enter Name");
            }
            else 
            { 
                studentDataGridView.Rows.Add (IDTextBox.Text,nameTextBox.Text);
            }

        }
    }
}
