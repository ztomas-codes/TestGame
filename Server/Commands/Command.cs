using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    public class Command
    {
        public string Prefix { get; set; }
        public Dictionary<string, string> Args { get; set; }
        public byte[] Message() { 
            byte[] message = new byte[1000];

            string ms = $"VOTE|{Prefix}|";
            Args.ToList().ForEach(x => ms += $"{x.Value}|");

            message = Encoding.Default.GetBytes(ms);
            return message;
        }
    }
}
