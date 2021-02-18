using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testskrypt : MonoBehaviour
{

    public CharacterController kontrola;
    public Animator animator;

    float predkosc;
    float skok = 10f;
    float grawitacja = 10f;

    Vector3 oskoku = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wektor = transform.forward * predkosc * Input.GetAxis("Vertical");
        kontrola.Move(wektor * Time.deltaTime);

        if(Input.GetButton("Jump") && kontrola.isGrounded)
        {
            oskoku.y = skok;
        }
        oskoku.y -= grawitacja * Time.deltaTime;

        kontrola.Move(oskoku * Time.deltaTime);

        animator.SetBool("bieg", Input.GetAxis("Vertical") !=0);
        animator.SetBool("skok", !kontrola.isGrounded);

    }
}
