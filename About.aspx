<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="RoPaSci.About" %>

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
    <h2>About</h2>
    <h3>Me</h3>
    <p>
        My name is Francisco CLotet, i graduated in 2013 as a Computer Science Engineer. At my 1st job i started working in a bank,
        until i decided to move to Costa Rica to have a better life quality, and at the same time to be able to grow 
        professionally, and personally.

        One of my biggest hobbies are video games and drums, i use to play daily almost any kind of video games, and while i
        was living in Venezuela i was in a band and we used to practice every Saturday.
        
        I am a person who values teamwork and I always aim at continuous improvements. I like to give the best of me 
        trying to have the best results in everything i do.

    </p>
    <p>
        I am looking for a job where i can apply my abilities and acquire new knowledge for my professional growing.

    </p>
    
    <h3>The RPS Program</h3>
    <p>
        The RPS program its a simulator of Rock-Paper-Scissors tournament where you can upload a .txt file with the 
        tournament structure, and the program will return the winner and save the first and the second place in a database,
        adding 3 points for the winner and 1 point for the second.

        In a game of rock-paper-scissors, each player chooses a name and a strategy where you choose to play either Rock (R), 
        Paper (P), or Scissors (S).
        The rules are: Rock beats Scissors, Scissors beats Paper, but Paper beats Rock. Also, the tournament ends when there is
        only one player left which is the winner, if there is more than one player left, players will continue playing against 
        an opponent and only one passes to the next and the other is disqualified. The player that wins will get 3 points and
        the second place is going to get 1. At the same time, there is going to be a list of the best players (according to the
        points obtained by them in every tournament)

    </p>
    <h3>The Tournament File</h3>
    <p>
        A rock-paper-scissors game is encoded as a list, where the elements are 2-element lists that encode a player’s name and 
        a player’s strategy. A rock, paper, scissors tournament is encoded as a bracketed array of games - that is, each element 
        can be considered its own tournament. Tournaments can be nested arbitrarily deep.

        A correct tournament file should have the following specifications:
    </p>
    <ul>
        <li>The file will contain only one tournament.</li>
        <li>The uploaded file has to have .txt extention.</li>
        <li>Every openning bracket has to have  a closing one.</li>
        <li>A list will have exactly 2 elements, and every element will be a 2 element list.</li>
        <li>The player's name and strategy will be between double quotes.</li>
        <li>Neither a player's name or a strategy will be null or blank.</li>
    </ul>

        <p>If the uploaded file do not follow all the especifications listed above, the system will return an exception.</p>
    
    <h3>The Code</h3>

    <p>The entirely code has been wrote by me, its full open source and it can be found and downloaded from Git Hub from <a href="https://github.com/Fclotetk/RPSProject.git">HERE</a></p>
        <p>The tecnology i used to accomplished this challenge whas C# in the .NET enviroment, working together with HTML5, CSS and JavaScript, also i implemented and a Rest Service to the system 
            using Windows Comunication Foundation, this api was supossed to has three services but i was able to do only one, since i have never use Rest before. 
        </p>

        <h3>The Solution</h3>
        <p> In order to answer the Rock Paper Scissors problem, i received an uploaded .txt file as required, once received i read the file and proceed to validate its structure, if the structure is no correct an exception will be given.
            When a file passes the structure validation, i started to move through it as a characters array to take appart the text that contains a player's name and strategy, with that information i created an object that from now on will be called player,
            every player is added to a players list. Once the list is completely created i make sure that the numbers of the players and games, are correct to start the tournament, this means that the number of players and games are pair to avoid a match with only one player.
        </p>
        <p>The game simulation starts taking the players from the list in pairs and compairing their strategies, the winner will be added to a auxiliar list, this process will continue untill theres no more matches in the main list, and the auxiliar one will be the main
             list for the next iteration of the process. This is done until there is only one player in the main list, meaning that player is the winner.</p>
        <p>The first and the second place of a tournament are stored in a database, adding 1 point to the second and 3 points for the first, this database can be restarted at any momment.</p>
        <br />
    
    </div>
    </form>
</body>
</html>
