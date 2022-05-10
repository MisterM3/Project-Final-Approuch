using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Collectable : CircleMechanic {
    Sound collectStar = new Sound("starsCollectTestSound.wav", false, false);
    public Collectable(Vec2 pPos, int pRadius) : base(pPos, pRadius) { 
    }

    protected override void InCircle()
    {
        collectStar.Play();
        CollectableSystem CS = myGame.GetCollectableSystem;
        CS.AddStarsLevel();
        this.LateDestroy();
    }

}
