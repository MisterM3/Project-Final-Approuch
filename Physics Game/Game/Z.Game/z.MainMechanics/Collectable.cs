﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Collectable : CircleMechanic {
    Sound collectStar = new Sound("starsCollectTestSound.wav", false, false);

    Sprite collect;
    float rotatingSpeed;
    public Collectable(Vec2 pPos, int pRadius) : base(pPos, pRadius) {

        collect = new Sprite("collect.png");
        collect.SetOrigin(collect.width/2, collect.height/2);
     //   collect.SetXY(-2, -2);
        collect.width = width;
        collect.height = height;

        collect.rotation = Utils.Random(0, 91);
        rotatingSpeed = Utils.Random(-2.0f, 3.0f);
        rotatingSpeed *= 3;
        AddChild(collect);

        alpha = 0;
    }

    protected override void Update() {

        collect.rotation += 3;
        base.Update();
    
    }
    protected override void InCircle()
    {
        collectStar.Play();
        CollectableSystem CS = myGame.GetCollectableSystem;
        CS.AddStarsLevel();
        this.LateDestroy();
    }

}
