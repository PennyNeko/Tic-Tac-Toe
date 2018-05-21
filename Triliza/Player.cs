using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triliza
{
    public enum Symbol { X, O}
    public enum Type { Computer, Human}
    public class Player
    {
        public Player(string name, Symbol playerSymbol, Type playerType)
        {
            Name = name;
            PlayerSymbol = playerSymbol;
            PlayerType = playerType;
        }

        public string Name { set; get; }
        public Symbol PlayerSymbol { set; get; }
        public Type PlayerType { set; get; }
    }
}
