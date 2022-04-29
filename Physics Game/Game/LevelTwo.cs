using System;
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
    
            Clouds cloud = new Clouds(new Vec2(1190, 255), new Vec2(1265, 180), new Vec2(930, 0), new Vec2(1080, 0));
        AddChild(cloud);

        Clouds cloud1 = new Clouds(new Vec2(690, 560), new Vec2(775, 480), new Vec2(425, 300), new Vec2(505, 220));
        AddChild(cloud1);

        Clouds cloud2 = new Clouds(new Vec2(362, 790), new Vec2(531, 792), new Vec2(325, 754), new Vec2(325, 591));
        AddChild(cloud2);

        Clouds cloud3 = new Clouds(new Vec2(1245, 517), new Vec2(1920, 517), new Vec2(1245, 467), new Vec2(1920, 467));
        AddChild(cloud3);


        myGame._colect[0] = new Collectable(30, new Vec2(1258, 324));
        myGame._colect[1] = new Collectable(30, new Vec2(722, 99));
        myGame._colect[2] = new Collectable(30, new Vec2(1341, 661));

        //Outside
        myGame._lines.Add ( new LineSegment(new Vec2(0, 1080), new Vec2(0,0)) );
        myGame._lines.Add( new LineSegment(new Vec2(1920, 1080), new Vec2(0, 1080)) );
        myGame._lines.Add(new LineSegment(new Vec2(1920, 0), new Vec2(1920, 1080)) );
        myGame._lines.Add(new LineSegment( new Vec2(0, 0), new Vec2(1920, 0)) );

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

