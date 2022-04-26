using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
        SaveStars();
    }


    public void SaveStars() {


            if (!File.Exists("stars.txt"))
            {
                Console.WriteLine("No save file found!");
                return;
            }
            try
            {
                // StreamReader: For reading a text file - requires System.IO namespace:
                // Note: the "using" block ensures that resources are released (reader.Dispose is called) when an exception occurs
                using (StreamWriter writer = new StreamWriter("stars.txt"))
                {
                    for (int i = 0; i < stars.Length; i++) {
                        writer.WriteLine("Stars Level {0} = {1}", i, stars[i]);
                    }
                    
                    writer.Close();

                    Console.WriteLine("Saved from stars.txt successful.");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error while reading save file: {0}", error.Message);
            }

        }



    }
