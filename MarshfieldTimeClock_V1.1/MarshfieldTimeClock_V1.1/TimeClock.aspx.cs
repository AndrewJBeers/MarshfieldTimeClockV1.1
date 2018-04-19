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
            /// populate users roles





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

        /// <summary>
        /// Clock in Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClockIn_Click(object sender, EventArgs e)
        {

            /// check if clocked in
            /// ~~ if clocked in from previous day 
            ///     give msg to do time adjustment
            ///     allow clock in 
            ///     get userID
            ///     get time
            ///     get role
            ///     post to db
            /// ~~ else if already clocked in from today
            ///     msg already clocked in today
            /// ~~ else allow clock in
            ///     get userID
            ///     get time
            ///     get role
            ///     post to database
            /// 
            /// 




            string time = DateTime.Now.ToString("t");
            string date = DateTime.Now.ToString("D");

            lblTimeClockStatus.Text = ("you have clocked in at " + time + " " + date);
        }

        /// <summary>
        /// Clock out Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClockOut_Click(object sender, EventArgs e)
        {
            /// check if clocked in
            /// ~~ if not clocked in
            ///     msg not clocked in
            /// ~~ else
            ///     get userID
            ///     get time
            ///     post to db



            string time = DateTime.Now.ToString("t");
            string date = DateTime.Now.ToString("D");

            lblTimeClockStatus.Text = ("you have clocked out at " + time + " " + date);
        }

        protected void btnChangeRole_Click(object sender, EventArgs e)
        {
            /// check if clocked in today
            /// ~~ if selected role is current roll user is clocked in as 
            ///     msg already in that role
            /// ~~ else 
            ///     post clock out time of old roll
            ///     post clock in time of new roll
            ///     msg role changed
            
            /// if not clocked in today 
            ///     msg not clocked into any rolls
        }
    }
}