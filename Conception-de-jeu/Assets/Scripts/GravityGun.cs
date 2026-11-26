using UnityEngine;
using UnityEngine.InputSystem;

public class GravityGun : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDistance = 10f, throwforce = 20f, lerpSpeed = 10f;
    [SerializeField] Transform objectHolder;

    Rigidbody grabbedRB;

    private InputAction grabInput;
    private InputAction pushInput;

    void Start()
    {
        grabInput = InputSystem.actions.FindAction("Attack");
        pushInput = InputSystem.actions.FindAction("Push");
    }


    void Update()
    {
        if (grabbedRB) 
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));

            if (pushInput.IsPressed()) 
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(cam.transform.forward * throwforce, ForceMode.VelocityChange);
                grabbedRB = null;
            }


        }

        if (grabInput.IsPressed()) 
        {
            if (grabbedRB) 
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            } else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if(Physics.Raycast(ray, out hit, maxGrabDistance)) 
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB) 
                    {
                        grabbedRB.isKinematic = true;
                    }
                }

            }
        }
    }
}
