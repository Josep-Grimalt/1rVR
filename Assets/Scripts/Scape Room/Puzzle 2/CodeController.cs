using System.Collections;
using TMPro;
using UnityEngine;

public class CodeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI codeText;
    private Renderer originalRederer;
    private EventManager eventManager;

    private void Awake()
    {
        eventManager = GameObject.Find("Event Manager").GetComponent<EventManager>();
        originalRederer = GetComponentInChildren<Renderer>();
    }

    public void AddNumber(string n)
    {
        codeText.text += n;
    }

    public void FullCode()
    {
        if (codeText.text.Equals("8624"))
        {
            eventManager.CodeEntered();
        }
        else
        {
            StartCoroutine(WrongCode(.2f));
        }
    }

    public void ResetCode()
    {
        codeText.text = "";
    }

    private IEnumerator WrongCode(float delay)
    {
        GetComponentInChildren<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(delay);
        GetComponentInChildren<Renderer>().material.color = originalRederer.material.color;
    }
}