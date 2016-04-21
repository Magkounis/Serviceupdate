using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace Service1
{
    class Readfromxml
    {

        public string hour;
        public string minutes;
        public string mode;
        
       public Readfromxml(string namexml)
        {
           
                XmlDocument doc = new XmlDocument();
                doc.Load(namexml);
                XmlNode node = doc.DocumentElement.SelectSingleNode("hour");
                hour = node.InnerText;
                XmlNode node2 = doc.DocumentElement.SelectSingleNode("minutes");
                minutes = node2.InnerText;
                XmlNode node3 = doc.DocumentElement.SelectSingleNode("mode");
                mode = node3.InnerText;
                doc = null;
                node = null;
           
            




        }







    }
}
