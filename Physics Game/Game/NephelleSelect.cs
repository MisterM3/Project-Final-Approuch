using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class LevelSelect : Scene {


    public enum Worlds { Nephelle, Bethel };

    Worlds _world;

    Sprite _backGround;
    Sprite _bottom;
    Sprite _hover;
    Sprite starEmpty = new Sprite("star_empty.png");
    Sprite starEmpty2 = new Sprite("star_empty.png");
    Sprite starFull = new Sprite("Star_Full.png");

    Vec2 stabalise = new Vec2(580, 515);
    public LevelSelect(Worlds pWorld) {

       _world = pWorld;
        CheckWorld();

        ImportSprites();
        MakeWorld();
    }

    public void CheckWorld() {


        switch (_world) {
            case Worlds.Nephelle:
                Console.WriteLine("World is Nephelle");
                break;
            case Worlds.Bethel:
                Console.WriteLine("World is Bethel");
                break;
            default:
                Console.WriteLine("World doesn't exist!");
               break;
        }
    }

    public void ImportSprites() {

        switch (_world)
        {
            case Worlds.Nephelle:
                _backGround = new Sprite("test1.png");
                _hover = new Sprite("backgroundHover.png");
                _bottom = new Sprite("level1.png");
                break;
            case Worlds.Bethel:
                Console.WriteLine("World Bethel is not implemented yet!");
                break;
            default:
                Console.WriteLine("World doesn't exist!");
                break;
        }
    }

    void MakeWorld() {

       AddChild(_backGround);
        BottonLevel Level1 = new BottonLevel(new Vec2(577, 526), Worlds.Nephelle, 1);
        AddChild(Level1);


        //_hover.SetOrigin(_hover.width/2, _hover.height/2);
        //_hover.SetXY(573, 528);
        //AddChild(_hover);

        //_bottom.SetOrigin(_bottom.width/2, _bottom.height/2);
        //_bottom.SetXY(577, 526);
        //AddChild(_bottom);

        //starEmpty.SetOrigin(_st)
    
    
    }







}