using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContorllerScript : MonoBehaviour
{
    private CharacterController characterControll;
    private Animator anim;
    private float speed;
    private Vector3 direction;
    private Vector3 currentLookTarget = Vector3.zero;
    [SerializeField]
    private LayerMask myLayer;
    // Start is called before the first frame update
    void Start()
    {
        characterControll = GetComponent<CharacterController>();
        speed = 10f;
        direction = Vector3.zero;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterControll.SimpleMove(direction * speed);

        if(direction != Vector3.zero)
        {
            anim.SetBool("walk", true);

        }
        else
        {
            anim.SetBool("walk", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("chop", true);
        }
        else
        {
            anim.SetBool("chop", false);
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit, 500 , myLayer,QueryTriggerInteraction.Ignore ))
        {
            if (hit.point != null)
            {
                currentLookTarget = hit.point;
            }

            Vector3 targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);
        }
    }

    

   


}
