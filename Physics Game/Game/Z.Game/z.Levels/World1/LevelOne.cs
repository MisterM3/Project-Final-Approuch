using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using System.Drawing;
public class LevelOne : Levels
{
    public LevelOne(Dictionary<string, Sound> soundLibrary) : base(soundLibrary)
    {
    }

    protected override void MakeLevel()
    {
  
        //Cannon
        cannon = new Cannon(game.height / 2 - 275, game.height / 2 + 50 - 150, 10);
        AddChild(cannon);

        myGame._lines.Add(new LineSegment(new Vec2(50, 50), new Vec2(750, 50)));
        myGame._lines.Add(new LineSegment(new Vec2(750, 50), new Vec2(750, 550)));
        myGame._lines.Add(new LineSegment(new Vec2(750, 550), new Vec2(50, 550)));
        myGame._lines.Add(new LineSegment(new Vec2(50, 550), new Vec2(50, 50)));

        



        //Bottom left part
        myGame._lines.Add(new LineSegment(new Vec2(200, 375), new Vec2(50, 375)));
        myGame._lines.Add(new LineSegment(new Vec2(225, 550), new Vec2(225, 400)));
        myGame._movers.Add(new Ball(25, new Vec2(200, 400), moving: false));

        myGame._lines.Add(new LineSegment(new Vec2(750, 540), new Vec2(225, 480)));



        //Side lines
        myGame._lines.Add(new LineSegment(new Vec2(0, 200), new Vec2(200, 0)));
        myGame._lines.Add(new LineSegment(new Vec2(600, 0), new Vec2(800, 200)));
        myGame._lines.Add(new LineSegment(new Vec2(200, 0), new Vec2(0, 200)));
        myGame._lines.Add(new LineSegment(new Vec2(800, 400), new Vec2(600, 600)));



        //Middle part

        myGame._lines.Add(new LineSegment(new Vec2(590, 420), new Vec2(585, 200)));
        myGame._lines.Add(new LineSegment(new Vec2(515, 200), new Vec2(530, 420)));

        myGame._movers.Add(new Ball(35, new Vec2(550, 200), moving: false));
        myGame._movers.Add(new Ball(30, new Vec2(560, 420), moving: false));

        //Collectables

        myGame._colect[0] = new Collectable(new Vec2(460, 123), 30);
        myGame._colect[1] = new Collectable(new Vec2(422, 452), 30);
        myGame._colect[2] = new Collectable(new Vec2(660, 293), 30);


        //Enemy
        myGame._movers.Add(new Enemy2Way(10, new Vec2(627, 220), new Vec2(705, 220)));


        EndCircle endCir = new EndCircle(new Vec2(300, 400), 50);
        AddChild(endCir);

    }

}

