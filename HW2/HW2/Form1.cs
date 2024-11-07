using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW2
{
    public partial class Form1 : Form
    {
        private readonly Model _model;
        private bool _startpressed = false;
        private bool _terminatorpressed = false;
        private bool _processpressed = false;
        private bool _decisionpressed = false;


        public Form1(Model model)
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();
            panel.MouseMove += MouseMoveHandler;
            panel.MouseDown += MouseDownHandeler;
            panel.MouseUp += MouseUpHandler;
            model.ModelChanged += UpdateView;
            model.ModelChanged += UpdateGrid;
            panel.Paint += HandelCanvasPaint;
            buttonStart.Click += ButtonShape_Click;
            buttonTerminator.Click += ButtonShape_Click;
            buttonProcess.Click += ButtonShape_Click;
            buttonDecision.Click += ButtonShape_Click;

            this._model = model; // Assign the model parameter to the _model field
            dataGridView_graph.CellClick += DataGridView_graph_CellClick;
        }

        // Initialize the combobox with the shape names
        private void InitializeComboBox()
        {
            comboBox_shapeName.Items.Add("Start");
            comboBox_shapeName.Items.Add("Terminator");
            comboBox_shapeName.Items.Add("Process");
            comboBox_shapeName.Items.Add("Decision");
        }

        // Initialize the datagridview
        private void InitializeDataGridView()
        {
            dataGridView_graph.Rows.Clear();
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Current cursor {e.X},{e.Y}");
            _model.MouseMoveHandler(e.X, e.Y);
            
            if (_model.GetMode() != "")
            {
                panel.Cursor = Cursors.Cross;
            }
            else
            {
                panel.Cursor = Cursors.Default;
            }
        }

        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            _model.MouseUpHandeler(e.X, e.Y);
            ClickHelper();
        }

        private void MouseDownHandeler(object sender, MouseEventArgs e)
        {
            _model.MouseDownHandeler(e.X, e.Y);
        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            try
            {
                string shapeName = comboBox_shapeName.Text;
                string textboxText = textBox_text.Text;
                int textboxX = int.Parse(textBox_x.Text);
                int textboxY = int.Parse(textBox_y.Text);
                int width = int.Parse(textBox_width.Text);
                int height = int.Parse(textBox_height.Text);

                // Add shape to the model
                _model.AddShape(shapeName, textboxText, textboxX, textboxY, width, height);
                UpdateGrid();
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }

        }

        private void UpdateGrid()
        {
            // Get the shapes from the model
            List<Shape> shapes = _model.GetShapes();
            // Clear the grid
            dataGridView_graph.Rows.Clear();

            // Add the shapes to the grid
            foreach (Shape shape in shapes)
            {
                dataGridView_graph.Rows.Add(
                    "Delete",
                    shape.ID,
                    shape.ShapeName,
                    shape.Text,
                    shape.X,
                    shape.Y,
                    shape.W,
                    shape.H
                );
            }
        }

        private void DataGridView_graph_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the delete button is clicked
            if (e.ColumnIndex != dataGridView_graph.Columns["Delete"].Index || e.RowIndex < 0)
                return;
            // Get the shape id
            int shapeId = (int)dataGridView_graph.Rows[e.RowIndex].Cells["Id"].Value;
            _model.RemoveShape(shapeId);
            UpdateGrid();
        }

        private void ButtonShape_Click(object sender, EventArgs e)
        {
            ClickHelper();
            if (!(sender is ToolStripButton button)) return;

            button.Checked = true;
            switch (button.Name)
            {
                case "buttonStart":
                    _startpressed = true;
                    break;
                case "buttonTerminator":
                    _terminatorpressed = true;
                    break;
                case "buttonProcess":
                    _processpressed = true;
                    break;
                case "buttonDecision":
                    _decisionpressed = true;
                    break;
            }
            SetMode();
        }
        private void SetMode()
        {
            if (_startpressed)
            {
                _model.SetMode("Start");
            }
            else if (_terminatorpressed)
            {
                _model.SetMode("Terminator");
            }
            else if (_processpressed)
            {
                _model.SetMode("Process");
            }
            else if (_decisionpressed)
            {
                _model.SetMode("Decision");
            }
        }
        private void ClickHelper()
        {
            _startpressed = false;
            _terminatorpressed = false;
            _processpressed = false;
            _decisionpressed = false;
            buttonStart.Checked = false;
            buttonTerminator.Checked = false;
            buttonProcess.Checked = false;
            buttonDecision.Checked = false;
        }
        private void UpdateView()
        {
            Invalidate(true);

        }

        private void HandelCanvasPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new FormGraphicAdapter(e.Graphics));
        }
    }
}
