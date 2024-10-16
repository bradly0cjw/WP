using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        private Model model;

        public Form1(Model model)
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();

            this.model = model;
            dataGridView_graph.CellClick += dataGridView_graph_CellClick;
        }

        private void InitializeComboBox()
        {
            comboBox_shape.Items.Add("Start");
            comboBox_shape.Items.Add("Terminator");
            comboBox_shape.Items.Add("Process");
            comboBox_shape.Items.Add("Decision");
        }

        private void InitializeDataGridView()
        {
            dataGridView_graph.Rows.Clear();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            ShapeData shapeData = new ShapeData
            {
                ShapeType = comboBox_shape.Text,
                Text = textBox_text.Text,
                X = int.Parse(textBox_x.Text),
                Y = int.Parse(textBox_y.Text),
                Width = int.Parse(textBox_w.Text),
                Height = int.Parse(textBox_h.Text)
            };

            int err = model.AddShape(shapeData);
            HandleError(err);

            UpdateGrid();
        }

        private void HandleError(int err)
        {
            switch (err)
            {
                case 1:
                    MessageBox.Show("Invalid shape type");
                    break;
                case 2:
                    MessageBox.Show("Invalid input");
                    break;
            }
        }

        private void UpdateGrid()
        {
            List<ShapeWrapper> shapes = model.GetShapes();
            dataGridView_graph.Rows.Clear();

            foreach (ShapeWrapper shapeWrapper in shapes)
            {
                dataGridView_graph.Rows.Add("Delete", shapeWrapper.Id, shapeWrapper.ShapeType, shapeWrapper.Shape.Text, shapeWrapper.Shape.X, shapeWrapper.Shape.Y, shapeWrapper.Shape.Width, shapeWrapper.Shape.Height);
            }
        }

        private void dataGridView_graph_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_graph.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int shapeId = (int)dataGridView_graph.Rows[e.RowIndex].Cells["Id"].Value;
                model.RemoveShape(shapeId);
                UpdateGrid();
            }
        }
    }
}
