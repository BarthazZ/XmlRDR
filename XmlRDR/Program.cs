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
            doc.Load(@"C:\Users\Patryk\Desktop\Oferty Pracy\oferta_pracy_SPRZEDAWCAOsiek.xml");

            XmlNodeList nazwaSt = doc.SelectNodes("//SzczegolyOferty");
            

            foreach (XmlNode node in nazwaSt)
            {
                XmlNode naz = node.SelectSingleNode("nazwaStanowiska");
                XmlNode ddo = node.SelectSingleNode("//pozostaleDane/dataDodaniaOferty");
                XmlNode zar = node.SelectSingleNode("//warunkiPracyIPlacy/wynagrodzenieBrutto");
                XmlNode gdt = node.SelectSingleNode("//warunkiPracyIPlacy/lGodzinWTygodniu");

                var template = $"Urząd pracy w Pile oferuje pracę na stanowisku {naz.InnerText}. " +
                    $"To ogłoeszenie zostało utworzone w dniu {ddo.InnerText}. " +
                    $"Pracując na tym stanowisku, będziesz mógł liczyć na wynagrodzenie na poziomie {zar.InnerText} na miesiąc. " +
                    $" Zapraszamy do udziału w tej rekrutacji, jeśli jesteś dostępny {gdt.InnerText} godzin tygodniowo." ;

                Console.WriteLine(template);
            }

            
        }    
        
    }
}
