using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class testSET_PIXELDATA
{
    [UnityTest]
    public IEnumerator testSET_PIXELDATAWithEnumeratorPasses()
    {
        var texture = new Texture2D(32, 32, TextureFormat.RGBA32, true);
        var dummyPixelData = new Color32[texture.GetPixelData<Color32>(0).Length];

        for(int i = 0; i < dummyPixelData.Length; i++)
        {
            dummyPixelData[i] = new Color32(255, 0, 0, 255);
        }    

        texture.SetPixelData<Color32>(dummyPixelData, 0, 0);
        texture.Apply();
        
        yield return null;
        
        Assert.That(texture.GetPixelData<Color32>(0), Is.All.EqualTo((Color32)Color.red));
    }
}
