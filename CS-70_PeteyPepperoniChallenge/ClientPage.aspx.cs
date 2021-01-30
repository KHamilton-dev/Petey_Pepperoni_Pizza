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
                if (sizeDropDownList.SelectedValue == "Small") total += 12;
                if (sizeDropDownList.SelectedValue == "Medium") total += 14;
                if (sizeDropDownList.SelectedValue == "Large") total += 18;
                if (sizeDropDownList.SelectedValue == "Regular") total += 0;
                if (crustDropDownList.SelectedValue == "Thick") total += 2;
                if (sausageCheckBox.Checked) total += 1;
                if (mushroomsCheckBox.Checked) total += .50;
                if (blackOlivesCheckBox.Checked) total += .75;
                if (greenOlivesCheckBox.Checked) total += .75;
                totalLabel.Text = total.ToString("C2");
            }
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            //parsing customer
            var newOrder = new PeteyPepperoni.DTO.OrderDetails();

            PeteyPepperoni.DTO.Enums.SizeType size;
            Enum.TryParse(sizeDropDownList.SelectedValue, out size);
            newOrder.Size = size;

            PeteyPepperoni.DTO.Enums.CrustType crust;
            Enum.TryParse(crustDropDownList.SelectedValue, out crust);
            newOrder.Crust = crust;

            if (sausageCheckBox.Checked) newOrder.Sausage = true;
            if (mushroomsCheckBox.Checked) newOrder.Mushrooms = true;
            if (blackOlivesCheckBox.Checked) newOrder.BlackOlives = true;
            if (greenOlivesCheckBox.Checked) newOrder.GreenOlives = true;
            newOrder.Name = nameTextBox.Text;
            newOrder.Address = addressTextBox.Text;
            newOrder.ZipCode = zipCodeTextBox.Text;

            if (cashRadioButton.Checked) newOrder.PaymentMethod = 
                    PeteyPepperoni.DTO.Enums.PaymentMethodType.Cash;
            if (creditRadioButton.Checked) newOrder.PaymentMethod =
                    PeteyPepperoni.DTO.Enums.PaymentMethodType.Credit;

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