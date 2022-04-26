using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Enemy2Way : Ball {


    Vec2 startLine;
    Vec2 endLine;

    Vec2 direction;

    bool toEnd = true;
    public Enemy2Way(int radius, Vec2 pPos, Vec2 startLinePos, Vec2 endLinePos, float speed = 1f) : base(radius, pPos) {


        startLine = startLinePos;
        endLine = endLinePos;

        position = pPos;

        direction = endLine - startLine;

        velocity = direction.Normalized();
        velocity *= speed;

    }

    public void Update() {
        Move();
    }

    public void Move() {

        Vec2 disToEnd = position - endLine;
        Vec2 disToStart = position - startLine;
        if (disToEnd.Length() <= 0.05f || disToStart.Length() <= 0.05f)
        {
            Console.WriteLine("wa");
            velocity *= -1;
        }

        position += velocity;

        x = position.x;
        y = position.y;
        
        
    
    }

    
}