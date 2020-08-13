using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class SpawnSpider : MonoBehaviour
{

    public float interval;
    private float t=0f;
    public GameObject Prefab;

    private void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        t = t + Time.deltaTime;
      //  Debug.Log(t);
        if(t> interval)
        {
            Debug.Log("spawn");
            t = 0f;
         Instantiate(Prefab,gameObject.transform);

        }
    }
}
