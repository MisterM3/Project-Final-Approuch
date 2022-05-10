using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class button : Sprite
{
    int scene;
    public button(Vec2 pPos, int pWidth, int pHeight, int pScene) : base("colors.png") {

        x = pPos.x;
        y = pPos.y;
        width = pWidth;
        height = pHeight;
        scene = pScene;
    }

    public void Update() {

        Hover();
    
    }

    void Hover() {

        if (Input.mouseX < width/2 && Input.mouseX > width/2 && Input.mouseY < height/2 && Input.mouseY > height/2)
        {
      //      _hover.alpha = 1;

            if (Input.GetMouseButtonDown(0)) SceneManager.instance.LoadScene(scene);
        }
        //else _hover.alpha = 0;
    }

} 