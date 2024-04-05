using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementTrigger : MonoBehaviour
{

    public GameObject roadSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection, new Vector3(1, 0, 0), Quaternion.identity);
        }
    }
}
