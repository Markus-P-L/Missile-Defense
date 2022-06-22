using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCollider : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mousePos).x, 0, 0);
    }
}
