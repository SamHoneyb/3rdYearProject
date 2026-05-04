using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.Networking;

//creates a class for the scenario summaries
[Serializable]
public class ScenariosSummary
{
    public int ScenarioID;
    public string Summary;
}

[Serializable]
public class SummaryWrapper
{
    public List<ScenariosSummary> ScenariosSummary;
}

public class PopulateDropDown : MonoBehaviour
{
    //creates the variables and a list for the summaries
    public TMP_Dropdown dropdown;
    public List<ScenariosSummary> allSummaries = new List<ScenariosSummary>();
    public int selctedScenario;

    //sets the API to be called
    private string scenarioAPI = "http://127.0.0.1:5000/Summaries";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetSummaries());
    }

    public IEnumerator GetSummaries()
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
            //removes noise from the response
            string fixedResponse = "{\"ScenariosSummary\":" + response + "}";

            SummaryWrapper wrapper = JsonUtility.FromJson<SummaryWrapper>(fixedResponse);
            allSummaries = wrapper.ScenariosSummary;

            DropDownPop();

        }
    }
    
    public void DropDownPop()
    {
        //populates drop down
        dropdown.ClearOptions();

        List<String> dropDownOptions = new List<String>();
        foreach(var scenario in allSummaries)
        {
            dropDownOptions.Add(scenario.Summary);
        }

        dropdown.AddOptions(dropDownOptions);
        dropdown.onValueChanged.RemoveAllListeners();
        dropdown.onValueChanged.AddListener(SelectedScenario);
        
    }

    public void SelectedScenario(int index)
    {
        selctedScenario = index;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}

