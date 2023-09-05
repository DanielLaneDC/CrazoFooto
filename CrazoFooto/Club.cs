using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CrazoFooto
{
    public class Club
    {
        public XmlDocument originalDocument { get; set; }

        public String xmlFileName { get; set; }
        public String name { get; set; }
        public String clubID { get; set; }

        public Club(XmlNode node, String filePath, XmlDocument originalDocument)
        {
            this.originalDocument = originalDocument;

            this.xmlFileName = filePath;
            this.name = node.SelectSingleNode("Name").InnerText;
            this.clubID = node.SelectSingleNode("ID").InnerText;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
