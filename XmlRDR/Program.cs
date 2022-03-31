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
                XmlNode owd = node.SelectSingleNode("//pozostaleDane/ofertaWaznaDo");

                XmlNode zar = node.SelectSingleNode("//warunkiPracyIPlacy/wynagrodzenieBrutto");
                XmlNode gdt = node.SelectSingleNode("//warunkiPracyIPlacy/lGodzinWTygodniu");
                XmlNode drp = node.SelectSingleNode("//warunkiPracyIPlacy/dataRozpoczeciaPracy");
                XmlNode mjp = node.SelectSingleNode("//warunkiPracyIPlacy/miejscePracy");
                XmlNode rdu = node.SelectSingleNode("//warunkiPracyIPlacy/rodzajUmowy");
                XmlNode zko = node.SelectSingleNode("//warunkiPracyIPlacy/zakresObowiazkow");
                XmlNode zmn = node.SelectSingleNode("//warunkiPracyIPlacy/zmianowosc");
                XmlNode gdm = node.SelectSingleNode("//warunkiPracyIPlacy/lGodzinWMiesiacu");
                XmlNode kpp = node.SelectSingleNode("//warunkiPracyIPlacy/kosztPrzejDoPolski");
                XmlNode zoz = node.SelectSingleNode("//warunkiPracyIPlacy/zatrOdZaraz");
                XmlNode wyz = node.SelectSingleNode("//warunkiPracyIPlacy/wyzywienie");
                XmlNode zak = node.SelectSingleNode("//warunkiPracyIPlacy/zakwaterowanie");
                XmlNode inw = node.SelectSingleNode("//wymagania/inneWymagania");
                XmlNode wyk = node.SelectSingleNode("//wymagania/wymaganiaKonieczne/wyksztalcenia");

                XmlNode prc = node.SelectSingleNode("//danePracodawcy/pracodawca");
                XmlNode odk = node.SelectSingleNode("//danePracodawcy/osobaDoKontaktu");
                XmlNode nrt = node.SelectSingleNode("//danePracodawcy/nrTelefonu");
                XmlNode adr = node.SelectSingleNode("//danePracodawcy/adres");
                XmlNode spa = node.SelectSingleNode("//danePracodawcy/sposobAplikowania");
                XmlNode app = node.SelectSingleNode("//danePracodawcy/sposobPrzekazaniaDok");
                XmlNode wmd = node.SelectSingleNode("//danePracodawcy/wymaganeDokumenty");

                var template = $"Urząd pracy w Pile oferuje pracę na stanowisku {naz.InnerText}. " +
                    $"To ogłoeszenie zostało utworzone w dniu {ddo.InnerText} i bedzie ważne do {owd.InnerText}. " +
                    $"Rozpoczęcie pracy na tym stanowisku zacznie się w dniu {drp.InnerText} w miejscowości {mjp.InnerText}. " +
                    $"Rodzaj umowy : {rdu.InnerText}. Zakresem obowiązków na podanym stanowisku będzie {zko.InnerText}. " +
                    $"Praca w systemie {zmn.InnerText}. " +
                    $"Pracując na tym stanowisku, będziesz mógł liczyć na wynagrodzenie na poziomie {zar.InnerText} na miesiąc. " +
                    $"Zapraszamy do udziału w tej rekrutacji, jeśli jesteś dostępny {gdt.InnerText} godzin tygodniowo. i {gdm.InnerText} miesięcznie. " +
                    $"Pracodawca pokrywa koszt przejazdu do Polski : {kpp.InnerText}. Zatrudnienie od zaraz: {zoz.InnerText}. " +
                    $"Zapeniwnie wyżywienia : {wyz.InnerText}. Zapewnienie zakwaterowania : {zak.InnerText}. " +
                    $"Wymagania : {inw.InnerText}. Wymagane wykształcenie : {wyk.InnerText}. " +
                    $"Nazwa Pracodawcy : {prc.InnerText} {odk.InnerText} nr tel : {nrt.InnerText} adres : {adr.InnerText}. Sposób aplikoweania : " +
                    $"{spa.InnerText}. {app.InnerText}. Wymagane dokumenty : {wmd.InnerText}." ;
                
                Console.WriteLine(template);
            }

            
        }    
        
    }
}
