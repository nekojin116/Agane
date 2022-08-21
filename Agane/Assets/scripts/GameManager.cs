using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
   

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;
    //notes score / player lvl
    public int currentScore;
    public float playerxp;
    //public int playerlevel;
    public int scorePerNote = 100;
    public int scorePerPerfectNote = 300;
    public int scorePerGoodNote = 150;
    public int scorePerBadNote = 50;
    //notes calculator 
    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    //rank calculator
    public float mhp;
    public float nhp;
    public float ghp;
    public float php;
    public float gexp;

    //ALPHA - Player LVL
  

    public GameObject resultScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missedtext, rankText, finalscoreText, PlayerLVL, gainedEXP;


    //Scores text
    public Text scoreText;
    public Text multiText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public GameObject videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "No score ?";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();

                videoPlayer.SetActive(true);
                
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missedtext.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;
                

                percentHitText.text = percentHit.ToString("F1");

                //calculating percent of different hits 
                 mhp = (missedHits / totalNotes) * 100f;
                 nhp = (normalHits / totalNotes) * 100f;
                 ghp = (goodHits / totalNotes) * 100f;
                 php = (perfectHits / totalNotes) * 100f;
                //calculating exp v1

                
                //stopping video and additional effects 
                videoPlayer.SetActive(false);


                Debug.Log("Calculated percentages");
                //calculating rank 
                Debug.Log("Calcualting rank..");

                string rankVal = "D"; 
                if(php >= 30 && mhp <= 20)
                {
                        rankVal = "C";

                        if(php >= 40 && mhp <= 5)
                        {
                            rankVal = "B";

                           if(php >= 70 && mhp <= 5)
                            {
                                rankVal = "A";

                                if(php >= 90 && mhp == 0)
                                {
                                    rankVal = "B";

                                    if(php == 100)
                                    {
                                        rankVal = "SS";
                                    }
                                }
                            }
                        }



                }
                    
                    rankText.text = rankVal;
                

                finalscoreText.text = currentScore.ToString();
                gexp = (currentScore / 1000);
                playerxp = playerxp + gexp;
             
            }
        }

    }

    public void NoteHit()
    {
        //Debug.Log("Hit On Time");
        
        
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "score :" + currentScore;
        multiText.text = "Multiplier : x" + currentMultiplier;
        
        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
         multiplierTracker++;
         if (multiplierThresholds[currentMultiplier - 1] <=multiplierTracker)
         {
            multiplierTracker = 0;
            currentMultiplier++;
         }
        }
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        normalHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        perfectHits++;
    }
    
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        goodHits++;
    }

  
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier : x" + currentMultiplier;
        missedHits++;
    }

}
