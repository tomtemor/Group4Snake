using System;
using System.Collections.Generic;
using System.Text;

namespace Inlupp2Skelett
{
    public abstract class GameObject
    {
        Position posX = new Position();
        Position posY = new Position();
        
        char appearance = 'O';

        void Update()
        {
            // Food.position(random) här eller i gameworld?    
        }
    }
    class Player : GameObject
    {
        public string direction = "";
        public Player(string input)
        {
            if(input == "left") // Direction anges av knapptryck, hanteras av switchen i Program.cs
            { //minska i X led varje update
                
            }
            else if(input == "right")
            {
                //öka i X led varje update
            }
            else if(input == "up")
            {
                // antingen öka eller minska, men i Y-led, ta reda på vilket håll
            }
            else if(input == "down")
            {
                // motsatt mot IF-en ovanför denna
            }
        }
    }
    class Food : GameObject
    {
        // random positions av Food här?
        public Food(int x, int y)
        {
            
        }
        void Update()
        {

        }
    }
}
