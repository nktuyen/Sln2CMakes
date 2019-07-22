using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vs
{
    public class VcProjectImportGroup : ProjectItem
    {
        public List<string> Items { get; set; }
        internal VcProjectImportGroup(string name = "") : base(name)
        {
            Items = new List<string>();
        }

        internal override void UpdateEnvironmentVariables()
        {
            base.UpdateEnvironmentVariables();

            var oldItems = Items;
            Items = new List<string>();
            foreach (string item in oldItems)
            {
                StringBuilder s = new StringBuilder(item);
                foreach (KeyValuePair<string, string> envVar in this.EnvironmentVariables)
                {
                    s.Replace(envVar.Key, envVar.Value);
                }
                string res = s.ToString();
                if (res.IndexOf(":") > 0)
                {

                }
                else
                {
                    if (EnvironmentVariables.ContainsKey("$(ProjectDir)")) {
                        res = Path.GetFullPath(EnvironmentVariables["$(ProjectDir)"] + res);
                    }
                }
                Items.Add(res);
            }
        }
    }
}
