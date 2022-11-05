using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_life : MonoBehaviour
{
    [SerializeField] private float tiempovida;

    void Start()
    {
        Destroy(gameObject,tiempovida);
    }

    
}
