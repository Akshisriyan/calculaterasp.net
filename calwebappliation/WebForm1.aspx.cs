using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calwebappliation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            calService.WebService1SoapClient client = new calService.WebService1SoapClient();
           int result= client.Add(Convert.ToInt32(txtFirstNumber.Text), Convert.ToInt32(txtSecondNumber.Text));

            lblResult.Text = result.ToString();

            gvCalculation.DataSource = client.GetCalculations();
            gvCalculation.DataBind();

            gvCalculation.HeaderRow.Cells[0].Text = "Recent Calculations";
            

        }
}
}