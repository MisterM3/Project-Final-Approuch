using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Clouds : Pivot {


    public Clouds() : base()
    {
        LineSegment line = new LineSegment(new Vec2(100, 100), new Vec2(500, 500));
        rotation = 90;
        MyGame myGame = ((MyGame)game);
        myGame.addLine(line);
    }

    public void Update() {
        
    }
}