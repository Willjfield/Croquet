using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	int selectedItem; 
	Transform StatusMenu;
	public List<Image> ColorButtons;
	private GameObject[] BallBtns;

	public Sprite ActiveSprite;
	public Sprite InactiveSprite;

    public GameObject saveGameText;

    void Awake()
    {
        transform.Find("Save").gameObject.SetActive(false);
		transform.Find("Load").gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
		StatusMenu = transform.Find ("CurrentGameStatus");
		if (BallBtns == null)
			BallBtns = GameObject.FindGameObjectsWithTag("BallButton");
		toggleGameStatusComponents (false);
		activateCurrentBall ();

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void toggleVisibility(){
		selectedItem = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
        switch (selectedItem)
        {
            case 0:
                toggleGameStatusComponents(false);
                break;
            case 1:
                toggleGameStatusComponents(true);
                break;
            case 2:
                Application.LoadLevel("Main_Scene");
                break;
            case 3:
                toggleGameStatusComponents(false);
                break;
            case 4:
                toggleGameStatusComponents(false);
                break;
            case 5:
                //RulesManager.Save ("MainGame");
                transform.Find("Save").gameObject.SetActive(true);
                break;
            case 6:
                transform.Find("Load").gameObject.SetActive(true);

                if (GameObject.Find("AvailableGames").GetComponent<Dropdown>().options.Count == 0)
                {
                    DirectoryInfo savedGamePath = new DirectoryInfo(Application.persistentDataPath);
                    FileInfo[] fileInfo = savedGamePath.GetFiles("*.dat", SearchOption.AllDirectories);

                    foreach (FileInfo file in fileInfo)
                    {
                        string listName = file.Name.Replace(".dat", "");
                        GameObject.Find("AvailableGames").GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = listName });
                    }
                }

			break;
		case 7:
			Application.Quit();
                break;
		}
	}

    public void saveGame(){
        string gameName = saveGameText.GetComponent<Text>().text;
        if (gameName.Length > 0)
        {
            RulesManager.Save(gameName);
            transform.Find("Save").gameObject.SetActive(false);
			GameObject.Find("Dropdown").GetComponent<Dropdown>().value = 0;
			GameObject.Find("Dropdown").GetComponent<Dropdown>().RefreshShownValue();
        }
    }

	public void loadGame()
	{
		//int selectedItem = GameObject.Find("AvailableGames").GetComponent<Dropdown>().value;

        string gameName = GameObject.Find("AvailableGames").transform.Find("Label").GetComponent<Text>().text;
        print("Loading "+gameName);
		if (gameName.Length > 0)
		{
			RulesManager.Load(gameName);
            //GameObject.Find("AvailableGames").GetComponent<Dropdown>().ClearOptions();
            GameObject list = GameObject.Find("AvailableGames").transform.Find("Dropdown List").gameObject;
            Destroy(list);
			transform.Find("Load").gameObject.SetActive(false);
			GameObject.Find("Dropdown").GetComponent<Dropdown>().value = 0;
			GameObject.Find("Dropdown").GetComponent<Dropdown>().RefreshShownValue();


		}
	}

    public void hideElement(GameObject element){
		
        GameObject list = GameObject.Find("AvailableGames").transform.Find("Dropdown List").gameObject;

        if(list!=null){
            Destroy(list);
        }

        //GameObject.Find("AvailableGames").GetComponent<Dropdown>().ClearOptions();
        GameObject.Find("Dropdown").GetComponent<Dropdown>().value = 0;
        GameObject.Find("Dropdown").GetComponent<Dropdown>().RefreshShownValue();
        element.SetActive(false);
    }

    public void hideSave(){
		//GameObject list = GameObject.Find("AvailableGames").transform.Find("Dropdown List").gameObject;

		//if (list != null)
		//{
		//	Destroy(list);
		//}

		//GameObject.Find("AvailableGames").GetComponent<Dropdown>().ClearOptions();
		GameObject.Find("Dropdown").GetComponent<Dropdown>().value = 0;
		GameObject.Find("Dropdown").GetComponent<Dropdown>().RefreshShownValue();
		GameObject.Find("Save").SetActive(false);
    }

    public void hideLoad() {

		//GameObject list = GameObject.Find("AvailableGames").transform.Find("Dropdown List").gameObject;

		//if (list != null)
		//{
		//	Destroy(list);
		//}
       
		//GameObject.Find("AvailableGames").GetComponent<Dropdown>().ClearOptions();
		GameObject.Find("Dropdown").GetComponent<Dropdown>().value = 0;
		GameObject.Find("Dropdown").GetComponent<Dropdown>().RefreshShownValue();
        GameObject.Find("Load").SetActive(false);

    }

	private void toggleGameStatusComponents(bool state){
		foreach (GameObject button in BallBtns) {
			button.GetComponent<Image> ().enabled = state;
			button.GetComponentInChildren<Text> ().enabled = state;
		}
		GameObject Scoreboard = GameObject.Find ("ScorebardBackground");
		Scoreboard.GetComponent<Image> ().enabled = state;
		Scoreboard.GetComponentsInChildren<Text> () [0].enabled = state;
	}

	public void deactivatePreviousBall(){
		string curBallName = RulesManager.getCurBallName();
		string curBallButtonColor = GameObject.Find (curBallName).GetComponent<Ball> ().color;
		GameObject curBallButton = GameObject.Find (curBallButtonColor + "Button");
		curBallButton.transform.localScale = new Vector3 (1f,1f,1f);
		curBallButton.GetComponent<Image> ().sprite = InactiveSprite;
	}

	public void activateCurrentBall(){
		string curBallName = RulesManager.getCurBallName();
		string curBallButtonColor = GameObject.Find (curBallName).GetComponent<Ball> ().color;
		GameObject curBallButton = GameObject.Find (curBallButtonColor + "Button");
        if(curBallButton != null){
			curBallButton.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
			curBallButton.GetComponent<Image>().sprite = ActiveSprite;
        }
		
	}
}
