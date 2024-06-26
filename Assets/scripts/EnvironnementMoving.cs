using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementMoving : MonoBehaviour
{
    private static float speed = -7f; // Vitesse initiale
    private float maxSpeed = -19f; // Vitesse maximale
    private float speedIncrease = -3f; // Augmentation de vitesse
    private float speedIncreaseInterval = 30f; // Intervalle d'augmentation de vitesse (30 secondes)
    private float nextSpeedIncreaseTime; // Temps avant d'augmenter la vitesse

    void Start()
    {
        nextSpeedIncreaseTime = Time.time + speedIncreaseInterval; // Initialiser le prochain temps d'augmentation de vitesse
    }


    void Update()
    {
        // Vérifier si le temps pour augmenter la vitesse est écoulé
        if (Time.time >= nextSpeedIncreaseTime && speed > maxSpeed)
        {
            speed += speedIncrease; // Augmenter la vitesse
            nextSpeedIncreaseTime += speedIncreaseInterval; // Mettre à jour le prochain temps d'augmentation de vitesse
        }

        // Déplacer l'environnement avec la vitesse actuelle
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }

// Ce code est une méthode qui gère les événements de collision déclenchés lorsqu'un autre collider entre en contact avec celui attaché à cet objet.
private void OnTriggerEnter(Collider other)
{
    // Vérifie si l'objet entré en collision a un tag spécifique appelé "Destroy".
    if (other.gameObject.CompareTag("Destroy"))
    {
        // Si l'objet entré en collision a le tag "Destroy", détruit l'objet auquel ce script est attaché.
        Destroy(gameObject);
    }
}

}
