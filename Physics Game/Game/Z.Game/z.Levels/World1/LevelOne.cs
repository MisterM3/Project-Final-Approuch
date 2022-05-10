using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;
public class LevelOne : Levels
{
    public static SoundChannel levelOneBg = new SoundChannel(1);
    Sound levelOne = new Sound("cloudsBG.mp3", true, false);

    Cannon cannon;
    public LevelOne(Dictionary<string, Sound> soundLibrary) : base(soundLibrary)
    {
    }

    protected override void MakeLevel()
    {
        levelOneBg = levelOne.Play();

        ((MyGame)game).GetCurrentLevel = 0;
        ((MyGame)game).GetCurrentScene = 1;
        Sprite bg = new Sprite("1.png");
        Console.WriteLine(myGame.width);
        Console.WriteLine(myGame.height);
        bg.width = 1920;
        bg.height = 1080;
        AddChild(bg);

        cannon = new Cannon(0, 450, 15);
        AddChild(cannon);

        Sprite sprite = new Sprite("cannon_tire.png");
        AddChild(sprite);
        sprite.SetOrigin(sprite.width/2, sprite.height/2);
        sprite.x = 350;
        sprite.y = 440;

        sprite.width = sprite.width / 4;
        sprite.height = sprite.height / 4;


        //myGame._endCircle = new EndCircle(new Vec2(400, 300));
        //AddChild(myGame._endCircle);

        //LineSegment ln = new LineSegment(new Vec2(333, 381), new Vec2(290, 441));
        //myGame._lines.Add(ln);


        //Button but = new Button(new Vec2(200, 100), ln);
        //AddChild(but);

        Clouds cloud = new Clouds(new Vec2(518, 1080), new Vec2(725, 1080), new Vec2(400, 958), new Vec2(400, 751), pWall: true);
        AddChild(cloud);

        Clouds cloud1 = new Clouds(new Vec2(863, 718), new Vec2(966, 614), new Vec2(527, 382), new Vec2(631, 279), pWall: true);
        AddChild(cloud1);

        Clouds cloud2 = new Clouds(new Vec2(1481, 324), new Vec2(1578, 229), new Vec2(1155, 0), new Vec2(1346, 0), pWall: true);
        AddChild(cloud2);

        Clouds cloud3 = new Clouds(new Vec2(1551, 660), new Vec2(1920, 663), new Vec2(1552, 595), new Vec2(1920, 594), pWall: true);
        AddChild(cloud3);


        //Outside
        myGame._lines.Add(new LineSegment(new Vec2(0, 1080), new Vec2(0, 0)));
        myGame._lines.Add(new LineSegment(new Vec2(1920, 1080), new Vec2(0, 1080)));
        myGame._lines.Add(new LineSegment(new Vec2(1920, 0), new Vec2(1920, 1080)));
        myGame._lines.Add(new LineSegment(new Vec2(0, 0), new Vec2(1920, 0)));

        //Box bottom left (Make new Class later to clean up
        Clouds cloud4 = new Clouds( new Vec2(0, 1080), new Vec2(400, 1080), new Vec2(0, 742), new Vec2(400, 742), pWall: true);
        AddChild(cloud4);


        //Fan
        Fan fan = new Fan(new Vec2(1322, 826), 120, 500, pPower: 1f);
        AddChild(fan);


        //Collectables
        myGame._colect[0] = new Collectable(new Vec2(898, 125), 30);
        myGame._colect[1] = new Collectable(new Vec2(1572, 436), 30);
        myGame._colect[2] = new Collectable(new Vec2(1678, 887), 30);


        EndCircle endCircle = new EndCircle(new Vec2(1812, 231), 50);
        AddChild(endCircle);
    }

}

