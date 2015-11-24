using eResturauntSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_DateTimeMocker : System.Web.UI.UserControl
{
    //create properties that will allow external users of this control to have access to the data on this control
    public DateTime MockDate {
        get{
            //setup a varible to hold the date, has a default
            DateTime date = DateTime.MinValue;
            //posibly overide the default with the contents of the web control search date
            DateTime.TryParse(SearchDate.Text, out date);

            return date;

        } 
        set{
            SearchDate.Text = value.ToString("yyyy-MM-dd");
        } 
    }
    public TimeSpan MockTime
    {
        get
        {
            //setup a varible to hold the time, has a default
            TimeSpan time = TimeSpan.MinValue;
            //posibly overide the default with the contents of the web control search time
            TimeSpan.TryParse(SearchTime.Text, out time);

            return time;

        }
        set
        {
            SearchTime.Text = DateTime.Today.Add(value).ToString("HH:mm:ss");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void MockLastBillingDateTime_Click(object sender, EventArgs e)
    {
        AdminController sysmgr = new AdminController();
        DateTime info = sysmgr.GetLastBillDateTime();
        SearchDate.Text = info.ToString("yyyy-MM-dd");
        SearchTime.Text = info.ToString("HH:mm");
    }
}