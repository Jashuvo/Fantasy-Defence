using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContorllerScript : MonoBehaviour
{
    private CharacterController characterControll;
    private Animator anim;
    private float speed;
    private Vector3 direction;
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
    }
}
