using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Levels : Scene
{
    public Cannon cannon;
    public EndUI endUI;
    private Pivot objectOwner;
    private SFXHandler sfxHandler;
    protected MyGame myGame;

    public Levels(Dictionary<string, Sound> soundLibrary) : base() {
        sfxHandler = new SFXHandler(soundLibrary, .2f);
    }


    protected override void Start()
    {
        isActive = true;
        objectOwner = new Pivot();
        myGame = (MyGame)game;

        MakeLevel();


        foreach (Ball _ball in myGame._movers)
        {
            AddChild(_ball);
        }

        foreach (LineSegment _line in myGame._lines)
        {
            AddChild(_line);
        }
        foreach (Collectable _col in myGame._colect)
        {
            AddChild(_col);
        }
        AddChild(objectOwner);
    }

    protected override void Update()
    {
        if (!base.isActive) return;

        if (Input.GetKeyDown(Key.F3))
        {
            LevelOne.levelOneBg.Stop();
            SceneManager.instance.TryLoadNextScene();
        }
    }

    public override void UnLoadScene()
    {
        base.UnLoadScene();
    }

    protected virtual void MakeLevel() { }
}



