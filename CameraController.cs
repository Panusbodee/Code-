using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothVertical;

    public float sensitive = 5.0f;
    public float smoothing = 2.0f;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitive * smoothing, sensitive * smoothing));

        smoothVertical.x = Mathf.Lerp(smoothVertical.x, md.x, 1f / smoothing);
        smoothVertical.y = Mathf.Lerp(smoothVertical.y, md.y, 1f / smoothing);

        mouseLook += smoothVertical;

        this.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);


    }
}
