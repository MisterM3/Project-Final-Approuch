using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class BottonLevel : Pivot
{
    
    Sprite _bottom;
    Sprite _hover;
    Sprite starEmpty = new Sprite("star_empty.png");
    Sprite starFull = new Sprite("Star_Full.png");
    Sprite number = new Sprite("number1.png");

    LevelSelect.Worlds _world;

    public BottonLevel(Vec2 pPos, LevelSelect.Worlds pWorld, int pLevel) : base() {

        
        x = pPos.x;
        y = pPos.y;
        _world = pWorld;
        ImportSprites();
        ImportNumber();
        MakeButton();
    }


    public void ImportSprites() {

        switch (_world)
        {
            case LevelSelect.Worlds.Nephelle:
                _hover = new Sprite("backgroundHover.png");
                _bottom = new Sprite("level1.png");
                break;
            case LevelSelect.Worlds.Bethel:
                Console.WriteLine("World Bethel is not implemented yet!");
                break;
            default:
                Console.WriteLine("World doesn't exist!");
                break;
        }
    }

    public void MakeButton() {

    


        _hover.SetOrigin(_hover.width / 2, _hover.height / 2);
        _hover.SetXY(-4, 2);
        _hover.alpha = 0;
        AddChild(_hover);

        _bottom.SetOrigin(_bottom.width / 2, _bottom.height / 2);
        _bottom.SetXY(0, 0);
        AddChild(_bottom);

        number.SetOrigin(number.width / 2, number.height / 2);
        number.SetXY(-1,-8);
        AddChild(number);
    }

    public void ImportStars() { 
    
    }

    public void ImportNumber() { 
    
    
    }

    void Update()
    {
        if (Input.GetKey(Key.G)) number.y++;
        if (Input.GetKey(Key.T)) number.y--;
        if (Input.GetKey(Key.F)) number.x--;
        if (Input.GetKey(Key.H)) number.x++;

        if (Input.GetKey(Key.V)) Console.WriteLine(new Vec2(number.x, number.y));

        if (Input.GetKey(Key.W)) _hover.alpha = 1;
    }
} 