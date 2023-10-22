using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private string fileName;
    private GameData gameData;
    private List<IData> dataObjects;
    private FileDataHandler fileDataHandler;
    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataObjects = FindAllDataObjects();
        LoadGame();
    }

    private void NewGame()
    {
        this.gameData = new GameData();
    }
    public void NewGame(bool restart)
    {
        if (restart)
        {
            fileDataHandler.Restart();
            NewGame();
        }
        else
        {
            NewGame();
        }
    }

    public void SaveGame()
    {
        foreach (IData dataObject in dataObjects)
        {
            dataObject.SaveData(ref gameData);
        }
        fileDataHandler.Save(gameData);
    }

    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();
        if (this.gameData == null)
        {
            NewGame();
        }
        foreach (IData dataObject in dataObjects)
        {
            dataObject.LoadData(gameData);
        }

    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IData> FindAllDataObjects()
    {
        IEnumerable<IData> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData>();
        return new List<IData>(dataObjects);
    }
}
