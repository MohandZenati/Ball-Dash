using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Instance statique du ScoreManager

    private int score = 0; // Score du joueur
    private float timer = 0f; // Compteur de temps
    public Text scoreText; // Référence au composant Text pour afficher le score en jeu
    public Text finalScoreText; // Référence au composant Text pour afficher le score final à la fin du jeu

    void Awake()
    {
        // Assure qu'il n'y a qu'une seule instance de ScoreManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ne pas détruire l'objet ScoreManager lors du chargement de nouvelles scènes
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Détruit les instances supplémentaires de ScoreManager
        }
    }

    void Update()
    {
        // Vérifie si la scène actuelle est la première scène du jeu
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            // Incrémente le score toutes les secondes
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                score += 1;
                timer = 0f;
            }

            // Positionne le texte du score en haut au centre de l'écran et l'affiche
            Vector3 screenPos = new Vector3(Screen.width / 2, Screen.height - 50, 0);
            scoreText.rectTransform.position = screenPos;
            scoreText.text = "Score: " + score.ToString();
            scoreText.gameObject.SetActive(true);
        }
        else
        {
            // Désactive le texte du score si la scène n'est pas la première scène
            scoreText.gameObject.SetActive(false);
            score = 0; // Réinitialise le score lorsque la scène change
        }
    }

    // Méthode pour obtenir le score depuis d'autres scripts
    public int GetScore()
    {
        return score;
    }
}
