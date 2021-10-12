using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testGET_PIXELS
{
    [Test]
    public void testGET_PIXELSSimplePasses()
    {
        //Red
        var texture = Resources.Load<Texture2D>("Textures/TrueRed");

        var pixelColor = texture.GetPixels();

        Assert.That(pixelColor, Is.All.EqualTo(Color.red));

        //MultiColor
        texture = Resources.Load<Texture2D>("Textures/MultiColor");

        pixelColor = texture.GetPixels();
        

        for (int i = 0; i < pixelColor.Length; i++)
        {
            //red
            if (i%32 >= 0 && i%32 <= 7)
                Assert.AreEqual(Color.red, pixelColor[i]);
            //green
            if (i % 32 >= 8 && i % 32 <= 15)
                Assert.AreEqual(Color.green, pixelColor[i]);
            //blue
            if (i % 32 >= 16 && i % 32 <= 23)
                Assert.AreEqual(Color.blue, pixelColor[i]);
            //white
            if (i % 32 >= 24 && i % 32 <= 27)
                Assert.AreEqual(Color.white, pixelColor[i]);
            //black
            if (i % 32 >= 28 && i % 32 <= 31)
                Assert.AreEqual(Color.black, pixelColor[i]);
        }
    }
}
