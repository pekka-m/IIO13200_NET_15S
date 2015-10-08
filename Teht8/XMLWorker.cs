using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Teht8
{
    public static class XMLWorker
    {
        public static void TeeXMLTiedosto()
        {
            string xmlFile = Properties.Settings.Default.PalauteXML;
            XmlDocument doc = new XmlDocument();
            XmlNode version = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(version);
            XmlNode rootNode = doc.CreateElement("palautteet");
            doc.AppendChild(rootNode);
            doc.Save(xmlFile);
        }
        public static void TallennaPalaute(string _tekija, string _opittu, string _haluanoppia, string _hyvaa, string _parannettavaa, string _muuta)
        {
            if (_tekija.Length != 0 && _opittu.Length != 0 && _haluanoppia.Length != 0 && _hyvaa.Length != 0 && _parannettavaa.Length != 0)
            {
                string xmlFile = Properties.Settings.Default.PalauteXML;
                XmlDocument doc = new XmlDocument();

                doc.Load(xmlFile);

                XmlElement palaute = doc.CreateElement("palaute");
                doc.DocumentElement.AppendChild(palaute);

                XmlElement Xmlpvm = doc.CreateElement("pvm");
                DateTime pvm = DateTime.Today.Date;
                Xmlpvm.InnerText = pvm.ToString("yyyyMMdd");
                palaute.AppendChild(Xmlpvm);

                XmlElement tekija = doc.CreateElement("tekija");
                tekija.InnerText = _tekija;
                palaute.AppendChild(tekija);

                XmlElement opittu = doc.CreateElement("opittu");
                opittu.InnerText = _opittu;
                palaute.AppendChild(opittu);

                XmlElement haluanoppia = doc.CreateElement("haluanoppia");
                haluanoppia.InnerText = _haluanoppia;
                palaute.AppendChild(haluanoppia);

                XmlElement hyvaa = doc.CreateElement("hyvaa");
                hyvaa.InnerText = _hyvaa;
                palaute.AppendChild(hyvaa);

                XmlElement parannettavaa = doc.CreateElement("parannettavaa");
                parannettavaa.InnerText = _parannettavaa;
                palaute.AppendChild(parannettavaa);

                XmlElement muuta = doc.CreateElement("muuta");
                muuta.InnerText = _muuta;
                palaute.AppendChild(muuta);
                doc.Save(xmlFile);
            }
        }

        public static System.ComponentModel.ICollectionView NaytaPalautteet()
        {
            string xmlFile = Properties.Settings.Default.PalauteXML;
            try
            {
                XElement Palautteet = XElement.Load(xmlFile);
                System.ComponentModel.ICollectionView c;
                c = System.Windows.Data.CollectionViewSource.GetDefaultView(Palautteet.Elements());
                return c;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
