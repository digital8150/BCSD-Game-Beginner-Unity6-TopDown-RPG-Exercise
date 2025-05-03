using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public QuestManager questManager;
    public Text talkText;
    public GameObject scannedObject;
    public Image portraitImg;
    public bool isAction;
    public int talkIndex;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    private void Awake()
    {
        talkPanel.SetActive(false);
    }

    public void Action(GameObject scannedObject)
    {
        this.scannedObject = scannedObject;
        ObjectData objectData = scannedObject.GetComponent<ObjectData>();
        Talk(objectData.id, objectData.isNpc);

        talkPanel.SetActive(isAction);

    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+questTalkIndex, talkIndex);

        //End Talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        //Continue Talk
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];
            int portraitIndex = int.Parse(talkData.Split(':')[1]);
            portraitImg.sprite = talkManager.GetPortrait(id, portraitIndex);
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
