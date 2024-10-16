namespace HW2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_graph = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shapetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_shape = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_w = new System.Windows.Forms.TextBox();
            this.textBox_h = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.textBox_text = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_graph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_graph
            // 
            this.dataGridView_graph.AllowUserToAddRows = false;
            this.dataGridView_graph.AllowUserToDeleteRows = false;
            this.dataGridView_graph.AllowUserToResizeRows = false;
            this.dataGridView_graph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_graph.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delete,
            this.ID,
            this.Shapetype,
            this.text,
            this.x,
            this.y,
            this.h,
            this.w});
            this.dataGridView_graph.Location = new System.Drawing.Point(3, 58);
            this.dataGridView_graph.MultiSelect = false;
            this.dataGridView_graph.Name = "dataGridView_graph";
            this.dataGridView_graph.ReadOnly = true;
            this.dataGridView_graph.RowHeadersVisible = false;
            this.dataGridView_graph.Size = new System.Drawing.Size(403, 365);
            this.dataGridView_graph.TabIndex = 0;
            // 
            // delete
            // 
            this.delete.HeaderText = "刪除";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "刪除";
            this.delete.Width = 40;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // Shapetype
            // 
            this.Shapetype.HeaderText = "形狀";
            this.Shapetype.Name = "Shapetype";
            this.Shapetype.ReadOnly = true;
            this.Shapetype.Width = 65;
            // 
            // text
            // 
            this.text.HeaderText = "文字";
            this.text.Name = "text";
            this.text.ReadOnly = true;
            // 
            // x
            // 
            this.x.HeaderText = "X";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.Width = 40;
            // 
            // y
            // 
            this.y.HeaderText = "Y";
            this.y.Name = "y";
            this.y.ReadOnly = true;
            this.y.Width = 40;
            // 
            // h
            // 
            this.h.HeaderText = "H";
            this.h.Name = "h";
            this.h.ReadOnly = true;
            this.h.Width = 40;
            // 
            // w
            // 
            this.w.HeaderText = "W";
            this.w.Name = "w";
            this.w.ReadOnly = true;
            this.w.Width = 40;
            // 
            // comboBox_shape
            // 
            this.comboBox_shape.FormattingEnabled = true;
            this.comboBox_shape.Location = new System.Drawing.Point(84, 31);
            this.comboBox_shape.Name = "comboBox_shape";
            this.comboBox_shape.Size = new System.Drawing.Size(72, 21);
            this.comboBox_shape.TabIndex = 1;
            this.comboBox_shape.Text = "形狀";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(3, 19);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 33);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "新增";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBox_w
            // 
            this.textBox_w.Location = new System.Drawing.Point(371, 32);
            this.textBox_w.Name = "textBox_w";
            this.textBox_w.Size = new System.Drawing.Size(32, 20);
            this.textBox_w.TabIndex = 4;
            // 
            // textBox_h
            // 
            this.textBox_h.Location = new System.Drawing.Point(333, 32);
            this.textBox_h.Name = "textBox_h";
            this.textBox_h.Size = new System.Drawing.Size(32, 20);
            this.textBox_h.TabIndex = 5;
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(295, 32);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(32, 20);
            this.textBox_y.TabIndex = 6;
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(257, 32);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(32, 20);
            this.textBox_x.TabIndex = 7;
            // 
            // textBox_text
            // 
            this.textBox_text.Location = new System.Drawing.Point(162, 32);
            this.textBox_text.Name = "textBox_text";
            this.textBox_text.Size = new System.Drawing.Size(89, 20);
            this.textBox_text.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox_w);
            this.groupBox1.Controls.Add(this.dataGridView_graph);
            this.groupBox1.Controls.Add(this.comboBox_shape);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.textBox_text);
            this.groupBox1.Controls.Add(this.textBox_y);
            this.groupBox1.Controls.Add(this.textBox_x);
            this.groupBox1.Controls.Add(this.textBox_h);
            this.groupBox1.Location = new System.Drawing.Point(711, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 429);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox10.Location = new System.Drawing.Point(371, 13);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(32, 13);
            this.textBox10.TabIndex = 13;
            this.textBox10.Text = "W";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox9.Location = new System.Drawing.Point(333, 13);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(32, 13);
            this.textBox9.TabIndex = 12;
            this.textBox9.Text = "H";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox8.Location = new System.Drawing.Point(295, 13);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(32, 13);
            this.textBox8.TabIndex = 11;
            this.textBox8.Text = "Y";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox7.Location = new System.Drawing.Point(257, 13);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(32, 13);
            this.textBox7.TabIndex = 10;
            this.textBox7.Text = "X";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox6.Location = new System.Drawing.Point(162, 13);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(89, 13);
            this.textBox6.TabIndex = 9;
            this.textBox6.Text = "文字";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(0, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 423);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 76);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 76);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyDrawing";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_graph)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_graph;
        private System.Windows.Forms.ComboBox comboBox_shape;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_w;
        private System.Windows.Forms.TextBox textBox_h;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.TextBox textBox_text;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shapetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn h;
        private System.Windows.Forms.DataGridViewTextBoxColumn w;
    }
}

