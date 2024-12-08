using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpPlayer : MonoBehaviour
{
    private GameObject Character;

    void Start()
    {
        Character = GameObject.FindGameObjectWithTag("Player");
        Character.transform.position = gameObject.transform.position;
    }

}
