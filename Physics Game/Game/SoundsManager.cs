using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class SoundManager : Pivot
{

    public Sound backgroundSound;
    SoundChannel channel;

    SoundChannel hover;
    bool switched = false;

    public bool hoverBool = false;
    Sound[] cloud = new Sound[8];

    Sound click;
    public SoundManager() {

        //       backgroundSound = new Sound("cloudsBG.mp3", true);
        //      backgroundSound.Play();

        click = new Sound("Sounds/Buttons/click.wav");
        LoadSounds();
        Sound hoverSound = new Sound("Sounds/Buttons/hover.wav", true);

       // hoverSound.Play();
        if (hover == null) hover = hoverSound.Play();
        hover.Volume = 0;


    }

    void LoadSounds() {
        for (int i = 0; i < 8; i++) cloud[i] = new Sound("Sounds/CloudCol/collision " + i.ToString() + ".wav");
    }

    public void SwitchBGSound(string soundswitch)
    {
        if (channel == null) channel = backgroundSound.Play();

        if (channel.Volume > 0 && !switched) channel.Volume -= 0.5f;
        else if (!switched)
        {
            switched = true;
            backgroundSound = new Sound(soundswitch);
            
        }
        else if (channel.Volume < 1) channel.Volume += 0.5f;



    }

    void Update() {
        if (hoverBool) HoverButtonStart();
        else HoverButtonEnd();
    }

    public void ShootSFX() {

        int i = Utils.Random(1, 7);

        string sound = "Sounds/Shoot/click" + i.ToString() + ".wav";

        Console.WriteLine(sound);
        Sound shoot = new Sound(sound);
        
        shoot.Play();

    }

    public void CloudSFX()
    {

        int i = Utils.Random(0, 8);

        

        cloud[i].Play();

    }

    public void RockSFX() {

        int i = Utils.Random(1, 8);

        string sound = "Sounds/RockCol/collision " + i.ToString() + ".wav";

        Console.WriteLine(sound);
        Sound shoot = new Sound(sound);

        shoot.Play();
        
    }

    public void ClickSFX() {

        click.Play();
    }

    
    public void HoverButtonStart() {

        if (hover.Volume < 2) hover.Volume += 0.1f;
        hoverBool = false;
        Console.WriteLine(hover.Volume);
    }
    public void HoverButtonEnd() {
        if (hover.Volume > 0) hover.Volume -= 0.1f;
    
    }

}