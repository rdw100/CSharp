using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp.DAction.Demo
{
    /// <summary>
    /// An Action encapsulates a method (holds a reference of one or more 
    /// methods) that has N parameters and does not return a value.
    /// </summary>
    /// <remarks>
    /// Use action or func instead of defining a custom delegate type. 
    /// </remarks>
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void isNotNull_ObjectWithActions_True()
        {
            Printable printer = new Printable();
            Saveable saver = new Saveable();

            var etl = new File(printer, saver);

            foreach (var action in etl.actionsPerformed)
            {
                action.PerformAction();
            }

            Assert.IsNotNull(etl);
        }

        [TestMethod]
        public void areEqual_Action_True()
        {
            Printable printer = new Printable();

            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            Action printIt = new Action(printer.PrintToNetwork);
            printIt();

            string expected = string.Format("Print to network!");
            Assert.AreEqual(expected, sw.ToString());
        }
    }

    public class File
    {
        public List<IAction> actionsPerformed = new List<IAction>();

        public File (params IAction[] action)
        {
            this.actionsPerformed.AddRange(action);
        }
    }

    public interface IAction
    {
        void PerformAction();
    }

    public class Printable : IAction
    {

        private void PrintToConsole()
        {
            Console.WriteLine("Printed to console!");
        }

        public void PrintToNetwork()
        {
            Console.Write("Print to network!");
        }

        public void PerformAction()
        {
            this.PrintToConsole();
        }
    }

    public class Saveable : IAction
    {
        private void Save()
        {
            Console.WriteLine("Save to file!");
        }

        public void PerformAction()
        {
            this.Save();
        }
    }
}
