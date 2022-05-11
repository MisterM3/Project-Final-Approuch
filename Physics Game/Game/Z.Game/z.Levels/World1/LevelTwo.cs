using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;

public class LevelTwo : Levels
{
    Sprite newCloud1;
    Sprite newCloud2;

    public LevelTwo(Dictionary<string, Sound> soundLibrary) : base(soundLibrary)
    {
       
    }

    protected override void MakeLevel()
    {
         newCloud1 = new Sprite("cloudHorizontal.png");
         newCloud2 = new Sprite("cloudHorizontal.png");

        ((MyGame)game).GetCurrentLevel = 1;
        ((MyGame)game).GetCurrentScene = 2;
        Sprite bg = new Sprite("2.png");

        bg.width = 1920;
        bg.height = 1080;
        AddChild(bg);




        Sprite wires = new Sprite("wires.png");

        wires.SetOrigin(wires.width / 2, wires.height / 2);
        wires.SetXY(260, 581);
        wires.rotation = 39;
        wires.width = wires.width / 4;
        wires.height = wires.height / 4;
        AddChild(wires);

        cannon = new Cannon(wires.x - 40, wires.y - 31, 15, -75, 38);
        AddChild(cannon);

        Fan fan = new Fan(new Vec2(1377, 938), 1000, 120, 180, pPower: 1f);
        AddChild(fan);

        //myGame._endCircle = new EndCircle(new Vec2(400, 300));
        //AddChild(myGame._endCircle);

        //LineSegment ln = new LineSegment(new Vec2(333, 381), new Vec2(290, 441));
        //myGame._lines.Add(ln);


        //Button but = new Button(new Vec2(200, 100), ln);
        //AddChild(but);




        //Walls
        Clouds cloud1 = new Clouds(new Vec2(0, 1080), new Vec2(500, 1080), new Vec2(0, 753), new Vec2(500, 753), pWall: true);
        AddChild(cloud1);
        Clouds cloud2 = new Clouds(new Vec2(500, 808), new Vec2(760, 808), new Vec2(500, 764), new Vec2(760, 764), pWall: true);
        AddChild(cloud2);
       
        Clouds cloud3 = new Clouds(new Vec2(500, 1080), new Vec2(1920, 1080), new Vec2(500, 1040), new Vec2(1920, 1040), pWall: true);
        AddChild(cloud3);

        Clouds cloud4 = new Clouds(new Vec2(1870, 1080), new Vec2(1920, 1080), new Vec2(1870, 0), new Vec2(1920, 0), pWall: true);
        AddChild(cloud4);
        Clouds cloud5 = new Clouds(new Vec2(0, 40), new Vec2(1920, 40), new Vec2(0, 0), new Vec2(1920, 0), pWall: true);
        AddChild(cloud5);

        Clouds cloud6 = new Clouds(new Vec2(0, 765), new Vec2(60, 770), new Vec2(0, 30), new Vec2(50, 30), pWall: true);
        AddChild(cloud6);
        Clouds cloud7 = new Clouds(new Vec2(50, 343), new Vec2(370, 40), new Vec2(0, 300), new Vec2(321, 0), pWall: true);
        AddChild(cloud7);
        Clouds cloud8 = new Clouds(new Vec2(395, 377), new Vec2(726, 377), new Vec2(395, 320), new Vec2(726, 320), pWall: true);
        AddChild(cloud8);

        //Clouds
        Clouds cloud9 = new Clouds(new Vec2(941, 518), new Vec2(983, 518), new Vec2(941, 183), new Vec2(983, 183));
        AddChild(cloud9);

        //Button + Line

        LineSegment ln = new LineSegment(new Vec2(756, 1036), new Vec2(756, 806));
        myGame.addLine(ln);

        MovablePlatform mp = new MovablePlatform(new Vec2(1437, 699), new Vec2(1661, 476), new Vec2(1412, 673), new Vec2(1636, 452), new Vec2(167, -178), true);
        AddChild(mp);

        Button but = new Button(new Vec2(1440, 80), ln, 160, 80);
        AddChild(but);

        //Collectables
        myGame._colect[0] = new Collectable(new Vec2(1566, 269), 33);
        myGame._colect[1] = new Collectable(new Vec2(966, 644), 33);
        myGame._colect[2] = new Collectable(new Vec2(562, 186), 33);


        //EndCircle
        EndCircle endcircle = new EndCircle(new Vec2(610, 931), 100);
        AddChild(endcircle);
    }

}

