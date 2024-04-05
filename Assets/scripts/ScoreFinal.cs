using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    public Text finalScoreText; // Référence au composant Text pour afficher le score final

    void Start()
    {
        // Vérifie si une instance de ScoreManager existe
        if (ScoreManager.instance != null)
        {
            // Affiche le score final en utilisant le ScoreManager
            finalScoreText.text = "Votre score est de " + ScoreManager.instance.GetScore().ToString() + " Bien joué !";
        }
        else
        {
            // Affiche un message d'erreur si ScoreManager n'est pas trouvé
            finalScoreText.text = "ScoreManager non trouvé.";
        }
    }
}
