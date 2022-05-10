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
    public Cannon(float pX, float pY, float pSpeed, int leftBound = -47, int rightBound = 56) : base("finalCannon.png")
    {
       
        SetOrigin(width / 2, height / 2);
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

        velocity = Vec2.GetUnitVectorDeg(rotation) * _speed;
        bulletPos = Vec2.GetUnitVectorDeg(rotation) * 100   + _position;
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
            ball.rotation = rotation;

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

    public void Update()
    {

        Controls();
        Shoot();
        UpdateSceenPosition();
    }
}
