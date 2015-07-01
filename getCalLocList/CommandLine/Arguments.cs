using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CommandLine
{
    /// <summary>
    /// Arguments class
    /// </summary>
    public class Arguments : Dictionary<string, string>
    {
        // Variables
        private string _Application;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Args">CommandLine Arguments</param>
        public Arguments( string[] Args )
        {
            Regex Spliter = new Regex(@"^-{1,2}|^/|=|:(?!\\)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            // new Regex(@"^-{1,2}|^/|=|:",
            Regex Remover = new Regex(@"^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            string Parameter = null;
            string[] Parts;

            // Valid parameters forms:
            // {-,/,--}param{ ,=,:}((",')value(",'))
            // Examples: 
            // -param1 value1 --param2 /param3:"Test-:-work" 
            //   /param4=happy -param5 '--=nice=--'
            foreach (string Txt in Args) {
                // Look for new parameters (-,/ or --) and a
                // possible enclosed value (=,:)
                Parts = Spliter.Split(Txt, 3);

                switch (Parts.Length) {
                    // Found a value (for the last parameter found (space separator))
                    case 1:
                        if (Parameter != null)
                            this.Add(Parameter, Remover.Replace(Parts[0], "$1"));

                        Parameter = null;

                        // else Error: no parameter waiting for a value (skipped)
                        break;

                    // Found just a parameter
                    case 2:
                        // The last parameter is still waiting. 
                        // With no value, set it to true.
                        if (Parameter != null)
                            this.Add(Parameter);

                        Parameter = Parts[1];
                        break;

                    // Parameter with enclosed value
                    case 3:
                        // The last parameter is still waiting. 
                        // With no value, set it to true.
                        if (Parameter != null)
                            this.Add(Parameter);

                        Parameter = Parts[1];

                        // Remove possible enclosing characters (",')
                        this.Add(Parameter, Remover.Replace(Parts[2], "$1"));

                        Parameter = null;
                        break;
                }
            }

            // In case a parameter is still waiting
            if (Parameter != null) {
                this.Add(Parameter);
            }
        }

        private string GetKey( string key )
        {
            if (!this.ContainsKey(key)) {
                int pos = 1;
                while (this.ContainsKey(key + pos)) {
                    pos++;
                }
                key += pos.ToString();
            }
            return key;
        }

        /// <summary>
        /// Fügt dem Wörterbuch den angegebenen Schlüssel und Wert hinzu.
        /// </summary>
        /// <param name="key">Der Schlüssel des hinzuzufügenden Elements.</param>
        /// <param name="value">Der Wert des hinzuzufügenden Elements.Der Wert kann für Referenztypen null sein.</param>
        /// <exception cref="System.ArgumentNullException">key ist null.</exception>
        /// <exception cref="System.ArgumentException">Ein Element mit demselben Schlüssel ist bereits in der System.Collections.Generic.Dictionary<TKey,TValue> vorhanden.</exception>
        public new void Add( string key, string value )
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new System.ArgumentNullException("key");

            key = GetKey(key);            
            base.Add(key, value);
        }

        /// <summary>
        /// Fügt dem Wörterbuch den angegebenen Schlüssel und Wert hinzu.
        /// </summary>
        /// <param name="key">Der Schlüssel des hinzuzufügenden Elements.</param>
        /// <exception cref="System.ArgumentNullException">key ist null.</exception>
        /// <exception cref="System.ArgumentException">Ein Element mit demselben Schlüssel ist bereits in der System.Collections.Generic.Dictionary<TKey,TValue> vorhanden.</exception>
        public new void Add( string key )
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new System.ArgumentNullException("key");

            key = GetKey(key);
            base.Add(key, "true");
        }

        /// <summary>
        /// Process an Argument which could be passed multiple times.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="process"></param>
        public void ProcessArgument(string key, Action<string> process)
        {
            if (!this.ContainsKey(key))
                return;
            process(this[key]);
            int part = 1;
            while (this.ContainsKey(key + part)) {
                process(this["locations" + part]);
                part++;
            }
        }
    }

}
