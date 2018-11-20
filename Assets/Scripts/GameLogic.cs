using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public Text PointsValue;
    public int PointsPerGoal;
    public Text TimeValue;
    public int RoundTime;
    private float TimeElapsed = 0;
    public PivotController pc;
    public List<LandingPadScript> LandingPads;//fill with trigger objects
    //public SoundSource ding;
	// Use this for initialization
	void Start () {
        int startingPoints = 0;
        PointsValue.text = startingPoints.ToString();
        ChooseNewGoal(0);
	}
	
	// Update is called once per frame
	void Update () {
        TimeElapsed = (TimeElapsed + Time.deltaTime);
        if (TimeElapsed < RoundTime)
        {
            TimeValue.text = ((int)(RoundTime - TimeElapsed)).ToString();
        }
        else
        {
            TimeValue.text = "0";
            pc.ControlsEnabled = false;
        }
        
        
        foreach (LandingPadScript lps in LandingPads)
        {
            if (lps.isTriggered == true)
            {
                lps.Deactivate();
                ScorePoints();
                ChooseNewGoal(LandingPads.IndexOf(lps));
            }
        }
	}

    void ScorePoints()
    {
        int previousPoints = int.Parse(PointsValue.text);
        int newPoints = previousPoints + PointsPerGoal;
        PointsValue.text = newPoints.ToString();
    }

    void ChooseNewGoal(int i)
    {
        int newIndex = Random.Range(0, LandingPads.Count-2);//excluding last index
        if(newIndex == i)
        {
            newIndex = LandingPads.Count-1;
        }
        LandingPads[newIndex].Activate();

    }
}
