using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookmark : MonoBehaviour
{
    public VocabularyCard index;
    public FetchDataofVocabulary bookmark;
    public void Bookmarked()
    {
        WWWForm form = new WWWForm();

        //form.AddField("vocabularyPost", bookmark[i]);
        form.AddField("imagePost", bookmark.ImageString[index.i]);
        form.AddField("audioPost", bookmark.AudioString[index.i]);

        WWW update = new WWW("http://10.254.253.91/bookmark.php",form);
    }
}
