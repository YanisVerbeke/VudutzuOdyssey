using UnityEngine;

public class CanvaOpener : MonoBehaviour
{
    public GameObject Canva;

    public void OpenCanva()
    {
        if(Canva != null)
        {

            Canva.SetActive(true);
        }
    }

    public void CloseCanva()
    {
        Canva.SetActive(false);
    }
}
