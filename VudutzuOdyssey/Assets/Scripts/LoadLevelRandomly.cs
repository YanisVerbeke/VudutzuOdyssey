using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelRandomly : MonoBehaviour
{
    // On crée nos variables
    [SerializeField]
    // Variable pour le délai avant de générer la scène
    private float delayBeforeLoading = 10f;
    [SerializeField]
    // Variable de la scène à générer
    private string sceneNameToLoad;

    // Variable du temps passé
    private float timeElapsed;

    private void Update()
    {
        // On compte combien de temps s'est passé
        timeElapsed += Time.deltaTime;

        // On regarde si le temps passé est supérieur à 10
        if(timeElapsed > delayBeforeLoading)
        {
            // On génère nôtre scène
            SceneManager.LoadScene(sceneNameToLoad); 
        }
    }
}
