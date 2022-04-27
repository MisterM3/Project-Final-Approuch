using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Fan : Sprite {

    public Fan(Vec2 Pos, int pWidth, int pHeight, float pRot, float pPower) : base("colors.png") { 
    
        width = pWidth;
        height = pHeight;
        SetOrigin(width / 2, height / 2);
        rotation = pRot;

        Vec2 force = Vec2.GetUnitVectorDeg(pRot);
        force *= pPower;
    
    }


    public void Update() { 
    
    
    }
}