using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Powers : Sprite {

    public Powers(Vec2 pPos) : base("circle.png") { 
    
        SetOrigin(width/2, height/2);
   //     x = pPos.x;
    //    y = pPos.y;

        x = 200;
        y = 300;
        Console.WriteLine(y);
         
    }


    void Update() {


        MyGame myGame = ((MyGame)game);

        for (int i = 0; i < myGame.GetNumberOfMovers(); i++)
        {
            Ball mover = myGame.GetMover(i);


            Vec2 pos = new Vec2(x, y);
            Vec2 relPos = mover.position - pos;

            if (relPos.Length() <= 0.1f) mover.velocity.SetAngleDeg(90);

        }
     
    }
}