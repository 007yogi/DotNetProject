using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class AbstractProperty
    {
        public abstract int SId { get; set; }
        public abstract string SName { get; set; }
    }
    public class AbstractData : AbstractProperty
    {
        private int id;
        private string name;
        public override int SId
        {
            set
            {
                this.id = value;
            }
            get
            {
                return id;
            }
        }
        public override string SName
        {
            set
            {
                this.name = value;
            }
            get
            {
                return name;
            }            
        }
    }

}
