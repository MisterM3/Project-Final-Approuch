using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Enemy2Way : Ball {


    Vec2 startLine;
    Vec2 endLine;

    public Enemy2Way(int radius, Vec2 pPos, Vec2 startLinePos, Vec2 endLinePos, float speed = 1f) : base(radius, pPos) {


        startLine = startLinePos;
        endLine = endLinePos;

        position = pPos;

    }


    public void Move() { 
        
    
    }

    
}