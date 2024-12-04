using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Tests
{
    [TestClass()]
    public class PresetationModelTests
    {
        public Model model = new Model();
        public PresetationModel pm;

        [TestInitialize()]
        public void Initialize()
        {
            pm = new PresetationModel(model);
        }
        [TestMethod()]
        public void PresetationModelTest()
        {
            Assert.Fail();
        }
        
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
        public void SelectPressedTest()
        {
            pm.SelectPressed();
            Assert.IsTrue(pm.IsSelectedChecked());
        }

        [TestMethod()]
        public void XChangedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void YChangedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WidthChangedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HeightChangedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShapeChangedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TextChangedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsXValidTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsYValidTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsWidthValidTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsHeightValidTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsShapeValidTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void XLabelColorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void YLabelColorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WidthLabelColorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HeightLabelColorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShapeNameColorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CursorTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            Assert.Fail();
        }
    }
}