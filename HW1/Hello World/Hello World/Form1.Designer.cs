namespace Hello_World
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IDLabel = new Label();
            IDTextBox = new MaskedTextBox();
            addButton = new Button();
            nameTextBox = new MaskedTextBox();
            nameLabel = new Label();
            studentDataGridView = new DataGridView();
            IDColumn = new DataGridViewTextBoxColumn();
            nameColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)studentDataGridView).BeginInit();
            SuspendLayout();
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Font = new Font("Segoe UI", 12F);
            IDLabel.Location = new Point(141, 92);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(82, 21);
            IDLabel.TabIndex = 0;
            IDLabel.Text = "Student ID";
            // 
            // IDTextBox
            // 
            IDTextBox.Font = new Font("Segoe UI", 12F);
            IDTextBox.Location = new Point(141, 116);
            IDTextBox.Name = "IDTextBox";
            IDTextBox.Size = new Size(100, 29);
            IDTextBox.TabIndex = 1;
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 12F);
            addButton.Location = new Point(141, 241);
            addButton.Name = "addButton";
            addButton.Size = new Size(109, 30);
            addButton.TabIndex = 3;
            addButton.Text = "Add Student";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font("Segoe UI", 12F);
            nameTextBox.Location = new Point(141, 192);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 29);
            nameTextBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 12F);
            nameLabel.Location = new Point(141, 153);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(109, 21);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Student Name";
            // 
            // studentDataGridView
            // 
            studentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            studentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            studentDataGridView.Columns.AddRange(new DataGridViewColumn[] { IDColumn, nameColumn });
            studentDataGridView.Location = new Point(313, 79);
            studentDataGridView.Name = "studentDataGridView";
            studentDataGridView.Size = new Size(405, 268);
            studentDataGridView.TabIndex = 5;
            // 
            // IDColumn
            // 
            IDColumn.HeaderText = "ID";
            IDColumn.Name = "IDColumn";
            // 
            // nameColumn
            // 
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "nameColumn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(studentDataGridView);
            Controls.Add(nameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(addButton);
            Controls.Add(IDTextBox);
            Controls.Add(IDLabel);
            Name = "Form1";
            Text = "Hello World";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)studentDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IDLabel;
        private MaskedTextBox IDTextBox;
        private Button addButton;
        private MaskedTextBox nameTextBox;
        private Label nameLabel;
        private DataGridView studentDataGridView;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewTextBoxColumn nameColumn;
    }
}
