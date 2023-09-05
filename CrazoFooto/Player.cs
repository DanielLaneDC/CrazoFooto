using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CrazoFooto
{
    public class Player
    {
        public XmlDocument originalDocument { get; private set; }

        public String playerID { get; set; }
        public String fname { get; set; }
        public String lname { get; set; }
        public String xmlFileName { get; private set; }
        public String homeState { get; set; }
        public String condition { get; set; }

        public Club club { get; private set; }
        public double age { get; private set; }

        // DOB
        public String age_day { get; set; }
        public String age_month { get; set; }
        public String age_year { get; set; }

        // Attributes
        public String height { get; set; }
        public String weight { get; set; }
        public String manMarking { get; set; }
        public String verticalLeap { get; set; }
        public String tenacity { get; set; }
        public String skill { get; set; }
        public String agility { get; set; }
        public String courage { get; set; }
        public String aggression { get; set; }
        public String xFactor { get; set; }
        public String strengthGroundLevel { get; set; }
        public String strengthOverhead { get; set; }
        public String strengthManOnMan { get; set; }
        public String acceleration { get; set; }
        public String speed { get; set; }
        public String endurance { get; set; }

        // Hidden
        public String confidence { get; set; }
        public String readPlay { get; set; }
        public String consistancy { get; set; }
        public String positioning { get; set; }
        public String copeWithPressure { get; set; }
        public String potentialTall { get; set; }
        public String potentialMid { get; set; }
        public String kickMaxDistance { get; set; }
        public String disciplineMatch { get; set; }
        public String disciplineTraining { get; set; }
        public String disciplineOffField { get; set; }
        public String umpireLikes { get; set; }
        public String umpireNotice { get; set; }
        public String goHomeTend { get; set; }
        public String injuryTend { get; set; }
        public String loyaltyTend { get; set; }
        public String clangerTend { get; set; }
        public String leadership { get; set; }

        // Improvement
        public String imp_markLead { get; set; }
        public String imp_markContested { get; set; }
        public String imp_spoilContested { get; set; }
        public String imp_spoilLead { get; set; }
        public String imp_evasion { get; set; }
        public String imp_catchPlayer { get; set; }
        public String imp_tackle { get; set; }
        public String imp_ruck { get; set; }
        public String imp_goalSet { get; set; }
        public String imp_goalRun { get; set; }
        public String imp_hardBallGets { get; set; }
        public String imp_handsInClose { get; set; }
        public String imp_clearance { get; set; }
        public String imp_getToContest { get; set; }
        public String imp_footSkills { get; set; }

        // Degradation
        public String deg_markLead { get; set; }
        public String deg_markContested { get; set; }
        public String deg_spoilContested { get; set; }
        public String deg_spoilLead { get; set; }
        public String deg_evasion { get; set; }
        public String deg_catchPlayer { get; set; }
        public String deg_tackle { get; set; }
        public String deg_ruck { get; set; }
        public String deg_goalSet { get; set; }
        public String deg_goalRun { get; set; }
        public String deg_hardBallGets { get; set; }
        public String deg_handsInClose { get; set; }
        public String deg_clearance { get; set; }
        public String deg_getToContest { get; set; }
        public String deg_footSkills { get; set; }

        // Contract
        public String clubID { get; set; }
        public String totalValue { get; set; }
        public String jumperNumber { get; set; }
        // DateSigned
        public String signed_day { get; set; }
        public String signed_month { get; set; }
        public String signed_year { get; set; }
        // DateExpired
        public String expired_day { get; set; }
        public String expired_month { get; set; }
        public String expired_year { get; set; }

        // AFLcareer
        // DraftPick
        public String draft_pick { get; set; }
        public String draft_year { get; set; }
        public String draft_draftType { get; set; }

        public Player(String fname, String lname)
        {
            this.fname = fname;
            this.lname = lname;
        }

        public Player(Player player, String filePath)
        {
            PropertyInfo[] props = this.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                prop.SetValue(this, prop.GetValue(player, null), null);
            }

            this.xmlFileName = filePath;
            this.playerID = this.xmlFileName;
        }

        public void changeYears(int change)
        {
            this.age_year = (Int32.Parse(this.age_year) + change).ToString();
            this.draft_year = (Int32.Parse(this.draft_year) + change).ToString();
            this.signed_year = (Int32.Parse(this.signed_year) + change).ToString();
            this.expired_year = (Int32.Parse(this.expired_year) + change).ToString();
        }

        public void CopyFrom(Player player, bool includeOriginalDocument = false)
        {
            PropertyInfo[] props = this.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (!prop.Name.Equals("originalDocument") || includeOriginalDocument == true)
                {
                    prop.SetValue(this, prop.GetValue(player, null), null);
                }
            }

            this.xmlFileName = player.xmlFileName;
            this.playerID = this.xmlFileName;
        }

        public void setOriginalDocument(XmlDocument document)
        {
            this.originalDocument = document;
        }

        public void reIdentify(String playerId)
        {
            this.xmlFileName = playerId + ".xml";
            this.playerID = playerId;

        }

        public Player(XmlNode node, String filePath, XmlDocument originalDocument)
        {
            this.originalDocument = originalDocument;

            this.playerID = node.SelectSingleNode("ID").InnerText;
            this.fname = node.SelectSingleNode("FirstName").InnerText;
            this.lname = node.SelectSingleNode("LastName").InnerText;
            this.xmlFileName = filePath;
            this.homeState = node.SelectSingleNode("HomeState").InnerText;
            this.condition = node.SelectSingleNode("Condition").InnerText;
            
            // DOB
            this.age_day = node.SelectSingleNode("DOB").SelectSingleNode("Day").InnerText;
            this.age_month = node.SelectSingleNode("DOB").SelectSingleNode("Month").InnerText;
            this.age_year = node.SelectSingleNode("DOB").SelectSingleNode("Year").InnerText;

            // Attributes
            this.height = node.SelectSingleNode("Attributes").SelectSingleNode("Height").InnerText;
            this.weight = node.SelectSingleNode("Attributes").SelectSingleNode("Weight").InnerText;
            this.manMarking = node.SelectSingleNode("Attributes").SelectSingleNode("ManMarking").InnerText;
            this.verticalLeap = node.SelectSingleNode("Attributes").SelectSingleNode("VerticalLeap").InnerText;
            this.tenacity = node.SelectSingleNode("Attributes").SelectSingleNode("Tenacity").InnerText;
            this.skill = node.SelectSingleNode("Attributes").SelectSingleNode("Skill").InnerText;
            this.agility = node.SelectSingleNode("Attributes").SelectSingleNode("Agility").InnerText;
            this.courage = node.SelectSingleNode("Attributes").SelectSingleNode("Courage").InnerText;
            this.aggression = node.SelectSingleNode("Attributes").SelectSingleNode("Aggression").InnerText;
            this.xFactor = node.SelectSingleNode("Attributes").SelectSingleNode("XFactor").InnerText;
            this.strengthGroundLevel = node.SelectSingleNode("Attributes").SelectSingleNode("StrengthGroundLevel").InnerText;
            this.strengthOverhead = node.SelectSingleNode("Attributes").SelectSingleNode("StrengthOverhead").InnerText;
            this.strengthManOnMan = node.SelectSingleNode("Attributes").SelectSingleNode("StrengthManOnMan").InnerText;
            this.acceleration = node.SelectSingleNode("Attributes").SelectSingleNode("Acceleration").InnerText;
            this.speed = node.SelectSingleNode("Attributes").SelectSingleNode("Speed").InnerText;
            this.endurance = node.SelectSingleNode("Attributes").SelectSingleNode("Endurance").InnerText;

            // Hidden
            this.confidence = node.SelectSingleNode("Hidden").SelectSingleNode("Confidence").InnerText;
            this.readPlay = node.SelectSingleNode("Hidden").SelectSingleNode("ReadPlay").InnerText;
            this.consistancy = node.SelectSingleNode("Hidden").SelectSingleNode("Consistancy").InnerText;
            this.positioning = node.SelectSingleNode("Hidden").SelectSingleNode("Positioning").InnerText;
            this.copeWithPressure = node.SelectSingleNode("Hidden").SelectSingleNode("CopeWithPressure").InnerText;
            this.potentialTall = node.SelectSingleNode("Hidden").SelectSingleNode("PotentialTall").InnerText;
            this.potentialMid = node.SelectSingleNode("Hidden").SelectSingleNode("PotentialMid").InnerText;
            this.kickMaxDistance = node.SelectSingleNode("Hidden").SelectSingleNode("KickMaxDistance").InnerText;
            this.disciplineMatch = node.SelectSingleNode("Hidden").SelectSingleNode("DisciplineMatch").InnerText;
            this.disciplineTraining = node.SelectSingleNode("Hidden").SelectSingleNode("DisciplineTraining").InnerText;
            this.disciplineOffField = node.SelectSingleNode("Hidden").SelectSingleNode("DisciplineOffField").InnerText;
            this.umpireLikes = node.SelectSingleNode("Hidden").SelectSingleNode("UmpireLikes").InnerText;
            this.umpireNotice = node.SelectSingleNode("Hidden").SelectSingleNode("UmpireNotice").InnerText;
            this.goHomeTend = node.SelectSingleNode("Hidden").SelectSingleNode("GoHomeTend").InnerText;
            this.injuryTend = node.SelectSingleNode("Hidden").SelectSingleNode("InjuryTend").InnerText;
            this.loyaltyTend = node.SelectSingleNode("Hidden").SelectSingleNode("LoyaltyTend").InnerText;
            this.clangerTend = node.SelectSingleNode("Hidden").SelectSingleNode("ClangerTend").InnerText;
            this.leadership = node.SelectSingleNode("Hidden").SelectSingleNode("Leadership").InnerText;

            // Improvement
            this.imp_markLead = node.SelectSingleNode("Improvement").SelectSingleNode("MarkLead").InnerText;
            this.imp_markContested = node.SelectSingleNode("Improvement").SelectSingleNode("MarkContested").InnerText;
            this.imp_spoilContested = node.SelectSingleNode("Improvement").SelectSingleNode("SpoilContested").InnerText;
            this.imp_spoilLead = node.SelectSingleNode("Improvement").SelectSingleNode("SpoilLead").InnerText;
            this.imp_evasion = node.SelectSingleNode("Improvement").SelectSingleNode("Evasion").InnerText;
            this.imp_catchPlayer = node.SelectSingleNode("Improvement").SelectSingleNode("CatchPlayer").InnerText;
            this.imp_tackle = node.SelectSingleNode("Improvement").SelectSingleNode("Tackle").InnerText;
            this.imp_ruck = node.SelectSingleNode("Improvement").SelectSingleNode("Ruck").InnerText;
            this.imp_goalSet = node.SelectSingleNode("Improvement").SelectSingleNode("GoalSet").InnerText;
            this.imp_goalRun = node.SelectSingleNode("Improvement").SelectSingleNode("GoalRun").InnerText;
            this.imp_hardBallGets = node.SelectSingleNode("Improvement").SelectSingleNode("HardBallGets").InnerText;
            this.imp_handsInClose = node.SelectSingleNode("Improvement").SelectSingleNode("HandsInClose").InnerText;
            this.imp_clearance = node.SelectSingleNode("Improvement").SelectSingleNode("Clearance").InnerText;
            this.imp_getToContest = node.SelectSingleNode("Improvement").SelectSingleNode("GetToContest").InnerText;
            this.imp_footSkills = node.SelectSingleNode("Improvement").SelectSingleNode("FootSkills").InnerText;

            // Degredation
            this.deg_markLead = node.SelectSingleNode("Degradation").SelectSingleNode("MarkLead").InnerText;
            this.deg_markContested = node.SelectSingleNode("Degradation").SelectSingleNode("MarkContested").InnerText;
            this.deg_spoilContested = node.SelectSingleNode("Degradation").SelectSingleNode("SpoilContested").InnerText;
            this.deg_spoilLead = node.SelectSingleNode("Degradation").SelectSingleNode("SpoilLead").InnerText;
            this.deg_evasion = node.SelectSingleNode("Degradation").SelectSingleNode("Evasion").InnerText;
            this.deg_catchPlayer = node.SelectSingleNode("Degradation").SelectSingleNode("CatchPlayer").InnerText;
            this.deg_tackle = node.SelectSingleNode("Degradation").SelectSingleNode("Tackle").InnerText;
            this.deg_ruck = node.SelectSingleNode("Degradation").SelectSingleNode("Ruck").InnerText;
            this.deg_goalSet = node.SelectSingleNode("Degradation").SelectSingleNode("GoalSet").InnerText;
            this.deg_goalRun = node.SelectSingleNode("Degradation").SelectSingleNode("GoalRun").InnerText;
            this.deg_hardBallGets = node.SelectSingleNode("Degradation").SelectSingleNode("HardBallGets").InnerText;
            this.deg_handsInClose = node.SelectSingleNode("Degradation").SelectSingleNode("HandsInClose").InnerText;
            this.deg_clearance = node.SelectSingleNode("Degradation").SelectSingleNode("Clearance").InnerText;
            this.deg_getToContest = node.SelectSingleNode("Degradation").SelectSingleNode("GetToContest").InnerText;
            this.deg_footSkills = node.SelectSingleNode("Degradation").SelectSingleNode("FootSkills").InnerText;

            // Contract
            this.clubID = node.SelectSingleNode("Contract").SelectSingleNode("ClubID").InnerText;
            this.totalValue = node.SelectSingleNode("Contract").SelectSingleNode("TotalValue").InnerText;
            this.jumperNumber = node.SelectSingleNode("Contract").SelectSingleNode("JumperNumber").InnerText;
            // DateSigned
            this.signed_day = node.SelectSingleNode("Contract").SelectSingleNode("DateSigned").SelectSingleNode("Day").InnerText;
            this.signed_month = node.SelectSingleNode("Contract").SelectSingleNode("DateSigned").SelectSingleNode("Month").InnerText;
            this.signed_year = node.SelectSingleNode("Contract").SelectSingleNode("DateSigned").SelectSingleNode("Year").InnerText;
            // DateExpired
            this.expired_day = node.SelectSingleNode("Contract").SelectSingleNode("DateExpired").SelectSingleNode("Day").InnerText;
            this.expired_month = node.SelectSingleNode("Contract").SelectSingleNode("DateExpired").SelectSingleNode("Month").InnerText;
            this.expired_year = node.SelectSingleNode("Contract").SelectSingleNode("DateExpired").SelectSingleNode("Year").InnerText;

            // AFLcareer
            // DraftPick
            this.draft_pick = node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("Pick").InnerText;
            this.draft_year = node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("Year").InnerText;
            this.draft_draftType = node.SelectSingleNode("AFLcareer").SelectSingleNode("DraftPick").SelectSingleNode("DraftType").InnerText;

            updateDate();
        }

        public void archetype(Archetype archetype)
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            PlayerArchetype playerArchetype = new PlayerArchetype(archetype);

            foreach (PropertyInfo prop in props)
            {
                PropertyInfo[] checkProps = playerArchetype.GetType().GetProperties();
                Boolean containsProps = false;
                foreach (PropertyInfo checkProp in checkProps)
                {
                    if (checkProp.Name.Equals(prop.Name)) containsProps = true;
                }

                if(containsProps==true)
                {
                    prop.SetValue(this, playerArchetype.GetType().GetProperty(prop.Name).GetValue(playerArchetype, null), null);
                }
            }
        }

        public void genericPotential()
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            bool startImp = false;
            bool startDeg = false;

            foreach (PropertyInfo prop in props)
            {
                if (startImp == false)
                {
                    if (prop.Name.Equals("imp_markLead"))
                    {
                        startImp = true;
                    }
                }

                if (startImp == true)
                {
                    int impValue = (int)(Math.Pow((40 - (int)age) / (float)17, 2) * (Form1.random.Next(0, 5000)));
                    prop.SetValue(this, impValue.ToString(), null);

                    if (prop.Name.Equals("imp_footSkills"))
                    {
                        startImp = false;
                    }
                }

                if (startDeg == false)
                {
                    if (prop.Name.Equals("deg_markLead"))
                    {
                        startDeg = true;
                    }
                }

                if (startDeg == true)
                {
                    int degValue = (int)((1-((40 - (int)age) / (float)17)) * (Form1.random.Next(0, 5000)));
                    if (degValue < 0) degValue = 0;
                    prop.SetValue(this, degValue.ToString(), null);

                    if (prop.Name.Equals("deg_footSkills"))
                    {
                        startDeg = false;
                    }
                }
            }
        }

        public void randomize()
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            bool startRandom = false;

            foreach (PropertyInfo prop in props)
            {
                if (startRandom == false)
                {
                    if (prop.Name.Equals("manMarking"))
                    {
                        startRandom = true;
                    }
                }

                if (startRandom == true)
                {
                    prop.SetValue(this, Form1.random.Next(30, 100).ToString(), null);

                    if (prop.Name.Equals("imp_footSkills"))
                    {
                        startRandom = false;
                    }
                }
            }
        }

        public void scaleAttr(double scalingAmount)
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            bool start = false;

            foreach (PropertyInfo prop in props)
            {
                if (start == false)
                {
                    if (prop.Name.Equals("manMarking"))
                    {
                        start = true;
                    }
                }

                if (start == true)
                {
                    prop.SetValue(this, ((int)(Int32.Parse((String)prop.GetValue(this, null)) * scalingAmount)).ToString(), null);

                    if (prop.Name.Equals("leadership"))
                    {
                        start = false;
                    }
                }
            }
        }

        public void scaleImp(double scalingAmount)
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            bool start = false;

            foreach (PropertyInfo prop in props)
            {
                if (start == false)
                {
                    if (prop.Name.Equals("imp_markLead"))
                    {
                        start = true;
                    }
                }

                if (start == true)
                {
                    prop.SetValue(this, ((int)(Int32.Parse((String)prop.GetValue(this, null)) * scalingAmount)).ToString(), null);

                    if (prop.Name.Equals("imp_footSkills"))
                    {
                        start = false;
                    }
                }
            }
        }

        public static XmlDocument blankPlayer()
        {
            XmlDocument player = new XmlDocument();

            using (XmlWriter writer = player.CreateNavigator().AppendChild()) 
            {
                writer.WriteStartDocument();
                {
                    writer.WriteStartElement("Player");
                    {
                        writer.WriteElementString("ID", "");
                        writer.WriteElementString("FirstName", "New");
                        writer.WriteElementString("LastName", "Player");
                        writer.WriteStartElement("DOB");
                        {
                            writer.WriteElementString("Day", "30");
                            writer.WriteElementString("Month", "4");
                            writer.WriteElementString("Year", "1992");
                        }
                        writer.WriteEndElement();
                        writer.WriteElementString("RegionalClubID", "");
                        writer.WriteElementString("HomeState", "1");
                        writer.WriteStartElement("RecruitedFrom");
                        {
                        }
                        writer.WriteEndElement();
                        writer.WriteElementString("SupporterOpinion", "0");
                        writer.WriteElementString("Condition", "50");
                        writer.WriteElementString("mfPerf", "False");
                        writer.WriteElementString("mfTrain", "False");
                        writer.WriteElementString("mfMatchDisc", "False");
                        writer.WriteElementString("CoachOpinion", "0");
                        writer.WriteElementString("Success", "0");
                        writer.WriteElementString("Opportinuty", "0");
                        writer.WriteElementString("ContractSat", "0");
                        writer.WriteStartElement("Attributes");
                        {
                            writer.WriteElementString("Height", "180");
                            writer.WriteElementString("Weight", "80");
                            writer.WriteElementString("ManMarking", "50");
                            writer.WriteElementString("VerticalLeap", "50");
                            writer.WriteElementString("Tenacity", "50");
                            writer.WriteElementString("Skill", "50");
                            writer.WriteElementString("Agility", "50");
                            writer.WriteElementString("Courage", "50");
                            writer.WriteElementString("Aggression", "50");
                            writer.WriteElementString("XFactor", "50");
                            writer.WriteElementString("StrengthGroundLevel", "50");
                            writer.WriteElementString("StrengthOverhead", "50");
                            writer.WriteElementString("StrengthManOnMan", "50");
                            writer.WriteElementString("Acceleration", "50");
                            writer.WriteElementString("Speed", "50");
                            writer.WriteElementString("Endurance", "50");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hidden");
                        {
                            writer.WriteElementString("Confidence", "50");
                            writer.WriteElementString("ReadPlay", "50");
                            writer.WriteElementString("Consistancy", "50");
                            writer.WriteElementString("Positioning", "50");
                            writer.WriteElementString("CopeWithPressure", "50");
                            writer.WriteElementString("PotentialTall", "50");
                            writer.WriteElementString("PotentialMid", "50");
                            writer.WriteElementString("KickMaxDistance", "50");
                            writer.WriteElementString("DisciplineMatch", "50");
                            writer.WriteElementString("DisciplineTraining", "50");
                            writer.WriteElementString("DisciplineOffField", "50");
                            writer.WriteElementString("UmpireLikes", "50");
                            writer.WriteElementString("UmpireNotice", "50");
                            writer.WriteElementString("GoHomeTend", "50");
                            writer.WriteElementString("InjuryTend", "50");
                            writer.WriteElementString("LoyaltyTend", "50");
                            writer.WriteElementString("ClangerTend", "50");
                            writer.WriteElementString("Leadership", "50");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Improvement");
                        {
                            writer.WriteElementString("MarkLead", "0");
                            writer.WriteElementString("MarkContested", "0");
                            writer.WriteElementString("SpoilContested", "0");
                            writer.WriteElementString("SpoilLead", "0");
                            writer.WriteElementString("Evasion", "0");
                            writer.WriteElementString("CatchPlayer", "0");
                            writer.WriteElementString("Tackle", "0");
                            writer.WriteElementString("Ruck", "0");
                            writer.WriteElementString("GoalSet", "0");
                            writer.WriteElementString("GoalRun", "0");
                            writer.WriteElementString("HardBallGets", "0");
                            writer.WriteElementString("HandsInClose", "0");
                            writer.WriteElementString("Clearance", "0");
                            writer.WriteElementString("GetToContest", "0");
                            writer.WriteElementString("FootSkills", "0");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Degradation");
                        {
                            writer.WriteElementString("MarkLead", "0");
                            writer.WriteElementString("MarkContested", "0");
                            writer.WriteElementString("SpoilContested", "0");
                            writer.WriteElementString("SpoilLead", "0");
                            writer.WriteElementString("Evasion", "0");
                            writer.WriteElementString("CatchPlayer", "0");
                            writer.WriteElementString("Tackle", "0");
                            writer.WriteElementString("Ruck", "0");
                            writer.WriteElementString("GoalSet", "0");
                            writer.WriteElementString("GoalRun", "0");
                            writer.WriteElementString("HardBallGets", "0");
                            writer.WriteElementString("HandsInClose", "0");
                            writer.WriteElementString("Clearance", "0");
                            writer.WriteElementString("GetToContest", "0");
                            writer.WriteElementString("FootSkills", "0");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Injuries");
                        {
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Reports");
                        {
                            writer.WriteStartElement("ReportHistoryID");
                            {
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("PointsCarriedForward", "0");
                            writer.WriteStartElement("PointsCarriedForwardExpiry");
                            {
                                writer.WriteElementString("Day", "1");
                                writer.WriteElementString("Month", "1");
                                writer.WriteElementString("Year", "1");
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("MatchesToMiss", "0");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Contract");
                        {
                            writer.WriteStartElement("AFLcontractID");
                            {
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("PlayerID");
                            {
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("ClubID", "");
                            writer.WriteElementString("TotalValue", Form1.defaultBaseSalary + "");
                            writer.WriteStartElement("DateSigned");
                            {
                                writer.WriteElementString("Day", "2");
                                writer.WriteElementString("Month", "1");
                                writer.WriteElementString("Year", "2011");
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("DateExpired");
                            {
                                writer.WriteElementString("Day", "22");
                                writer.WriteElementString("Month", "11");
                                writer.WriteElementString("Year", "2011");
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("HasRequestedTrade", "False");
                            writer.WriteElementString("RequestedTradeState", "0");
                            writer.WriteStartElement("RequestedTradeClubID");
                            {
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("RequestedTradeReason");
                            {
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("ContractType", "1");
                            writer.WriteElementString("Loading", "100");
                            writer.WriteElementString("JumperNumber", "");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("RatingHistory");
                        {
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Training");
                        {
                            writer.WriteElementString("TrainingGroup", "3");
                            writer.WriteStartElement("SpecialistID");
                            {
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("SpecialistSkill", "0");
                            writer.WriteElementString("TrainingIntensity", "0");
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("AFLcareer");
                        {
                            writer.WriteElementString("ClubID", "");
                            writer.WriteStartElement("DraftPick");
                            {
                                writer.WriteElementString("Pick", "64");
                                writer.WriteElementString("Year", "2010");
                                writer.WriteElementString("DraftType", "1");
                                writer.WriteElementString("ClubID", "");
                                writer.WriteElementString("DrafteeID", "");
                            }
                            writer.WriteEndElement();
                            writer.WriteElementString("Games", "0");
                            writer.WriteElementString("Goals", "0");
                            writer.WriteElementString("Behinds", "0");
                            writer.WriteElementString("Clearances", "0");
                            writer.WriteElementString("HBalls", "0");
                            writer.WriteElementString("HardBallGets", "0");
                            writer.WriteElementString("HitOuts", "0");
                            writer.WriteElementString("Kicks", "0");
                            writer.WriteElementString("Marks", "0");
                            writer.WriteElementString("Opp", "0");
                            writer.WriteElementString("Spoils", "0");
                            writer.WriteElementString("Tackles", "0");
                            writer.WriteElementString("FreeFor", "0");
                            writer.WriteElementString("FreeAgainst", "0");
                            writer.WriteElementString("Clangers", "0");
                            writer.WriteElementString("Rebounds", "0");
                            writer.WriteElementString("InsideFifty", "0");
                            writer.WriteElementString("Rating", "10.00");
                            writer.WriteElementString("ContestedMarks", "0");
                            writer.WriteElementString("UncontestedMarks", "0");
                            writer.WriteStartElement("Seasons");
                            {
                                writer.WriteStartElement("Season");
                                {
                                    writer.WriteElementString("Year", "2011");
                                    writer.WriteElementString("Club", "");
                                    writer.WriteElementString("nfImpPuff", "False");
                                    writer.WriteElementString("nfDrftPuff", "False");
                                    writer.WriteElementString("Games", "0");
                                    writer.WriteElementString("Goals", "0");
                                    writer.WriteElementString("Behinds", "0");
                                    writer.WriteElementString("Clearances", "0");
                                    writer.WriteElementString("HBalls", "0");
                                    writer.WriteElementString("HardBallGets", "0");
                                    writer.WriteElementString("HitOuts", "0");
                                    writer.WriteElementString("Kicks", "0");
                                    writer.WriteElementString("Marks", "0");
                                    writer.WriteElementString("Opp", "0");
                                    writer.WriteElementString("Spoils", "0");
                                    writer.WriteElementString("Tackles", "0");
                                    writer.WriteElementString("FreeFor", "0");
                                    writer.WriteElementString("FreeAgainst", "0");
                                    writer.WriteElementString("Clangers", "0");
                                    writer.WriteElementString("Rebounds", "0");
                                    writer.WriteElementString("InsideFifty", "0");
                                    writer.WriteElementString("Rating", "10.00");
                                    writer.WriteElementString("ContestedMarks", "0");
                                    writer.WriteElementString("UncontestedMarks", "0");
                                    
                                }
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.WriteStartElement("Chemistry");
                        {
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndDocument();
            }

            return player;
        }

        public void updateDate()
        {
            if (int.Parse(this.age_month) == 2 && int.Parse(this.age_day) > 27) this.age_day = "27";
            this.age = (new DateTime(2011,4,30) - new DateTime(int.Parse(this.age_year), int.Parse(this.age_month), int.Parse(this.age_day))).TotalDays/365.25;
        }

        public void setClub(Club club)
        {
            this.club = club;

            // Contract
            this.clubID = club.clubID;
        }

        public void changeClub(Club club, int newJumperNumber)
        {
            this.club = club;

            // Contract
            this.clubID = club.clubID;
            this.jumperNumber = newJumperNumber.ToString();
        }

        public static int Compare(Player x, Player y)
        {
            if (x.club.name.Equals(y.club.name))
            {
                return String.Compare(x.lname, y.lname);
                //return String.Compare(x.totalValue, y.totalValue);
            }
            else
            {
                return String.Compare(x.club.name, y.club.name);
            }
        }

        public bool SameAs(Player player)
        {
            bool equal = true;

            if (equal == true) { equal = player.xmlFileName.Equals(this.xmlFileName); }
            if (equal == true) { equal = player.playerID.Equals(this.playerID); }
            if (equal == true) { equal = player.fname.Equals(this.fname); }
            if (equal == true) { equal = player.lname.Equals(this.lname); }
            if (equal == true) { equal = player.homeState.Equals(this.homeState); }
            if (equal == true) { equal = player.condition.Equals(this.condition); }

            // DOB
            if (equal == true) { equal = player.age_day.Equals(this.age_day); }
            if (equal == true) { equal = player.age_month.Equals(this.age_month); }
            if (equal == true) { equal = player.age_year.Equals(this.age_year); }

            // Attributes
            if (equal == true) { equal = player.height.Equals(this.height); }
            if (equal == true) { equal = player.weight.Equals(this.weight); }
            if (equal == true) { equal = player.manMarking.Equals(this.manMarking); }
            if (equal == true) { equal = player.verticalLeap.Equals(this.verticalLeap); }
            if (equal == true) { equal = player.tenacity.Equals(this.tenacity); }
            if (equal == true) { equal = player.skill.Equals(this.skill); }
            if (equal == true) { equal = player.agility.Equals(this.agility); }
            if (equal == true) { equal = player.courage.Equals(this.courage); }
            if (equal == true) { equal = player.aggression.Equals(this.aggression); }
            if (equal == true) { equal = player.xFactor.Equals(this.xFactor); }
            if (equal == true) { equal = player.strengthGroundLevel.Equals(this.strengthGroundLevel); }
            if (equal == true) { equal = player.strengthOverhead.Equals(this.strengthOverhead); }
            if (equal == true) { equal = player.strengthManOnMan.Equals(this.strengthManOnMan); }
            if (equal == true) { equal = player.acceleration.Equals(this.acceleration); }
            if (equal == true) { equal = player.speed.Equals(this.speed); }
            if (equal == true) { equal = player.endurance.Equals(this.endurance); }

            // Hidden
            if (equal == true) { equal = player.confidence.Equals(this.confidence); }
            if (equal == true) { equal = player.readPlay.Equals(this.readPlay); }
            if (equal == true) { equal = player.consistancy.Equals(this.consistancy); }
            if (equal == true) { equal = player.positioning.Equals(this.positioning); }
            if (equal == true) { equal = player.copeWithPressure.Equals(this.copeWithPressure); }
            if (equal == true) { equal = player.potentialTall.Equals(this.potentialTall); }
            if (equal == true) { equal = player.potentialMid.Equals(this.potentialMid); }
            if (equal == true) { equal = player.kickMaxDistance.Equals(this.kickMaxDistance); }
            if (equal == true) { equal = player.disciplineMatch.Equals(this.disciplineMatch); }
            if (equal == true) { equal = player.disciplineTraining.Equals(this.disciplineTraining); }
            if (equal == true) { equal = player.disciplineOffField.Equals(this.disciplineOffField); }
            if (equal == true) { equal = player.umpireLikes.Equals(this.umpireLikes); }
            if (equal == true) { equal = player.umpireNotice.Equals(this.umpireNotice); }
            if (equal == true) { equal = player.goHomeTend.Equals(this.goHomeTend); }
            if (equal == true) { equal = player.injuryTend.Equals(this.injuryTend); }
            if (equal == true) { equal = player.loyaltyTend.Equals(this.loyaltyTend); }
            if (equal == true) { equal = player.clangerTend.Equals(this.clangerTend); }
            if (equal == true) { equal = player.leadership.Equals(this.leadership); }

            // Improvement
            if(equal==true) { equal = player.imp_markLead.Equals(this.imp_markLead); }
            if(equal==true) { equal = player.imp_markContested.Equals(this.imp_markContested); }
            if(equal==true) { equal = player.imp_spoilContested.Equals(this.imp_spoilContested); }
            if(equal==true) { equal = player.imp_spoilLead.Equals(this.imp_spoilLead); }
            if(equal==true) { equal = player.imp_evasion.Equals(this.imp_evasion); }
            if(equal==true) { equal = player.imp_catchPlayer.Equals(this.imp_catchPlayer); }
            if(equal==true) { equal = player.imp_tackle.Equals(this.imp_tackle); }
            if(equal==true) { equal = player.imp_ruck.Equals(this.imp_ruck); }
            if(equal==true) { equal = player.imp_goalSet.Equals(this.imp_goalSet); }
            if(equal==true) { equal = player.imp_goalRun.Equals(this.imp_goalRun); }
            if(equal==true) { equal = player.imp_hardBallGets.Equals(this.imp_hardBallGets); }
            if(equal==true) { equal = player.imp_handsInClose.Equals(this.imp_handsInClose); }
            if(equal==true) { equal = player.imp_clearance.Equals(this.imp_clearance); }
            if(equal==true) { equal = player.imp_getToContest.Equals(this.imp_getToContest); }
            if(equal==true) { equal = player.imp_footSkills.Equals(this.imp_footSkills); }

            // Degradation
            if (equal == true) { equal = player.deg_markLead.Equals(this.deg_markLead); }
            if (equal == true) { equal = player.deg_markContested.Equals(this.deg_markContested); }
            if (equal == true) { equal = player.deg_spoilContested.Equals(this.deg_spoilContested); }
            if (equal == true) { equal = player.deg_spoilLead.Equals(this.deg_spoilLead); }
            if (equal == true) { equal = player.deg_evasion.Equals(this.deg_evasion); }
            if (equal == true) { equal = player.deg_catchPlayer.Equals(this.deg_catchPlayer); }
            if (equal == true) { equal = player.deg_tackle.Equals(this.deg_tackle); }
            if (equal == true) { equal = player.deg_ruck.Equals(this.deg_ruck); }
            if (equal == true) { equal = player.deg_goalSet.Equals(this.deg_goalSet); }
            if (equal == true) { equal = player.deg_goalRun.Equals(this.deg_goalRun); }
            if (equal == true) { equal = player.deg_hardBallGets.Equals(this.deg_hardBallGets); }
            if (equal == true) { equal = player.deg_handsInClose.Equals(this.deg_handsInClose); }
            if (equal == true) { equal = player.deg_clearance.Equals(this.deg_clearance); }
            if (equal == true) { equal = player.deg_getToContest.Equals(this.deg_getToContest); }
            if (equal == true) { equal = player.deg_footSkills.Equals(this.deg_footSkills); }

            // Contract
            if (equal == true) { equal = player.clubID.Equals(this.clubID); }
            if (equal == true) { equal = player.totalValue.Equals(this.totalValue); }
            if (equal == true) { equal = player.jumperNumber.Equals(this.jumperNumber); }
            // DateSigned
            if (equal == true) { equal = player.signed_day.Equals(this.signed_day); }
            if (equal == true) { equal = player.signed_month.Equals(this.signed_month); }
            if (equal == true) { equal = player.signed_year.Equals(this.signed_year); }
            // DateExpired
            if (equal == true) { equal = player.expired_day.Equals(this.expired_day); }
            if (equal == true) { equal = player.expired_month.Equals(this.expired_month); }
            if (equal == true) { equal = player.expired_year.Equals(this.expired_year); }


            // AFLcareer
            // DraftPick
            if (equal == true) { equal = player.draft_pick.Equals(this.draft_pick); }
            if (equal == true) { equal = player.draft_year.Equals(this.draft_year); }
            if (equal == true) { equal = player.draft_draftType.Equals(this.draft_draftType); }


            if (equal == false)
            {
                Console.WriteLine(player.fname + " " + player.lname);
            }

            return equal;
        }
    }
}
