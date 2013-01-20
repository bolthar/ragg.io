using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ragg.io.Models
{
    public class Player
    {
        public String Name { get; private set; }

        public Player(String name)
        {
            Name = name;
        }
    }
}
