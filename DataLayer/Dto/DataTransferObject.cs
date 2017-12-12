using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public abstract class DataTransferObject
    {
        protected int id;
        protected string name;

        public DataTransferObject() { }

        public DataTransferObject(int id) => this.id = id;
        public DataTransferObject(string name) => this.name = name;

        public DataTransferObject(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
    }
}
