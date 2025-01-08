using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace HW2.GUITests
{
    [TestClass()]
    public class DrawGUITests
    {
        private const string WinAppDriverUrl = "http://127.0.0.1:4723";
        private UITest uiTest;
        private string targetAppPath;

        [TestInitialize]
        public void Setup()
        {
            var projectName = "HW2";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "HW2.exe");
            Console.Write(targetAppPath);

            uiTest = new UITest(targetAppPath, "MyDrawing"); // Replace "RootWindowName" with the actual root window name
        }

        [TestCleanup()]
        public void Cleanup()
        {
            uiTest.CleanUp();
        }

        [TestMethod]
        public void TestDrawShapes()
        {
            // Click the Start button and assert it is checked
            uiTest.ClickButton("Start");
            uiTest.AssertChecked("Start", true);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", false);

            // Simulate mouse down at the starting point
            int x = 110;
            int y = 110;
            uiTest.MouseClickNHold(10,10,x,y);

            // Assert the shape is drawn and its properties in DataGridView
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", startX.ToString(), startY.ToString(), (endX - startX).ToString(), (endY - startY).ToString(), "test" });

            // Repeat for other shapes
            uiTest.ClickButton("Terminator");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", true);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select",false);
            uiTest.AssertChecked("Line",false);

            x = 300;
            y = 200;
            uiTest.MouseClickNHold(100, 100, x, y);

            uiTest.ClickButton("Process");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", true);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", false);

            x = 400;
            y = 300;
            uiTest.MouseClickNHold(200, 200, x, y);

            uiTest.ClickButton("Decision");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", true);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", false);

            // Simulate mouse down at the starting point
            x = 400;
            y = 400;
            uiTest.MouseClickNHold(300, 300, x, y);

            uiTest.ClickButton("Line");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", true);

            // Simulate mouse down at the starting point
            x = 398;
            y = 250;
            //uiTest.MouseMove(200,100,x,y);
            Thread.Sleep(2000);
            uiTest.MouseClickNHold(200, 100, x, y);
            
        }

        [TestMethod]
        public void TestUndoRedoAdd()
        {
            // Draw a shape
            uiTest.ClickButton("Start");

            // Simulate mouse down at the starting point
            int x = 110;
            int y = 110;
            uiTest.MouseClickNHold(10, 10, x, y);
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);

            // Undo the action and assert the shape is removed
            uiTest.ClickButton("buttonUndo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 0);

            // Redo the action and assert the shape is added back
            uiTest.ClickButton("buttonRedo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });
        }
        [TestMethod]
        public void TestUndoRedoAddDataGridView()
        {
            // Draw a shape
            uiTest.SetTextBox("textBox_x", "100");
            uiTest.SetTextBox("textBox_y", "100");
            uiTest.SetTextBox("textBox_width", "100");
            uiTest.SetTextBox("textBox_height", "100");
            uiTest.SetTextBox("textBox_text", "test");

            // Add shape via DataGridView
            uiTest.ClickButton("button_add");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);

            // Undo the action and assert the shape is removed
            uiTest.ClickButton("buttonUndo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 0);

            // Redo the action and assert the shape is added back
            uiTest.ClickButton("buttonRedo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });
        }
        [TestMethod]
        public void TestUndoRedoAddLine()
        {
            // Draw a shape
            uiTest.ClickButton("Start");


            // Simulate mouse down at the starting point
            int x = 110;
            int y = 110;
            uiTest.MouseClickNHold(10, 10, x, y);

            uiTest.ClickButton("Process");
            

            x = 400;
            y = 300;
            uiTest.MouseClickNHold(200, 200, x, y);

            uiTest.ClickButton("Line");

            uiTest.MouseClickNHold(200, 100, x, y);
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);

            // Undo the action and assert the shape is removed
            uiTest.ClickButton("buttonUndo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 0);

            // Redo the action and assert the shape is added back
            uiTest.ClickButton("buttonRedo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });
        }
        [TestMethod]
        public void TestUndoRedoMove()
        {
            // Draw a shape
            uiTest.ClickButton("Start");


            // Simulate mouse down at the starting point
            int x = 200;
            int y = 200;
            uiTest.MouseClickNHold(1, 1, x, y);

            // Drag the shape
            Thread.Sleep(500);
            uiTest.MouseClickNHold(150, 150, 300, 300);

            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);

            // Undo the action and assert the shape is removed
            uiTest.ClickButton("buttonUndo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 0);

            // Redo the action and assert the shape is added back
            uiTest.ClickButton("buttonRedo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });
        }
        [TestMethod]
        public void TestUndoRedoTextMove()
        {
            // Draw a shape
            uiTest.ClickButton("Start");

            // Simulate mouse down at the starting point
            int x = 200;
            int y = 200;
            uiTest.MouseClickNHold(1, 1, x, y);

            // Drag the shape
            Thread.Sleep(500);
            uiTest.MouseClickNHold(132, 102, 162, 112);

            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);

            // Undo the action and assert the shape is removed
            uiTest.ClickButton("buttonUndo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 0);

            // Redo the action and assert the shape is added back
            uiTest.ClickButton("buttonRedo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });
        }
        [TestMethod]
        public void TestUndoRedoTextChange()
        {
            // Draw a shape
            uiTest.ClickButton("Start");


            int x = 200;
            int y = 200;
            uiTest.MouseClickNHold(1, 1, x, y);

            Thread.Sleep(500);

            //// Modify the text
            uiTest.MouseDoubleClick(132, 100);
            uiTest.SetTextBox("textBoxNewText", "newText");
            uiTest.ClickButton("OK");

            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);

            // Undo the action and assert the shape is removed
            uiTest.ClickButton("buttonUndo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 0);

            // Redo the action and assert the shape is added back
            uiTest.ClickButton("buttonRedo");
            //uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 1);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });
        }
        [TestMethod]
        public void TestAddDeleteShapeViaDataGridView()
        {
            // Select shape and input details
            uiTest.SetComboBox("Start");
            uiTest.SetTextBox("textBox_x", "100");
            uiTest.SetTextBox("textBox_y", "100");
            uiTest.SetTextBox("textBox_width", "100");
            uiTest.SetTextBox("textBox_height", "100");
            uiTest.SetTextBox("textBox_text", "test");

            // Add shape via DataGridView
            uiTest.ClickButton("button_add");
            uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });

            // Delete shape via DataGridView
            uiTest.ClickDataGridViewCellBy("dataGridView_graph", 0, "Delete");
            uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 0);
        }

        [TestMethod]
        public void TestDragShape()
        {
            // Draw a shape
            uiTest.ClickButton("Start");
            uiTest.AssertChecked("Start", true);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);

            // Simulate mouse down at the starting point
            int x = 200;
            int y = 200;
            uiTest.MouseClickNHold(1, 1, x, y);

            // Drag the shape
            Thread.Sleep(500);
            uiTest.MouseClickNHold(150, 150, 300, 300);
            //Thread.Sleep(5000);

            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "200", "200", "100", "100", "test" });
        }

        [TestMethod]
        public void TestDragText()
        {
            uiTest.ClickButton("Start");
            uiTest.AssertChecked("Start", true);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });

            int x = 200;
            int y = 200;
            uiTest.MouseClickNHold(1, 1, x, y);

            // Drag the shape
            Thread.Sleep(500);
            uiTest.MouseClickNHold(132, 102, 162, 112);

            // Drag the text
            //uiTest.DragText("Start", 200, 200);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "200", "200", "100", "100", "test" });
        }

        [TestMethod]
        public void TestModifyText()
        {
            // Draw a shape
            uiTest.ClickButton("Start");
            uiTest.AssertChecked("Start", true);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });

            int x = 200;
            int y = 200;
            uiTest.MouseClickNHold(1, 1, x, y);

            Thread.Sleep(500);

            //// Modify the text
            uiTest.MouseDoubleClick(132,100);
            uiTest.SetTextBox("textBoxNewText", "newText");
            uiTest.ClickButton("OK");
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "newText" });
        }

        [TestMethod]
        public void TestSaveLoad()
        {
            
            // Draw shapes and save
            uiTest.SetComboBox("Start");
            uiTest.SetTextBox("textBox_x", "100");
            uiTest.SetTextBox("textBox_y", "100");
            uiTest.SetTextBox("textBox_width", "100");
            uiTest.SetTextBox("textBox_height", "100");
            uiTest.SetTextBox("textBox_text", "test");

            // Add shape via DataGridView
            uiTest.ClickButton("button_add");
            uiTest.ClickButton("ButtonSave");
            uiTest.ClickButton("Save");
            try
            {
                uiTest.ClickButton("Yes");
            }
            catch
            {

            }

            //uiTest.SaveFile("test.mydrawing");
            uiTest.AssertEnable("ButtonSave", false);

            Thread.Sleep(4000);
            uiTest.ClickButton("OK");
            // Perform other actions while saving
            uiTest.ClickButton("Process");
            uiTest.AssertEnable("Process", true);

            // Load the saved file
            uiTest.ClickButton("ButtonLoad");
            uiTest.ClickButton("Open");
            //uiTest.LoadFile("test.mydrawing");
            //uiTest.AssertDataGridViewRowDataBy("dataGridView_graph", 0, new string[] { "Start", "100", "100", "100", "100", "test" });
        }

        [TestMethod]
        public void TestAutoSave()
        {
            // Draw a shape
            uiTest.SetComboBox("Start");
            uiTest.SetTextBox("textBox_x", "100");
            uiTest.SetTextBox("textBox_y", "100");
            uiTest.SetTextBox("textBox_width", "100");
            uiTest.SetTextBox("textBox_height", "100");
            uiTest.SetTextBox("textBox_text", "test");

            
            // Wait for auto-save
            uiTest.Sleep(30);
            uiTest.AssertText("statusLabel", "Auto Saving");

            // Perform other actions while auto-saving
            uiTest.ClickButton("Process");
            uiTest.AssertEnable("Process", true);

            // Assert auto-save file exists
            string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
            Assert.IsTrue(Directory.GetFiles(backupFolder, "*_bak.mydrawing").Length > 0);
        }

        [TestMethod]
        public void TestIntegration()
        {
            // Draw shapes and lines
            uiTest.ClickButton("Start");
            uiTest.ClickButton("Add");
            uiTest.ClickButton("Terminator");
            uiTest.ClickButton("Add");
            uiTest.ClickButton("Process");
            uiTest.ClickButton("Add");
            uiTest.ClickButton("Decision");
            uiTest.ClickButton("Add");
            uiTest.ClickButton("Line");
            uiTest.ClickButton("Add");

            // Save and load
            uiTest.ClickButton("Save");
            //uiTest.SaveFile("integration.mydrawing");
            uiTest.ClickButton("Load");
            //uiTest.LoadFile("integration.mydrawing");

            // Assert shapes and lines are correct
            uiTest.AssertDataGridViewRowCountBy("dataGridView_graph", 5);
        }
    }
}
