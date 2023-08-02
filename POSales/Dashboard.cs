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

namespace POSales
{
    public partial class Dashboard : Form
    {
        SqlConnection cn = new SqlConnection();        
        DBConnect dbcon = new DBConnect();

        public Dashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string sdate = DateTime.Now.ToShortDateString();
            lblDalySale.Text = dbcon.ExtractData("SELECT ISNULL(SUM(total),0) AS total FROM tbCart WHERE status LIKE 'Sold' AND sdate BETWEEN '"+sdate+ "' AND '" + sdate + "'").ToString("#,##0.00");
            lblTotalProduct.Text = dbcon.ExtractData("SELECT COUNT(*) FROM tbProduct").ToString("#,##0");
            lblStockOnHand.Text = dbcon.ExtractData("SELECT ISNULL(SUM(qty), 0) AS qty FROM tbProduct").ToString("#,##0");
            lblCriticalItems.Text = dbcon.ExtractData("SELECT COUNT(*) FROM vwCriticalItems").ToString("#,##0");
            getTopSell();
            getTopSellMonth();


        }
        public void getTopSell()
        {
            cn.Open();
            SqlCommand cm = new SqlCommand("select top 1 pdesc,sum(qty) as tsum from vwTopSelling where status='Sold' group by pdesc order by tsum desc", cn);
            SqlDataReader dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblTopSelling.Text = dr["pdesc"].ToString();
                lblQuantity.Text = dr["tsum"].ToString() + " )";
            }
            cn.Close();
        }
        public void getTopSellMonth()
        {
            cn.Open();
            var date = DateTime.Now.Month;
            string month;
            //label13.Text = date;
            if (date == 1) month = "January";
            else if (date == 2) month = "February";
            else if (date == 3) month = "March";
            else if (date == 4) month = "April";
            else if (date == 5) month = "May";
            else if (date == 6) month = "June";
            else if (date == 7) month = "July";
            else if (date == 8) month = "August";
            else if (date == 9) month = "September";
            else if (date == 10) month = "October";
            else if (date == 11) month = "November";
            else month = "December";
            lblMonth.Text= month;   

            SqlCommand cm = new SqlCommand("SELECT Top 1 pdesc, sum(qty)as SQty FROM vwTopSelling  where status LIKE 'Sold' and sdate like '______"+date+"___' group by pdesc order by SQty desc", cn);
            SqlDataReader dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblSoldMonth.Text = dr["pdesc"].ToString();
                lblQuanMonth.Text = dr["SQty"].ToString()+" )";
            }
            else
            {
                lblSoldMonth.Text = "";
                lblQuanMonth.Text = "0 )";
            }
            cn.Close();
        }

    }
}
