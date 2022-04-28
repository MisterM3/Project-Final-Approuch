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
        objectOwner.AddChild(myGame.cannon);

        Fan fan = new Fan(new Vec2(400, 300), 100, 100);
        AddChild(fan);

        Collectable col4 = new Collectable(30, new Vec2(400, 300));
        AddChild(col4);

        myGame._endCircle = new EndCircle(new Vec2(400, 300));
        AddChild(myGame._endCircle);

        Clouds cloud = new Clouds(new Vec2(100, 200), new Vec2(200, 200), new Vec2(100, 100), new Vec2(200, 100));
        AddChild(cloud);

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

