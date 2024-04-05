using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers; // Masque de couches pour détecter le sol
    [SerializeField] private float runSpeed = 4f; // Vitesse de course du joueur
    [SerializeField] private float JumpHeight = 4f; // Hauteur de saut du joueur

    [SerializeField] private AudioClip jumpSoundEffect; // Effet sonore du saut
    private float gravity = -50f; // Gravité appliquée au joueur
    private CharacterController characterController; // Référence au composant CharacterController
    private Vector3 velocity; // Vitesse du joueur
    private bool isGrounded; // Indique si le joueur est au sol
    private float horizontalInput; // Entrée horizontale du joueur

    void Start()
    {
        characterController = GetComponent<CharacterController>(); // Obtient le composant CharacterController attaché à cet objet
    }

    void Update()
    {
        horizontalInput = 1; // Définit une valeur d'entrée horizontale par défaut (pour un mouvement vers l'avant)
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1); // Oriente le joueur dans la direction du mouvement

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore); // Vérifie si le joueur est au sol en lançant une sphère de détection

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0; // Réinitialise la vitesse de chute lorsque le joueur touche le sol
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // Applique la gravité au joueur
        }

        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime); // Déplace le joueur horizontalement

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Si le joueur est au sol et appuie sur le bouton de saut, le joueur saute
            velocity.y += Mathf.Sqrt(JumpHeight * -2 * gravity);
            AudioSource.PlayClipAtPoint(jumpSoundEffect, transform.position, 0.5f); // Joue l'effet sonore du saut
        }

        characterController.Move(velocity * Time.deltaTime); // Applique la vélocité au joueur
    }
}
