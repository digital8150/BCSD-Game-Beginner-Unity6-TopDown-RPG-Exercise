using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObjects;
    Dictionary<int, QuestData> questList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }
    
    void GenerateData()
    {
        questList.Add(10, new QuestData(name: "마을 사람들과 이야기 나누기", npcId: new int[] {1000, 2000}));
        questList.Add(20, new QuestData(name: "루도의 동전 찾아주기.", new int[] { 5000, 2000 }));
        questList.Add(30, new QuestData(name: "퀘스트 올 클리어!", new int[] { }));
    }

    public int GetQuestTalkIndex(int npcId)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int npcId)
    {
        

        if (npcId == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }
        //Control Quest Object
        ControlObject();
        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }

        return questList[questId].questName;
       
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if(questActionIndex == 2)
                    questObjects[0].SetActive(true);
                break;
            case 20:
                if(questActionIndex == 1)
                    questObjects[0].SetActive(false);
                break;

        }
    }
}
