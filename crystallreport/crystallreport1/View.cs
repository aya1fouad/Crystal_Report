using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crystallreport1
{
    public partial class View : Form
    {
        int x;
        SqlConnection con = new SqlConnection();
        
        public View()
        {
            InitializeComponent();
        }
        public View(string _x)
        {
            InitializeComponent();

            this.x = int.Parse(_x);
        }
        private void View_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=.;Initial Catalog=AdventureWorks2012;Integrated Security=True";
            string sql = "SELECT Purchasing.PurchaseOrderHeader.PurchaseOrderID, Employee_1.NationalIDNumber, Sales.Customer.CustomerID, Sales.Customer.PersonID, Purchasing.PurchaseOrderHeader.OrderDate, Production.Product.Name,Production.ProductCategory.Name AS CatName, Purchasing.PurchaseOrderDetail.OrderQty, Purchasing.PurchaseOrderDetail.UnitPrice,Purchasing.PurchaseOrderDetail.UnitPrice* Purchasing.PurchaseOrderDetail.OrderQty AS Total FROM Purchasing.PurchaseOrderHeader INNER JOIN HumanResources.Employee AS Employee_1 ON Purchasing.PurchaseOrderHeader.EmployeeID = Employee_1.BusinessEntityID AND Purchasing.PurchaseOrderHeader.EmployeeID = Employee_1.BusinessEntityID INNER JOIN Purchasing.PurchaseOrderDetail ON Purchasing.PurchaseOrderHeader.PurchaseOrderID = Purchasing.PurchaseOrderDetail.PurchaseOrderID AND Purchasing.PurchaseOrderHeader.PurchaseOrderID = Purchasing.PurchaseOrderDetail.PurchaseOrderID AND Purchasing.PurchaseOrderHeader.PurchaseOrderID = Purchasing.PurchaseOrderDetail.PurchaseOrderID INNER JOIN Production.Product ON Purchasing.PurchaseOrderDetail.ProductID = Production.Product.ProductID AND Purchasing.PurchaseOrderDetail.ProductID = Production.Product.ProductID AND Purchasing.PurchaseOrderDetail.ProductID = Production.Product.ProductID CROSS JOIN Production.ProductCategory CROSS JOIN Sales.Customer WHERE Purchasing.PurchaseOrderHeader.PurchaseOrderID =" + x;
            DataSet1 ds = new DataSet1();
            SqlDataAdapter DA = new SqlDataAdapter(sql, con);
            DA.Fill(ds.Tables["Order"]);
            CrystalReport1 orders = new CrystalReport1();
            orders.SetDataSource(ds.Tables["Order"]);
            crystalReportViewer1.ReportSource = orders;
            crystalReportViewer1.Refresh();
     
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
