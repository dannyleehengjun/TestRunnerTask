using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testSET_PIXELS32
{
    [UnityTest]
    public IEnumerator testSET_PIXELS32WithEnumeratorPasses()
    {
        var texture = new Texture2D(32, 32, TextureFormat.RGBA32, true);

        var dummyPixels = new Color32[texture.GetPixels().Length];

        for (int i = 0; i < dummyPixels.Length; i++)
        {
            dummyPixels[i] = Color.red;
        }

        texture.SetPixels32(dummyPixels);
        texture.Apply();

        yield return null;

        Assert.That(texture.GetPixels32(), Is.All.EqualTo((Color32)Color.red));
    }
}
