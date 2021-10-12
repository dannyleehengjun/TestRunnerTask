using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testREINITIALIZE
{
    [UnityTest]
    public IEnumerator testREINITIALIZEWithEnumeratorPasses()
    {
        var texture = new Texture2D(32, 32, TextureFormat.RGBA32, false);
        Graphics.CopyTexture(Resources.Load<Texture2D>("Textures/TrueRed"), texture);

        Assert.AreEqual(32, texture.width);
        Assert.AreEqual(32, texture.height);

        texture.Reinitialize(64, 64);
        texture.Apply();

        yield return null;

        Assert.AreEqual(64, texture.width);
        Assert.AreEqual(64, texture.height);

    }
}
