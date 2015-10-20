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
        if (!Page.IsPostBack)
        {
            RefreshWaiterList("0");
            DateHired.Text = DateTime.Today.ToString();
        }
    }

    protected void RefreshWaiterList(string selectedvalue)
    {
        //force a requery of the DDL
        WaiterList.DataBind();
        //insert the prompt line
        WaiterList.Items.Insert(0, "Select a Waiter");
        //position on a waiter in the list
        WaiterList.SelectedValue = selectedvalue;
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
        protected void InsertWaiter_Click(object sender, EventArgs e)
        {
            //this example is using the the tryrun inline
            MessageUserControl.TryRun(() =>
            {
                Waiter item = new Waiter();
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Address = Address.Text;
                item.Phone = Phone.Text;
                item.HireDate = DateTime.Parse(DateHired.Text);
                item.ReleaseDate = null;
                AdminController sysmgr = new AdminController();
                WaiterID.Text = sysmgr.Waiter_Add_r_WaiterID(item).ToString();
                MessageUserControl.ShowInfo("Waiter Added");
                RefreshWaiterList(WaiterID.Text);
            }
            );
        
        }
        protected void UpdateWaiter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WaiterID.Text))
            {
                MessageUserControl.ShowInfo("Please Select A Waiter to Update");
            }
            else
            {
                MessageUserControl.TryRun(() =>
                {
                    Waiter item = new Waiter();
                    item.WaiterID = int.Parse(WaiterID.Text);
                    item.FirstName = FirstName.Text;
                    item.LastName = LastName.Text;
                    item.Address = Address.Text;
                    item.Phone = Phone.Text;
                    item.HireDate = DateTime.Parse(DateHired.Text);
                    if (string.IsNullOrEmpty(DateReleased.Text))
                    {
                        item.ReleaseDate = null;
                    }
                    else
                    {
                        item.ReleaseDate = DateTime.Parse(DateReleased.Text);
                    }
                    AdminController sysmgr = new AdminController();
                    sysmgr.Waiter_Update(item);
                    MessageUserControl.ShowInfo("Waiter Updated");
                    RefreshWaiterList(WaiterID.Text);
                }
           );
            }
        }
}