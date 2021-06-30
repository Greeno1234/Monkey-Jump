using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public Text highscoreText;
    public Text highscoreHardText;
    public Text bananas;
    public Text version;
    public Text skin;
    public GameObject skinButtonPrefab;
    public GameObject skinItemContainer;
    public int Availability = 0;
    public int Currency;
    public static bool hard;

    private int[] costs = { 0, 100, 150, 200, 269, 350, 420, 500, 666, 800, 1111, 2500 };




    void Start()
    {
      
        skin.text = "Selected Skin: " + (PlayerPrefs.GetInt("Skin") + 1);
        bananas.text = "Bananas: " + PlayerPrefs.GetInt("Bananas");
        Availability = PlayerPrefs.GetInt("SkinAvailability");
        version.text = "Version " + Application.version;
        if (Availability <= 0)
        {
            PlayerPrefs.SetInt("SkinAvailability", 1);
        }

        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
        highscoreHardText.text = "Hard Highscore: " + PlayerPrefs.GetInt("HighscoreHard");
        Availability = PlayerPrefs.GetInt("SkinAvailability");
        Currency = PlayerPrefs.GetInt("Bananas");

        //monkey skin compiler
        int textureIndex = 0;
        Sprite[] textures = Resources.LoadAll<Sprite>("Player");
        foreach(Sprite texture in textures)
        {
            GameObject container = Instantiate(skinButtonPrefab) as GameObject;
            container.GetComponent<Image>().sprite = texture;
            container.transform.SetParent(skinItemContainer.transform, false);

            int monkeyIndex = textureIndex;
            container.GetComponent<Button> ().onClick.AddListener (() => SkinChange(monkeyIndex));
            container.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = costs[monkeyIndex].ToString();

            if ((Availability & 1 << monkeyIndex) == 1 << monkeyIndex)
            {
                container.transform.GetChild (0).gameObject.SetActive(false);
            }
            textureIndex++;
        }
        
    }

    private void SkinChange(int monkeyIndex)
    {

        if ((Availability & 1 << monkeyIndex) == 1 << monkeyIndex)
        {
            //Debug.Log(1 << monkeyIndex);
            
            PlayerPrefs.SetInt("Skin", monkeyIndex);
            skin.text = "Selected Skin: " + (PlayerPrefs.GetInt("Skin") + 1);
        }
        else
        {
            // you do not have the skin, give option to buy it
            
            int cost = costs[monkeyIndex];
            

            if (Currency >= cost)
            {
                //buy skin
                Currency -= cost;
                PlayerPrefs.SetInt("Bananas", Currency);

                Availability += 1 << monkeyIndex;
                PlayerPrefs.SetInt("SkinAvailability", Availability);
                skinItemContainer.transform.GetChild(monkeyIndex).GetChild(0).gameObject.SetActive(false);

                bananas.text = "Bananas: " + PlayerPrefs.GetInt("Bananas");
            }
        }

    }



    public void PlayGame ()
    {      
        SceneManager.LoadScene(1);
        hard = false;
    }
    public void PlayHardGame ()
    {
        SceneManager.LoadScene(1);
        hard = true;
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }





}
