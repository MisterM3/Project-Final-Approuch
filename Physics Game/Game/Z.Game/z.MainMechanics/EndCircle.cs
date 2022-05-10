using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class EndCircle : CircleMechanic {

    //endcircle should be this radius
    int radius = 40;

    EndUI endUI;
    public EndCircle(Vec2 pPos, int pRad) : base(pPos, pRad)
    {
    }

    protected override void InCircle(Ball pMove, Vec2 pRel)
    {

        Vec2 moreVel = pRel.Normalized();

        pMove.accel = moreVel * 0.01f * (pRel.Length());
        pMove.velocity *= 0.9f;
        if (endUI == null)
        {
            SceneManager.instance.LoadScene(0);
            CollectableSystem CS = myGame.GetCollectableSystem;
            

            endUI = new EndUI(CS.currentStarsLevel);
            parent.AddChild(endUI);

        }
    }

}
