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

        cannon = new Cannon(game.height / 2 - 275, game.width / 2 + 50 - 150, 10);
        AddChild(cannon);

        Fan fan = new Fan(new Vec2(400, 300), 100, 100, pPower: 0.5f) ;
        AddChild(fan);



        myGame._endCircle = new EndCircle(new Vec2(400, 300));
        AddChild(myGame._endCircle);

        LineSegment ln = new LineSegment(new Vec2(333, 381), new Vec2(290, 441));
        myGame._lines.Add(ln);

        Button but = new Button(new Vec2(200, 100), ln);
        AddChild(but);

        //Clouds cloud = new Clouds(new Vec2(100, 200), new Vec2(200, 200), new Vec2(100, 100), new Vec2(200, 100));
        //AddChild(cloud);

        foreach (Ball _ball in myGame._movers)
        {
            AddChild(_ball);
        }

        foreach (LineSegment _line in myGame._lines)
        {
            AddChild(_line);
        }

        ///No 3 collectables in level results in a crash
        //foreach (Collectable _col in myGame._colect)
        //{
        //    AddChild(_col);
        //}
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

