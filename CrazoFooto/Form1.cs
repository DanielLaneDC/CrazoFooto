using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CrazoFooto
{
    public partial class Form1 : Form
    {
        public static Comparison<Player> sortPlayersAlgorithm;
        public static Random random = new Random();
        public static int defaultBaseYear = 1994;
        public static int defaultBaseSalary = 60000;

        //"E:\\Programs\\Premiership Coach 2011\\Data\\Base\\user_AFL_allstars";
        String dirPath = "E:\\Programs\\Premiership Coach 2011\\Data\\Base\\user_everyFewYearsGC";
        List<Player> players;
        List<Club> clubs;
        int logCount, instructionCount;
        String playerSortAttribute = "fname";
        bool playerSortAscending;
        int currentBaseYear = 1994;
        int currentBaseSalary = Int32.MaxValue;

        public Form1()
        {
            InitializeComponent();

            //dirPathInput.Text = "E:\\Programs\\Premiership Coach 2011\\Data\\Base\\Base2010\\Players";
            //dirPathInput.Text = "C:\\Users\\Daniel\\Desktop\\Base2010";
            //dirPathInput.Text = dirPath;
            updateInstructions();
        }

        private void addInstruction(String instruction)
        {
            instructionCount++;

            instructionLabel.Text += instructionCount + ". " + instruction + Environment.NewLine;
        }

        private void updateInstructions()
        {
            instructionCount = 0;
            instructionLabel.Text = "";

            if(dirPathInput.Text.Equals(""))
            {
                addInstruction("You need to input a directory. Ie., Premiership Coach 2011\\Data\\Base\\YourRatingsFolder or Premiership Coach 2011\\Data\\Saves\\YourSaveFolder");
            }

            if (players == null || clubs == null)
            {
                addInstruction("You need to load data - use the '" + findButton.Text + "' button.");
            }
            else
            {
                addInstruction("You are free to manipulate the data as you wish now. If you want to load a different directory, input it and use the '" + findButton.Text + "' button.");
            }
        }

        private int getNewAutoGenId()
        {
            for (int autoGenId = 0; autoGenId < int.MaxValue; autoGenId++)
            {
                if (File.Exists(dirPath + "\\Players\\" + "custompl-ayer-auto-genI-" + formatAutoGenId(autoGenId) + ".xml") == false)
                {
                    return autoGenId;
                }
            }

            return -1;
        }

        private String formatAutoGenId(int autoGenId)
        {
            String autoGenIdFormatted = autoGenId.ToString();

            while (autoGenIdFormatted.Length < "87ce32c8a7ec".Length)
            {
                autoGenIdFormatted = "0" + autoGenIdFormatted;
            }

            return autoGenIdFormatted;
        }

        private void createPlayer()
        {
            if (clubsDataGridView.SelectedRows.Count > 0)
            {
                // generate new file name
                String newFileName = "custompl-ayer-auto-genI-" + formatAutoGenId(getNewAutoGenId());

                // generate new player object based on another player
                XmlDocument newPlayerDocument = Player.blankPlayer();
                Player player = new Player(newPlayerDocument.SelectNodes("Player")[0], newFileName + ".xml", newPlayerDocument);
                player.playerID = newFileName;

                // assign to club
                Club club = (Club)clubsDataGridView.SelectedRows[0].DataBoundItem;
                player.changeClub(club, getNextAvailableJumperNumber(club));

                // save file as copy of another player's file
                player.originalDocument.Save(dirPath + "\\Players\\" + player.xmlFileName);

                // acknowledge as player in list
                players.Add(player);

                // update all files, this will update the new player
                updateXml();

                // refresh view
                refreshDataGridView();
            }
            else
            {
                MessageBox.Show("You must select a player from the list.");
            }
        }

        private void removePlayer()
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                Player player = (Player)playersDataGridView.SelectedRows[0].DataBoundItem;
                players.Remove(player);

                File.Delete(dirPath + "\\Players\\" + player.xmlFileName);
            }

            refreshDataGridView();
        }

        private void findXml()
        {
            currentBaseYear = defaultBaseYear;
            currentBaseSalary = Int32.MaxValue;
            dirPath = dirPathInput.Text;

            updateLog("Using directory '" + dirPath + "'");

            clubs = new List<Club>();

            if (System.IO.Directory.Exists(dirPath + "\\Clubs"))
            {
                foreach (String filePath in System.IO.Directory.GetFiles(dirPath + "\\Clubs"))
                {
                    if (filePath.Substring(filePath.Length - 3, 3).Equals("xml"))
                    {
                        XmlDocument xmlClubs = loadXML(filePath);

                        foreach (XmlNode node in xmlClubs.SelectNodes("Club"))
                        {
                            Club newClub = new Club(node, filePath.Replace(dirPath + "\\Clubs\\", ""), xmlClubs);
                            clubs.Add(newClub);
                        }
                    }
                }
            }

            updateLog("Amount of clubs found: " + clubs.Count);

            clubs.Sort((x, y) => string.Compare(x.clubID, y.clubID));

            players = new List<Player>();

            if (System.IO.Directory.Exists(dirPath + "\\Players"))
            {
                foreach (String filePath in System.IO.Directory.GetFiles(dirPath + "\\Players"))
                {
                    if (filePath.Substring(filePath.Length - 3, 3).Equals("xml"))
                    {
                        XmlDocument xmlPlayers = loadXML(filePath);

                        foreach (XmlNode node in xmlPlayers.SelectNodes("Player"))
                        {
                            Player newPlayer = new Player(node, filePath.Replace(dirPath + "\\Players\\", ""), xmlPlayers);

                            foreach (Club club in clubs)
                            {
                                if (club.clubID.Equals(newPlayer.clubID))
                                {
                                    newPlayer.setClub(club);
                                }
                            }

                            players.Add(newPlayer);

                            if (this.currentBaseYear < Int32.Parse(newPlayer.age_year))
                            {
                                this.currentBaseYear = Int32.Parse(newPlayer.age_year);
                            }

                            if (this.currentBaseSalary > Int32.Parse(newPlayer.totalValue))
                            {
                                this.currentBaseSalary = Int32.Parse(newPlayer.totalValue);
                            }
                        }
                    }
                }
            }

            updateLog("Amount of players found: " + players.Count);

            if (players.Count == 0 || clubs.Count == 0)
            {
                if (players.Count == 0)
                {
                    MessageBox.Show("I couldn't find any player data in the directory you input.","Whoops! Load error.");
                }
                else
                {
                    MessageBox.Show("I couldn't find any club data in the directory you input.", "Whoops! Load error.");
                }

                players = null;
                clubs = null;
            }
            else
            {

                //Console.WriteLine(this.currentBaseYear);
                updateLog("This save is " + (this.currentBaseYear - Form1.defaultBaseYear) + " years ahead.");
                updateLog("This save has a currency valued at " + Math.Floor(100 * (double)this.currentBaseSalary / Form1.defaultBaseSalary) + " percent of its starting position.");

                clubs.Sort((x, y) => string.Compare(x.name, y.name));
                players.Sort((x, y) => string.Compare(x.club.name, y.club.name));

                clubsDataGridView.DataSource = clubs;
                playersDataGridView.DataSource = players;

                refreshDataGridView();
            }
        }

        private void refreshDataGridView()
        {
            sortClubs();
            sortPlayers();

            //playersDataGridView.DataSource = players;
            playersDataGridView.Refresh();

            //clubsDataGridView.DataSource = clubs;
            clubsDataGridView.Refresh();
        }

        // Updates XML document (the file)
        private void updateXml()
        {
            String dirPath = dirPathInput.Text;
            int count = 0;

            foreach (Player player in players)
            {
                XmlDocument xmlPlayer = loadXML(dirPath + "\\Players\\" + player.xmlFileName);

                if (!(new Player(xmlPlayer.SelectSingleNode("Player"), player.xmlFileName, xmlPlayer).SameAs(player)))
                {
                    xmlPlayer = changeXml(player, xmlPlayer);

                    xmlPlayer.Save(dirPath + "\\Players\\" + player.xmlFileName);

                    count++;
                }
            }

            updateLog("Amount of players updated: " + count);
        }

        private XmlDocument changeXml(Player player, XmlDocument xmlPlayer)
        {
            foreach (XmlNode node in xmlPlayer.SelectNodes("Player"))
            {
                node.SelectSingleNode("ID").InnerText = player.playerID;
                node.SelectSingleNode("FirstName").InnerText = player.fname;
                node.SelectSingleNode("LastName").InnerText = player.lname;
                node.SelectSingleNode("RegionalClubID").InnerText = player.clubID;
                node.SelectSingleNode("HomeState").InnerText = player.homeState;
                node.SelectSingleNode("Condition").InnerText = player.condition;

                // DOB
                node.SelectSingleNode("DOB").SelectSingleNode("Day").InnerText = player.age_day;
                node.SelectSingleNode("DOB").SelectSingleNode("Month").InnerText = player.age_month;
                node.SelectSingleNode("DOB").SelectSingleNode("Year").InnerText = player.age_year;

                // Attributes
                node.SelectSingleNode("Attributes").SelectSingleNode("Height").InnerText = player.height;
                node.SelectSingleNode("Attributes").SelectSingleNode("Weight").InnerText = player.weight;
                node.SelectSingleNode("Attributes").SelectSingleNode("ManMarking").InnerText = player.manMarking;
                node.SelectSingleNode("Attributes").SelectSingleNode("VerticalLeap").InnerText = player.verticalLeap;
                node.SelectSingleNode("Attributes").SelectSingleNode("Tenacity").InnerText = player.tenacity;
                node.SelectSingleNode("Attributes").SelectSingleNode("Skill").InnerText = player.skill;
                node.SelectSingleNode("Attributes").SelectSingleNode("Agility").InnerText = player.agility;
                node.SelectSingleNode("Attributes").SelectSingleNode("Courage").InnerText = player.courage;
                node.SelectSingleNode("Attributes").SelectSingleNode("Aggression").InnerText = player.aggression;
                node.SelectSingleNode("Attributes").SelectSingleNode("XFactor").InnerText = player.xFactor;
                node.SelectSingleNode("Attributes").SelectSingleNode("StrengthGroundLevel").InnerText = player.strengthGroundLevel;
                node.SelectSingleNode("Attributes").SelectSingleNode("StrengthOverhead").InnerText = player.strengthOverhead;
                node.SelectSingleNode("Attributes").SelectSingleNode("StrengthManOnMan").InnerText = player.strengthManOnMan;
                node.SelectSingleNode("Attributes").SelectSingleNode("Acceleration").InnerText = player.acceleration;
                node.SelectSingleNode("Attributes").SelectSingleNode("Speed").InnerText = player.speed;
                node.SelectSingleNode("Attributes").SelectSingleNode("Endurance").InnerText = player.endurance;

                // Hidden
                node.SelectSingleNode("Hidden").SelectSingleNode("Confidence").InnerText = player.confidence;
                node.SelectSingleNode("Hidden").SelectSingleNode("ReadPlay").InnerText = player.readPlay;
                node.SelectSingleNode("Hidden").SelectSingleNode("Consistancy").InnerText = player.consistancy;
                node.SelectSingleNode("Hidden").SelectSingleNode("Positioning").InnerText = player.positioning;
                node.SelectSingleNode("Hidden").SelectSingleNode("CopeWithPressure").InnerText = player.copeWithPressure;
                node.SelectSingleNode("Hidden").SelectSingleNode("PotentialTall").InnerText = player.potentialTall;
                node.SelectSingleNode("Hidden").SelectSingleNode("PotentialMid").InnerText = player.potentialMid;
                node.SelectSingleNode("Hidden").SelectSingleNode("KickMaxDistance").InnerText = player.kickMaxDistance;
                node.SelectSingleNode("Hidden").SelectSingleNode("DisciplineMatch").InnerText = player.disciplineMatch;
                node.SelectSingleNode("Hidden").SelectSingleNode("DisciplineTraining").InnerText = player.disciplineTraining;
                node.SelectSingleNode("Hidden").SelectSingleNode("DisciplineOffField").InnerText = player.disciplineOffField;
                node.SelectSingleNode("Hidden").SelectSingleNode("UmpireLikes").InnerText = player.umpireLikes;
                node.SelectSingleNode("Hidden").SelectSingleNode("UmpireNotice").InnerText = player.umpireNotice;
                node.SelectSingleNode("Hidden").SelectSingleNode("GoHomeTend").InnerText = player.goHomeTend;
                node.SelectSingleNode("Hidden").SelectSingleNode("InjuryTend").InnerText = player.injuryTend;
                node.SelectSingleNode("Hidden").SelectSingleNode("LoyaltyTend").InnerText = player.loyaltyTend;
                node.SelectSingleNode("Hidden").SelectSingleNode("ClangerTend").InnerText = player.clangerTend;
                node.SelectSingleNode("Hidden").SelectSingleNode("Leadership").InnerText = player.leadership;

                // Improvement
                node.SelectSingleNode("Improvement").SelectSingleNode("MarkLead").InnerText = player.imp_markLead;
                node.SelectSingleNode("Improvement").SelectSingleNode("MarkContested").InnerText = player.imp_markContested;
                node.SelectSingleNode("Improvement").SelectSingleNode("SpoilContested").InnerText = player.imp_spoilContested;
                node.SelectSingleNode("Improvement").SelectSingleNode("SpoilLead").InnerText = player.imp_spoilLead;
                node.SelectSingleNode("Improvement").SelectSingleNode("Evasion").InnerText = player.imp_evasion;
                node.SelectSingleNode("Improvement").SelectSingleNode("CatchPlayer").InnerText = player.imp_catchPlayer;
                node.SelectSingleNode("Improvement").SelectSingleNode("Tackle").InnerText = player.imp_tackle;
                node.SelectSingleNode("Improvement").SelectSingleNode("Ruck").InnerText = player.imp_ruck;
                node.SelectSingleNode("Improvement").SelectSingleNode("GoalSet").InnerText = player.imp_goalSet;
                node.SelectSingleNode("Improvement").SelectSingleNode("GoalRun").InnerText = player.imp_goalRun;
                node.SelectSingleNode("Improvement").SelectSingleNode("HardBallGets").InnerText = player.imp_hardBallGets;
                node.SelectSingleNode("Improvement").SelectSingleNode("HandsInClose").InnerText = player.imp_handsInClose;
                node.SelectSingleNode("Improvement").SelectSingleNode("Clearance").InnerText = player.imp_clearance;
                node.SelectSingleNode("Improvement").SelectSingleNode("GetToContest").InnerText = player.imp_getToContest;
                node.SelectSingleNode("Improvement").SelectSingleNode("FootSkills").InnerText = player.imp_footSkills;

                // Degradation
                node.SelectSingleNode("Degradation").SelectSingleNode("MarkLead").InnerText = player.deg_markLead;
                node.SelectSingleNode("Degradation").SelectSingleNode("MarkContested").InnerText = player.deg_markContested;
                node.SelectSingleNode("Degradation").SelectSingleNode("SpoilContested").InnerText = player.deg_spoilContested;
                node.SelectSingleNode("Degradation").SelectSingleNode("SpoilLead").InnerText = player.deg_spoilLead;
                node.SelectSingleNode("Degradation").SelectSingleNode("Evasion").InnerText = player.deg_evasion;
                node.SelectSingleNode("Degradation").SelectSingleNode("CatchPlayer").InnerText = player.deg_catchPlayer;
                node.SelectSingleNode("Degradation").SelectSingleNode("Tackle").InnerText = player.deg_tackle;
                node.SelectSingleNode("Degradation").SelectSingleNode("Ruck").InnerText = player.deg_ruck;
                node.SelectSingleNode("Degradation").SelectSingleNode("GoalSet").InnerText = player.deg_goalSet;
                node.SelectSingleNode("Degradation").SelectSingleNode("GoalRun").InnerText = player.deg_goalRun;
                node.SelectSingleNode("Degradation").SelectSingleNode("HardBallGets").InnerText = player.deg_hardBallGets;
                node.SelectSingleNode("Degradation").SelectSingleNode("HandsInClose").InnerText = player.deg_handsInClose;
                node.SelectSingleNode("Degradation").SelectSingleNode("Clearance").InnerText = player.deg_clearance;
                node.SelectSingleNode("Degradation").SelectSingleNode("GetToContest").InnerText = player.deg_getToContest;
                node.SelectSingleNode("Degradation").SelectSingleNode("FootSkills").InnerText = player.deg_footSkills;

                // Contract
                node.SelectSingleNode("Contract").SelectSingleNode("AFLcontractID").InnerText = player.playerID;
                node.SelectSingleNode("Contract").SelectSingleNode("PlayerID").InnerText = player.playerID;
                node.SelectSingleNode("Contract").SelectSingleNode("ClubID").InnerText = player.clubID;
                node.SelectSingleNode("Contract").SelectSingleNode("TotalValue").InnerText = player.totalValue;
                node.SelectSingleNode("Contract").SelectSingleNode("JumperNumber").InnerText = player.jumperNumber;
                // DateSigned
                node.SelectSingleNode("Contract").SelectSingleNode("DateSigned").SelectSingleNode("Day").InnerText = player.signed_day;
                node.SelectSingleNode("Contract").SelectSingleNode("DateSigned").SelectSingleNode("Month").InnerText = player.signed_month;
                node.SelectSingleNode("Contract").SelectSingleNode("DateSigned").SelectSingleNode("Year").InnerText = player.signed_year;
                // DateExpired
                node.SelectSingleNode("Contract").SelectSingleNode("DateExpired").SelectSingleNode("Day").InnerText = player.expired_day;
                node.SelectSingleNode("Contract").SelectSingleNode("DateExpired").SelectSingleNode("Month").InnerText = player.expired_month;
                node.SelectSingleNode("Contract").SelectSingleNode("DateExpired").SelectSingleNode("Year").InnerText = player.expired_year;


                // AFLcareer
                node.SelectSingleNode("AFLcareer").SelectSingleNode("ClubID").InnerText = player.clubID;
                // DraftPick
                node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("Pick").InnerText = player.draft_pick;
                node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("Year").InnerText = player.draft_year;
                node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("DraftType").InnerText = player.draft_draftType;
                node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("ClubID").InnerText = player.clubID;
                node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("DrafteeID").InnerText = player.playerID;
            }

            return xmlPlayer;
        }

        private void updateLog(String update)
        {
            logCount++;
            statsBox.Text = logCount + ". " + update + Environment.NewLine + statsBox.Text;
        }

        private XmlDocument loadXML(String path)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(path);

            return xmlDoc;
        }

        private int getNextAvailableJumperNumber(Club club)
        {
            List<string> usedJumperNumbers = new List<string>();

            foreach (Player player in players)
            {
                if (player.clubID.Equals(club.clubID))
                {
                    usedJumperNumbers.Add(player.jumperNumber);
                }
            }

            for (int index = 1; index < 60; index++)
            {
                if (!usedJumperNumbers.Contains(index.ToString()))
                {
                    return index;
                }
            }

            return -1;
        }

        private void changeClub()
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                if (clubsDataGridView.SelectedRows.Count > 0)
                {
                    Club club = (Club)clubsDataGridView.SelectedRows[0].DataBoundItem;
                    ((Player)playersDataGridView.SelectedRows[0].DataBoundItem).changeClub(club, getNextAvailableJumperNumber(club));
                }
            }

            refreshDataGridView();
        }

        private void randomize()
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                ((Player)playersDataGridView.SelectedRows[0].DataBoundItem).randomize();
            }

            refreshDataGridView();
        }

        private void improveAttr()
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                ((Player)playersDataGridView.SelectedRows[0].DataBoundItem).scaleAttr(1.05);
            }

            refreshDataGridView();
        }

        private void degradeAttr()
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                ((Player)playersDataGridView.SelectedRows[0].DataBoundItem).scaleAttr(0.95);
            }

            refreshDataGridView();
        }

        private void improveImp()
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                ((Player)playersDataGridView.SelectedRows[0].DataBoundItem).scaleImp(1.05);
            }

            refreshDataGridView();
        }

        private void degradeImp()
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                ((Player)playersDataGridView.SelectedRows[0].DataBoundItem).scaleImp(0.95);
            }

            refreshDataGridView();
        }

        private void makeArchetype(Archetype archetype)
        {
            if (playersDataGridView.SelectedRows.Count > 0)
            {
                ((Player)playersDataGridView.SelectedRows[0].DataBoundItem).archetype(archetype);
            }

            refreshDataGridView();
        }

        private void makeAllArchetype(Archetype archetype)
        {
            foreach (Player player in players)
            {
                player.archetype(archetype);
            }

            refreshDataGridView();
        }

        private void sortPlayers()
        {
            if (playerSortAttribute == null)
            {
                players.Sort((x, y) => Player.Compare(x, y));
            }
            else
            {
                try
                {
                    if (this.playerSortAscending == true)
                    {
                        sortPlayersAlgorithm = sortPlayersAscending;
                    }
                    else
                    {
                        sortPlayersAlgorithm = sortPlayersDescending;
                    }
                    players.Sort((x, y) => sortPlayersAlgorithm(x, y));
                }
                catch (Exception e)
                {
                    players.Sort((x, y) => Player.Compare(x, y));
                }
            }
        }

        private void sortClubs()
        {
            clubs.Sort((x, y) => string.Compare(x.name, y.name));
        }

        private int sortPlayersAscending(Player x, Player y)
        {
            PropertyInfo prop = typeof(Player).GetProperty(playerSortAttribute);

            if (prop.GetValue(x, null).GetType().Equals(typeof(double)) || prop.GetValue(x, null).GetType().Equals(typeof(int)))
            {
                return Convert.ToInt32((double)prop.GetValue(x, null) * 100 - (double)prop.GetValue(y, null) * 100);
            }
            else
            {
                return -prop.GetValue(x, null).ToString().CompareTo(prop.GetValue(y, null).ToString());
            }
            
        }

        private int sortPlayersDescending(Player x, Player y)
        {
            return -1 * sortPlayersAscending(x, y);
        }        

        private void randomizeAll()
        {
            foreach (Player player in players)
            {
                player.randomize();
            }

            refreshDataGridView();
        }

        private void allGenericPotential()
        {
            foreach (Player player in players)
            {
                player.genericPotential();
            }

            refreshDataGridView();
        }

        private void allYearOlder()
        {
            foreach (Player player in players)
            {
                player.age_year = (Int32.Parse(player.age_year) - 1).ToString();
            }

            refreshDataGridView();
        }

        private void importTeam()
        {
            if (clubsDataGridView.SelectedRows.Count > 0)
            {
                Club club = (Club)clubsDataGridView.SelectedRows[0].DataBoundItem;

                List<Player> removePlayers = new List<Player>();

                foreach (Player player in players)
                {
                    if (player.clubID.Equals(club.clubID))
                    {
                        removePlayers.Add(player);
                    }
                }

                foreach (Player player in removePlayers)
                {
                    players.Remove(player);
                    File.Delete(dirPath + "\\Players\\" + player.xmlFileName);
                }

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                String importPath = "";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    importPath = folderBrowserDialog.SelectedPath;

                    foreach (String filePath in System.IO.Directory.GetFiles(importPath))
                    {
                        if (filePath.Substring(filePath.Length - 3, 3).Equals("xml"))
                        {
                            XmlDocument xmlPlayers = loadXML(filePath);

                            foreach (XmlNode node in xmlPlayers.SelectNodes("Player"))
                            {
                                // generate new file name
                                String newFileName = "custompl-ayer-auto-genI-" + formatAutoGenId(getNewAutoGenId());

                                // generate new player object based on another player
                                Player newPlayer = new Player(node, newFileName + ".xml", xmlPlayers);

                                newPlayer.reIdentify(newFileName);
                                newPlayer.fname = newPlayer.fname;// +club.name.Substring(0, 2);
                                //newPlayer.totalValue = "100000";

                                //newPlayer.setClub(club);
                                newPlayer.changeClub(club, getNextAvailableJumperNumber(club));

                                Console.WriteLine("Adding " + newPlayer.fname + " " + newPlayer.lname + " to team " + club.name + " (" + club.clubID + ").");
                                Console.WriteLine("Player has club ID: " + newPlayer.clubID);

                                players.Add(newPlayer);

                                xmlPlayers = newPlayer.originalDocument;
                                xmlPlayers = changeXml(newPlayer, xmlPlayers);

                                xmlPlayers.Save(dirPath + "\\Players\\" + newPlayer.xmlFileName);
                            }
                        }
                    }
                }

                updateXml();

                refreshDataGridView();
            }
        }

        private void clearPlayerHistory(Player player)
        {

        }

        private void exportAllTeams()
        {
            if (clubs.Count > 0)
            {
                String exportPath = "";
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                folderBrowserDialog.Description = "Select a folder to save the clubs in.";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    exportPath = folderBrowserDialog.SelectedPath;
                }

                foreach (Club club in clubs)
                {
                    exportTeam(club, exportPath + "\\" + club.name);
                }

                refreshDataGridView();
            }
        }

        private void exportTeam(Club club, String exportPath = "")
        {
            List<Player> exportPlayers = new List<Player>();

            foreach (Player player in players)
            {
                if (player.clubID.Equals(club.clubID))
                {
                    exportPlayers.Add(player);
                }
            }

            if(exportPath.Equals(""))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            
                folderBrowserDialog.Description = "Select a folder to save the players of club '" + club.name + "'.";
            
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    exportPath = folderBrowserDialog.SelectedPath;
                }
            }

            if(!exportPath.Equals(""))
            {
                if (!Directory.Exists(exportPath))
                {
                    Directory.CreateDirectory(exportPath);
                }

                foreach (Player player in exportPlayers)
                {
                    if (!File.Exists(exportPath + "\\" + player.xmlFileName))
                    {
                        XmlDocument xmlPlayer = Player.blankPlayer();

                        Player translatedPlayer = new Player(xmlPlayer.SelectNodes("Player")[0], player.xmlFileName, xmlPlayer);
                        translatedPlayer.CopyFrom(player);
                        translatedPlayer.changeYears(Form1.defaultBaseYear - this.currentBaseYear);
                        translatedPlayer.totalValue = (Math.Floor(Int32.Parse(translatedPlayer.totalValue) / ((double)this.currentBaseSalary / Form1.defaultBaseSalary))).ToString();

                        translatedPlayer.setOriginalDocument(changeXml(translatedPlayer, xmlPlayer));
                        xmlPlayer = translatedPlayer.originalDocument;

                        xmlPlayer.Save(exportPath + "\\" + player.xmlFileName);
                    }
                    else
                    {
                        Console.WriteLine("File " + player.xmlFileName + " already exists.");
                    }
                }
            }
        }

        private void exportTeam()
        {
            if (clubsDataGridView.SelectedRows.Count > 0)
            {
                Club club = (Club)clubsDataGridView.SelectedRows[0].DataBoundItem;

                exportTeam(club);

                refreshDataGridView();
            }
        }

        #region form_controls

        private void findButton_Click(object sender, EventArgs e)
        {
            if (!dirPathInput.Text.Equals(""))
            {
                findXml();
            }
            updateInstructions();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updateXml();
            updateInstructions();
        }

        private void playersDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (playerSortAttribute.Equals(playersDataGridView.Columns[e.ColumnIndex].DataPropertyName) == true)
            {
                playerSortAscending = !playerSortAscending;
            }
            else
            {
                playerSortAttribute = playersDataGridView.Columns[e.ColumnIndex].DataPropertyName;
                playerSortAscending = false;
            }

            refreshDataGridView();
            updateInstructions();
        }

        private void changeClubButton_Click(object sender, EventArgs e)
        {
            changeClub();
            updateInstructions();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            removePlayer();
            updateInstructions();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            createPlayer();
            updateInstructions();
        }

        private void randomizeAllButton_Click(object sender, EventArgs e)
        {
            randomizeAll();
            updateInstructions();
        }

        private void randomzieButton_Click(object sender, EventArgs e)
        {
            randomize();
            updateInstructions();
        }

        private void impAttrButton_Click(object sender, EventArgs e)
        {
            improveAttr();
            updateInstructions();
        }

        private void impImpButton_Click(object sender, EventArgs e)
        {
            improveImp();
            updateInstructions();
        }

        private void degAttrButton_Click(object sender, EventArgs e)
        {
            degradeAttr();
            updateInstructions();
        }

        private void degImpButton_Click(object sender, EventArgs e)
        {
            degradeImp();
            updateInstructions();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            importTeam();
            updateInstructions();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            exportTeam();
            updateInstructions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportAllTeams();
            updateInstructions();
        }

        private void dirPathInput_TextChanged(object sender, EventArgs e)
        {
            updateInstructions();
        }

        private void backPocketButton_Click(object sender, EventArgs e)
        {
            makeArchetype(Archetype.BackPocket);
            updateInstructions();
        }

        #endregion

        private void allBackPocketButton_Click(object sender, EventArgs e)
        {
            makeAllArchetype(Archetype.BackPocket);
            updateInstructions();
        }

        private void allGenericPotentialButton_Click(object sender, EventArgs e)
        {
            allGenericPotential();
            updateInstructions();
        }

        private void allYearOlderButton_Click(object sender, EventArgs e)
        {
            allYearOlder();
            updateInstructions();
        }

    }
}
