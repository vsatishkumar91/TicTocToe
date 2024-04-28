using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Helpers
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PlayerStats Stats { get; set; } = new PlayerStats();


        public Player(int playerId, string name, string description)
        {
            PlayerId = playerId;
            Name = name;
            Description = description;
        }
    }
}
