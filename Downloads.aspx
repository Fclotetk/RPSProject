<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Downloads.aspx.cs" Inherits="RoPaSci.Downloads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RPS Project</title>

    <link rel="stylesheet"
			  type="text/css"
			  href="bootstrap.css"
		/>
		
		<link rel="stylesheet"
			  type="text/css"
			  href="styles.css"
		/>
</head>
<body>
    <div id="navbar" class="navbar" runat="server">
        <h2>RPS Project</h2>
        <a href="Default.aspx">
		Home
		</a>
		&nbsp;
		<a href="About.aspx">
		About
		</a>
		&nbsp;
		<a href="Downloads.aspx">
		Examples
		</a>
        &nbsp;
		<a href="Rest.aspx">
		Rest
		</a>
		<hr />
    </div>

    <form id="form1" runat="server">
    <div class="container">
        <h2>Downloads.</h2>
    <h3>Example Files.</h3>
    <p>
        In this section you will find a few examples to test the RPS program.
    </p>

    <ul>
        <li>           
            <asp:LinkButton id="tournament1" runat="server" Text="Tournament1.txt" onclick="download_file"></asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton id="tournament2" runat="server" Text="Tournament2.txt" onclick="download_file"></asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton id="tournament3" runat="server" Text="Tournament3.txt" onclick="download_file"></asp:LinkButton>
        </li>
    </ul>
    
    </div>
    </form>
</body>
</html>
