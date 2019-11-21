using UnityEngine;

public class CanvaModifier : MonoBehaviour
{
    public GameObject Canva;

    // Fonction qui nous permet d'ouvrir un canva qui est désactivé
    public void OpenCanva()
    {
        // On regarde si notre canva existe ou non
        if(Canva != null)
        {
            // On affiche notre canva
            Canva.SetActive(true);
        }
    }

    // Fonction qui nous permet de désactiver un canva
    public void CloseCanva()
    {
        // On cache notre canva
        Canva.SetActive(false);
    }
}
