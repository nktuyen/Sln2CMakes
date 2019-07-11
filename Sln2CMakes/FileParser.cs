using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sln2CMakes
{
    internal class FileParser
    {
        protected StreamReader _reader = null;
        protected Model _model = null;
        protected Model _parsingModel = null;
        protected string _filePath = string.Empty;

        public Model Model { get { return _model; } }
        public string FileName { get { return _filePath; } }
        public bool Parse(string filePath)
        {
            _model = null;
            _reader = null;
            _parsingModel = null;
            _filePath = filePath;
            if (!PreParsing())
            {
                return false;
            }

            try
            {
                _reader = new StreamReader(filePath);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                _reader = null;
                return false;
            }

            string lineContent = null;
            int lineNum = 0;
            while((lineContent = _reader.ReadLine()) != null)
            {
                if(!ParseLine(lineContent, ref lineNum))
                {
                    break;
                }
            }

            PostParsing();

            return true;
        }

        protected virtual bool ParseLine(string lineContent, ref int lineNum)
        {
            lineNum++;
            return true;
        }

        protected virtual bool PreParsing()
        {
            return true;
        }

        protected virtual  void PostParsing()
        {

        }
    }
}
