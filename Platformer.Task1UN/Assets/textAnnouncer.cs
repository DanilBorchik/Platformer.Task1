using UnityEngine;
using UnityEngine.UI;

public class textAnnouncer : MonoBehaviour
{
    private Text txt;
    private Animator anim;
    private string textToSet;
    private void Start()
    {
        txt = GetComponentInChildren<Text>();
        anim = GetComponent<Animator>();
        DoText("(A) (D) to move, (space) to jump");
    }

    public void DoText(string text)
    {
        textToSet = text;
        anim.SetTrigger("showtext");
    }

    public void SetText()
    {
        txt.text = textToSet;
    }
}
