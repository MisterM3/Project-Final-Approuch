using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Button : BoxMechanic
{


    LineSegment Wall;
    bool pressed = false;
    public Button(Vec2 pPos, LineSegment pWall, int pWidth, int pHeight) : base(pPos, pWidth, pHeight)
    {
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
                if (line == Wall)
                {
                    myGame.RemoveLine(Wall);



                }
            }
        }

    }
}