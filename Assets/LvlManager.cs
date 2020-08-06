using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    public GameObject nextLvl;

    private void OnTriggerExit(Collider other)
    {
        var rb = Controller.instance.player.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        //Controller.instance.player.GetComponent<Rigidbody>().velocity = rb;

        Instantiate(nextLvl, Controller.instance.nextPoint.position, Quaternion.identity);
    }
}
