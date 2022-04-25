using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Lines : LineSegment {


    public Lines(Vec2 start, Vec2 end) : base(start, end, 0xff00ff00, 4) { 
    
    
    }

    void Update() {


        start += new Vec2(1,0);
        end += new Vec2(1, 0);

    }
}