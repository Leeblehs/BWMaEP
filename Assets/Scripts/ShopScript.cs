using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScript : MonoBehaviour
{
    [SerializeField] GameObject shopUIRef;
    [SerializeField] Mesh hat;
    [SerializeField] MeshFilter playerHatSocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyPurchase()// will do more, currently just give the player a cool hat
    {

        playerHatSocket.mesh = hat;
       


    }
}
