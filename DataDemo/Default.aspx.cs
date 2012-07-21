using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DataDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void DataAccess()
        {
            DataSet dsCustomerOrders = new DataSet("CustomerOrders");

            DataTable dtOrders = dsCustomerOrders.Tables.Add("Orders");
            DataTable dtCustomers = dsCustomerOrders.Tables.Add("Customers");

            DataColumn pkOrderID = dtOrders.Columns.Add("OrderID", typeof(Int32));
            dtOrders.Columns.Add("OrderQty", typeof(Int32));
            dtOrders.Columns.Add("Company", typeof(string));
            dtOrders.PrimaryKey = new DataColumn[] { pkOrderID };

            DataColumn pkCustomerID = dtCustomers.Columns.Add("CustomerID", typeof(Int32));
            dtCustomers.Columns.Add("Name", typeof(string));
            dtCustomers.Columns.Add("Age", typeof(Int32));
            dtCustomers.Columns.Add("OrderID", typeof(Int32));
            dtCustomers.PrimaryKey = new DataColumn[] { pkCustomerID };

            DataRelation drCustOrders1 = dsCustomerOrders.Relations.Add
                ("CustOrders1", dtOrders.Columns["OrderID"], dtCustomers.Columns["OrderID"]);

            DataRelation drCustOrders = dsCustomerOrders.Relations.Add
                ("CustOrders", dsCustomerOrders.Tables["Orders"].Columns["OrderID"], dsCustomerOrders.Tables["Customers"].Columns["OrderID"]);
        }
    }
}
