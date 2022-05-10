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

        backgroundSound = new Sound("cloudsBG.mp3", true);
        backgroundSound.Play();
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

}