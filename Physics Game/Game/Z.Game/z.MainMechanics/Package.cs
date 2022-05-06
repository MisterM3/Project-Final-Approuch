using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Package : Ball
{



    public enum PackageSpeed { Slow, Normal, Fast }

    public PackageSpeed speed;

    public bool acid = false;
    //seconds
    public float timer = 5.0f;

    public float spedTimer = 1.0f;


    //Base velocity when the speed is normal
    Vec2 baseVelocity;
    public Package(Vec2 pPos, Vec2 pVel) : base(10, pPos, pVel)
    {
        baseVelocity = pVel;
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
                    myGame.RemoveBalls(this);
                    this.LateDestroy();
                }
            }




        }
        else
        {
            if (acid) timer -= Time.deltaTime / 500.0f;
            else timer -= Time.deltaTime / 1000.0f;
            alpha = 0.2f * timer;
        }
    }


    //Changes the speed after a speedpad has been hit
    public void CheckSpeed() {

        switch (speed)
        { 
            case PackageSpeed.Slow:
                velocity = baseVelocity / 2.0f;
                break;
            case PackageSpeed.Normal:
                velocity = baseVelocity;
                break;
            case PackageSpeed.Fast:
                velocity = baseVelocity * 2.0f;
                break;
            default:
                Console.WriteLine("Speed not in available range!");
                break;  
        }            
    }

}