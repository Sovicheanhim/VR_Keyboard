using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookmarkWord : MonoBehaviour
{
    public string Word;
    public byte[] ImageByte;
    
    public BookmarkWord(string word, byte[] imagebyte)
    {
        Word = word;
        ImageByte = imagebyte;
    }
}
