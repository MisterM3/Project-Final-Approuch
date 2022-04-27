using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class MoveableLine : LineSegment
{

    Vec2 moveAround;
    Vec2 center;
    public MoveableLine(Vec2 StartLine, Vec2 EndLine, Vec2 moveFromCenter) : base(StartLine, EndLine) {

        moveAround = moveFromCenter;

      

    }


}
