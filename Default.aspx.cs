using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Net;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using MySql.Web;

namespace RoPaSci
{
    public partial class Default : System.Web.UI.Page
    {
        //
        static string myconnectionstring = ConfigurationManager.ConnectionStrings["ConnectionStringrps"].ToString();
        
        
     

        protected void Page_Load(object sender, EventArgs e)
        {       
            
            score_area.Visible = false;
            table_area.Visible = false;
            text_mensaje.Text = ""; //restarts the value of the message text
            
        }
        //a class created to work with in the list of players
        public class jugadores
        {
            public string Name { get; set; }
            public string Strategy { get; set; }
        }

        protected void UploadBtn_Click(object sender, EventArgs e) //a function to upload the file
        {
            // Specify the path on the server to
            // save the uploaded file to.            
            string savePath = Server.MapPath(@"~\uploads\");

            // Before attempting to save the file, verify
            // that the FileUpload control contains a file.
            if (FileUpload1.HasFile)
            {
                // Get the name of the file to upload.
                string fileName = Server.HtmlEncode(FileUpload1.FileName);

                // Get the extension of the uploaded file.
                string extension = System.IO.Path.GetExtension(fileName);

                // Allow only files with .doc or .xls extensions
                // to be uploaded.
                if (extension == ".txt")
                {
                    // Append the name of the file to upload to the path.
                    savePath += fileName;

                    // Call the SaveAs method to save the 
                    // uploaded file to the specified path.
                    // This example does not perform all
                    // the necessary error checking.               
                    // If a file with the same name
                    // already exists in the specified path,  
                    // the uploaded file overwrites it.
                    FileUpload1.SaveAs(savePath);

                    // Notify the user that their file was successfully uploaded.
                    UploadStatusLabel.Text = "Your file was uploaded successfully.";

                    read_document(savePath);
                    grid_load(sender, e);
                }
                else
                {
                    // Notify the user why their file was not uploaded.
                    UploadStatusLabel.Text = "Your file was not uploaded because " +
                                             "it does not have a .txt extension.";

                    torneo.Text = "";
                }

            }
            else
            {
                UploadStatusLabel.Text = "You have to select a file to upload. ";
                //Page.RegisterClientScriptBlock("12323", "<script language=\"javascript\" type=\"text/javascript\">alert('You have to select a file to upload.')</script>");
                torneo.Text = "";
            }


        }

        private void read_document(string ruta) // this function takes the uploaded file and read it
        {
            try
            {
            StreamReader SR = new StreamReader(ruta);
            string texto;
             
            texto = SR.ReadToEnd(); //asign the entire document to a string to work with easier.
            SR.Close();            
            if (valid_estructure(texto.Trim()) == true) //calls the structure validation function
            {                
                doc_cut(texto.Trim()); //calls the function to cut the string to the way we need it.
            }
            else
            {                
                    throw new Exception("The document's structure is not correct.");
            }
            }
            catch (Exception ex)
            {                
                text_mensaje.Text = ex.Message;
            }


        }

        protected Boolean valid_estructure(string doc)
        {
            //this function watch the document estructure looking for the right syntax of the list "[,]"
            string tournament = doc;
            string validation ="";
            string copy = "";
            if (tournament.Length != 0)
            {
                for (int i=0; i<tournament.Length; i++)
                {
                    if ((tournament[i] == '[') || (tournament[i] == ',')|| (tournament[i] == ']')) //ignores all the characters diferent to '[', ',' , and ']' and makes a string with this characters
                    {
                        validation += tournament[i]; 
                    }
                }

                while (validation.Length != 0 && validation != copy) //the cycles end when the string is empty or the replace function do nothing. 
                {
                    copy = validation;
                    validation = validation.Replace("[,]", "");  //remove the list estructure inside a list.                  
                }

                if (validation == copy) //there is no more list structures to remove but there is still elements in the string
                {
                    return false;
                }
                return true; //if the string its empty means that all list structures in the document were correctly

            }
            return false;
        }

        private void doc_cut(string torneo)
        {
            //the function to cut the string and takes the player's names and strategies.
            try
            {
                //variable initialization
                int i = 0;
                int j = 0;
                int w = 0;
                int x;
                
                var juga = new List<jugadores> { }; //create a list of players
                Boolean find = true;
                while (i < torneo.Length - 1 && find == true) //move trough the string looking for names and strategies
                {
                    find = false;
                    for (j = w; j < torneo.Length - 1; j++)
                    {
                        if (torneo[j] == '"')
                        {
                            find = true;
                            break;
                        }

                    }
                    if (find == true)
                    {
                        for (x = j + 1; (x < torneo.Length - 1) && (torneo[x] != '"'); x++) ;

                        string nombre = torneo.Substring(j + 1, x - j - 1).Trim(); //save the name found
                        if (nombre.Length == 0)
                        {
                            throw new Exception("A player name can't be null");
                        }
                        w = x + 1;

                        for (j = w; (j < torneo.Length - 1) && (torneo[j] != '"'); j++) ;

                        for (x = j + 1; (x < torneo.Length - 1) && (torneo[x] != '"'); x++) ;


                        string estrategia = torneo.Substring(j + 1, x - j - 1).Trim(); //save the strategy found
                        estrategia = estrategia.ToUpper();
                        if (estrategia != "P" && estrategia != "R" && estrategia != "S") //validate that the strategy is valid
                        {                            
                            throw new Exception("A non valid value has been find for a strategy.");
                        }

                        juga.Add(new jugadores() { Name = nombre, Strategy = estrategia }); //add a player to the list with the name and strategy just found.

                        w = x + 1;
                    }


                    i = w;
                }
                int cantidad = juga.Count<jugadores>(); //validates the number of player is pair
                if (cantidad !=0)
                { 
                if (((cantidad % 2 == 0) && ((cantidad / 2) % 2 == 0)) || ((cantidad % 2 == 0) && (cantidad / 2 == 1))) //validates the number of matches
                {
                    play(juga); //call the game simulation function.
                }
                else
                {
                    throw new Exception("There is not a correct number of players.");
                }
                }
                else
                {
                    throw new Exception("There is no players in the document.");
                }

            }
            catch (Exception ex)
            {                
                text_mensaje.Text = ex.Message;
            }
        }

        protected void play(List<jugadores> players)
        {
            //the function tha simules a rock paper scissors match
            List<jugadores> list1 = players; //starts with the obtained list of player
            List<jugadores> list2 = new List<jugadores> { }; // auxiliar list to catch the winners in each match.
            string[] finalists = new string[2]; //an array to save the last two players
            string first = "";
            string second = "";
            while (list1.Count<jugadores>() > 1) //take players in pairs and compares their strategies. the winner is adde to the auxiliar list.
            {
                for (int i = 0; i < list1.Count<jugadores>(); i += 2)
                {
                    switch (list1[i].Strategy)
                    {
                        case "R":
                            if ((list1[i + 1].Strategy == "R") || (list1[i + 1].Strategy == "S"))
                            {
                                list2.Add(list1[i]);
                            }
                            else
                            {
                                list2.Add(list1[i + 1]);
                            }
                            break;

                        case "P":
                            if ((list1[i + 1].Strategy == "P") || (list1[i + 1].Strategy == "R"))
                            {
                                list2.Add(list1[i]);
                            }
                            else
                            {
                                list2.Add(list1[i + 1]);
                            }
                            break;
                        case "S":
                            if ((list1[i + 1].Strategy == "P") || (list1[i + 1].Strategy == "S"))
                            {
                                list2.Add(list1[i]);
                            }
                            else
                            {
                                list2.Add(list1[i + 1]);
                            }
                            break;
                    }
                }
                if (list1.Count<jugadores>() == 2) //validates if two players left
                {

                    int i = 0;
                    foreach (jugadores player in list1)
                    {
                        finalists[i] = player.Name;
                        i++;
                    }
                }
                list1.Clear();
                foreach (jugadores jugador in list2) //makes the aux list the new basic list.
                {
                    list1.Add(jugador);
                }
                list2.Clear(); //clean the auxiliar list

            }
            string winner = "[" + list1[0].Name.ToString() + "," + list1[0].Strategy.ToString() + "]"; // shows the winner's name and strategy
            
            torneo.Text = winner;
            win_label.Visible = true;
            torneo.Visible = true;

            if (finalists[0].Trim() == list1[0].Name.ToString().Trim()) //look for the winner and the second place
            {
                first = finalists[0].Trim();
                second = finalists[1].Trim();
            }
            else
            {
                first = finalists[1].Trim();
                second = finalists[0].Trim();
            }

            inserta_punto(first, second);

        }

        protected void inserta_punto(string first, string sec) //insert points to the database
        {
            string winner = first;
            string second = sec;

            //create and open the mysql conection
            MySqlConnection cn = new MySqlConnection(myconnectionstring);
            MySqlCommand cmd = new MySqlCommand("insert_points", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cn.Open();

            try
            {

                //adds the winner's and second's place name to add them to the database
                cmd.Parameters.AddWithValue("winner", winner);
                cmd.Parameters.AddWithValue("second", second);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {                
                text_mensaje.Text = ex.Message;
            }

        }

        protected void grid_load(object sender, EventArgs e) //function to load the grid of scores in the home page
        {
            //create the mysql connection
            MySqlConnection cn = new MySqlConnection(myconnectionstring);
            MySqlCommand cmd;
            try
            {
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandText = "select Name, Points from rps_scores order by Points desc LIMIT 10;"; //selects the best 10 players from the database
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable scores = new DataTable();
                adapter.Fill(scores); //put the query's result into a datatable object

                if (scores.Rows.Count != 0)
                {
                    RadGrid2.DataSource = scores.DefaultView; //set the source of the data for the grid in the client side
                    score_area.Visible = true;
                    table_area.Visible = true;
                }
                
            }
            catch (Exception ex)
            {                
                text_mensaje.Text = ex.Message;
            }


        }

        protected void RadGrid2_PreRender(object sender, System.EventArgs e)
        {
            this.RadGrid2.DataBind(); //refresh the grid's data every time the page load
        }

        protected void reset_scores(object sender, System.EventArgs e) //function to delete all the content of the database
        {
            //create the mysql connection
            MySqlConnection cn = new MySqlConnection(myconnectionstring);
            MySqlCommand cmd;
            try
            {
                cn.Open();
                cmd = cn.CreateCommand();
                cmd.CommandText = "truncate rps_scores;"; //deletes all the items in the database
                cmd.ExecuteNonQuery();

                RadGrid2.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                text_mensaje.Text = ex.Message;
            }

        }
       
    }
}