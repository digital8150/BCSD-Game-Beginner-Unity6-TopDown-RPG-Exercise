using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scannedObject;
    public bool isAction;

    private void Awake()
    {
        talkPanel.SetActive(false);
    }

    public void Action(GameObject scannedObject)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            this.scannedObject = scannedObject;
            talkText.text = $"이것의 이름은 {scannedObject.name} 이라고 한다.";
        }
        talkPanel.SetActive(isAction);

    }
}
