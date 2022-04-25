using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;



public class Inventory : EasyDraw {

    EasyDraw l = new EasyDraw(800, 300);
    
    List<Lines> linesInInventory = new List<Lines>();


    public bool lineActive = false;
    public Inventory() : base(800, 300) {
        Fill(122);
        Rect(400, 0, 800, 300);

        Fill(0);
        Rect(75, 75, 100, 100);

        Fill(0);
        Rect(225, 75, 100, 100);

        Fill(0);
        Rect(375, 75, 100, 100);

        l.Fill(255);
        l.Line(50, 50, 100, 100);
        AddChild(l);
        Lines line = new Lines(new Vec2(200, 200), new Vec2(400, 400));
        linesInInventory.Add(line);
    }

    void Update() { 
    
        if (Input.GetMouseButtonDown(0) && Input.mouseX > 50 && Input.mouseY > 50 && Input.mouseX < 100 && Input.mouseY < 100 ) {
            l.alpha = 0;


            ((MyGame)game).AddLines(new Vec2(200, 200), new Vec2(400, 400));
        
        }

        
    }
}