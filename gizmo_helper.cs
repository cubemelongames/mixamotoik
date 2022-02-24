using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmo_helper : MonoBehaviour
{
    public Color col = Color.blue;
    void OnDrawGizmos()
    {
        Gizmos.color = col;
        Gizmos.DrawSphere(transform.position, .03f);
    }
}
