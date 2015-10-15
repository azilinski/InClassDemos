using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using eResturauntSystem.BLL;
using eResturauntSystem.Entities;
using EatIn.UI;

public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //initialize the date hired to today
        DateHired.Text = DateTime.Today.ToString();
    }
    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        if (WaiterList.SelectedIndex == 0)
        {
            MessageUserControl.ShowInfo("Please select a waiter before clicking fetch waiter");
        }
        else
        {
            //we will use a try run from the message user controll
            //this will capture error messages when/if they happen
            //and proporly display in the user controll
            //GetWaiterInfo is your method for accessing your query
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
        }
    }
        public void GetWaiterInfo()
        {
            //a standard lookup method
            AdminController sysmgr = new AdminController();
            var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterList.SelectedValue));
            WaiterID.Text = waiter.WaiterID.ToString();
            FirstName.Text = waiter.FirstName;
            LastName.Text = waiter.LastName;
            Phone.Text = waiter.Phone;
            Address.Text = waiter.Address;
            DateHired.Text = waiter.HireDate.ToShortDateString();
            if (waiter.ReleaseDate.HasValue)
            {
                DateReleased.Text = waiter.ReleaseDate.ToString();
            }
        }    
}