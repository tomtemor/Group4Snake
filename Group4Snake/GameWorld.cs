using System;
using System.Collections.Generic;
using System.Text;

namespace Inlupp2Skelett
{
    class GameWorld
    {
        int poäng = 0;
        int bredd = 50;
        int höjd = 20;
        
        public GameWorld(List<GameObject>objects)
        {
            objects = new List<GameObject>();
        }
        
        public void Update()
        {
            // Player.position här eller?
        }
    }
}
