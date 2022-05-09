using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Collectable : CircleMechanic {
    
    public Collectable(Vec2 pPos, int pRadius) : base(pPos, pRadius) { 
    }

    protected override void InCircle()
    {
        CollectableSystem CS = myGame.GetCollectableSystem;
        CS.AddStarsLevel();
        this.LateDestroy();
    }

}
