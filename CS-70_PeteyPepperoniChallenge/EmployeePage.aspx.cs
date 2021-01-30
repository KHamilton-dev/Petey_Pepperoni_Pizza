using PeteyPepperoni.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_70_PeteyPepperoniChallenge
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderStorageEntities db = new OrderStorageEntities();

            if (!Page.IsPostBack)
            {
                orderGridView.DataSource = db.OrderInformations.ToList();
                orderGridView.DataBind(); 
            }
        }
        protected void orderGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            orderGridView.Rows[index].Visible = false;
        }
    }
}