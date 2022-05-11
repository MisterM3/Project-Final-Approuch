using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
public class StartScreen : Scene
{

    Sprite truck;
    EasyDraw exitButton;
    public StartScreen()
    {
        ((MyGame)game).GetCurrentScene = 0;
        ((MyGame)game).GetCurrentLevel = 0;
        Sprite background = new Sprite("BGN.jpg");
        background.width = 1920;
        background.height = 1080;

        Sprite alien = new Sprite("cillus.jpg");
        alien.SetXY(200, 200);
        alien.scale = 0.3f;

        truck = new Sprite("truck.png");
        truck.SetXY(500, 500);
        truck.width = 500;
        truck.height = 250;

        exitButton = new EasyDraw(300,200,false);

        exitButton.SetXY(1500, 600);
        exitButton.TextSize(50);
        exitButton.Text("EXIT");
        
       

        AddChild(background);
        AddChild(alien);
        AddChild(truck);
        AddChild(exitButton);
    }

    
    protected override void Update()
    {
        if (((MyGame)game).GetCurrentScene == 0)
        {
            if(Input.mouseX >= truck.x + 70 && Input.mouseX <= truck.x + truck.width - 70 && Input.mouseY >= truck.y + 70 && Input.mouseY <= truck.y + truck.height - 70)
            {
                if (Input.GetMouseButtonDown(0)) SceneManager.instance.LoadScene(((MyGame)game).GetCurrentScene + 1);
            }

            if(Input.mouseX >= exitButton.x && Input.mouseX <= exitButton.x  + exitButton.width - 130 && Input.mouseY >= exitButton.y + 120 && Input.mouseY <= exitButton.y + exitButton.height - 20)
            {
                Console.WriteLine("Over Button");
                if (Input.GetMouseButtonDown(0)) game.Destroy();
            }
        }
    }
}
