using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

[Serializable]
public class SelectedScenarios
{
    public int ScenarioID;
    public string Scenario;
    public string Answer;
    public string Incorrect1;
    public string Incorrect2;
    public string Incorrect3;
    public string Reason;
    public string Summary;
}

[Serializable]
public class SelectedScenarioWrapper
{
    public List<SelectedScenarios> SelectedScenarios;
}


public class SelectedScenarioCall : MonoBehaviour
{
    public List<SelectedScenarios> allSelectedScenarios = new List<SelectedScenarios>();
    public TMP_Text questionpnlTxt;
    public TMP_Text answer1Txt;
    public TMP_Text answer2Txt;
    public TMP_Text answer3Txt;
    public TMP_Text answer4Txt;
    public GameObject Answer1Btn;
    public GameObject Answer2Btn;
    public GameObject Answer3Btn;
    public GameObject Answer4Btn;

    public PopulateDropDown PopulateDropDown;
    public SelectedScenarios currentScenario;
    public string correctAnswer;


    //sets API to be called
    private string scenarioAPI = "http://127.0.0.1:5000/Scenarios";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PopulateDropDown = FindObjectOfType<PopulateDropDown>();
        StartCoroutine(GetScenarios());
    }

    public IEnumerator GetScenarios()
    {
        //calls the API
        UnityWebRequest www = UnityWebRequest.Get(scenarioAPI);

        yield return www.SendWebRequest();


        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);
            //removes noise from the reponse
            string fixedResponse = "{\"SelectedScenarios\":" + response + "}";

            SelectedScenarioWrapper wrapper = JsonUtility.FromJson<SelectedScenarioWrapper>(fixedResponse);
            allSelectedScenarios = wrapper.SelectedScenarios;

            LoadScenrario();
        }
    }

    public void LoadScenrario() {
        currentScenario = allSelectedScenarios[PopulateDropDown.selctedScenario];
        correctAnswer = currentScenario.Answer;

        List<String> randomiseButtons = new List<String>() {
            currentScenario.Answer,
            currentScenario.Incorrect1,
            currentScenario.Incorrect2,
            currentScenario.Incorrect3,
        };

        System.Random rnd = new System.Random();

        //randomises and sets the buttons
        for (int i = 0; i < randomiseButtons.Count; i++)
        {
            int random = rnd.Next(i, randomiseButtons.Count);

            string temp = randomiseButtons[i];
            randomiseButtons[i] = randomiseButtons[random];
            randomiseButtons[random] = temp;

            questionpnlTxt.text = currentScenario.Scenario;
            answer1Txt.text = randomiseButtons[0];
            answer2Txt.text = randomiseButtons[1];
            answer3Txt.text = randomiseButtons[2];
            answer4Txt.text = randomiseButtons[3];
        }

    }

    //checks if the answer is correct based on button pressed
    public void Button1Pressed()
    {
        StartCoroutine(answerCheck(answer1Txt.text));
    }
    public void Button2Pressed()
    {
        StartCoroutine(answerCheck(answer2Txt.text));
    }
    public void Button3Pressed()
    {
        StartCoroutine(answerCheck(answer3Txt.text));
    }
    public void Button4Pressed()
    {
        StartCoroutine(answerCheck(answer4Txt.text));
    }

    //checks if the answer is correct
    IEnumerator answerCheck(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswer) {
            Debug.Log("correct");
            questionpnlTxt.text = currentScenario.Reason;
            questionpnlTxt.color = Color.green;
            LeaveCorrectButton();
            yield return new WaitForSeconds(6f);
            LoadSelectScreen();
        }
        else
        {
            Debug.Log("incorrect");
            questionpnlTxt.text = currentScenario.Reason;
            questionpnlTxt.color = Color.red;
            LeaveCorrectButton();
            yield return new WaitForSeconds(6f);
            LoadSelectScreen();

        }
    }

    //leaves only the button with the right answer
    private void LeaveCorrectButton()
    {
        if(answer1Txt.text != correctAnswer)
        { 
            Answer1Btn.SetActive(false);
        }
        else
        {
            answer1Txt.color = Color.green;
            Answer1Btn.GetComponent<Button>().interactable = false;

        }

        if (answer2Txt.text != correctAnswer)
        {
            Answer2Btn.SetActive(false);
        }
        else
        {
            answer2Txt.color = Color.green;
            Answer2Btn.GetComponent<Button>().interactable = false;

        }

        if (answer3Txt.text != correctAnswer)
        {
            Answer3Btn.SetActive(false);
        }
        else
        {
            answer3Txt.color = Color.green;
            Answer3Btn.GetComponent<Button>().interactable = false;

        }

        if (answer4Txt.text != correctAnswer)
        {
            Answer4Btn.SetActive(false);
        }
        else
        {
            answer4Txt.color = Color.green;
            Answer4Btn.GetComponent<Button>().interactable = false;
        }
    }
    
    //takes the player back to the home screen
    public void LoadSelectScreen()
    {
        SceneManager.LoadSceneAsync("HomeScreen");
    }


};
