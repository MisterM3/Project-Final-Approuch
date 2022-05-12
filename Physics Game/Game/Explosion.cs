using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Explosion : AnimationSprite
{
    Vec2 speed;
    public Explosion(Vec2 pspeed) : base("ballerdestroy.png", 6, 2) { 
    
        speed = pspeed;

    }

    void Update() {

        Animate(0.3f);

        x += speed.x;
        y += speed.y;

        speed *= 0.99f;

        if (currentFrame > 10) this.LateDestroy();

    }

}