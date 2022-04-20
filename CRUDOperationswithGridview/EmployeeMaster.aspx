<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="CRUDOperationswithGridview.EmployeeMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Master</title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:HiddenField ID="hfEmployeeMasterID" runat="server" />
            <table border="1" cellspacing="0" cellpadding="0" style="border-color: blue">
                <tr>
                    <td style="text-align: center; font-weight: bold;">Employee Name
                    </td>
                </tr>
                <tr>
                    <td>                        
                         <asp:GridView ID="gvEmployeeDetails" runat="server" CellPadding="3" 
                            AutoGenerateColumns="False" ShowFooter="True" 
                            DataKeyNames="EmployeeMasterID" 
                            ShowHeaderWhenEmpty="True" 
                            OnRowCommand="gvEmployeeDetails_RowCommand" 
                            OnRowEditing="gvEmployeeDetails_RowEditing" 
                            OnRowCancelingEdit="gvEmployeeDetails_RowCancelingEdit" 
                            OnRowUpdating="gvEmployeeDetails_RowUpdating" 
                            OnRowDeleting="gvEmployeeDetails_RowDeleting" 
                            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                            <Columns>
                                <asp:TemplateField HeaderText="Employee Code" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeCode" Text='<%# Eval("EmployeeCode") %>' runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeeCode" runat="server" Text='<%# Eval("EmployeeCode") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtEmployeeCode_Footer" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeName" Text='<%# Eval("EmployeeName") %>' runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeeName" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtEmployeeName_Footer" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" Text='<%# Eval("Designation") %>' runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtDesignation_Footer" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salary" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalary" Text='<%# Eval("Salary") %>' runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSalary" runat="server" Text='<%# Eval("Salary") %>' Width="50px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtSalary_Footer" runat="server" Width="50px"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/Edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                        <asp:ImageButton ImageUrl="~/Images/Delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/Save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                        <asp:ImageButton ImageUrl="~/Images/Cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/Add.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblmessage" runat="server" style="font-weight:bold;color:green"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
