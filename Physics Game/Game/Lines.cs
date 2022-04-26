using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Lines : LineSegment {



    public Lines(Vec2 pStart, Vec2 pEnd) : base(pStart, pEnd) { 
    
    
    
    
    }

    public void Update() {


        if (!Input.GetMouseButtonDown(0)) return;
        Vec2 holdStart = start; 
        Vec2 holdEnd = end;

        start = new Vec2(end.x, start.y);
        end = new Vec2(holdStart.x, holdEnd.y);
    
    
    }

}