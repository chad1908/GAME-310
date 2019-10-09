using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Alien : MonoBehaviour {

    public Transform target;
    public float navigationUpdate;
    private float navigationTime = 0;
    private NavMeshAgent agent;
    public UnityEvent OnDestroy;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        navigationTime += Time.deltaTime;
        if (navigationTime > navigationUpdate)
        {
            agent.destination = target.position;
            navigationTime = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //calls public void die() and destroys the game object
        Die();
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
    }

    //this destroys the alien
    public void Die()
    {
        OnDestroy.Invoke();     //notifies all listeners including gameobject of the aliens death
        OnDestroy.RemoveAllListeners();
        Destroy(gameObject);
    }
}
