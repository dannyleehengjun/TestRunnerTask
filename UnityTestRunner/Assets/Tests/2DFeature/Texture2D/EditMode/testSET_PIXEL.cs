using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testSET_PIXEL
{
    [UnityTest]
    public IEnumerator testSET_PIXELDATAWithEnumeratorPasses()
    {
        var texture = new Texture2D(32, 32, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(Resources.Load<Texture2D>("Textures/TrueRed"), texture);

        texture.SetPixel(10, 10, Color.white);
        texture.Apply();

        yield return null;

        var pixelColor = texture.GetPixel(10, 10);
        Assert.AreEqual(Color.white, pixelColor);
    }
}
