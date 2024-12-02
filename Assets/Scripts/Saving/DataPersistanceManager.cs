using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;
    public static DataPersistanceManager instance { get; private set; }

    public AudioManager audioManager;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
        Saving();

        //InvokeRepeating("SaveGame", 6f, 16f);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public GameObject testingObject;

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initialzing data to defaults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistanceObj in dataPersistenceObjects)
        {
            //Debug.Log("FoundSave");
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPErsistenceObj in dataPersistenceObjects)
        {
            dataPErsistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void Saving()
    {
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave()
    {
        yield return new WaitForSecondsRealtime(10);
        if(Choises.endingBlockAutoSave == false)
        {
            //Debug.Log("Save");
            SaveTheGameData();
        }
        Saving();
    }

    public void ClickSaveSound()
    {
        audioManager.Play("UI_Click2");
    }

    public void SaveTheGameData()
    {
        SaveGame();
    }
}
