using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera _camera;
    private float horizontalMultiplier = 21f / 1.4f;
    private float verticalMultiplier = 32f / -1.4f;

    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        var mousePos = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            _camera.nearClipPlane);
        var wp = _camera.ScreenToWorldPoint(mousePos);
        var angleHorizontal = Mathf.Atan2(wp.x, 1);
        var angleVerticle = Mathf.Atan2(wp.y, 1);
//        Debug.LogFormat("{0} {1}", angleHorizontal, angleVerticle);
        var angle = new Vector3(angleVerticle * verticalMultiplier, angleHorizontal * horizontalMultiplier, 0);
//        Debug.Log(angle);

        transform.rotation = Quaternion.Euler(angle);

//        var vp = camera.ScreenToViewportPoint(mousePos);
//        var sp = camera.ViewportToScreenPoint(vp);
//        transform.LookAt(wp);
    }
}