using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml;

namespace XmlRDR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Patryk\Desktop\Oferty Pracy\oferta_pracy_SPRZEDAWCA.xml");

            XmlNodeList nodes = doc.SelectNodes("//SzczegolyOferty/danePracodawcy");

            foreach (XmlNode node in nodes)
            {
                XmlNode adres = node.SelectSingleNode("adres");
                if (adres != null)
                {
                    Console.WriteLine(@"Adres:" + adres.InnerText);
                }

                XmlNode jezykAplikacji = node.SelectSingleNode("jezykAplikacji");
                if (jezykAplikacji != null)
                {
                    Console.WriteLine(@"Język Aplikacji:" + jezykAplikacji.InnerText);
                }
            } 
        }    
    
    }
}
