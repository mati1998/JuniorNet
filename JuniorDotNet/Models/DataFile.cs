using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace JuniorDotNet.Models
{
    public class DataFile
    {
        private static List<Product> programData = new List<Product>();

        public static List<Product> Products
        {
            get
            {
                UpdateApp();
                return programData;
            }
        }

        public static void UpdateFile()
        {
            if (!File.Exists("ApplicationData.xml"))
            {
                using (FileStream fs = File.Create("ApplicationData.xml")) { }
            }

            using (StreamWriter file = File.CreateText("ApplicationData.xml"))
            {
                XmlSerializer xmlserial = new XmlSerializer(programData.GetType());
                xmlserial.Serialize(file, programData);
            }
        }

        public static void UpdateApp()
        {
            if (!File.Exists("ApplicationData.xml"))
            {
                using (FileStream fs = File.Create("ApplicationData.xml")) { }
            }

            using (StreamReader file = File.OpenText("ApplicationData.xml"))
            {
                XmlSerializer xmlserial = new XmlSerializer(programData.GetType());
                try
                {
                    programData = (List<Product>)(xmlserial.Deserialize(file));
                }
                catch
                {
                    programData = new List<Product>();
                }
            }
        }
    }
}
