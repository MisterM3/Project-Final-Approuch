using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Clouds : Pivot {

    LineSegment[] lines = new LineSegment[4];
    Ball[] caps = new Ball[4];

    MyGame myGame;

    //pRot is in Deg
    public Clouds(Vec2 pBottomLeft, Vec2 pBottomRight, Vec2 pTopLeft, Vec2 pTopRight, float pRot = 0) : base()
    {


        lines[0] = new LineSegment(pTopLeft, pBottomLeft);
        lines[1] = new LineSegment(pBottomLeft, pBottomRight);
        lines[2] = new LineSegment(pBottomRight, pTopRight);
        lines[3] = new LineSegment(pTopRight, pTopLeft);

        caps[0] = new Ball(0, pTopLeft, moving: false);
        caps[1] = new Ball(0, pBottomLeft, moving: false);
        caps[2] = new Ball(0, pBottomRight, moving: false);
        caps[3] = new Ball(0, pTopRight, moving: false);




        myGame = ((MyGame)game);
        for (int i = 0; i < lines.Length; i++) myGame.addLine(lines[i]);
        for (int i = 0; i < caps.Length; i++) myGame.addMover(caps[i]);
    }

    public void Update() {


        for (int i = 0; i < lines.Length; i++) {

            for (int j = 0; j < myGame.GetNumberOfMovers(); j++) {

                Ball mover = myGame.GetMover(j);

                if (mover.moving && mover.latestCollision == lines[i]) {
                    DeleteCloud();
                }
            }
        }
    }


    public void DeleteCloud() {

        for (int i = 0; i < lines.Length; i++)
        {
            myGame.RemoveLine(lines[i]);
            lines[i] = null;

        }
        
        for (int i = 0; i < caps.Length; i++) myGame.RemoveBalls(caps[i]);
       this.LateDestroy();

    }
}