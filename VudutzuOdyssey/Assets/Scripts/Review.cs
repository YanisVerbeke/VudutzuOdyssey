using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Review : MonoBehaviour
{

    public string userName;
    public string mailName;
    public string commentName;

    public Review()
    {
        
        commentName = ReviewForm.commentText;
        mailName = ReviewForm.mailText;
        userName = ReviewForm.nameText;

    }
}
