using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebcamFunc : MonoBehaviour
{
    public bool camAvaliable { get; set; }
    public WebCamTexture cam { get; set; }
    public Texture defaultTexture { get; set; }

    public RawImage background;
    public AspectRatioFitter fit;

    public MeshRenderer meshRenderer;

    void Start()
    {
        defaultTexture = background.texture;

        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("No cameras");
            camAvaliable = false;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                cam = new WebCamTexture(devices[i].name, Screen.width,Screen.height);
            }
        }
        if (cam == null)
        {
            Debug.Log("No cam");
            return;
        }

        cam.Play();
        background.texture = cam;
        camAvaliable = true;
        meshRenderer.material.mainTexture = cam;

    }

    void Update()
    {
        if (camAvaliable)
        {

            var ratio = (float)cam.width / (float)cam.height;
            fit.aspectRatio = ratio;

            var scaleY = cam.videoVerticallyMirrored ? -1f : 1f;
            background.rectTransform.localScale = new Vector3(1, scaleY, 1f);

            var orient = -cam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        }
    }
}
