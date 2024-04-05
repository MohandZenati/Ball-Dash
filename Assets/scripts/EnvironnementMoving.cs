using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementMoving : MonoBehaviour
{
    private static float speed = -2f; // Vitesse initiale
    private float maxSpeed = -30f; // Vitesse maximale
    private float speedIncrease = -2f; // Augmentation de vitesse
    private float speedIncreaseInterval = 3f; // Intervalle d'augmentation de vitesse
    private float nextSpeedIncreaseTime; // Temps avant d'augmenter la vitesse


    void Start()
    {
        nextSpeedIncreaseTime = Time.time + speedIncreaseInterval; // Initialiser le prochain temps d'augmentation de vitesse
    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}