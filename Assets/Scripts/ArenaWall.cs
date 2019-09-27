using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWall : MonoBehaviour
{

    private Animator arenaAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //accesses the game object (arena) then calls the animator
        GameObject arena = transform.parent.gameObject;
        arenaAnimator = arena.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //sets IsLowered to true when the collider is triggered
    void OnTriggerEnter(Collider other)
    {
        arenaAnimator.SetBool("IsLowered", true);
    }

    //sets IsLowered to false when the player exits the collider
    void OnTriggerExit(Collider other)
    {
        arenaAnimator.SetBool("IsLowered", false);
    }
}
