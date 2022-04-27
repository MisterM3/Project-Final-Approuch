using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Package : Ball
{

    //seconds
    public float timer = 5.0f;
    public Package(Vec2 pPos, Vec2 pVel) : base(10, pPos, pVel)
    {


    }

    void Update()
    {
        base.Update();

        if (timer <= 0 || latestCollision is Enemy2Way)
        {


            MyGame myGame = ((MyGame)game);
            for (int i = 0; i < myGame.GetNumberOfMovers(); i++)
            {
                if (myGame.GetMover(i) == this)
                {
                    Console.WriteLine("deada");
                    myGame.RemoveBalls(this);
                    this.LateDestroy();
                }
            }




        }
        else
        {
            alpha = 0.2f * timer;
            timer -= Time.deltaTime / 1000.0f;
        }
    }
}