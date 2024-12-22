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
    public class PresentationModel2Tests
    {
        public Model model = new Model();
        public PresentationModel2 pm;
        public String test = "test";

        [TestInitialize()]
        public void Initialize()
        {
            pm = new PresentationModel2(test);
        }
        [TestMethod()]
        public void TextChangedTest()
        {
            Assert.IsFalse(pm.IsConfirmEnabled);
            pm.TextChanged("test2");
            Assert.IsTrue(pm.IsConfirmEnabled);
            pm.TextChanged("test");
            Assert.IsFalse(pm.IsConfirmEnabled);
            pm.TextChanged("");
            Assert.IsFalse(pm.IsConfirmEnabled);
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


    }
}