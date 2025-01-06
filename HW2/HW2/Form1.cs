using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace HW2
{
    public partial class Form1 : Form
    {
        private readonly Model _model;
        private readonly PresentationModel _pModel;
        private readonly Timer _autoSaveTimer;


        public Form1(Model model)
        {
            this._pModel = new PresentationModel(model);
            InitializeComponent();
            InitializeComboBox();
            InitializeDataGridView();

            // Initialize the auto-save timer
            _autoSaveTimer = new Timer();
            _autoSaveTimer.Interval = 30000; // 30 seconds
            _autoSaveTimer.Tick += AutoSaveTimer_Tick;
            _autoSaveTimer.Start();


            panel.MouseMove += MouseMoveHandler;
            panel.MouseDown += MouseDownHandeler;
            panel.MouseUp += MouseUpHandler;
            panel.MouseDoubleClick += MouseDoubleClickHandler;

            model.ModelChanged += UpdateView;
            model.ModelChanged += UpdateGrid;

            panel.Paint += HandelCanvasPaint;

            button_add.DataBindings.Add("Enabled", _pModel, "IsAddEnabled");


            buttonStart.Click += ButtonStart_Click;
            buttonTerminator.Click += ButtonTerminator_Click;
            buttonProcess.Click += ButtonProcess_Click;
            buttonDecision.Click += ButtonDecision_Click;
            buttonSelect.Click += ButtonSelect_Click;
            buttonUndo.Click += ButtonUndo_Click;
            buttonRedo.Click += ButtonRedo_Click;
            buttonLine.Click += ButtonLine_Click;
            ButtonSave.Click += ButtonSave_Click;
            ButtonLoad.Click += ButtonLoad_Click;


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

        private void MouseDoubleClickHandler(object sender, MouseEventArgs e)
        {
            _model.PointerDoubleClick(e.X, e.Y);
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

        private void ButtonLine_Click(object sender, EventArgs e)
        {
            _pModel.LinePressed();
            RefreshControls();
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            _pModel.Undo();
            RefreshControls();
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            _pModel.Redo();
            RefreshControls();
        }

        private async void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            if (_model.HasChanges) // Assuming you have a way to check if the model has changes
            {
                string originalTitle = this.Text;
                this.Text += " Auto saving...";

                string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
                Directory.CreateDirectory(backupFolder);

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string backupFileName = $"{timestamp}_bak.p0n3";
                string backupFilePath = Path.Combine(backupFolder, backupFileName);

                try
                {
                    await _model.SaveAsync(backupFilePath);
                    ManageBackupFiles(backupFolder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Auto-save failed. Error: {ex.Message}", "Auto-Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Text = originalTitle;
                }
            }
        }

        private void ManageBackupFiles(string backupFolder)
        {
            var backupFiles = new DirectoryInfo(backupFolder).GetFiles()
                .OrderByDescending(f => f.CreationTime)
                .Skip(5)
                .ToList();

            foreach (var file in backupFiles)
            {
                file.Delete();
            }
        }



        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Pony files (*.p0n3)|*.p0n3|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ButtonSave.Enabled = false;
                    try
                    {
                        await _model.SaveAsync(saveFileDialog.FileName);
                        MessageBox.Show("Save completed successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save the file. Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        ButtonSave.Enabled = true;
                    }
                }
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pony files (*.p0n3)|*.p0n3|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _model.Load(openFileDialog.FileName);
                        MessageBox.Show("Load completed successfully.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load the file. Error: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void RefreshControls()
        {
            buttonStart.Checked = _pModel.IsStartChecked();
            buttonTerminator.Checked = _pModel.IsTerminatorChecked();
            buttonProcess.Checked = _pModel.IsProcessChecked();
            buttonDecision.Checked = _pModel.IsDecisionChecked();
            buttonSelect.Checked = _pModel.IsSelectedChecked();
            buttonLine.Checked = _pModel.IsLineChecked();

            buttonUndo.Enabled = _pModel.IsUndoClickable();
            buttonRedo.Enabled = _pModel.IsRedoClickable();

            panel.Cursor = _pModel.CursorType();

            textBox_h_readonly.ForeColor = _pModel.HeightLabelColor();
            textBox_w_readonly.ForeColor = _pModel.WidthLabelColor();
            textBox_x_readonly.ForeColor = _pModel.XLabelColor();
            textBox_y_readonly.ForeColor = _pModel.YLabelColor();
            comboBox_shapeName.ForeColor = _pModel.ShapeNameColor();
            textBox_text_readonly.ForeColor = _pModel.TextColor();

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
            RefreshControls();
        }
    }
}
