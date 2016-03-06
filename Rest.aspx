<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rest.aspx.cs" Inherits="RoPaSci.Rest" %>

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
    <h2>Rest Services</h2>
    <p>
        According to the challenge i implemented and Rest api to interact with the system and the data.</p>
    <p> in this section, you will find the documentation about the services, and how to work with them. I was unable to complete all of the three services described in the pdf requeriments document,
        because this was my first time working with Rest, i am sure with a little more of practice and time, i can acomplish the goals.
    </p>
        <h3>GET api/championship/top</h3>
        <p>
            Retrieves the top players of all championships. Returns the list of player names based on the count provided. This was the only service i could did.
        </p>
        <h4>Resource information:</h4>
        <h4>Resource URL:</h4> http://fclotet-001-site1.ctempurl.com/api/championship.svc/top

        <h4>HTTP Method:</h4> Post.
        <h4>Response format:</h4>Json.
        <h4>Parameters:</h4>
        <p>count (optional)     Sets the count of records to be retrieved. If not provided, the default value is 10.</p>
        <p>Example: 123</p>
        <h4>Example Request</h4>
        <p>GET   http://fclotet-001-site1.ctempurl.com/api/championship.svc/top?count=5 </p>
        <h4>Example Output</h4>
        <p>{"TopResult":["Richard","Dave","Allen","Armando"]}</p>
        <br />
        
   
    
    
    
    </div>
    </form>
</body>
</html>
