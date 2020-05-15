using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dbvrvocabularyread : MonoBehaviour
{
    public Text status;
    public InputField inputUser, inputPassword;
    int currentID;
    bool takenUsername;

    string dbString;

    public string[] registeredUser;

    public string[] usernames = new string[10000];
    public string[] password = new string[10000];

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW users = new WWW("http://192.168.7.92/read.php");
        //wait until response from the website
        yield return users;
        dbString = users.text;
        registeredUser = dbString.Split(';');

        // loop through all users 
        for(int i = 0; i < registeredUser.Length -1; i++){
            usernames[i] = registeredUser[i].Substring(registeredUser[i].IndexOf('U') + 9);
            usernames[i] = usernames[i].Remove(usernames[i].IndexOf('|'));

            password[i] = registeredUser[i].Substring(registeredUser[i].IndexOf("Password") + 9);
        }
    }

    public void tryToLogin(){
        currentID = -1;
        if(inputUser.text == "" || inputUser.text == ""){
            status.text = "Username and password required*";
        }
        else{
            for(int i = 0; i < registeredUser.Length -1; i++){
                if(inputUser.text == usernames[i]){
                    currentID = i;
                }
            }
            if (currentID == -1){
                status.text = "User not found!";
            }
            else{
                if(inputPassword.text == password[currentID]){
                    status.text = "Success";
                }
                else{
                    status.text = "Password incorrect";
                }
            }
           
        }
    }
    
    /*public void tryToRegister(){
        takenUsername = false;

        if(regUsername.text == "" || regPassword.text == "" || regEmail.text == ""){
            status.text = "Registration: No empty fields allowed";
        }
        else{
            for(int i = 0; i < registeredUser.Length - 1; i++){
                if(regUsername.text == usernames[i]){
                    takenUsername = true;
                }
            }
            if (takenUsername == false && regUsername.text != "Password"){
                status.text = "Registration successful";
                registerUser(regUsername.text, regPassword.text, regEmail.text);
            }
            else{
                status.text = "Invalid username";
            }
        }
    }
    public void registerUser(string username, string password, string email){
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("emailPost", email);

        WWW register = new WWW("http://10.254.253.91/insertuser.php", form);
    }*/
}
