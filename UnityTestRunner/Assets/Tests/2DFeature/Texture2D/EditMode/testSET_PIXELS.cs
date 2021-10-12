using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testSET_PIXELS
{
    [UnityTest]
    public IEnumerator testSET_PIXELSWithEnumeratorPasses()
    {
        var texture = new Texture2D(32, 32, TextureFormat.RGBA32, true);

        var dummyPixels = new Color[texture.GetPixels().Length];

        for(int i = 0; i < dummyPixels.Length; i++)
        {
            dummyPixels[i] = Color.red;
        }

        texture.SetPixels(dummyPixels);
        texture.Apply();

        yield return null;

        Assert.That(texture.GetPixels(), Is.All.EqualTo(Color.red));
    }
}
