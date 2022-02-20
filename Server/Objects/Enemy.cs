using Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Objects
{
    public class Enemy : Object
    {
        public Enemy()
        {
            Type = "Enemy";
            Id = GetId();
            Objects.Add(this);
        }
    }
}
