using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
    public static bool IsRolling;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5) Destroy(gameObject);
    }
}