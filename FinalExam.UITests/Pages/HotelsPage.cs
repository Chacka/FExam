using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.UITests.Pages
{
    public class HotelsPage
    {
        private IWebDriver Driver { get; set; }

        private IWebElement AddButton { get; set; }

        private IWebElement TableElement { get; set; }

        private List<IWebElement> Rows { get; set; }

        private List<IWebElement> Cells { get; set; }

        public Table HotelsTable { get; set; }

        public HotelsPage(IWebDriver driver)
        {
            Driver = driver;
            AddButton = Driver.FindElement(By.XPath("//button[contains(text(),'Add')]"));
            TableElement = Driver.FindElement(By.CssSelector("table.table"));
            HotelsTable = new Table(TableElement, Driver);
        }
    }

    public struct Table
    {
        private IWebDriver Driver { get; set; }
        public Table(IWebElement table,IWebDriver driver)
        {
            Driver = driver;
            CurrentTable = table;
            Rows = new List<Row>();
            var Rowelements = CurrentTable.FindElements(By.XPath("./tr"));
            foreach (var item in Rowelements)
            {
                Rows.Add(new Row(item, Driver));
            }
        }
        public IWebElement CurrentTable { get; set; }
        public List<Row> Rows { get; set; }
    }

    public struct Row
    {
        private IWebDriver Driver { get; set; }
        public Row(IWebElement row, IWebDriver driver)
        {
            Driver = driver;
            CurrentRow = row;
            Cells = new List<Cell>();
            var CellElements = CurrentRow.FindElements(By.XPath("./td"));
            foreach (var item in CellElements)
            {
                Cells.Add(new Cell(item));
            }
        }
        public IWebElement CurrentRow { get; set; }
        public List<Cell> Cells { get; set; }
    }

    public struct Cell
    {
        public IWebElement CurrentCell { get; set; }

        public Cell(IWebElement cell)
        {
            CurrentCell = cell;
        }
    }

}
