using UnityEngine;
public class Player_Anim_Controller : MonoBehaviour
{
    Animator CH_Arms_controller;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        CH_Arms_controller = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Press the up arrow button to reset the trigger and set another one
        if (Input.GetMouseButtonDown(0))
        {

            //Send the message to the Animator to activate the trigger parameter named "Fire"
            CH_Arms_controller.SetTrigger("Fire");

        
        }

        if (Input.GetKey(KeyCode.R))
        {
            //Send the message to the Animator to activate the trigger parameter named "Fire"
            CH_Arms_controller.SetBool("Reload", true);

            //Send the message to the Animator to activate the trigger parameter named "Fire"
            CH_Arms_controller.SetBool("Reload", false);


        }
    }
}

