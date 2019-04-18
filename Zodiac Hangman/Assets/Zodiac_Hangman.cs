using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;
using UnityEngine;


public class Zodiac_Hangman : MonoBehaviour
{
  
    bool firstTime = true;
    bool begin = false;
    string que;
    string unrev;
    string ans;
    char[] queArr, unrevArr;
    int chance;
    string[] answers = new string[] { "A Q U A R I U S", "P I S C E S", "A R I E S", "T A U R U S", "G E M I N I", "L E O", "C A N C E R", "V I R G O", "L I B R A", "S C O R P I O", "S A G I T T A R I U S", "C A P R I C O R N" };
    string[] questions = new string[] { "_ _ _ A _ I _ _", "_ _ _ _ E _", "_ _ I _ _", "_ A _ _ U _", "_ E _ _ _ _", "_ _ _", "_ _ _ _ E _", "_ I _ _ _", "_ I _ _ _ ", "_ _ _ R _ _ _ ", "_ A _ _ _ _ _ _ I _ _", "_ A _ _ _ _ _ R _" };
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is an extremely challenging Zodiac Hangman game. Guess the Zodiac by entering missing letters. You lose in 3 wrong tries! Press Enter to begin");
        
    }
   
    // Update is called once per frame
    void Update()
    {
        StringBuilder sb = new StringBuilder();
        


        if (Input.GetKeyDown(KeyCode.Return) && firstTime == true)
        {
            firstTime = false;
            begin = true;
            chance = 3;
            Debug.Log("Guess the following zodiac. Enter a single letter :");


            int zodNum = UnityEngine.Random.Range(0, 12);
            ans = answers[zodNum];
            que = questions[zodNum];
            Debug.Log(que);
            for (int i = 0; i < ans.Length; i++)
            {
                if (que[i] == '_' || Char.IsWhiteSpace(que[i]))
                {
                    sb.Append(Char.ToString(ans[i]));

                }
                else
                    sb.Append(Char.ToString('_'));

            }
            unrev = sb.ToString();
            unrevArr = unrev.ToCharArray();
            queArr = que.ToCharArray();
        }
       

            if (begin == true )
        {
            String press = Input.inputString;

            if (press.Length == 1)
                {
                    char inp = Convert.ToChar(press);
             
                if (inp >= 97 && inp <= 122)
                    {
                              inp = Char.ToUpper(inp);
                              Debug.Log(inp);
                    int i = 0;
                        if (unrevArr.Contains(inp))
                        {
                            //Debug.Log(inp);
                            while (Array.IndexOf(unrevArr, inp, i) != -1)                   
                            {
                           
                            int ind = Array.IndexOf(unrevArr, inp, i);
                                queArr[ind] = unrevArr[ind];
                                unrevArr[ind] = '_';
                                if (i < unrevArr.Length - 1)
                                    i++;
                                else
                                    break;


                            }
                        
                        Debug.Log(new string(queArr));
                        if(!queArr.Contains('_'))
                            {
                            Debug.Log("Awesome! You figured it out! Press Enter to play again.");
                                 firstTime = true;
                                begin = false;
                              }
                        }
                        else
                        {   if (chance == 1)
                        {
                            Debug.Log("You lost! The Zodiac was " + ans + " . Press Enter to play again.");
                            firstTime = true;
                            begin = false;
                        }
                        else
                        {
                            chance--;
                            Debug.Log(chance + " tries left!!");
                        }
                        }
                    }


                }
            }

        

        

      

    }





}
