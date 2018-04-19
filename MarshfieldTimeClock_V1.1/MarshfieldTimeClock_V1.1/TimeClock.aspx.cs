using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarshfieldTimeClock_V1._1
{
    public partial class TimeClock : System.Web.UI.Page
    {
        bool buttonsEnabled = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBxDisplayTime.Text = DateTime.Now.ToString("t");
            txtBxDisplayDay.Text = DateTime.Now.ToString("D");

            if (buttonsEnabled)
            {
                btnClockIn.Enabled = true;
                btnClockOut.Enabled = true;
            }
            else
            {
                btnClockIn.Enabled = false;
                btnClockOut.Enabled = false;
            }
        }

        protected void drpDwnWorkId_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonsEnabled = true;
        }

        protected void btnClockIn_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("t");
            string date = DateTime.Now.ToString("D");

            lblTimeClockStatus.Text = ("you have clocked in at " + time + " " + date);
        }

        protected void btnClockOut_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("t");
            string date = DateTime.Now.ToString("D");

            lblTimeClockStatus.Text = ("you have clocked out at " + time + " " + date);
        }









    }
}