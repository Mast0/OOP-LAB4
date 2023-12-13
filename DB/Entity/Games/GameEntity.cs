using DB.Service;
using GameClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entity.Games
{
    public enum GameTypes
    {
        CUMMON_GAME = 1,
        RANDOM_RATE_GAME = 2,
        TRAIN_GAME = 3,
    }

    public class GameEntity
    {
        public GameService service;
        public int ID;
        public int Index { get; set; }
        public GameAccount User1 { get; set; }
        public GameAccount User2 { get; set; }
        public int Rate { get; set; }
        public GameTypes GameType { get; set; }
    }
}
