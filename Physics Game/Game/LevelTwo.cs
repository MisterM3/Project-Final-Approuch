﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;

public class LevelTwo : Scene
{
    public Cannon cannon;
    private Pivot objectOwner;
    public LevelTwo() : base()
    {
       
    }

    protected override void Start()
    {
        isActive = true;
        objectOwner = new Pivot();

        MyGame myGame = (MyGame)game;


        Sprite bg = new Sprite("1.png");
        Console.WriteLine(myGame.width);
        Console.WriteLine(myGame.height);
        bg.width = 1536;
        bg.height = 801;
        AddChild(bg);

        cannon = new Cannon(0, 450, 10);
        AddChild(cannon);

        Fan fan = new Fan(new Vec2(1060, 613), 100, 357, pPower: 1f) ;
        AddChild(fan);

        //myGame._endCircle = new EndCircle(new Vec2(400, 300));
        //AddChild(myGame._endCircle);

        //LineSegment ln = new LineSegment(new Vec2(333, 381), new Vec2(290, 441));
        //myGame._lines.Add(ln);


        //Button but = new Button(new Vec2(200, 100), ln);
        //AddChild(but);
    
            Clouds cloud = new Clouds(new Vec2(1186, 243), new Vec2(1260, 170), new Vec2(925, 0), new Vec2(1080, 0));
        AddChild(cloud);

        Clouds cloud1 = new Clouds(new Vec2(690, 530), new Vec2(773, 455), new Vec2(422, 283), new Vec2(504, 205));
        AddChild(cloud1);

        Clouds cloud2 = new Clouds(new Vec2(1241, 491), new Vec2(1533, 490), new Vec2(1242, 443), new Vec2(1534, 444));
        AddChild(cloud2);

        Clouds cloud3 = new Clouds(new Vec2(416, 801), new Vec2(578, 801), new Vec2(324, 715), new Vec2(326, 564));
        AddChild(cloud3);


        myGame._colect[0] = new Collectable(30, new Vec2(1258, 324));
        myGame._colect[1] = new Collectable(30, new Vec2(722, 99));
        myGame._colect[2] = new Collectable(30, new Vec2(1341, 661));

        //Outside
        myGame._lines.Add ( new LineSegment(new Vec2(0, 801), new Vec2(0,0)) );
        myGame._lines.Add( new LineSegment(new Vec2(1536, 801), new Vec2(0, 801)) );
        myGame._lines.Add(new LineSegment(new Vec2(1536, 0), new Vec2(1536, 801)) );
        myGame._lines.Add(new LineSegment( new Vec2(0, 0), new Vec2(1536, 0)) );

        //Box bottom left (Make new Class later to clean up
        Clouds cloud4 = new Clouds(new Vec2(0, 801), new Vec2(325, 801), new Vec2(0, 549), new Vec2(324,549), pWall: true);
        AddChild(cloud4);

        //lines[0] = new LineSegment(pTopLeft, pBottomLeft);
        //lines[1] = new LineSegment(pBottomLeft, pBottomRight);
        //lines[2] = new LineSegment(pBottomRight, pTopRight);
        //lines[3] = new LineSegment(pTopRight, pTopLeft);

        foreach (Ball _ball in myGame._movers)
        {
            AddChild(_ball);
        }

        foreach (LineSegment _line in myGame._lines)
        {
            AddChild(_line);
        }

        ///No 3 collectables in level results in a crash
        foreach (Collectable _col in myGame._colect)
        {
            AddChild(_col);
        }


        AddChild(objectOwner);
        
        
    }

    public override void UnLoadScene()
    {
        base.UnLoadScene();
    }

    protected override void Update()
    {
        if (!base.isActive) return;
    }

}
