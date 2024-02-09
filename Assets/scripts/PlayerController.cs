using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float runSpeed = 8f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    bool isGrounded;
    private float horizontalInput;


    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    void Update()
    {
        // Vérifier si le joueur est au sol
        horizontalInput = 1;
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        // Si le joueur est au sol et la vitesse verticale est négative, réinitialiser la vitesse verticale
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);


        // Calculer la gravité
        velocity.y += gravity * Time.deltaTime;

        // Appliquer la gravité
        characterController.Move(velocity * Time.deltaTime);
    }
}
