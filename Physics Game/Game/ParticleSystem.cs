using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class ParticleSystem : Pivot {

    int particles = 50;

    

    public ParticleSystem()
    {
        x = 400;
        y = 300;
    }

    public void Update() {

        if (Input.GetKeyDown(Key.E))
        {
            // Boom();
            // Cone(180.0f, 45.0f);
            Regen();
            Console.WriteLine("boom");
        }
        else if (Input.GetKeyDown(Key.F))
        {
            Boom();
        }
        else if (Input.GetKeyDown(Key.D)) {
            Cone(180.0f, 45.0f);
        }
    }
    public void Boom() {

        //for (int i = 0; i < particles; i++) {
        //    Particle ball = new Particle(10, new Vec2(400,300));
        //    ball.velocity = new Vec2(Utils.Random(-3.0f, 3.0f), Utils.Random(-3.0f, 3.0f));
        //    parent.AddChild(ball);
        //}

        for (int i = 0; i < particles; i++)
        {
            Particle ball = new Particle(10, new Vec2(400, 300));

            ball.velocity = Vec2.RandomUnitVector();
            ball.velocity *= Utils.Random(0, 5.0f);

            //ball.velocity = new Vec2(Utils.Random(-3.0f, 3.0f), Utils.Random(-3.0f, 3.0f));
            parent.AddChild(ball);
        }
    }

    public void Cone(float middleDeg, float turnDeg) {
        for (int i = 0; i < particles; i++)
        {
            Particle ball = new Particle(10, new Vec2(400, 300));

            float angle = middleDeg + Utils.Random(-turnDeg, turnDeg);
            ball.velocity = new Vec2(0, 1);
            ball.velocity.SetAngleDeg(angle);
            ball.velocity *= Utils.Random(0, 5.0f);

            //ball.velocity = new Vec2(Utils.Random(-3.0f, 3.0f), Utils.Random(-3.0f, 3.0f));
            parent.AddChild(ball);
        }


    }

    public void Regen() {
        for (int i = 0; i < particles;  i++)
        {
            Particle ball = new Particle(10, new Vec2(400, 300));

            ball.velocity = Vec2.RandomUnitVector();
            ball.velocity *= Utils.Random(0, 5.0f);

            //ball.velocity = new Vec2(Utils.Random(-3.0f, 3.0f), Utils.Random(-3.0f, 3.0f));
            parent.AddChild(ball);
            ball.regen = true;
        }

    }

    public void SpawnRandom() {
        Particle ball = new Particle(10, new Vec2(400, 300));

        ball.velocity = Vec2.RandomUnitVector();
        ball.velocity *= Utils.Random(0, 5.0f);

        parent.AddChild(ball);
        ball.regen = true;

    }

}