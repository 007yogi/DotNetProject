using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class IndexerDemo
    {
        private string[] strArr = new string[5]; // internal data storage.
        // defines an indexer for its private array strArr
        public string this[int index]
        {
            get => strArr[index];
            set => strArr[index] = value;
        }
    }
}
