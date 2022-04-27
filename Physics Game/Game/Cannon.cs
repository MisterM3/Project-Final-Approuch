using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
public class Cannon : Sprite
{
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
    public Cannon(float pX, float pY, float pSpeed, int pRadius = 100) : base("cannonSmall.png")
    {
       
        SetOrigin(width / 2, height / 2);
        _position.x = pX;
        _position.y = pY;  
        _speed = pSpeed; 
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

        if(rotation < -47)
        {

            rotation = -47;
        }

        if(rotation > 56)
        {
            rotation = 56;
        }

        velocity = Vec2.GetUnitVectorDeg(rotation) * _speed;
        bulletPos = Vec2.GetUnitVectorDeg(rotation) * 100   + _position;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Package ball = new Package(bulletPos, velocity);
            ((MyGame)game)._movers.Add(ball);
            parent.AddChild(ball);
            ball.rotation = rotation;
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
