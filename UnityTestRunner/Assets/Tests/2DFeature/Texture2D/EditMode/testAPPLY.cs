using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testAPPLY
{
    [UnityTest]
    public IEnumerator testAPPLYWithEnumeratorPasses()
    {
        var texture = new Texture2D(32,32, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(Resources.Load<Texture2D>("Textures/TrueRed"), texture);

        texture.SetPixel(10, 10, Color.white);
        var pixelColor = texture.GetPixel(10, 10);
        texture.Apply();

        yield return null;

        Assert.AreEqual(Color.white, pixelColor);
    }
}
