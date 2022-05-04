using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Particle : Ball
{
    float runTimer;
    public bool regen = false;
    public Particle(int pRadius, Vec2 pPosition, Vec2 pVelocity = new Vec2(), float RunTime = 1.0f) : base(pRadius, pPosition, pVelocity) 
    {
        runTimer = RunTime + Utils.Random(-RunTime/4, RunTime/4);

    }

    void Update() {
        base.Update();

       
        if (runTimer < 0)
        {
                alpha -= 0.05f;
            if (alpha < 0)
            {
                if (regen) {
                    ((MyGame)game).PS.SpawnRandom();


                }
                this.LateDestroy();
            }
            }
        else { 
        runTimer -= Time.deltaTime / 1000.0f;
        }
    }

}