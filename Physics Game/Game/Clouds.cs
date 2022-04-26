using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Clouds : Pivot {

    LineSegment[] lines = new LineSegment[4];



    public Clouds(Vec2 pTopLeft, Vec2 pBottomRight, float pRot = 0) : base()
    {


        lines[0] = new LineSegment(pTopLeft, new Vec2(pTopLeft.x, pBottomRight.y));
        lines[1] = new LineSegment(new Vec2(pTopLeft.x, pBottomRight.y), pBottomRight);
        lines[2] = new LineSegment(pBottomRight, new Vec2(pBottomRight.x, pTopLeft.y));
        lines[3] = new LineSegment(new Vec2(pBottomRight.x, pTopLeft.y), pTopLeft);

        if (pRot != 0) {

            for (int i = 0; i < lines.Length; i++) { 
            
            }
        
        }
        
        MyGame myGame = ((MyGame)game);
        for (int i = 0; i < lines.Length; i++) myGame.addLine(lines[i]);
    }

    public void Update() {
        
    }
}