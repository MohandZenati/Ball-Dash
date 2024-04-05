using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Méthode appelée lorsqu'un objet entre en collision avec le collider attaché à cet objet
    void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet en collision a le tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Charge la scène avec l'index 1
            SceneManager.LoadScene(1);
        }
    }

    // Méthode publique pour redémarrer le jeu
    public void RestartGame()
    {
        // Charge la scène avec l'index 0
        SceneManager.LoadScene(0);
    }
}
