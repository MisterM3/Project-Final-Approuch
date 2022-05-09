using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class EndUI : Pivot
{

    EasyDraw grayBG;
    Pivot endBox = new Pivot();
    EasyDraw Box;

    Sprite star1;
    Sprite star2;
    Sprite star3;
    Sprite star4;
    Sprite star5;
    Sprite star6;

    int stars;
    public EndUI(int Stars) {

        stars = Stars;

        grayBG = new EasyDraw(1920, 1080);
        grayBG.x = -1920 / 2.0f;
        grayBG.y = -1080 / 2.0f;
        grayBG.Fill(0);
        grayBG.Rect(1920 / 2.0f, 1080 / 2.0f, 1920, 1080);
        grayBG.alpha = 0;
        AddChild(grayBG);


        x = 1920 / 2.0f;
        y = 1080 / 2.0f;

        
        AddChild(endBox);


        Box = new EasyDraw(600, 600);
        Box.SetOrigin(300, 200);
        Box.Fill(System.Drawing.Color.Cyan);
        Box.Rect(300, 300, 600, 600);
        Box.y = -50;
        endBox.AddChild(Box);

         star1 = new Sprite("star_empty.png");
        star1.SetOrigin(star1.width / 2, star1.height / 2);
        star1.SetScaleXY(2.5f, 2.5f);
        star1.y = -125;
        endBox.AddChild(star1);

         star2 = new Sprite("star_empty.png");
        star2.SetOrigin(star2.width / 2, star2.height / 2);
        star2.SetScaleXY(2, 2);
        star2.SetXY(-125, -25);
        endBox.AddChild(star2);

         star3 = new Sprite("star_empty.png");
        star3.SetOrigin(star3.width / 2, star3.height / 2);
        star3.SetScaleXY(2, 2);
        star3.SetXY(125, -25);
        endBox.AddChild(star3);

        EasyDraw text = new EasyDraw(600, 100);
        text.SetOrigin(300, 50);
        text.Fill(0);
        text.TextSize(30);
        text.TextAlign(CenterMode.Center, CenterMode.Center);
        text.Text("You Did It, Twat!", 300, 50);
        text.y = 100;
        endBox.AddChild(text);

        endBox.SetScaleXY(0, 0);

        EasyDraw button1 = new EasyDraw(100, 100);
        button1.SetOrigin(50, 50);
        button1.Fill(0);
        button1.Rect(50, 50, 100, 100);
        button1.SetXY(-200, 250);
        endBox.AddChild(button1);

        EasyDraw button2 = new EasyDraw(180, 100);
        button2.SetOrigin(90, 50);
        button2.Fill(0);
        button2.Rect(100, 50, 180, 100);
        button2.SetXY(-40, 250);
        endBox.AddChild(button2);

        EasyDraw button3 = new EasyDraw(180, 100);
        button3.SetOrigin(90, 50);
        button3.Fill(0);
        button3.Rect(100, 50, 180, 100);
        button3.SetXY(160, 250);
        endBox.AddChild(button3);

         star4 = new Sprite("Star_Full.png");
        star4.SetOrigin(star4.width / 2, star4.height / 2);
        star4.SetScaleXY(2, 2);
        star4.SetXY(-125, -25);
        endBox.AddChild(star4);

         star5 = new Sprite("Star_Full.png");
        star5.SetOrigin(star5.width / 2, star5.height / 2);
        star5.SetScaleXY(2.5f, 2.5f);
        star5.y = -125;
        endBox.AddChild(star5);

         star6 = new Sprite("Star_Full.png");
        star6.SetOrigin(star6.width / 2, star6.height / 2);
        star6.SetScaleXY(2, 2);
        star6.SetXY(125, -25);
        endBox.AddChild(star6);

        star4.scale = 0;
        star5.scale = 0;
        star6.scale = 0;
    }

    float scale = 0;
   
    public void Update() {

        if (scale >= 0.999f) {
            scale = 1f;
            endBox.SetScaleXY(scale, scale);
            Stars();

        }
        else if (scale < 1)
        {

            scale = scale * 0.95f + 1f * 0.05f;
            endBox.SetScaleXY(scale, scale);
            Console.WriteLine(scale);
        }
        if (grayBG.alpha <= 0.5f) grayBG.alpha += 0.01f;

    }

    bool done1 = false;
    bool done2 = false;
    bool done3 = false;
    void Stars()
    {

        if (star4.scale < 1.99f && stars >= 1)
        {
            star4.scale = star4.scale * 0.95f + 2f * 0.05f;
            star4.SetScaleXY(star4.scale, star4.scale);
            Console.WriteLine("1");


        }
        else if (!done1 && stars >=1)
        {
            done1 = true;
            Console.WriteLine("dwaw");
            ((MyGame)game).PS.Boom(new Vec2(x + star4.x, star4.y + y), size: 3);
        }
        else if (star5.scale < 2.49 && stars >= 2)
        {

            star5.scale = star5.scale * 0.95f + 2.5f * 0.05f;
            star5.SetScaleXY(star5.scale, star5.scale);
            Console.WriteLine("2");

        }
        else if (!done2 && stars >= 2)
        {
            done2 = true;
            ((MyGame)game).PS.Boom(new Vec2(x + star5.x, star5.y + y), size: 3);
        }
        else if (star6.scale < 1.99f && stars >= 3)
        {
            star6.scale = star6.scale * 0.95f + 2f * 0.05f;
            star6.SetScaleXY(star6.scale, star6.scale);
            Console.WriteLine("3");
        }
        else if (!done3 && stars >= 3) {
            done3 = true;
            ((MyGame)game).PS.Boom(new Vec2(x + star6.x, star6.y + y), size: 3);

        }

    }





}
