using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Google.Cloud.Translation.V2;
using Google.Cloud.Translate.V3;

namespace XmlRDR
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //go to xml files folder and read them all 
            var xmlfiles = Directory.GetFiles(@"C:\Users\Patryk\Desktop\Oferty Pracy\Pobrane Oferty\XML\translate", "*.xml", SearchOption.AllDirectories);
            foreach (var file in xmlfiles)
            {
                //loading data from xml file
                XmlDocument document = new XmlDocument();
                document.Load(file);
                
                XmlNodeList nodeList = document.SelectNodes("//SzczegolyOferty");

                
                foreach (XmlNode node in nodeList)
                {
                    //the name of the professionproffesion
                    XmlNode professionText = node.SelectSingleNode("nazwaStanowiska");
                    //other data
                    XmlNode dateAddedText = node.SelectSingleNode("//pozostaleDane/dataDodaniaOferty");
                    XmlNode expirationDateText = node.SelectSingleNode("//pozostaleDane/ofertaWaznaDo");
                    //working conditions
                    XmlNode salaryText = node.SelectSingleNode("//warunkiPracyIPlacy/wynagrodzenieBrutto"); 
                    XmlNode weekHoursText = node.SelectSingleNode("//warunkiPracyIPlacy/lGodzinWTygodniu");
                    XmlNode startDateText = node.SelectSingleNode("//warunkiPracyIPlacy/dataRozpoczeciaPracy");
                    XmlNode mjp = node.SelectSingleNode("//warunkiPracyIPlacy/miejscePracy");
                    XmlNode typeOfContractText = node.SelectSingleNode("//warunkiPracyIPlacy/rodzajUmowy");
                    XmlNode responsibilitiesText = node.SelectSingleNode("//warunkiPracyIPlacy/zakresObowiazkow");
                    XmlNode workSystmText = node.SelectSingleNode("//warunkiPracyIPlacy/zmianowosc");
                    XmlNode monthHoursText = node.SelectSingleNode("//warunkiPracyIPlacy/lGodzinWMiesiacu");
                    XmlNode transportToPlText = node.SelectSingleNode("//warunkiPracyIPlacy/kosztPrzejDoPolski");
                    XmlNode workFromNowText = node.SelectSingleNode("//warunkiPracyIPlacy/zatrOdZaraz");
                    XmlNode mealsText = node.SelectSingleNode("//warunkiPracyIPlacy/wyzywienie");
                    XmlNode accommodationText = node.SelectSingleNode("//warunkiPracyIPlacy/zakwaterowanie");
                    //requirements
                    XmlNode additionalRequirementsText = node.SelectSingleNode("//wymagania/inneWymagania");
                    XmlNode educationText = node.SelectSingleNode("//wymagania/wymaganiaKonieczne/wyksztalcenia");
                    //employer's data
                    XmlNode employerText = node.SelectSingleNode("//danePracodawcy/pracodawca");
                    XmlNode contactPersonText = node.SelectSingleNode("//danePracodawcy/osobaDoKontaktu");
                    XmlNode telNumberText = node.SelectSingleNode("//danePracodawcy/nrTelefonu");
                    XmlNode employerAddressText = node.SelectSingleNode("//danePracodawcy/adres");
                    XmlNode applicationMethodText = node.SelectSingleNode("//danePracodawcy/sposobAplikowania");
                    XmlNode applicationMethodText2 = node.SelectSingleNode("//danePracodawcy/sposobPrzekazaniaDok");
                    XmlNode requiredDocumentsText = node.SelectSingleNode("//danePracodawcy/wymaganeDokumenty");
                    XmlNode email = node.SelectSingleNode("//danePracodawcy/email");
                    XmlNode webSite = node.SelectSingleNode("//danePracodawcy/adresWww");

                    //translate to Ukrainian language
                    TranslationClient client = TranslationClient.CreateFromApiKey("AIzaSyA9VrzGzDZGS2BB-Jf9yObeHN_urz-2ZhE");
                    TranslationResult professionUAText = client.TranslateText(professionText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult typeOfContractUAText = client.TranslateText(typeOfContractText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult responsibilitiesUAText = client.TranslateText(responsibilitiesText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult workSystmUAText = client.TranslateText(workSystmText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult salaryUAText = client.TranslateText(salaryText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult educationUAText = client.TranslateText(educationText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult additionalRequirementUAText = client.TranslateText(additionalRequirementsText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult applicationMethodUAText = client.TranslateText(applicationMethodText?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult applicationMethodUAText2 = client.TranslateText(applicationMethodText2?.InnerText, LanguageCodes.Ukrainian);
                    TranslationResult requiredDocumentsUAText = client.TranslateText(requiredDocumentsText?.InnerText, LanguageCodes.Ukrainian);

                    //create a tample
                    string[] templateText =
                    { 
                        $"{professionUAText.TranslatedText} / {professionText?.InnerText}",
                        "",
                        $"Управління праці в Познані пропонує роботу на позиції : {professionUAText.TranslatedText}.",
                        $"Ця реклама була створена на {dateAddedText?.InnerText}  і буде дійсною для  {expirationDateText?.InnerText}.",
                        $"Початок роботи на цій посаді було призначено : {startDateText?.InnerText}.",
                        $"Тип договору : {typeOfContractUAText.TranslatedText}.",
                        $"Обсяг обов'язків у заданій позиції буде, {responsibilitiesUAText.TranslatedText}.",
                        $"Робота в системі : {workSystmUAText.TranslatedText}.",
                        $"Працюючи в цій позиції, ви зможете розраховувати на винагороду {salaryUAText.TranslatedText}.",
                        $"Робота в вимірі {weekHoursText?.InnerText} години на тиждень та {monthHoursText?.InnerText} години на місяць.",
                        $"РРоботодавець покриває вартість проїзду до Польщі : HE",
                        $"Зайняття негайно : HE",
                        $"Забезпечення проживання : HE",
                        $"Забезпечення їжі : HE",
                        $"Необхідна освіта : {educationUAText.TranslatedText}",
                        $"Додаткові вимоги: {additionalRequirementUAText.TranslatedText}.",
                        $"Спосіб застосування : {applicationMethodUAText.TranslatedText} , {applicationMethodUAText2.TranslatedText}",
                        $"Необхідні документи : {requiredDocumentsUAText.TranslatedText}",
                        "",
                        $"Ми запрошуємо вас взяти участь у цьому наборі",
                        "",
                        $"Urząd pracy w Poznaniu oferuje pracę na stanowisku : {professionText?.InnerText}.",
                        $"To ogłoszenie zostało utworzone w dniu {dateAddedText?.InnerText} i będzie ważne do {expirationDateText?.InnerText}.",
                        $"Rozpoczęcie pracy na tym stanowisku zostało wyznaczone na : {startDateText?.InnerText}.",
                        $"Rodzaj umowy : {typeOfContractText?.InnerText}.",
                        $"Zakresem obowiązków na podanym stanowisku będzie, {responsibilitiesText?.InnerText}.",
                        $"Praca w systemie : {workSystmText?.InnerText}.",
                        $"Pracując na tym stanowisku, będziesz mógł liczyć na wynagrodzenie na poziomie {salaryText?.InnerText}.",
                        $"Praca w wymiarze {weekHoursText?.InnerText} godzin tygodniowo i {monthHoursText?.InnerText} godzin miesięcznie.",
                        $"Pracodawca pokrywa koszt przejazdu do Polski : {transportToPlText?.InnerText}",
                        $"Zatrudnienie od zaraz: {workFromNowText?.InnerText}",
                        $"Zapewnienie zakwaterowania : {accommodationText?.InnerText}",
                        $"Zapewnienie wyżywienia : {mealsText?.InnerText}",
                        $"Wymagane wykształcenie : {educationText?.InnerText}",
                        $"Wymagania dodatkowe: {additionalRequirementsText?.InnerText}.",
                        $"Sposób aplikowania : {applicationMethodText?.InnerText} , {applicationMethodText2?.InnerText}",
                        $"Wymagane dokumenty : {requiredDocumentsText?.InnerText}",
                        "",
                        $"Zapraszamy do udziału w tej rekrutacji.",
                        "",
                        $"Ім'я роботодавця / Nazwa Pracodawcy : {employerText?.InnerText},",
                        $"контактна особа  / osoba do kontaktu : {contactPersonText?.InnerText},",
                        $"Номер телефону / nr tel.: {telNumberText?.InnerText},",
                        $"адреса / adres : {employerAddressText?.InnerText},",
                        $"email: {email?.InnerText},",
                        $"www: {webSite?.InnerText}.",
                    };

                    string offersFolder = @"C:\Users\Patryk\Desktop\Oferty Pracy\Pobrane Oferty\TXT\translate";
                    if (!Directory.Exists(offersFolder))
                        Directory.CreateDirectory(offersFolder);

                    if (!offersFolder.EndsWith("\\"))
                        offersFolder += "\\";

                    string fileName = offersFolder + Guid.NewGuid().ToString() + ".txt";
                    while (File.Exists(fileName))
                        fileName = offersFolder + Guid.NewGuid().ToString() + ".txt";

                    TextWriter writer = null;
                    try
                    {
                        File.WriteAllLinesAsync(Path.Combine(offersFolder, fileName), templateText);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception occured: " + e.ToString());
                    }
                    finally
                    {
                        if (writer != null)
                            writer.Close();
                    }
                }
                
            }
        }    
        
    }
}
