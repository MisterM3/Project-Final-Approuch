using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class MoveableLine : LineSegment
{

    
    Vec2 leftBound;
    Vec2 rightBound;
    Vec2 moveAround;
    Vec2 center;
    Vec2 velocity;
    Vec2 position;
    public MoveableLine(Vec2 StartLine, Vec2 EndLine, Vec2 moveFromCenter) : base(StartLine, EndLine) {


        start = StartLine;
        end = EndLine;
        moveAround = moveFromCenter;
        center = (EndLine - StartLine)/2.0f;

        leftBound = center - moveAround;
        rightBound = center + moveAround;
        velocity = leftBound.Normalized();

        

    }

    public void Update() {
        center += velocity;
        end += velocity;
        start += velocity;



        base.Check();
        float distance = (leftBound - rightBound).Length();
        if ((center - leftBound).Length() >= distance || ((center - rightBound).Length() >= distance)) velocity *= -1;


    }


}
