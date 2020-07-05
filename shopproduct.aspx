<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="shopproduct.aspx.cs" Inherits="shopproduct" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5">
 <Columns>
 <asp:BoundField HeaderText="Category Code" DataField="pno" />
 <asp:BoundField HeaderText="Product Name" DataField="pname" />
 <asp:BoundField HeaderText="Unit Price" DataField="price" />
 <asp:TemplateField>
 <ItemTemplate>
 <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("logo")%>' Width="75px" Height="75px"></asp:Image>
 </ItemTemplate>
 </asp:TemplateField>
  <asp:HyperLinkField HeaderText="View Details" DataNavigateUrlFields="pno,pname" DataNavigateUrlFormatString="~/customer/details.aspx?pno={0}&amp;pname={1}"
 Target="_blank" Text="View" /> 
 <asp:TemplateField HeaderText="Buy Product">
 <ItemTemplate>
 <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"sno") %>'>Add to Cart</asp:LinkButton>
 </ItemTemplate>
 </asp:TemplateField>    
 </Columns>
</asp:GridView>
</asp:Content>

