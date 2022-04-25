using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Lines : LineSegment {

    Vec2 Half;
    bool stuck = false;
 


    public Lines(Vec2 start, Vec2 end) : base(start, end, 0xff00ff00, 4) { 
    
        Half = start - end;
        start = new Vec2(Input.mouseX, Input.mouseY) + Half;
        end = new Vec2(Input.mouseX, Input.mouseY) - Half;

    }

    void Update() {

        if (Input.GetMouseButtonDown(0) ) stuck = true;
        if (!stuck )
        {
            start = new Vec2(Input.mouseX, Input.mouseY) + Half;
            end = new Vec2(Input.mouseX, Input.mouseY) - Half;
        }
    }
}