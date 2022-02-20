using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Objects
{
    public class Enemy : Object
    {
        public Enemy()
        {
            Type = "Enemy";
            Objects.Add(this);
        }
    }
}
