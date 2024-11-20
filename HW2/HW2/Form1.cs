using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace HW2
{
    public partial class Form1 : Form
    {
        private readonly Model _model;
        private readonly PresetationModel _pModel;


        public Form1(Model model)
        {
            this._pModel = new PresetationModel(model);
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();

            panel.MouseMove += MouseMoveHandler;
            panel.MouseDown += MouseDownHandeler;
            panel.MouseUp += MouseUpHandler;

            model.ModelChanged += UpdateView;
            model.ModelChanged += UpdateGrid;

            panel.Paint += HandelCanvasPaint;

            button_add.DataBindings.Add("Enabled", _pModel, "IsAddEnabled");

            buttonStart.Click += ButtonStart_Click;
            buttonTerminator.Click += ButtonTerminator_Click;
            buttonProcess.Click += ButtonProcess_Click;
            buttonDecision.Click += ButtonDecision_Click;
            buttonSelect.Click += ButtonSelect_Click;

            
            this._model = model; // Assign the model parameter to the _model field
            dataGridView_graph.CellClick += DataGridView_graph_CellClick;
            _pModel.SelectPressed();
            RefreshControls();
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
            _model.PointerMove(e.X, e.Y);
        }

        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            _model.PointerUp(e.X, e.Y);
        }

        private void MouseDownHandeler(object sender, MouseEventArgs e)
        {
            _model.PointerDown(e.X, e.Y);
        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            
                _pModel.AddShape();
                UpdateGrid();
            

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

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            _pModel.StartPressed();
            RefreshControls();
        }

        private void ButtonTerminator_Click(object sender, EventArgs e)
        {
            _pModel.TerminatorPressed();
            RefreshControls();
        }

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            _pModel.ProcessPressed();
            RefreshControls();
        }

        private void ButtonDecision_Click(object sender, EventArgs e)
        {
            _pModel.DecisionPressed();
            RefreshControls();
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            _pModel.SelectPressed();
            RefreshControls();
        }
        private void RefreshControls()
        {
            buttonStart.Checked = _pModel.IsStartChecked();
            buttonTerminator.Checked = _pModel.IsTerminatorChecked();
            buttonProcess.Checked = _pModel.IsProcessChecked();
            buttonDecision.Checked = _pModel.IsDecisionChecked();
            buttonSelect.Checked = _pModel.IsSelectedChecked();

            panel.Cursor = _pModel.CursorType();

            textBox_h_readonly.ForeColor = _pModel.HeightLabelColor();
            textBox_w_readonly.ForeColor = _pModel.WidthLabelColor();
            textBox_x_readonly.ForeColor = _pModel.XLabelColor();
            textBox_y_readonly.ForeColor = _pModel.YLabelColor();
            comboBox_shapeName.ForeColor = _pModel.ShapeNameColor();

        }
        private void UpdateView()
        {
            Invalidate(true);
            RefreshControls();
        }

        private void HandelCanvasPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new FormGraphicAdapter(e.Graphics));
        }

        private void TextBox_x_TextChanged(object sender, EventArgs e)
        {
            _pModel.XChanged(textBox_x.Text);
            RefreshControls();
        }

        private void TextBox_y_TextChanged(object sender, EventArgs e)
        {
            _pModel.YChanged(textBox_y.Text);
            RefreshControls();
        }

        private void TextBox_height_TextChanged(object sender, EventArgs e)
        {
            _pModel.HeightChanged(textBox_height.Text);
            RefreshControls();
        }

        private void TextBox_width_TextChanged(object sender, EventArgs e)
        {
            _pModel.WidthChanged(textBox_width.Text);
            RefreshControls();
        }

        private void ComboBox_shapeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pModel.ShapeChanged(comboBox_shapeName.Text);
            RefreshControls();
        }

        private void TextBox_text_TextChanged(object sender, EventArgs e)
        {
            _pModel.TextChanged(textBox_text.Text);
        }
    }
}
