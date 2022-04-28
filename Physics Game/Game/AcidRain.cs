using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class AcidRain : Sprite {


    public AcidRain(Vec2 Pos, int pWidth, int pHeight) : base("colors.png") {

        SetOrigin(width / 2, height / 2);
        width = pWidth;
        height = pHeight;

        x = Pos.x;
        y = Pos.y;
    }

    void Update() {

        MyGame myGame = ((MyGame)game);

        for (int i = 0; i < myGame.GetNumberOfMovers(); i++)
        {
            Ball mover = myGame.GetMover(i);

            if (mover is Package)
            {
                Package p = (Package)mover;
                //Checks if package inside area of effect
                if (mover.x <= x + width / 2 && mover.x >= x - width / 2 && mover.y <= y + height / 2 && mover.y >= y - height / 2)
                {
                    if (!p.acid) p.acid = true;

                }
                else if (p.acid) p.acid = false;

            }

        }
    }
}