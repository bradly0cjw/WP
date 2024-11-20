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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView_graph = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shapetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.w = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_shapeName = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_width = new System.Windows.Forms.TextBox();
            this.textBox_height = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.textBox_text = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_w_readonly = new System.Windows.Forms.TextBox();
            this.textBox_h_readonly = new System.Windows.Forms.TextBox();
            this.textBox_y_readonly = new System.Windows.Forms.TextBox();
            this.textBox_x_readonly = new System.Windows.Forms.TextBox();
            this.textBox_text_readonly = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonStart = new System.Windows.Forms.ToolStripButton();
            this.buttonTerminator = new System.Windows.Forms.ToolStripButton();
            this.buttonDecision = new System.Windows.Forms.ToolStripButton();
            this.buttonProcess = new System.Windows.Forms.ToolStripButton();
            this.buttonSelect = new System.Windows.Forms.ToolStripButton();
            this.panel = new HW2.DoubleBufferPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_graph)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            // comboBox_shapeName
            // 
            this.comboBox_shapeName.FormattingEnabled = true;
            this.comboBox_shapeName.Location = new System.Drawing.Point(84, 31);
            this.comboBox_shapeName.Name = "comboBox_shapeName";
            this.comboBox_shapeName.Size = new System.Drawing.Size(72, 21);
            this.comboBox_shapeName.TabIndex = 1;
            this.comboBox_shapeName.Text = "形狀";
            this.comboBox_shapeName.SelectedIndexChanged += new System.EventHandler(this.ComboBox_shapeName_SelectedIndexChanged);
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
            this.button_add.Click += new System.EventHandler(this.Button_add_Click);
            // 
            // textBox_width
            // 
            this.textBox_width.Location = new System.Drawing.Point(371, 32);
            this.textBox_width.Name = "textBox_width";
            this.textBox_width.Size = new System.Drawing.Size(32, 20);
            this.textBox_width.TabIndex = 4;
            this.textBox_width.TextChanged += new System.EventHandler(this.TextBox_width_TextChanged);
            // 
            // textBox_height
            // 
            this.textBox_height.Location = new System.Drawing.Point(333, 32);
            this.textBox_height.Name = "textBox_height";
            this.textBox_height.Size = new System.Drawing.Size(32, 20);
            this.textBox_height.TabIndex = 5;
            this.textBox_height.TextChanged += new System.EventHandler(this.TextBox_height_TextChanged);
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(295, 32);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(32, 20);
            this.textBox_y.TabIndex = 6;
            this.textBox_y.TextChanged += new System.EventHandler(this.TextBox_y_TextChanged);
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(257, 32);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(32, 20);
            this.textBox_x.TabIndex = 7;
            this.textBox_x.TextChanged += new System.EventHandler(this.TextBox_x_TextChanged);
            // 
            // textBox_text
            // 
            this.textBox_text.Location = new System.Drawing.Point(162, 32);
            this.textBox_text.Name = "textBox_text";
            this.textBox_text.Size = new System.Drawing.Size(89, 20);
            this.textBox_text.TabIndex = 8;
            this.textBox_text.TextChanged += new System.EventHandler(this.TextBox_text_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_w_readonly);
            this.groupBox1.Controls.Add(this.textBox_h_readonly);
            this.groupBox1.Controls.Add(this.textBox_y_readonly);
            this.groupBox1.Controls.Add(this.textBox_x_readonly);
            this.groupBox1.Controls.Add(this.textBox_text_readonly);
            this.groupBox1.Controls.Add(this.textBox_width);
            this.groupBox1.Controls.Add(this.dataGridView_graph);
            this.groupBox1.Controls.Add(this.comboBox_shapeName);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Controls.Add(this.textBox_text);
            this.groupBox1.Controls.Add(this.textBox_y);
            this.groupBox1.Controls.Add(this.textBox_x);
            this.groupBox1.Controls.Add(this.textBox_height);
            this.groupBox1.Location = new System.Drawing.Point(711, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 429);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // textBox_w_readonly
            // 
            this.textBox_w_readonly.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_w_readonly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_w_readonly.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_w_readonly.Location = new System.Drawing.Point(371, 13);
            this.textBox_w_readonly.Name = "textBox_w_readonly";
            this.textBox_w_readonly.Size = new System.Drawing.Size(32, 13);
            this.textBox_w_readonly.TabIndex = 13;
            this.textBox_w_readonly.Text = "W";
            this.textBox_w_readonly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_h_readonly
            // 
            this.textBox_h_readonly.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_h_readonly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_h_readonly.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_h_readonly.Location = new System.Drawing.Point(333, 13);
            this.textBox_h_readonly.Name = "textBox_h_readonly";
            this.textBox_h_readonly.Size = new System.Drawing.Size(32, 13);
            this.textBox_h_readonly.TabIndex = 12;
            this.textBox_h_readonly.Text = "H";
            this.textBox_h_readonly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_y_readonly
            // 
            this.textBox_y_readonly.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_y_readonly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_y_readonly.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_y_readonly.Location = new System.Drawing.Point(295, 13);
            this.textBox_y_readonly.Name = "textBox_y_readonly";
            this.textBox_y_readonly.Size = new System.Drawing.Size(32, 13);
            this.textBox_y_readonly.TabIndex = 11;
            this.textBox_y_readonly.Text = "Y";
            this.textBox_y_readonly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_x_readonly
            // 
            this.textBox_x_readonly.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_x_readonly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_x_readonly.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_x_readonly.Location = new System.Drawing.Point(257, 13);
            this.textBox_x_readonly.Name = "textBox_x_readonly";
            this.textBox_x_readonly.Size = new System.Drawing.Size(32, 13);
            this.textBox_x_readonly.TabIndex = 10;
            this.textBox_x_readonly.Text = "X";
            this.textBox_x_readonly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_text_readonly
            // 
            this.textBox_text_readonly.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_text_readonly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_text_readonly.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_text_readonly.Location = new System.Drawing.Point(162, 13);
            this.textBox_text_readonly.Name = "textBox_text_readonly";
            this.textBox_text_readonly.Size = new System.Drawing.Size(89, 13);
            this.textBox_text_readonly.TabIndex = 9;
            this.textBox_text_readonly.Text = "文字";
            this.textBox_text_readonly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(0, 46);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonStart,
            this.buttonTerminator,
            this.buttonDecision,
            this.buttonProcess,
            this.buttonSelect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1118, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonStart
            // 
            this.buttonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(23, 22);
            this.buttonStart.Text = "Start";
            // 
            // buttonTerminator
            // 
            this.buttonTerminator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonTerminator.Image = ((System.Drawing.Image)(resources.GetObject("buttonTerminator.Image")));
            this.buttonTerminator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonTerminator.Name = "buttonTerminator";
            this.buttonTerminator.Size = new System.Drawing.Size(23, 22);
            this.buttonTerminator.Text = "terminator";
            // 
            // buttonDecision
            // 
            this.buttonDecision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDecision.Image = ((System.Drawing.Image)(resources.GetObject("buttonDecision.Image")));
            this.buttonDecision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDecision.Name = "buttonDecision";
            this.buttonDecision.Size = new System.Drawing.Size(23, 22);
            this.buttonDecision.Text = "Decision";
            // 
            // buttonProcess
            // 
            this.buttonProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonProcess.Image = ((System.Drawing.Image)(resources.GetObject("buttonProcess.Image")));
            this.buttonProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(23, 22);
            this.buttonProcess.Text = "Process";
            // 
            // buttonSelect
            // 
            this.buttonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSelect.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelect.Image")));
            this.buttonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(23, 22);
            this.buttonSelect.Text = "Select";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(134, 46);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(574, 429);
            this.panel.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 492);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip1);
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_graph;
        private System.Windows.Forms.ComboBox comboBox_shapeName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_width;
        private System.Windows.Forms.TextBox textBox_height;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.TextBox textBox_text;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_w_readonly;
        private System.Windows.Forms.TextBox textBox_h_readonly;
        private System.Windows.Forms.TextBox textBox_y_readonly;
        private System.Windows.Forms.TextBox textBox_x_readonly;
        private System.Windows.Forms.TextBox textBox_text_readonly;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonStart;
        private System.Windows.Forms.ToolStripButton buttonTerminator;
        private System.Windows.Forms.ToolStripButton buttonDecision;
        private System.Windows.Forms.ToolStripButton buttonProcess;
        private System.Windows.Forms.ToolStripButton buttonSelect;
        private DoubleBufferPanel panel;
    }
}

