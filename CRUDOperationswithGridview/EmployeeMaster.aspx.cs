using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRUDOperationswithGridview
{
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        BLL_EmployeeDetails objBLL_EmployeeDetails = new BLL_EmployeeDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeDetails();
            }
        }

        void GetEmployeeDetails()
        {
            DataTable dtEmployees = null;
            dtEmployees = objBLL_EmployeeDetails.GetEmployeedetails(hfEmployeeMasterID.Value == "" ? 0 : Convert.ToInt16(hfEmployeeMasterID.Value));

            if (dtEmployees.Rows.Count > 0)
            {
                gvEmployeeDetails.DataSource = dtEmployees;
                gvEmployeeDetails.DataBind();
            }
            else
            {
                dtEmployees.Rows.Add(dtEmployees.NewRow());
                gvEmployeeDetails.DataSource = dtEmployees;
                gvEmployeeDetails.DataBind();
                gvEmployeeDetails.Rows[0].Cells.Clear();
                gvEmployeeDetails.Rows[0].Cells.Add(new TableCell());
                gvEmployeeDetails.Rows[0].Cells[0].ColumnSpan = dtEmployees.Columns.Count;
                gvEmployeeDetails.Rows[0].Cells[0].Text = "Data not found...";
                gvEmployeeDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Add"))
                {
                    string result = string.Empty;

                    int EmployeeMasterID = hfEmployeeMasterID.Value == "" ? 0 : Convert.ToInt16(hfEmployeeMasterID.Value);
                    int employeecode = Convert.ToInt32((gvEmployeeDetails.FooterRow.FindControl("txtEmployeeCode_Footer") as TextBox).Text.Trim());
                    string employeename = (gvEmployeeDetails.FooterRow.FindControl("txtEmployeeName_Footer") as TextBox).Text.Trim();
                    string designation = (gvEmployeeDetails.FooterRow.FindControl("txtDesignation_Footer") as TextBox).Text.Trim();
                    int salary = Convert.ToInt32((gvEmployeeDetails.FooterRow.FindControl("txtSalary_Footer") as TextBox).Text.Trim());

                    result = objBLL_EmployeeDetails.Add(EmployeeMasterID, employeecode, employeename, designation, salary);
                    GetEmployeeDetails();
                    lblmessage.Text = result;
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvEmployeeDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployeeDetails.EditIndex = e.NewEditIndex;
            GetEmployeeDetails();
        }

        protected void gvEmployeeDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployeeDetails.EditIndex = -1;
            GetEmployeeDetails();
        }

        protected void gvEmployeeDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string result = string.Empty;

                int employeeMasterID = Convert.ToInt32(gvEmployeeDetails.DataKeys[e.RowIndex].Value.ToString());
                int employeeCode = Convert.ToInt32((gvEmployeeDetails.Rows[e.RowIndex].FindControl("txtEmployeeCode") as TextBox).Text.Trim());
                string employeeName = (gvEmployeeDetails.Rows[e.RowIndex].FindControl("txtEmployeeName") as TextBox).Text.Trim();
                string designation = (gvEmployeeDetails.Rows[e.RowIndex].FindControl("txtDesignation") as TextBox).Text.Trim();
                int salary = Convert.ToInt32((gvEmployeeDetails.Rows[e.RowIndex].FindControl("txtSalary") as TextBox).Text.Trim());

                result = objBLL_EmployeeDetails.Add(employeeMasterID, employeeCode, employeeName, designation, salary);
                gvEmployeeDetails.EditIndex = -1;
                GetEmployeeDetails();
                lblmessage.Text = result;
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvEmployeeDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string result = string.Empty;
                int EmployeeMasterID = Convert.ToInt32(gvEmployeeDetails.DataKeys[e.RowIndex].Value.ToString());
                result = objBLL_EmployeeDetails.Delete(EmployeeMasterID);
                GetEmployeeDetails();
                lblmessage.Text = result;
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}