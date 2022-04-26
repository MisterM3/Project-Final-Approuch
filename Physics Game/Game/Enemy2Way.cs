﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Enemy2Way : Ball {


    Vec2 startLine;
    Vec2 endLine;

    Vec2 direction;


    float totalLenght;
    bool toEnd = true;
    public Enemy2Way(int radius, Vec2 pPos, Vec2 startLinePos, Vec2 endLinePos, float speed = 1f) : base(radius, pPos) {


        startLine = startLinePos;
        endLine = endLinePos;

        position = endLine;

        direction = endLine - startLine;

        totalLenght = direction.Length();
        velocity = direction.Normalized();
        velocity *= speed;

    }

    public void Update() {
        Move();
    }

    public void Move() {

        Vec2 disToEnd = position - endLine;
        Vec2 disToStart = position - startLine;

        //change so it's lenght between > total lenght
        if (disToEnd.Length() >= totalLenght || disToStart.Length() >= totalLenght)
        {
            Console.WriteLine("wa");
            velocity *= -1;
        }

        position += velocity;

        x = position.x;
        y = position.y;
        
        
    
    }

    
}