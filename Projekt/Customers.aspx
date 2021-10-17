<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Projekt.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Custom2.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="mojaForma" runat="server">
        <div>
               <div class="header">  
                    <asp:Label Text="Number of customers :" runat="server" ID="lblNumber" /> 
                <br />
                <div class="list">
                <asp:RadioButtonList  RepeatDirection="Horizontal" ID="rblNumber" runat="server" OnSelectedIndexChanged="rblNumber_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>10&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem>25&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem>50&nbsp;&nbsp;</asp:ListItem>
                </asp:RadioButtonList>
                </div>
                <asp:Label Text="Select country and city :" runat="server" ID="lblStateCity" /> 
                <asp:DropDownList runat="server" ID="ddlDrazava" AutoPostBack="True" DataSourceID="SqlDrzave" DataTextField="Naziv" DataValueField="IDDrzava"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDrzave" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" SelectCommand="SELECT DISTINCT Drzava.* FROM Drzava INNER JOIN Grad ON Grad.DrzavaID=Drzava.IDDrzava INNER JOIN Kupac ON Grad.IDGrad=Kupac.GradID"></asp:SqlDataSource>
                <asp:DropDownList runat="server" ID="ddlGrad" AutoPostBack="True" DataSourceID="SqlGradovi" DataTextField="Naziv" DataValueField="IDGrad"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlGradovi" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" SelectCommand="SELECT Grad.IDGrad, Grad.Naziv, Grad.DrzavaID FROM Drzava INNER JOIN Grad ON Drzava.IDDrzava = Grad.DrzavaID WHERE Grad.DrzavaID=@DrzavaID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlDrazava" Name="DrzavaID" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>

                   <asp:Button ID="btnHome" runat="server" Text="Home"  OnClick="btnHome_Click"/>
            </div>
            
            <asp:GridView ID="gvKupci" runat="server" CellPadding="4" CssClass="table  " ForeColor="Black" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="IDKupac" DataSourceID="SqlBaza" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1"  CssClass="btn  btn-success"    runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2"  CssClass="btn  btn-danger"  runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CssClass="btn  btn-primary"  runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IDKupac" HeaderText="IDKupac" InsertVisible="False" ReadOnly="True" SortExpression="IDKupac" />
                    <%--<asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime" />--%>
                      <asp:TemplateField HeaderText="Ime" SortExpression="Ime">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIme"   runat="server" Text='<%# Bind("Ime") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   ControlToValidate="txtIme"      ErrorMessage="Invalid  ime *" ></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblIme" runat="server" Text='<%# Bind("Ime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="Prezime" HeaderText="Prezime" SortExpression="Prezime" />--%>
                     <asp:TemplateField HeaderText="Prezime" SortExpression="Prezime">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrezime" runat="server" Text='<%# Bind("Prezime") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   ControlToValidate="txtPrezime"      ErrorMessage="Invalid  prezime *" ></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrezime" runat="server" Text='<%# Bind("Prezime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Email" SortExpression="Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"   ControlToValidate="txtEmail"      ErrorMessage="Invalid  e-mail *"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Email","<a href=mailto:{0}>{0}</a>") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Telefon" HeaderText="Telefon" SortExpression="Telefon" />
                    <asp:BoundField DataField="GradID" HeaderText="GradID" SortExpression="GradID" />
                    <asp:BoundField DataField="Naziv" HeaderText="Naziv" SortExpression="Naziv" />
                    <asp:BoundField DataField="Drzava" HeaderText="Drzava" SortExpression="Drzava" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle  Backcolor="#cccccc" forecolor="black"  HorizontalAlign="Left"  CssClass="gridview" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            
            <asp:SqlDataSource ID="SqlBaza" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>" DeleteCommand="DELETE FROM [Kupac] WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))" InsertCommand="INSERT INTO [Kupac] ([Ime], [Prezime], [Email], [Telefon], [GradID]) VALUES (@Ime, @Prezime, @Email, @Telefon, @GradID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT Kupac.IDKupac, Kupac.Ime, Kupac.Prezime, Kupac.Email, Kupac.Telefon, Kupac.GradID, Grad.Naziv, Drzava.Naziv AS Drzava FROM Kupac INNER JOIN Grad ON Kupac.GradID = Grad.IDGrad INNER JOIN Drzava ON Grad.DrzavaID = Drzava.IDDrzava WHERE Kupac.GradID=@GradID AND Grad.DrzavaID=@IDDrzava" UpdateCommand="UPDATE [Kupac] SET [Ime] = @Ime, [Prezime] = @Prezime, [Email] = @Email, [Telefon] = @Telefon, [GradID] = @GradID WHERE [IDKupac] = @original_IDKupac AND [Ime] = @original_Ime AND [Prezime] = @original_Prezime AND (([Email] = @original_Email) OR ([Email] IS NULL AND @original_Email IS NULL)) AND (([Telefon] = @original_Telefon) OR ([Telefon] IS NULL AND @original_Telefon IS NULL)) AND (([GradID] = @original_GradID) OR ([GradID] IS NULL AND @original_GradID IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_IDKupac" Type="Int32" />
                    <asp:Parameter Name="original_Ime" Type="String" />
                    <asp:Parameter Name="original_Prezime" Type="String" />
                    <asp:Parameter Name="original_Email" Type="String" />
                    <asp:Parameter Name="original_Telefon" Type="String" />
                    <asp:Parameter Name="original_GradID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Ime" Type="String" />
                    <asp:Parameter Name="Prezime" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Telefon" Type="String" />
                    <asp:Parameter Name="GradID" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlGrad" Name="GradID" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="ddlDrazava" Name="IDDrzava" PropertyName="SelectedValue" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Ime" Type="String" />
                    <asp:Parameter Name="Prezime" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Telefon" Type="String" />
                    <asp:Parameter Name="GradID" Type="Int32" />
                    <asp:Parameter Name="original_IDKupac" Type="Int32" />
                    <asp:Parameter Name="original_Ime" Type="String" />
                    <asp:Parameter Name="original_Prezime" Type="String" />
                    <asp:Parameter Name="original_Email" Type="String" />
                    <asp:Parameter Name="original_Telefon" Type="String" />
                    <asp:Parameter Name="original_GradID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            
        </div>
        <div><asp:ValidationSummary runat="server" /></div>
    </form>
</body>
</html>


