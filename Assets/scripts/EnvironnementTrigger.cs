// Ce script Unity instancie un objet roadSection à une position spécifique lorsque cet objet entre en collision avec un autre objet portant le tag "Trigger".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementTrigger : MonoBehaviour
{
    // Variable publique pour spécifier l'objet à instancier
    public GameObject roadSection;

    // Méthode appelée lorsqu'un objet entre en collision avec le collider attaché à cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet en collision a le tag "Trigger"
        if (other.gameObject.CompareTag("Trigger"))
        {
            // Crée une copie de roadSection à la position (1, 0, 0) dans l'espace mondial
            Instantiate(roadSection, new Vector3(1, 0, 0), Quaternion.identity);
        }
    }
}
