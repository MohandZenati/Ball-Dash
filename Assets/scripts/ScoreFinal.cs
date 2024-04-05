using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    public Text finalScoreText; // Assurez-vous d'assigner cela dans l'éditeur Unity

    void Start()
    {
        if (ScoreManager.instance != null)
        {
            finalScoreText.text = "Votre score est de " + ScoreManager.instance.GetScore().ToString() + " Bien joué !";
        }
        else
        {
            finalScoreText.text = "ScoreManager non trouvé.";
        }
    }
}
