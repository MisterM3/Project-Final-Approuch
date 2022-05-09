using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Button : BoxMechanic {


    LineSegment Wall;
    bool pressed = false;
    public Button(Vec2 pPos, LineSegment pWall) : base(pPos, 40, 20) { 
        Wall = pWall;
    }

    protected override void InBox(Package pPack)
    {
        if (!pressed)
        {
            pressed = true;
            for (int j = 0; j < myGame.GetNumberOfLines(); j++)
            {

                LineSegment line = myGame.GetLine(j);
                if (line == Wall) line.Destroy();

            }
        }
    }

}