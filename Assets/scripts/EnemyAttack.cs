using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Vector3 playerPos;
    [SerializeField]
    private Vector3 distance;
    private float playerFarRange = 3f;
    private bool playerInRange;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(enmeyAttack());

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameManager.instance.player.transform.position;
        if (Vector3.Distance(playerPos, gameObject.transform.position) < playerFarRange)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
    IEnumerator enmeyAttack()
    {
        if (!GameManager.instance.GameOver && playerInRange)
        {
            anim.Play("Attack");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Attack");

        }
        yield return null;
        

        StartCoroutine(enmeyAttack());
    }



}
