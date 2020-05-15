/***********************************************************************************
MIT License
Copyright (c) 2016 Aaron Faucher
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
***********************************************************************************/

using UnityEngine;
using UnityEngine.Experimental.Networking;
using System.Collections;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine.Networking;
using UnityEngine.UI;

public class STT : MonoBehaviour
{
    public ShowControlButton ButtonClicked;
    public Understood understood;

    public Text speechText;
    public GameObject YourSpeech;
    public GameObject LoadingPanel;

    // Audio variables
    public AudioClip commandClip;
    int samplerate;

    // API access parameters
    string url;
    string token;
    UnityWebRequest wr;

    void Start()
    {
        samplerate = 16000;
    }

    public void BtnClicked()
    {
        YourSpeech.SetActive(true);
        StartCoroutine(Record());
        //Record();
    }

    public IEnumerator Record()
    {
        print("Listening for command");
        commandClip = Microphone.Start(null, false, 10, samplerate);  //Start recording (rewriting older recordings)
        yield return new WaitForSeconds(3);
        LoadingPanel.SetActive(true);
        Validate();
    }

    public void Validate()
    {
        // Save the audio file
        Microphone.End(null);
        SaveWav.Save("sample", commandClip);

        // At this point, we can delete the existing audio clip
        commandClip = null;

        //Grab the most up-to-date JSON file
            // url = "https://api.wit.ai/message?v=20160305&q=Put%20the%20box%20on%20the%20shelf";
        token = "V65J5VZSQLT6QBHHQETEK4DYR7L7DOBK";

        //Start a coroutine called "WaitForRequest" with that WWW variable passed in as an argument
        string witAiResponse = GetJSONText(Application.persistentDataPath + "/Sample.wav");
        print(witAiResponse);

        var N = JSON.Parse(witAiResponse);
        // Find the word
        string speechWord = N["entities"]["word"][0]["value"].Value.ToLower();
        print(speechWord);

        speechText.text = speechWord;

        if(speechText.text == ButtonClicked.CurrentVocabularyBtnClickedName.ToLower())
        {
            //StartCoroutine(understood.comparePronunciation());
        }
        LoadingPanel.SetActive(false);
    }

    string GetJSONText(string file)
    {
        // get the file w/ FileStream
        FileStream filestream = new FileStream(file, FileMode.Open, FileAccess.Read);
        BinaryReader filereader = new BinaryReader(filestream);
        byte[] BA_AudioFile = filereader.ReadBytes((Int32)filestream.Length);
        filestream.Close();
        filereader.Close();

        // create an HttpWebRequest
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.wit.ai/speech");

        request.Method = "POST";
        request.Headers["Authorization"] = "Bearer " + token;
        request.ContentType = "audio/wav";
        request.ContentLength = BA_AudioFile.Length;
        request.GetRequestStream().Write(BA_AudioFile, 0, BA_AudioFile.Length);

        // Process the wit.ai response
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                print("Http went through ok");
                StreamReader response_stream = new StreamReader(response.GetResponseStream());
                return response_stream.ReadToEnd();
            }
            else
            {
                return "Error: " + response.StatusCode.ToString();
            }
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
}
