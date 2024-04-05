using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null; // Référence à l'objet que la caméra doit suivre
    private Vector3 offset; // Distance initiale entre la caméra et l'objet suivi

    void Start()
    {
        offset = transform.position - target.position; // Calcule la distance initiale entre la caméra et l'objet suivi
        offset.y = 0; // Assure que la caméra reste à la même hauteur que l'objet suivi
    }

    void LateUpdate()
    {
        // Utilise la fonction Vector3.Lerp pour déplacer la caméra progressivement vers la position de l'objet suivi
        // Time.deltaTime * 3 permet de rendre le mouvement de la caméra plus fluide en fonction du temps
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z) + offset, Time.deltaTime * 3);
    }
}
