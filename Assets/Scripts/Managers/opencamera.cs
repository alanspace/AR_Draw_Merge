using UnityEngine;
//using UnityEngine.iOS;
using System.Collections;

// Get WebCam information from the browser
public class opencamera : MonoBehaviour
{
    private WebCamDevice[] devices;
    
    // Use this for initialization
    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("webcam found");
            devices = WebCamTexture.devices;
            for (int cameraIndex = 0; cameraIndex < devices.Length; ++cameraIndex)
            {
                Debug.Log("devices[cameraIndex].name: ");
                Debug.Log(devices[cameraIndex].name);
                Debug.Log("devices[cameraIndex].isFrontFacing");
                Debug.Log(devices[cameraIndex].isFrontFacing);
            }
        }
        else
        {
            Debug.Log("no webcams found");
        }
    }
}