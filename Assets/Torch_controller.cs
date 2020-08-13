using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Torch_controller : MonoBehaviour
{
    public ParticleSystem[] torcharr;

    private void Start()
    {
        for (var i = 0; i < 4; i++)
        {
           torcharr[i] = GameObject.Find("torch" + (i+1)).GetComponentInChildren<ParticleSystem>();
        }
    }
    public void Torch_enable(ParticleSystem[] arr,int tourchno)
    {
        for (int i = tourchno; i < 4; i++)
        {
            var emit = arr[i - 1].emission;
            if(emit.enabled)
            {
                Debug.Log("disable");
                Torch_Disable(arr);
            }
        }
        var emission = arr[tourchno-1].emission;
        emission.enabled = true;
    }
    public void Torch_Disable(ParticleSystem[] arr)
    {
        for (int i = 0; i < 4; i++)
        {
            var emission = arr[i].emission;
            emission.enabled = false;
        }
        
    }
    public void Check(ParticleSystem[] arr)
    {
        bool check=true;
        for (int i = 0; i < 4; i++)
        {
            var emission = arr[i].emission;
            if(!emission.enabled)
            {
                check = false;
            }
        }
        if (check)
        {
            GetComponent<Teleport>().Teleportsp();
        }
    }
}
