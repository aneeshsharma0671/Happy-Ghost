using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemanager : MonoBehaviour
{
    public float timetoteleport=0f;
    private void Update()
    {
        timetoteleport += Time.deltaTime;
    }
}
