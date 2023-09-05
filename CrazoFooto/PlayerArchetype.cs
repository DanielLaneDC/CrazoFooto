using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Archetype { BackPocket, BackFlank, Wing, Center, Rover, RuckRover, Ruck, ForwardPocketTall, ForwardPocketSmall, FullForward, CenterHalfForward, ForwardFlank }

namespace CrazoFooto
{

    class PlayerArchetype
    {
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

        private int generateAttribute(float ability, int idealMin, int variance)
        {
            return (int)(((idealMin/(float)0.8) * ability) + Form1.random.Next(0, 15));
        }

        public PlayerArchetype(Archetype type)
        {
            float ability = (Form1.random.Next(80, 100) / 100);

            switch (type)
            {
                case Archetype.BackPocket:
                    height = Form1.random.Next(170, 188).ToString();
                    weight = Form1.random.Next(70, 100).ToString();
                    manMarking = generateAttribute(ability, 70, 15).ToString();
                    verticalLeap = generateAttribute(ability, 10, 15).ToString();
                    tenacity = generateAttribute(ability, 30, 20).ToString();
                    skill = generateAttribute(ability, 30, 30).ToString();
                    agility = generateAttribute(ability, 40, 15).ToString();
                    courage = Form1.random.Next(0, 100).ToString();
                    aggression = Form1.random.Next(0, 100).ToString();
                    xFactor = Form1.random.Next(0, 100).ToString();
                    strengthGroundLevel = generateAttribute(ability, 40, 15).ToString();
                    strengthOverhead = generateAttribute(ability, 10, 15).ToString();
                    strengthManOnMan = generateAttribute(ability, 35, 15).ToString();
                    acceleration = generateAttribute(ability, 40, 15).ToString();
                    speed = generateAttribute(ability, 30, 15).ToString();
                    endurance = generateAttribute(ability, 15, 40).ToString();
                    confidence = Form1.random.Next(0, 100).ToString();
                    readPlay = generateAttribute(ability, 40, 15).ToString();
                    consistancy = Form1.random.Next(0, 100).ToString();
                    positioning = generateAttribute(ability, 25, 15).ToString();
                    copeWithPressure = Form1.random.Next(0, 100).ToString();
                    potentialTall = generateAttribute(ability, 10, 15).ToString();
                    potentialMid = generateAttribute(ability, 25, 15).ToString();
                    kickMaxDistance = generateAttribute(ability, 45, 15).ToString();
                    disciplineMatch = Form1.random.Next(0, 100).ToString();
                    disciplineTraining = Form1.random.Next(0, 100).ToString();
                    disciplineOffField = Form1.random.Next(0, 100).ToString();
                    umpireLikes = Form1.random.Next(0, 100).ToString();
                    umpireNotice = Form1.random.Next(0, 100).ToString();
                    goHomeTend = Form1.random.Next(0, 100).ToString();
                    injuryTend = Form1.random.Next(0, 100).ToString();
                    loyaltyTend = Form1.random.Next(0, 100).ToString();
                    clangerTend = Form1.random.Next(0, 100).ToString();
                    leadership = Form1.random.Next(0, 100).ToString();
                    break;
                case Archetype.BackFlank:
                    height = Form1.random.Next(170, 188).ToString();
                    weight = Form1.random.Next(70, 100).ToString();
                    manMarking = generateAttribute(ability, 70, 15).ToString();
                    verticalLeap = generateAttribute(ability, 10, 15).ToString();
                    tenacity = generateAttribute(ability, 30, 20).ToString();
                    skill = generateAttribute(ability, 30, 30).ToString();
                    agility = generateAttribute(ability, 40, 15).ToString();
                    courage = Form1.random.Next(0, 100).ToString();
                    aggression = Form1.random.Next(0, 100).ToString();
                    xFactor = Form1.random.Next(0, 100).ToString();
                    strengthGroundLevel = generateAttribute(ability, 40, 15).ToString();
                    strengthOverhead = generateAttribute(ability, 10, 15).ToString();
                    strengthManOnMan = generateAttribute(ability, 35, 15).ToString();
                    acceleration = generateAttribute(ability, 40, 15).ToString();
                    speed = generateAttribute(ability, 30, 15).ToString();
                    endurance = generateAttribute(ability, 15, 40).ToString();
                    confidence = Form1.random.Next(0, 100).ToString();
                    readPlay = generateAttribute(ability, 40, 15).ToString();
                    consistancy = Form1.random.Next(0, 100).ToString();
                    positioning = generateAttribute(ability, 25, 15).ToString();
                    copeWithPressure = Form1.random.Next(0, 100).ToString();
                    potentialTall = generateAttribute(ability, 10, 15).ToString();
                    potentialMid = generateAttribute(ability, 25, 15).ToString();
                    kickMaxDistance = generateAttribute(ability, 45, 15).ToString();
                    disciplineMatch = Form1.random.Next(0, 100).ToString();
                    disciplineTraining = Form1.random.Next(0, 100).ToString();
                    disciplineOffField = Form1.random.Next(0, 100).ToString();
                    umpireLikes = Form1.random.Next(0, 100).ToString();
                    umpireNotice = Form1.random.Next(0, 100).ToString();
                    goHomeTend = Form1.random.Next(0, 100).ToString();
                    injuryTend = Form1.random.Next(0, 100).ToString();
                    loyaltyTend = Form1.random.Next(0, 100).ToString();
                    clangerTend = Form1.random.Next(0, 100).ToString();
                    leadership = Form1.random.Next(0, 100).ToString();
                    break;
            }
        }
    }
}
