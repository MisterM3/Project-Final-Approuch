using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Button : Sprite {


    LineSegment Wall;
    bool pressed;
    public Button(Vec2 pPos, LineSegment pWall) : base("colors.png") { 
    
        x = pPos.x;
        y = pPos.y;

        Wall = pWall;
    }


    public void Update() {

        // rotation++;
        MyGame myGame = ((MyGame)game);

        for (int i = 0; i < myGame.GetNumberOfMovers(); i++)
        {
            Ball mover = myGame.GetMover(i);

            if (mover.moving)
            {

                //Checks if package inside area of effect
                if (mover.x <= x + width / 2 && mover.x >= x - width / 2 && mover.y <= y + height / 2 && mover.y >= y - height / 2)
                {
                    pressed = true;
                    for (int j = 0; j < myGame.GetNumberOfLines(); j++) { 
                    
                        LineSegment line = myGame.GetLine(j);
                        if (line == Wall) line.Destroy();
                    }
                    
                }
                else mover.accel = new Vec2(0, 0);

            }

        }
    }
}