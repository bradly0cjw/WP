using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Point = System.Windows.Point;

namespace HW2.GUITests
{
    public class UITest
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public UITest(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            options.AddAdditionalCapability("platformName","Windows");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} dataItem {rowIndex}").Click();
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        public void AssertChecked(string controlName,bool state)
        {
            var control = _driver.FindElementByName(controlName);
            string toggleState = control.GetAttribute("Toggle.ToggleState");
            bool isChecked;
            if (bool.TryParse(toggleState, out isChecked))
            {
                Assert.AreEqual(state, isChecked);
            }
        }

        // test
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rows = dataGridView.FindElementsByXPath("//DataItem");
            

            Assert.AreEqual(1,rows.Count);

            // Split the actual value by the delimiter used in the Value property

            // Ensure the actual data length matches the expected data length
            //    for (int i = 0; i < data.Length; i++)
            //    {
            //        string actualText = actualData[i].Replace("(null)", "");
            //        string expectedText = data[i];
            //        Console.WriteLine($"Comparing cell {i}: expected '{expectedText}', actual '{actualText}'");
            //        Assert.AreEqual(expectedText, actualText);
            //    }
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }

        }
        //public void MouseDown(int x, int y)
        //{
        //    var panel = _driver.FindElementByName("panel");
        //    var action = new OpenQA.Selenium.Interactions.Actions(_driver);
        //    action.MoveToElement(panel,10,10).MoveByOffset(x, y).ClickAndHold().Perform();
        //}

        public void MouseMove(int x,int y,int fx, int fy)
        {
            var panel = _driver.FindElementByName("panel");
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(panel, x, y).MoveByOffset(fx-x, fy-y).Perform();
        }

        //public void MouseUp(int x, int y)
        //{
        //    var panel = _driver.FindElementByName("panel");
        //    var action = new OpenQA.Selenium.Interactions.Actions(_driver);
        //    action.MoveToElement(panel, 10, 10).MoveByOffset(x, y).Release().Perform();
        //}

        //public void MouseClickNHold(int x, int y)
        //{
        //    var panel = _driver.FindElementByName("panel");
        //    var action = new OpenQA.Selenium.Interactions.Actions(_driver);
        //    action.MoveToElement(panel, 10, 10).ClickAndHold().MoveByOffset(x, y).Release().Perform();
        //}

        //public void MouseClick(int x, int y)
        //{
        //    var panel = _driver.FindElementByName("panel");
        //    var action = new OpenQA.Selenium.Interactions.Actions(_driver);
        //    action.MoveToElement(panel, 10, 10).MoveByOffset(x, y).Click().Perform();
        //}

        
        public void MouseClickNHold(int x, int y,int fx,int fy)
        {
            var panel = _driver.FindElementByName("panel");
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(panel, x, y).ClickAndHold().MoveByOffset(fx - x, fy-y).Release().Perform();
        }

        public void MouseDoubleClick(int x, int y)
        {
            var panel = _driver.FindElementByName("panel");
            var action = new OpenQA.Selenium.Interactions.Actions(_driver);
            action.MoveToElement(panel, 0, 0).MoveByOffset(x, y).DoubleClick().Perform();
        }

        public void SetComboBox(string itemName)
        {
            var comboBox = _driver.FindElementByName("comboBox_shapeName");
            comboBox.Click();
            var items = comboBox.FindElementsByXPath("//ListItem");
            foreach (var item in items)
            {
                if (item.Text == itemName)
                {
                    item.Click();
                    break;
                }
            }
        }

        public void SetTextBox(string name, string text)
        {
            var textBox = _driver.FindElementByAccessibilityId(name);
            textBox.Clear();
            textBox.SendKeys(text);
        }

    }
}