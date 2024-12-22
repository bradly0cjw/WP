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
        
    }
}