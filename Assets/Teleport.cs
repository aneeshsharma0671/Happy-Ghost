using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    private Transform doorfrom;
    public Transform doorto;
    private Animator animator;
    public int tourchNum;
    private Transform masterteleport;

    private void Start()
    {
        animator = GameObject.Find("Fade").GetComponent<Animator>();
        player = GameObject.Find("ghost");
        doorfrom = gameObject.transform;
        

    }
    private void Update()
    { 

        if(player.transform.position.x > (doorfrom.position.x - 1) && player.transform.position.x < (doorfrom.position.x + 1))
        {
            if (Input.GetKeyDown("w") && player.GetComponent<Timemanager>().timetoteleport > 1f)
            {
                animator.SetTrigger("fade");
                player.transform.position = doorto.position;
                player.GetComponent<Timemanager>().timetoteleport = 0f;

                if (GetComponent<Torch_controller>())
                {
                    GetComponent<Torch_controller>().Check(GetComponent<Torch_controller>().torcharr);
                    GetComponent<Torch_controller>().Torch_enable(GetComponent<Torch_controller>().torcharr, tourchNum);
                }
            }
        }
      
    }
    public void Teleportsp()
    {
        animator.SetTrigger("fade");
        masterteleport = GameObject.Find("Teleporter").GetComponentInChildren<Transform>();
        Debug.Log("masterTeleport");
        if(masterteleport)
        player.transform.position = masterteleport.position;
        player.GetComponent<Timemanager>().timetoteleport = 0f;
    }
}
