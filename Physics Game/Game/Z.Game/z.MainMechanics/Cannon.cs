using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
public class Cannon : Sprite
{


    public int shots = 3;
    //public fields
    float _speed = 1;
    public Vec2 position
    {

        get
        {
            return _position;
        }
    }


    //private fields
    Vec2 _position;
    Vec2 bulletPos;
    Vec2 velocity;

    int left;
    int right;

    Sprite sprite;
    public Cannon(float pX, float pY, float pSpeed, int leftBound = -47, int rightBound = 56) : base("cannon.png")
    {
        SetOrigin(width / 3, height / 2);
        width = width / 4;
        height = height / 4;
        _position.x = pX;
        _position.y = pY;
        _speed = pSpeed;

        left = leftBound;
        right = rightBound;

    }

    void Controls()
    {

        
        float angleRotation = rotation * Mathf.PI / 180;

        if (Input.GetKey(Key.LEFT))
        {
            rotation--;
        }

        if (Input.GetKey(Key.RIGHT))
        {
            rotation++;
        }

        if(rotation < left)
        {

            rotation = left;
        }

        if(rotation > right)
        {
            rotation = right;
        }

        velocity = Vec2.GetUnitVectorDeg(rotation - 14) * _speed;
        bulletPos = Vec2.GetUnitVectorDeg(rotation - 14) * 100 + _position;

      
    }

    void Shoot()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(Key.SPACE)) && shots > 0)
        {
            ((MyGame)game).soundLibrary["Shoot"].Play(false, 0, .1f);
            bulletPos.y -= 50;
            Package ball = new Package(bulletPos, velocity);
            ((MyGame)game)._movers.Add(ball);
            parent.AddChild(ball);
            ball.rotation = rotation ;

        //   HUD _hud = ((MyGame)game).GetHUD;
            shots--;
        //    _hud.UpdateShots();
        }

    }

    void UpdateSceenPosition()
    {
        x = _position.x;
        y = _position.y;

    }

    public void FollowMouse()
    {
       

    }

    Ball[] aimLine = new Ball[8];
    public void GEQOLL() {

        int balls = 4;
        float alpha = 1.0f;
        if (aimLine[0] == null) {
            for (int i = 0; i < aimLine.Length; i++) {
                Ball b = new Ball(20 - (2 * i), new Vec2(0, 0), new Vec2(0, 0), moving: false, tr: true);
                b.alpha -= i * 0.1f;
                aimLine[i] = b;
                parent.AddChild(b);
            }
        }

        if (aimLine[0] != null) {
            for (int i = 0; i < aimLine.Length; i++) { 
                aimLine[i].position = Vec2.GetUnitVectorDeg(rotation - 14) * (225 + 50 * i) + _position;
            }
         
        }
    }

    public void Update()
    {

        Controls();
        GEQOLL();
        Shoot();
        UpdateSceenPosition();

    }
}
