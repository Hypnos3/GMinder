using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Utilities
{
    public class LoadSave
    {
        private static String GetStorageFolderPath(string path)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirectoryInfo storageFolder = new DirectoryInfo(appDataPath + @"\GMinder");
            if (!storageFolder.Exists)
            {
                storageFolder.Create();
            }
            return Path.Combine(storageFolder.ToString(), path);
        }

        public static Dictionary<string, string> LoadDictionary(string filename)
        {
            try
            {
                OutPut.Text("load file from {0}", filename);
                return XElement.Parse(File.ReadAllText(filename))
                                .Elements()
                                .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());
            }
            catch (Exception e)
            {
                Logging.Log(e, "Error occurred on loading Dictionary from '{0}'!", filename);
            }
            return null;
        }

        public static void SaveDictionary(string filename, Dictionary<string, string> dict)
        {
            try
            {
                if (dict == null)
                    return;

                OutPut.Text("save file to {0}", filename);
                new XElement("root", dict.Select(kv => new XElement(kv.Key, kv.Value)))
                            .Save(filename, SaveOptions.OmitDuplicateNamespaces);
            }
            catch (Exception e)
            {
                Logging.Log(e, "Error occurred on saving Dictionary to file '{0}'!", filename);
            }
        }
    }
}
