using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
public class CountScore : MonoBehaviour
{
    PhotonView view;
    public TextMeshProUGUI scoreText;
    int score = 0;
    //Sets the name of player
    public TextMeshProUGUI playerNameText;
    private void Start()
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            scoreText.gameObject.SetActive(false);
        }
        if (PhotonNetwork.IsMasterClient)
        {
            playerNameText.text = "PlayerOne";
        }
        else {
            playerNameText.text = "PlayerTwo"; 
       }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (view.IsMine)
            {
                score++;
                scoreText.text = score.ToString();

            }
        }
    }
}
