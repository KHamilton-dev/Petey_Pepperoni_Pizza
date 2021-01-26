﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_70_PeteyPepperoniChallenge.Default" MaintainScrollPositionOnPostBack="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="page-header">
                <h1>Petey Pepperoni's Pizza</h1>
                <p class="lead">Best Pepperoni Pizza This Side of the Street</p>
                <p></p>
            </div>

            <div class="form-group">
                <label><b>Size</b></label>
                <asp:DropDownList ID ="sizeDropDownList" runat="server" CssClass="form-control" AutoPostBack="True">
                    <asp:ListItem Text="Select Size..." Value="null"/>
                    <asp:ListItem Text="Small (12&quot;)" Value="Small" />
                    <asp:ListItem Text="Medium (14&quot;)" Value="Medium" />
                    <asp:ListItem Text="Large (18&quot;)" Value="Large" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label><b>Crust</b></label>
                <asp:DropDownList ID="crustDropDownList" runat="server" CssClass="form-control" AutoPostBack="True">
                    <asp:ListItem Text="Select Crust..." Value="null"/>
                    <asp:ListItem Text="Regular" Value="Regular" />
                    <asp:ListItem Text="Thick (+$2.00)" Value="Thick" />
                </asp:DropDownList>
            </div>

            <!--<div class="form-group">
                <label>Toppings: </label>
                <asp:CheckBoxList ID="toppingsCheckBoxes" runat="server" CssClass="form-control" Style="border:0;">
                    <asp:ListItem Text="&nbsp;Sausage" Value=".50" />
                    <asp:ListItem Text="&nbsp;Mushrooms" Value=".50" />
                    <asp:ListItem Text="&nbsp;Black Olives" Value=".50" />
                    <asp:ListItem Text="&nbsp;Green Olives" Value=".50" />
                </asp:CheckBoxList>-->
            
            <b>Toppings</b><p></p>
            <asp:CheckBox ID="sausageCheckBox" Text="&nbsp;Sausage" Value =".50" runat="server" AutoPostBack="True" />
            <br />
            <asp:CheckBox ID="mushroomsCheckBox" Text="&nbsp;Mushrooms" Value =".50" runat="server" AutoPostBack="True" />
            <br />
            <asp:CheckBox ID="blackOlivesCheckBox" Text="&nbsp;Black Olives" Value =".50" runat="server" AutoPostBack="True" />
            <br />
            <asp:CheckBox ID="greenOlivesCheckBox" Text="&nbsp;Green Olives" Value =".50" runat="server" AutoPostBack="True" />
            <p></p>

            <h4>Total:</h4>
            <asp:Label ID="totalLabel" Text="$0.00" Font-Bold="false" Font-Size="X-Large" runat="server"></asp:Label>
            <br />
            <br />

            <h4>Deliver to:</h4>
            <p></p>

            Name
            <br />
            <asp:TextBox ID="nameTextBox" runat="server" Width="400"></asp:TextBox>
            <p></p>

            Address
            <br />
            <asp:TextBox ID="addressTextBox" runat="server" Width="400"></asp:TextBox><p></p>

            Zip Code
            <br />
            <asp:TextBox ID="zipCodeTextBox" runat="server" Width="100"></asp:TextBox><p></p>

            <h4>Payment Method:</h4>
            <p></p>
            <asp:RadioButton ID="cashRadioButton" Text="&nbsp;Cash" GroupName="paymentGroup" runat="server"></asp:RadioButton>
            <br />
            <asp:RadioButton ID="creditRadioButton" Text="&nbsp;Credit" GroupName="paymentGroup" runat="server"></asp:RadioButton>
            <p></p>

            <asp:Button ID="orderButton" Text="Place Order" runat="server" CssClass="btn btn-lg btn-primary" OnClick="orderButton_Click"/>
            <p></p>
            <p>
                <asp:Label ID="resultLabel" runat="server"></asp:Label>
            </p>

        </div>
    </form>
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
