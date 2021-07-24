using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviour
{
    public GameObject cameraof;
    CharacterController controller;
    float speed = 15f;
    
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        cameraof.transform.SetParent(null, true);
        if (!view.IsMine) {
            cameraof.SetActive(false);
        }
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector3 move;
            //We rotate the player on Y aix by 180 to make the camera look at same thing on both cilent and hence need to chnage movement axis
            if (transform.rotation == Quaternion.Euler(0, 180, 0))
            {
                move = new Vector3(Input.GetAxisRaw("Horizontal") * -1, 0, 0);
            }
            else {
                move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            }
            controller.Move(move * speed * Time.deltaTime);
           
        }
        
    }
}
