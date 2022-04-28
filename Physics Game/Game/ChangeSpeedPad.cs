﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class ChangeSpeedPad : Sprite {

    float speedChange;

    public ChangeSpeedPad(Vec2 Pos, int pWidth, int pHeight, float pRot = -90.0f, float pSpeed = 1f) : base("colors.png") {

        SetOrigin(width / 2, height / 2);
        width = pWidth;
        height = pHeight;
        //rotation = pRot;

        x = Pos.x;
        y = Pos.y;
        
        speedChange = pSpeed;
    }


    public void Update()
    {


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

                    mover.velocity *= speedChange;
                }
                

            }

        }
    }
}