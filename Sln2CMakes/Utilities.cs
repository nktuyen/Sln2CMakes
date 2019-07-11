using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    public class Utilities
    {
        private static Utilities _instance = null;

        public static Utilities Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new Utilities();
                }
                return _instance;
            }
        }

        public string GetFileTitle(string fullPath)
        {
            string res = fullPath;
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(fullPath);
                res = fi.Name;
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return res;
        }

        public string GetFileDirectory(string fullPath)
        {
            string res = fullPath;
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(fullPath);
                res = fi.DirectoryName;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return res;
        }

        public string UnescapeString(string input)
        {
            int start = 0;
            int len = input.Length;
            if (input.Substring(0, 1) == "\"")
            {
                start++;
                len--;
            }

            if (input.Substring(input.Length - 1, 1) == "\"")
            {
                len--;
            }

            string res = input.Substring(start, len);   
            return res;
        }
    }
}
