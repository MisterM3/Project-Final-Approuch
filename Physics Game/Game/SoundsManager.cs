using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class SoundManager : Pivot
{

    public Sound backgroundSound;
    public SoundChannel channel;

    bool switched = false;
    public SoundManager() {

 //       backgroundSound = new Sound("cloudsBG.mp3", true);
  //      backgroundSound.Play();
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


    public void ShootSFX() {

        int i = Utils.Random(1, 7);

        string sound = "Sounds/Shoot/click" + i.ToString() + ".wav";

        Console.WriteLine(sound);
        Sound shoot = new Sound(sound);
        
        shoot.Play();

    }

    public void CloudSFX()
    {

        int i = Utils.Random(1, 9);

        string sound = "Sounds/CloudCol/collision " + i.ToString() + ".wav";

        Console.WriteLine(sound);
        Sound shoot = new Sound(sound);

        shoot.Play();

    }

    public void RockSFX() {

        int i = Utils.Random(1, 8);

        string sound = "Sounds/RockCol/collision " + i.ToString() + ".wav";

        Console.WriteLine(sound);
        Sound shoot = new Sound(sound);

        shoot.Play();
    }

}