using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class CollectableSystem : Pivot {



    int[] stars;

    public CollectableSystem() {

        MyGame myGame = ((MyGame)game);
        int levels = myGame.GetLevelCount;

        stars = new int[levels];
    }




    //Change if levels start with 1 otherwise keep the same
    public void CheckStars(int index, int amountStars) { 
        if (amountStars > stars[index]) stars[index] = amountStars;

        for (int i = 0; i < stars.Length; i++)
        {
            Console.WriteLine(stars[i]);
        }
    }
}