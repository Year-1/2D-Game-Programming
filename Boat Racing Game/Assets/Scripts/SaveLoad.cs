using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


//Can have this also track coins for rewards

//C:\Users\RyanW\AppData\LocalLow\DefaultCompany\Boat Racing Game
public class SaveLoad : MonoBehaviour
{
    public static SaveLoad SL;
    FileStream file;

    public List<int> leaderboardScore = new List<int>();
    public List<int> LeaderboardScore { get { return leaderboardScore; } }

    public int totalCoins;
    public int TotalCoins { get { return totalCoins; } set { totalCoins += value; } }

    public int score;
    public int Score { set { score = value; LeaderboardCheck(); } }

    private void Start()
    {
        //This will make the object stay active between scene loading.
        if (SL == null) {
            DontDestroyOnLoad(gameObject);
            SL = this;
        } else if (SL != this) {
            Destroy(gameObject);
        }

        //If no file called playerScores.txt it creates it, then dumps 5 empty values.
        if (!File.Exists(Application.persistentDataPath + "/playerScores.txt")) {
            for (int i = 0; i < 5; i++) {
                leaderboardScore.Add(0);
            }
            Save();
            leaderboardScore.Clear();
        }
        Load();
    }

    //Adds a score, sorts the array and then deletes the last entry if theres 6 elements.
    public void LeaderboardCheck()
    {
        leaderboardScore.Add(score);
        leaderboardScore.Sort();
        leaderboardScore.Reverse();

        if (leaderboardScore.Count == 6) {
            leaderboardScore.RemoveAt(leaderboardScore.Count - 1);
        }
    }

    //Saves the variables to /playerScores.txt file.
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        file = File.Create(Application.persistentDataPath + "/playerScores.txt");

        Scores data = new Scores();

        data.totalCoins = totalCoins;
        foreach (int item in leaderboardScore) {
            data.leaderboardScore.Add(item);
        }

        bf.Serialize(file, data);
        file.Close();
    }

    //Opens /playerScores.txt file and assigns the variables the values from file.
    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        file = File.Open(Application.persistentDataPath + "/playerScores.txt", FileMode.Open);

        Scores data = (Scores)bf.Deserialize(file);
        file.Close();

        totalCoins = data.totalCoins;
        foreach (int item in data.leaderboardScore) {
            leaderboardScore.Add(item);
        }
    }
}

[Serializable]
class Scores
{
    public List<int> leaderboardScore = new List<int>();
    public int totalCoins;
}


