﻿using System;
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

    public int ballsActive = 0;
    Pause_FailUI pauseMenu;

    bool paused = false;

    public Levels(Dictionary<string, Sound> soundLibrary) : base() {
        sfxHandler = new SFXHandler(soundLibrary, .2f);
    }


    protected override void Start()
    {
        isActive = true;
        objectOwner = new Pivot();
        myGame = (MyGame)game;
        ballsActive = 0;
        MakeLevel();
        pauseMenu = new Pause_FailUI(true);
        


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
        Test();
        if (Input.GetKeyDown(Key.F3))
        {
            LevelOne.levelOneBg.Stop();
            SceneManager.instance.TryLoadNextScene();
        }
        if (Input.GetKeyDown(Key.TAB)) Pause();
     
    }

    void Pause() {

        if (!((MyGame)game).frozen || paused)paused = !paused;


        if (paused)
        {
            AddChild(pauseMenu);
            pauseMenu.paused = true;
            ((MyGame)game).frozen = true;
        }
        else
        {
            ((MyGame)game).frozen = false;
            pauseMenu.paused = false;
        }
    }

    public override void UnLoadScene()
    {
        paused = false;
        base.UnLoadScene();
    }

    protected virtual void MakeLevel() { }
    protected virtual void Test() { }

}



