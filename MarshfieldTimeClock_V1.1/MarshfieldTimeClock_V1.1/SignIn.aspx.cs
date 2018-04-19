using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarshfieldTimeClock_V1._1
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            /// if username and password are not empty
            try
            {
                /// LADP authentication
                /// ~~ if authorized 
                ///     log in and go to time clock page
                /// ~~ else (not authorized)
                ///     error msg wrong username or password



            }
            catch
            {

            }
        }
    }
}