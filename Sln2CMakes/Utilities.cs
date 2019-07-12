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
                int pos = res.LastIndexOf('.');
                if (pos >= 0)
                {
                    res = res.Substring(0, pos);
                }
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return res;
        }

        public string GetFileExtension(string filePath)
        {
            string res = string.Empty;
            int pos = filePath.LastIndexOf('.');
            if(pos > 0)
            {
                res = filePath.Substring(pos + 1);
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

        public string GetFileName(string fullName)
        {
            string res = fullName;
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(fullName);
                res = fi.Name;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return res;
        }
        public string UnescapeString(string input, string escc = "\"")
        {
            int start = 0;
            int len = input.Length;
            if (input.Substring(0, 1) == escc)
            {
                start++;
                len--;
            }

            if (input.Substring(input.Length - 1, 1) == escc)
            {
                len--;
            }

            string res = input.Substring(start, len);   
            return res;
        }
    }
}
