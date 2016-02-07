using UnityEngine;
using System.Collections;

[System.Serializable]
public class relationship {

    public string name;
    public bool like;
    public string opinion;

    public relationship(string theName, bool likes, string theOpinion)
    {
        name = theName;
        like = likes;
        opinion = theOpinion;
    }       
}
