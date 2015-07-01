/// Copyright (c) 2009, Greg Todd
/// All rights reserved.
///
/// Redistribution and use in source and binary forms, with or without modification,
/// are permitted provided that the following conditions are met:
/// 
/// * Redistributions of source code must retain the above copyright notice,
///   this list of conditions and the following disclaimer.
///   
/// * Redistributions in binary form must reproduce the above copyright notice,
///   this list of conditions and the following disclaimer in the documentation
///   and/or other materials provided with the distribution.
///   
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
/// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
/// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
/// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
/// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
/// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
/// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
/// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
/// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
/// OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace ReflectiveCode.GMinder
{
    /// <summary>
    /// Provides methods to serialize and deserialize objects
    /// </summary>
    public static class Storage
    {
        public static void AppendText( string path, string text )
        {
#if DEBUG
            Console.WriteLine(text);
#endif
            using (var stream = new IsolatedStorageFileStream(path, FileMode.Append)) {
                using (var writer = new StreamWriter(stream)) {
                    writer.WriteLine(text);
                    writer.Flush();
                }
#if DEBUG
                Console.WriteLine("saved to:");
                Console.WriteLine(stream.GetType().GetField("m_FullPath", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stream).ToString());
#endif
            }
        }

        public static string LoadText( string path )
        {
            using (var stream = new IsolatedStorageFileStream(path, FileMode.OpenOrCreate))
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }

        public static void SaveObject( string path, object value )
        {
            var serializer = new XmlSerializer(value.GetType());
            using (var stream = new FileStream(GetStorageFolderPath(path), FileMode.Create)) {
                serializer.Serialize(new XmlTextWriter(stream, Encoding.Unicode), value);
                stream.Flush();
            }
        }

        private static String GetStorageFolderPath( string path )
        {
            var retPath = Path.Combine(Application.StartupPath, path);
            if (File.Exists(retPath))
                return retPath;

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirectoryInfo storageFolder = new DirectoryInfo(appDataPath + @"\GMinder");
            if (!storageFolder.Exists) {
                storageFolder.Create();
            }
#if DEBUG
            Console.WriteLine("Writing File to {0}", Path.Combine(storageFolder.ToString(), path));
#endif
            return Path.Combine(storageFolder.ToString(), path);
        }

        public static T LoadObject<T>( string path )
        {
            var serializer = new XmlSerializer(typeof(T));
            try {
                using (var stream = new FileStream(GetStorageFolderPath(path), FileMode.Open))
                    return (T)serializer.Deserialize(new XmlTextReader(stream));
            }
            catch (FileNotFoundException) {
                return default(T);
            }
        }

        public static Dictionary<string, string> LoadDictionary( string path )
        {
            var filename = GetStorageFolderPath(path);
            if (!File.Exists(filename))
                return null;

            return XElement.Parse(File.ReadAllText(filename))
                            .Elements()
                            .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());
        }

        public static void SaveDictionary( string path, Dictionary<string, string> dict )
        {
            var filename = GetStorageFolderPath(path);
            new XElement("root", dict.Select(kv => new XElement(kv.Key, kv.Value)))
                        .Save(filename, SaveOptions.OmitDuplicateNamespaces);
        }

    }
}
