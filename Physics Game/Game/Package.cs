using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Package : Ball
{





    public bool acid = false;
    //seconds
    public float timer = 5.0f;

    public bool sped = false;
    public bool slow = false;
    public bool normal = true;
    public float spedTimer = 1.0f;
    public Package(Vec2 pPos, Vec2 pVel) : base(10, pPos, pVel)
    {


    }

    void Update()
    {
        base.Update();
        Console.WriteLine(velocity.Length());
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
            if (acid) timer -= Time.deltaTime / 500.0f;
            else timer -= Time.deltaTime / 1000.0f;
        }
    }

}