using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject playerPrefab;
    public Transform ballPosi;
    public Transform masterSpawnPosi;
    public Transform clientSpawnPosi;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, masterSpawnPosi.position, Quaternion.identity);
            PhotonNetwork.Instantiate(ballPrefab.name, ballPosi.position, Quaternion.identity);
        }
        else {
            PhotonNetwork.Instantiate(playerPrefab.name, clientSpawnPosi.position, Quaternion.Euler(0,180,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
