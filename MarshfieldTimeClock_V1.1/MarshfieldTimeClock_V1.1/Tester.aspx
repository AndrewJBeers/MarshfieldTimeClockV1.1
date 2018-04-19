<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tester.aspx.cs" Inherits="Tester" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.Configuration" %>

<!DOCTYPE html>

<asp:PlaceHolder ID = "PlaceHolder1" runat="server" />

<script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
            //{
            //SqlCommand cmd = new SqlCommand("SELECT ClockIn, ClockOut FROM Log_Table WHERE EmployeeID = 'nancy.worden' AND DateOut BETWEEN '4/1/2018' AND '4/30/2018'", cn);
            //cn.Open();
            //SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //StringBuilder myString = new StringBuilder();
            //while (rdr.Read())
            //{
            //    myString.Append(rdr[0].ToString());
            //    myString.Append(" ");
            //    myString.Append(rdr[1].ToString());
            //    myString.Append(Environment.NewLine);
            //}
            //Response.Write(myString.ToString());
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                DataTable dt = this.GetData();

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                //Table start.
                html.Append("<table border = '1'>");

                //Building the Header row.
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr>");

                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        //}
    }


    private DataTable GetData()
    {
        string constr = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT CONVERT(VARCHAR, DateIn, 101) AS DateIn, ClockIn, ' ' as ' ', CONVERT(VARCHAR, DateOut, 101) AS DateOut, ClockOut, HoursWorked FROM Log_Table WHERE EmployeeID = 'paul.rottmund' AND Month(DateIn) = Month(getdate()) AND Month(DateOut) = Month(getdate())"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL Authentication</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    </div>
    </form>
</body>
</html>
