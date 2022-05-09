using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class EndCircle : CircleMechanic {

    //endcircle should be this radius
    int radius = 40;

    public EndCircle(Vec2 pPos, int pRad) : base(pPos, pRad)
    {
    }

    protected override void InCircle()
    {
        myGame.NextLevel();
    }

}
