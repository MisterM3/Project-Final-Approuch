﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Fade : Pivot {

    EasyDraw grayBG;

     bool fadeIn = false;

     int scene;
    public Fade()
    {
        grayBG = new EasyDraw(1920, 1080);
 
        grayBG.Fill(0);
        grayBG.Rect(1920 / 2.0f, 1080 / 2.0f, 1920, 1080);
        grayBG.alpha = 1;
        AddChild(grayBG);
    }

    public void Update() {

        if (fadeIn) FadeIn();
        else FadeOut();
    }

    public void FadeIn() {
        if (grayBG.alpha < 1) grayBG.alpha += 0.05f;
        else
        {
            Console.WriteLine(grayBG.alpha);
            fadeIn = false;
            SceneManager.instance.LoadScene(scene);
        }
        
        
    }

    public void SwitchScenes(int pScene) { 
    fadeIn = true;
    scene = pScene;
    }

    public void FadeOut() {
        if (grayBG.alpha > 0) grayBG.alpha -= 0.05f;
    }
}
