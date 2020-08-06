using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seter : MonoBehaviour
{
    public GameObject map;

    private void OnTriggerEnter(Collider other)
    {
        Controller.instance.ChangeMap(map);
    }
}
