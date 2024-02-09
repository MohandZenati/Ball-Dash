using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables de gravité
    public float gravity = 9.81f;
    public float jumpSpeed = 8.0f; // Vitesse du saut
    private Vector3 moveDirection = Vector3.zero;

    // Référence au CharacterController
    private CharacterController controller;

    void Start()
    {
        // Récupérer le CharacterController attaché à ce GameObject
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Calcul de la gravité
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            // Si le joueur est au sol et appuie sur la touche de saut (par exemple la touche espace)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Ajouter la vitesse du saut à la direction du mouvement
                moveDirection.y = jumpSpeed;
            }
        }

        // Appliquer la gravité au CharacterController
        controller.Move(moveDirection * Time.deltaTime);
    }
}
