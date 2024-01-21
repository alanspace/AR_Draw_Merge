using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PanoramaCapture : MonoBehaviour
{
    public Camera targetCamera;
    public RenderTexture cubeMapLeft;
    public RenderTexture equirectRT;

    string subdirectory = "Draw";
    string fullPath;

    // Start is called before the first frame update
    void Start()
    {
        fullPath = Path.Combine(Application.persistentDataPath, subdirectory);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Capture();
    }

    public void Capture()
    {
        targetCamera.RenderToCubemap(cubeMapLeft);
        cubeMapLeft.ConvertToEquirect(equirectRT);
        Save(equirectRT);
    }

    public void Save(RenderTexture rt)
    {
        Texture2D tex = new Texture2D(rt.width, rt.height);

        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        RenderTexture.active = null;

        byte[] bytes = tex.EncodeToJPG();

        string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_beta_drawing.jpg";
        string filePath = Path.Combine(fullPath, fileName);
        File.WriteAllBytes(filePath, bytes);

        Destroy(tex);
        Debug.Log("Image saved at: " + filePath);

        // Open the file using the default app associated with the file type
        Application.OpenURL("file://" + filePath);
    }
}
