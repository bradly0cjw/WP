using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HW2.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        public Model model = new Model();
        public PresentationModel pm;

        [TestInitialize()]
        public void Initialize()
        {
            pm = new PresentationModel(model);
        }
        //[TestMethod()]
        //public void PresetationModelTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void StartPressedTest()
        {
            pm.StartPressed();
            Assert.IsTrue(pm.IsStartChecked());
        }

        [TestMethod()]
        public void TerminatorPressedTest()
        {
            pm.TerminatorPressed();
            Assert.IsTrue(pm.IsTerminatorChecked());
        }

        [TestMethod()]
        public void ProcessPressedTest()
        {
            pm.ProcessPressed();
            Assert.IsTrue(pm.IsProcessChecked());
        }

        [TestMethod()]
        public void DecisionPressedTest()
        {
            pm.DecisionPressed();
            Assert.IsTrue(pm.IsDecisionChecked());
        }
        [TestMethod()]
        public void LinePressedTest()
        {
            pm.LinePressed();
            Assert.IsTrue(pm.IsLineChecked());
        }


        [TestMethod()]
        public void SelectPressedTest()
        {
            pm.SelectPressed();
            Assert.IsTrue(pm.IsSelectedChecked());
        }

        [TestMethod()]
        public void XChangedTest()
        {

            pm.XChanged("");
            Assert.IsFalse(pm.IsXValid());
            Assert.AreEqual(Color.Red, pm.XLabelColor());

            pm.XChanged("1");
            Assert.IsTrue(pm.IsXValid());
            Assert.AreEqual(Color.Black, pm.XLabelColor());
        }

        [TestMethod()]
        public void YChangedTest()
        {

            pm.YChanged("");
            Assert.IsFalse(pm.IsYValid());
            Assert.AreEqual(Color.Red, pm.YLabelColor());

            pm.YChanged("1");
            Assert.IsTrue(pm.IsYValid());
            Assert.AreEqual(Color.Black, pm.YLabelColor());
        }

        [TestMethod()]
        public void WidthChangedTest()
        {
            pm.WidthChanged("");
            Assert.IsFalse(pm.IsWidthValid());
            Assert.AreEqual(Color.Red, pm.WidthLabelColor());

            pm.WidthChanged("1");
            Assert.IsTrue(pm.IsWidthValid());
            Assert.AreEqual(Color.Black, pm.WidthLabelColor());
        }

        [TestMethod()]
        public void HeightChangedTest()
        {
            pm.HeightChanged("");
            Assert.IsFalse(pm.IsHeightValid());
            Assert.AreEqual(Color.Red, pm.HeightLabelColor());

            pm.HeightChanged("1");
            Assert.IsTrue(pm.IsHeightValid());
            Assert.AreEqual(Color.Black, pm.HeightLabelColor());
        }

        [TestMethod()]
        public void ShapeChangedTest()
        {

            pm.ShapeChanged("Start");
            Assert.IsTrue(pm.IsShapeValid());
            Assert.AreEqual(Color.Black, pm.ShapeNameColor());

            pm.ShapeChanged("Terminator");
            Assert.IsTrue(pm.IsShapeValid());
            Assert.AreEqual(Color.Black, pm.ShapeNameColor());

            pm.ShapeChanged("Process");
            Assert.IsTrue(pm.IsShapeValid());
            Assert.AreEqual(Color.Black, pm.ShapeNameColor());

            pm.ShapeChanged("Decision");
            Assert.IsTrue(pm.IsShapeValid());
            Assert.AreEqual(Color.Black, pm.ShapeNameColor());

            pm.ShapeChanged("aaa");
            Console.WriteLine(pm.IsShapeValid());
            Assert.IsFalse(pm.IsShapeValid());
            Assert.AreEqual(Color.Red, pm.ShapeNameColor());
        }

        [TestMethod()]
        public void TextChangedTest()
        {

            pm.TextChanged("aaa");
            Assert.IsTrue(pm.IsTextValid());
            Assert.AreEqual(Color.Black, pm.TextColor());

            pm.TextChanged("");
            Assert.IsFalse(pm.IsTextValid());
            Assert.AreEqual(Color.Red, pm.TextColor());

        }


        [TestMethod()]
        public void UpdateStateTest()
        {

            pm.SelectPressed();
            pm.UpdateState();
            Assert.IsTrue(pm.IsSelectedChecked());
            Assert.AreEqual(Cursors.Default, pm.CursorType());

            pm.StartPressed();
            pm.UpdateState();
            Assert.IsTrue(pm.IsStartChecked());
            Assert.AreEqual(Cursors.Cross, pm.CursorType());
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            pm.TextChanged("test");
            pm.XChanged("100");
            pm.YChanged("100");
            pm.WidthChanged("100");
            pm.HeightChanged("100");
            pm.ShapeChanged("Start");
            pm.AddShape();

            Assert.IsTrue(pm.IsAddEnabled);
            var shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);

        }

        [TestMethod()]

        public void NotifyTest()
        {
            PrivateObject po = new PrivateObject(pm);

            var propertyChanged = false;
            pm.PropertyChanged += (sender, e) =>
            {
                propertyChanged = true;
            };

            Assert.IsFalse(propertyChanged);
            pm.TextChanged("aaa");
            Assert.IsNotNull(po.GetFieldOrProperty("PropertyChanged"));
            Assert.IsTrue(propertyChanged);
        }

        [TestMethod()]
        public void UndoTest()
        {
            Assert.IsFalse(pm.IsUndoClickable());
            model.AddShape("Start", "test", 100, 100, 100, 100);
            Assert.IsTrue(pm.IsUndoClickable());
            Assert.AreEqual(1,model.GetShapes().Count);
            pm.Undo();
            Assert.AreEqual(0, model.GetShapes().Count);
            Assert.IsFalse(pm.IsUndoClickable());
        }
        [TestMethod()]
        public void RedoTest()
        {
            Assert.IsFalse(pm.IsRedoClickable());
            model.AddShape("Start", "test", 100, 100, 100, 100);
            Assert.AreEqual(1, model.GetShapes().Count);
            Assert.IsFalse(pm.IsRedoClickable());
            pm.Undo();
            Assert.AreEqual(0, model.GetShapes().Count);
            Assert.IsTrue(pm.IsRedoClickable());
            pm.Redo();
            Assert.AreEqual(1, model.GetShapes().Count);
            Assert.IsFalse(pm.IsRedoClickable());
        }

        [TestMethod()]
        public async Task SaveAsyncTest()
        {
            // Arrange
            string filePath = Path.Combine(Path.GetTempPath(), "test_save.p0n3");
            pm.TextChanged("test");
            pm.XChanged("100");
            pm.YChanged("100");
            pm.WidthChanged("100");
            pm.HeightChanged("100");
            pm.ShapeChanged("Start");
            pm.AddShape();
            pm.TextChanged("test");
            pm.XChanged("100");
            pm.YChanged("100");
            pm.WidthChanged("100");
            pm.HeightChanged("100");
            pm.ShapeChanged("Start");
            pm.AddShape();
            pm.TextChanged("test");
            pm.XChanged("0");
            pm.YChanged("1");
            pm.WidthChanged("1");
            pm.HeightChanged("1");
            pm.ShapeChanged("Line");
            pm.AddShape();
            Shape shape1 = model.GetShape(0);
            Shape shape2 = model.GetShape(1);
            Line line = (Line)model.GetShape(2);
            line.Shape1 = shape1;
            line.Shape2 = shape2;
            line.Connection1 = 0;
            line.Connection2 = 1;

            // Act
            pm.SaveAsync(filePath);

            // Assert
            Assert.IsTrue(File.Exists(filePath));
            var fileContent = File.ReadAllText(filePath);
            Assert.IsTrue(fileContent.Contains("Shape ID X Y W H Text"));
            Assert.IsTrue(fileContent.Contains("Start 0 100 100 100 100 test"));

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod()]
        public void LoadTest()
        {
            // Arrange
            string filePath = Path.Combine(Path.GetTempPath(), "test_load.p0n3");
            string fileContent = "Shape ID X Y W H Text\nStart 0 100 100 100 100 test\nStart 1 100 100 100 100 test\n---------\nLine ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2\nLine 2 0 1 1 2\n---------\n";
            File.WriteAllText(filePath, fileContent);

            // Act
            pm.Load(filePath);

            // Assert
            var shapes = model.GetShapes();
            Assert.AreEqual(3, shapes.Count);
            var shape = shapes.First();
            Assert.AreEqual("Start", shape.ShapeName);
            Assert.AreEqual(100, shape.X);
            Assert.AreEqual(100, shape.Y);
            Assert.AreEqual(100, shape.W);
            Assert.AreEqual(100, shape.H);
            Assert.AreEqual("test", shape.Text);


            fileContent = "@@@@@@@";
            File.WriteAllText(filePath, fileContent);
            pm.Load(filePath);

            fileContent = "Shape ID X Y W H Text\nStart 0 100 100 100 100\nStart 1 100 100 100 100 test\n---------\n";
            File.WriteAllText(filePath, fileContent);
            pm.Load(filePath);

            fileContent = "Shape ID X Y W H Text\nStart 0 100 100 100 100 test\nStart 1 100 100 100 100 test\n---------\nLine ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2\nLine 0 1 1 2\n---------\n";
            File.WriteAllText(filePath, fileContent);
            pm.Load(filePath);  

            fileContent = "Shape ID X Y W H Text\nStart 0 aaa 100 100 test\nStart 1 100 100 100 100 test\n---------\nLine ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2\nLine 0 1 1 2\n---------\n";
            File.WriteAllText(filePath, fileContent);
            pm.Load(filePath);
            // Cleanup
            File.Delete(filePath);

        }


        [TestMethod()]
        public void AutoSaveAsync_HasChangesFalse_DoesNotSave()
        {
            // Arrange
            model.HasChanges = false;

            // Act
            pm.AutoSaveAsync("test");

            // Assert
            // Ensure no backup folder is created
            string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
            Assert.IsFalse(Directory.Exists(backupFolder));
        }

        [TestMethod()]
        public void AutoSaveAsync_HasChangesTrue_SavesBackup()
        {
            // Arrange
            model.HasChanges = true;
            string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
            if (Directory.Exists(backupFolder))
            {
                Directory.Delete(backupFolder, true);
            }

            pm.TextChanged("test");
            pm.XChanged("100");
            pm.YChanged("100");
            pm.WidthChanged("100");
            pm.HeightChanged("100");
            pm.ShapeChanged("Start");
            pm.AddShape();
            pm.TextChanged("test");
            pm.XChanged("100");
            pm.YChanged("100");
            pm.WidthChanged("100");
            pm.HeightChanged("100");
            pm.ShapeChanged("Start");
            pm.AddShape();
            pm.TextChanged("test");
            pm.XChanged("0");
            pm.YChanged("1");
            pm.WidthChanged("1");
            pm.HeightChanged("1");
            pm.ShapeChanged("Line");
            pm.AddShape();

            Shape shape1 = model.GetShape(0);
            Shape shape2 = model.GetShape(1);
            Line line = (Line)model.GetShape(2);
            line.Shape1 = shape1;
            line.Shape2 = shape2;
            line.Connection1 = 0;
            line.Connection2 = 1;

            // Act
            pm.AutoSaveAsync("test");

            // Assert
            Assert.IsTrue(Directory.Exists(backupFolder));
            var backupFiles = Directory.GetFiles(backupFolder);
            Assert.IsTrue(backupFiles.Length > 0);
            var latestBackupFile = backupFiles.OrderByDescending(f => new FileInfo(f).CreationTime).First();
            var fileContent = File.ReadAllText(latestBackupFile);
            Assert.IsTrue(fileContent.Contains("Shape ID X Y W H Text"));
            Assert.IsTrue(fileContent.Contains("Start 0 100 100 100 100 test"));

            model.HasChanges = true;
            // Cleanup
            Directory.Delete(backupFolder, true);
        }



        [TestMethod()]
        public void TextChangeTest()
        {
            model.AddShape("Start","test",100,200,300,400);
            Shape shape = model.GetShapes().First();
            pm.TextChange(shape, "newText");
            Assert.AreEqual("newText", shape.Text);
        }

        [TestMethod()]
        public void ManageBackupFilesTest()
        {
            // Arrange
            string backupFolder = Path.Combine(Path.GetTempPath(), "test_backup");
            Directory.CreateDirectory(backupFolder);

            // Create 10 dummy backup files
            for (int i = 0; i < 10; i++)
            {
                string filePath = Path.Combine(backupFolder, $"backup_{i}.p0n3");
                File.WriteAllText(filePath, "dummy content");
                // Set different creation times
                File.SetCreationTime(filePath, DateTime.Now.AddMinutes(-i));
            }

            // Act
            pm.ManageBackupFiles(backupFolder);

            // Assert
            var remainingFiles = Directory.GetFiles(backupFolder);
            Assert.AreEqual(5, remainingFiles.Length);

            // Cleanup
            Directory.Delete(backupFolder, true);
        }

    }
}
