using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] {"안녕?:0", "너도 뺑이 치러 왔구나?:1"});
        talkData.Add(2000, new string[] { "우리 집 오지마:3", "선풍기가 하나 뿐이야:3" });
        talkData.Add(100, new string[] { "개딴딴해보이는 나무 상자다..." });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { 
            "어서 와.:0", 
            "이 마을에 놀라운 전설이 있다? :1",
            "오른쪽에 루도가 알려줄꺼야:2"
        });

        talkData.Add(11 + 2000, new string[] {
            "이 호수의 전설에 대해 들으러 온거야? :1",
            "내 잃어버린 1BTC좀 찾아줘.:2",
            "비싼거라구.:3"
        });

        talkData.Add(20 + 1000, new string[] {
            "루도의 동전?:1",
            "돈을 흘리고 다니면 못쓰지!:3",
            "나중에 루도에게 한마디 해야겠어.:3"
        });

        talkData.Add(20 + 2000, new string[]
        {
            "찾으면 꼭 좀 가져다 줘.:1"
        });
        talkData.Add(20 + 5000, new string[]{
            "근처에서 동전을 찾았다."
        });

        talkData.Add(21 + 2000, new string[]
        {
            "엇, 찾아줘서 고마워.:2"
        });


        //portrait Data
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);


    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {

            if(!talkData.ContainsKey(id - id % 10))
            {
                //퀘스트 맨 처음 대사 마저 없을 때
                //기본 대사를 가지고 온다
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                //해당 퀘스트 진행 순서 중 대사가 없을 때
                //퀘스트 맨 처음 대사를 가지고 온다
                return GetTalk(id - id % 10, talkIndex);
            }
        }
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData.ContainsKey(id) ? talkData[id][talkIndex] : null;
        }

    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
