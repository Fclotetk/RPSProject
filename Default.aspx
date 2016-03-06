<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RoPaSci.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RPS Project</title>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <link rel="stylesheet"
			  type="text/css"
			  href="bootstrap.css"
		/>
		
		<link rel="stylesheet"
			  type="text/css"
			  href="styles.css"
		/>
    <script type="text/javascript">

        

        $(document).ready(function () {
            
            //var messa = document.getElementById('text_mensaje').value;
            ////$("#text_mensaje").attr("hide");
            //// messa = $("#mensaje_label").val();
            //if (messa != "") {
            //    alert(messa);                
            //}
            alerta();
        });

        function alerta() {            
                var messa = document.getElementById('text_mensaje').value;
                //$("#text_mensaje").attr("hide");
                // messa = $("#mensaje_label").val();
                if (messa != "") {
                    alert(messa);
                }
        }



    </script>
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
    
    <form id="area" runat="server">
        
        <div class="container">
            <h2>Welcome</h2>
            <p>RPS Project is a rock-paper-scissors game simulator, please upload a tournament structure .txt file to begin.
                For more information about the project or the tournament file please visit the <a href="About.aspx">About</a> section.
            </p>

        </div>
    <div class="container thin_border" id="upload_area">        
        <h4>Select a championship file to upload:</h4>

        <asp:FileUpload id="FileUpload1" runat="server" Width="400px" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black">
        </asp:FileUpload>
        
        <br />

        <asp:Button id="UploadBtn" 
            Text="Upload file"
            OnClick="UploadBtn_Click"
            runat="server">
        </asp:Button>    

        <br />

        <asp:Label id="UploadStatusLabel"
            runat="server">
        </asp:Label> 
           
    </div>
    <br />

    <div id="score_area" class="container thin_border" runat="server" style="width:35%" visible="false">
    <div class="container" style="width:50%">
        
        <asp:Label ID="win_label" Font-Size="X-Large" CssClass="mia" runat="server" Text="The winner is:"></asp:Label>
        <br /><asp:TextBox ID="torneo" runat="server" Visible="false" ReadOnly="true"></asp:TextBox>            
        
    </div>
    <br />   
    </div>
        <br />
   <div id="table_area" class="container thin_border" runat="server" style="width:35%" visible="false">   
    
        <h2 style="text-align:center"> Scoreboard</h2>
        <asp:DataGrid ID="RadGrid2" CssClass="center" runat="server" Width="90%" Visible="true" OnPreRender="RadGrid2_PreRender" AutoGenerateColumns="False">
            
            <Columns>         
                 
                <asp:BoundColumn DataField="Name" HeaderText="Player Name" ReadOnly="True" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" SortExpression="Name" >
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Points" HeaderText="Points" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" SortExpression="Points">
                </asp:BoundColumn>
                                
            </Columns>
         </asp:DataGrid>
    <br />
         <asp:Button ID="reset" CssClass="center-block" runat="server" Text="Reset ScoreBoard" Width="150px" OnClick="reset_scores"  />
    <br />
   </div>
        <asp:TextBox ID="text_mensaje" runat="server" Visible="true" BorderStyle="None" ForeColor="White" Font-Size="XX-Small"></asp:TextBox>
    </form>

</body>
</html>
