using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_70_PeteyPepperoniChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populating total label
            if (Page.IsPostBack)
            {
                double total = 0;
                if (sizeDropDownList.SelectedValue == "Small") total += 12.0;
                if (sizeDropDownList.SelectedValue == "Medium") total += 14.0;
                if (sizeDropDownList.SelectedValue == "Large") total += 18.0;
                if (crustDropDownList.SelectedValue == "Thick") total += 2.0;
                if (sausageCheckBox.Checked) total += .50;
                if (mushroomsCheckBox.Checked) total += .50;
                if (blackOlivesCheckBox.Checked) total += .50;
                if (greenOlivesCheckBox.Checked) total += .50;
                totalLabel.Text = total.ToString("C2");
            }
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            //adding to db
            var newOrder = new PeteyPepperoni.DTO.OrderDetails();

            newOrder.Size = sizeDropDownList.SelectedValue;
            newOrder.Crust = crustDropDownList.SelectedValue;
            if (sausageCheckBox.Checked) newOrder.Sausage = true;
            if (mushroomsCheckBox.Checked) newOrder.Mushrooms = true;
            if (blackOlivesCheckBox.Checked) newOrder.BlackOlives = true;
            if (greenOlivesCheckBox.Checked) newOrder.GreenOlives = true;
            newOrder.Name = nameTextBox.Text;
            newOrder.Address = addressTextBox.Text;
            newOrder.ZipCode = zipCodeTextBox.Text;
            if (cashRadioButton.Checked) newOrder.PaymentMethod = "Cash";
            if (creditRadioButton.Checked) newOrder.PaymentMethod = "Credit";

            //exceptions
            if (sizeDropDownList.SelectedValue == "null")
            {
                resultLabel.Text = "Please select a size.";
                return;
            }
            else if (crustDropDownList.SelectedValue == "null")
            {
                resultLabel.Text = "Please select a crust.";
                return;
            }
            else if (nameTextBox.Text.Length == 0)
            {
                resultLabel.Text = "Please enter a name.";
                return;
            }
            else if (addressTextBox.Text.Length == 0)
            {
                resultLabel.Text = "Please enter an address.";
                return;
            }
            else if (zipCodeTextBox.Text.Length == 0)
            {
                resultLabel.Text = "Please enter a zip code.";
                return;
            }
            else if (!cashRadioButton.Checked && !creditRadioButton.Checked)
            {
                resultLabel.Text = "Please select a payment method.";
                return;
            }
            else
            {
                PeteyPepperoni.Domain.OrderManager.AddCustomer(newOrder);
                Response.Redirect("Success.aspx");
            }
        }     
    }
}