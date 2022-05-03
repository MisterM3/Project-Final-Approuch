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
                _backGround = new Sprite("World1BG.png");
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

    
    
    }





}