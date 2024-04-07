using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject Door;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //this function is where we will desing our interaction using code.
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        Door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
