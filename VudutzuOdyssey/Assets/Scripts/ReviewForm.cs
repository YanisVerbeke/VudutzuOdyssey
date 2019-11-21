using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class ReviewForm : MonoBehaviour
{
    [SerializeField] private InputField nameField;
    [SerializeField] private InputField mailField;
    [SerializeField] private InputField commentField;

    [SerializeField] private Button submitButton;

    public static string nameText;
    public static string mailText;
    public static string commentText;

    // Start is called before the first frame update

    // Update is called once per frame
    public void OnClick()
    {
        nameText = nameField.text;
        mailText = mailField.text;
        commentText = commentField.text;
        PostToDb();
    }

    public void PostToDb()
    {
        Review review = new Review();
        RestClient.Put("https://vudutzu.firebaseio.com/reviews/"+ nameText + ".json",review);
    }
}
