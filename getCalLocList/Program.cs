using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using CommandLine;
using Utilities;

namespace getCalLocList
{
    class Program
    {
        private static HashSet<string> ignoreList = new HashSet<string>();
        private static string layoutPath = string.Empty;
        //private static List<string> ignoreList = new List<string>();

        /*
         * getCalLocList locations=\\globalconnect.gfoundries.com\dresden\home\services\KonferenzRaeume\Grafiken%20fr%20Raumliste\Lage\ layout=\\globalconnect.gfoundries.com\dresden\home\services\KonferenzRaeume\Grafiken%20fr%20Raumliste\Layout\
         */

        static void Main( string[] args )
        {
            Console.Clear();
            Console.Title = typeof(Program).Name;
            OutPut.Line();
            OutPut.Text("started Application with {0}", Environment.CommandLine);
            OutPut.Line();

            // Command line parsing
            Arguments CommandLine = new Arguments(args);

            bool handled = false;
            if (CommandLine.ContainsKey("?") || CommandLine.ContainsKey("help"))
            {
                Help();
                handled = true;
            }

            if (CommandLine.ContainsKey("ignore"))
            {
                string ignorelst = CommandLine["ignore"];

                OutPut.Text(Environment.NewLine);
                OutPut.Text(string.Format("Using ignore list {0}.", ignorelst));
                ignoreList = new HashSet<string>(ignorelst.Split(new char[] { ',', ';', '.', ':' }, StringSplitOptions.RemoveEmptyEntries));
            }

            if (CommandLine.ContainsKey("layout"))
                layoutPath = CommandLine["layout"];

            if (CommandLine.ContainsKey("locations"))
            {
                OutPut.Text(Environment.NewLine);
                OutPut.Text("Get List of Locations");
                Dictionary<string, string> dict = null;
                CommandLine.ProcessArgument("locations", ( s ) => UpdataData(dict, s));
                if (dict != null) {
                    LoadSave.SaveDictionary("locations.xml", dict);
                    handled = true;
                }
            }

            if (CommandLine.ContainsKey("layouts"))
            {
                OutPut.Text(Environment.NewLine);
                OutPut.Text("Get List of layouts");
                Dictionary<string, string> dict = null;
                CommandLine.ProcessArgument("layouts", ( s ) => UpdataData(dict, s));
                if (dict != null) {
                    LoadSave.SaveDictionary("layouts.xml", dict);
                    handled = true;
                }
            }

            if (CommandLine.ContainsKey("AddTask")) {
                if (CommandLine.ContainsKey("locations") ||
                    CommandLine.ContainsKey("layouts")) {
                    string arguments = string.Empty;
                    foreach (var key in CommandLine.Keys) {
                        if (key != "AddTask" && key != "RemoveTask") {
                            arguments += "-" + key + "=" + CommandLine[key] + " ";
                        }
                    }
                    OutPut.Text(Environment.NewLine);
                    OutPut.Text("Adding Task '{0}' with arguments '{1}'", typeof(Program).Name, arguments);

                    Utilities.TaskScheduler.AddTask(typeof(Program).Name,
                                                    arguments,
                                                    "Creates File for Calendar locations or layouts.");
                }
                else {
                    OutPut.Text("Could not plan Task, because no files will generated!");
                }
            }

            if (CommandLine.ContainsKey("RemoveTask")) {
                OutPut.Text(Environment.NewLine);
                OutPut.Text("Remove planned Task '{0}'", typeof(Program).Name);
                Utilities.TaskScheduler.RemoveTask(typeof(Program).Name);
                handled = true;
            }            

            if (!handled)
            {
                OutPut.Text("Command line Parameter missing!!");
                Console.WriteLine("");
                Help();
            }
        }

        private static void Help()
        {
            Console.WriteLine("Help to Tool:");
            ///////////////////12345678901234567890123456789012345678901234567890123456789012345678901234567890
            Console.WriteLine("This Tool generates a Location and or a layout file to Google Calendar locations.");
            Console.WriteLine("Start Tool with comand line parameters to generate ");
            Console.WriteLine("");
            Console.WriteLine("Usage");
            Console.WriteLine("getCalLocList.exe -Parameter=value");
            Console.WriteLine("");
            Console.WriteLine("A parameter starts with '-' or '/'.");
            Console.WriteLine("Parametervalues could put into \" if they contain spaces.");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Parameter   Description");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("help        Shows this Help.");
            Console.WriteLine("?           Shows this Help.");
            Console.WriteLine("");
            Console.WriteLine("ignore=     Komma seperated (no spaces) list of tokens to ignore.");
            Console.WriteLine("            Parameter must be given as first parameter!!");
            Console.WriteLine("");
            Console.WriteLine("locations=  Path to directory with images to locations.");
            Console.WriteLine("");
            Console.WriteLine("layouts=    Path to directory with images to layouts.");
            Console.WriteLine("");
            Console.WriteLine("AddTask     Adds this programm as a Task to the Task scheduler to run weekly.");
            Console.WriteLine("            Parameter must be used additionally with");
            Console.WriteLine("            locations and/or layout Parameter ");
            Console.WriteLine("");
            Console.WriteLine("RemoveTask  removes a prevously planned Task");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Examples: ");
            Console.WriteLine("getCalLocList.exe -locations=C:\\MyPictures\\Locations  -layouts=C:\\MyPictures\\Layouts ");
            Console.WriteLine("getCalLocList.exe /locations=\"C:\\My Pictures\\Locations\"  /layouts=\"C:\\MyPictures\\Layouts\" /ignore=\"Baum,Stock,Haus\" ");
            Console.WriteLine("getCalLocList.exe -locations=C:\\MyPictures\\Locations  -layouts=C:\\MyPictures\\Layouts -AddTask");
            Console.WriteLine("");
            Console.WriteLine("Press a key ...");
            Console.ReadKey();
        }

        #region Meeting Rooms
        public static void UpdataData(Dictionary<string, string> dict, string path)
        {
            try {
                OutPut.Text(string.Format("Get List of Pictures from {0}.", path));

                if (dict == null)
                    dict = new Dictionary<string, string>();
                foreach (string file in System.IO.Directory.EnumerateFiles(path)) {
                    var name = System.IO.Path.GetFileNameWithoutExtension(file).ToLower().Replace(" ", string.Empty).Replace("_", string.Empty);

                    var namepart = name.Split(new char[] { ',', '.', '-', ';', ':', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < namepart.Length; i++) {
                        var key =namepart[i];
                        if (Char.IsDigit(key[0]))
                            key = "_" + key;

                        if (ignoreList.Contains(key))
                            OutPut.Text("ignore key {0} for file {1}", key, file.Replace(path, ""));
                        if (dict.ContainsKey(key))
                            OutPut.Text("already added key {0} for file '{1}', will not add for file '{2}'", key, dict[key].Replace(path, ""), file.Replace(path, ""));
                        if (!ignoreList.Contains(key) && !dict.ContainsKey(key))
                        {
                            OutPut.Text("adding key {0} = '{1}'", key, file);
                            dict.Add(key, file);
                        }
                    }
                }
            }
            catch (Exception e) {
                Logging.Log(e, "Error occurred on loading Dictionary from '{0}'!", path);
            }
        }
        #endregion
    }
}
