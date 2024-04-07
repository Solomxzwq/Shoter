                         using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUi playerUi;
    private InputManger inputManger;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUi = GetComponent<PlayerUi>();
        inputManger = GetComponent<InputManger>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUi.UpdateText(string.Empty);
        //create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // variable to store our collision information.
        if(Physics.Raycast(ray, out hitInfo,distance,mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUi.UpdateText(interactable.promptMessage);
                if (inputManger.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }   
    }
}
