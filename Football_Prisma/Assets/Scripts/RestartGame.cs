using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RestartGame : MonoBehaviour
{
    //This scripts destroys the ball whenever hit to the oject the script is attached to and restats the game on all clients

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball") {
            StartCoroutine(loadLevel());
        }
    }
    //Wait for some time when ball is hit and then restart the level
    IEnumerator loadLevel() {
        yield return new WaitForSeconds(2);
        PhotonNetwork.LoadLevel("Main");
    }

}
