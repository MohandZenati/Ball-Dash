using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Instance statique pour accéder au score depuis n'importe où

    private int score = 0;
    private float timer = 0f;
    public Text scoreText;
    public Text finalScoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Empêche la destruction lors du chargement
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Assure qu'il n'y a qu'une seule instance
        }
    }

    void Update()
    {
        // Vérifie si la scène actuelle est la scène 0
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                score += 1;
                timer = 0f;
            }

            Vector3 screenPos = new Vector3(Screen.width / 2, Screen.height - 50, 0);
            scoreText.rectTransform.position = screenPos;
            scoreText.text = "Score: " + score.ToString();
            scoreText.gameObject.SetActive(true); // Activer le texte du score dans la scène 0
        }
        else
        {
            scoreText.gameObject.SetActive(false); // Désactiver le texte du score dans les autres scènes
            score = 0; // Réinitialiser le score lorsque vous quittez la scène 0
        }
    }

    public int GetScore()
    {
        return score; // Permet d'accéder au score de l'extérieur
    }
}
