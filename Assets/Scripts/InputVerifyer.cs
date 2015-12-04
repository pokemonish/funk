using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class InputVerifyer : MonoBehaviour {

    private InputField mainInput;
    private string prevInput = null;
    private string[] requiredFunctions;
    private int prevPos = 0;

    // Use this for initialization
    void Start()
    {
        var mainInputGO = GameObject.Find("InputField");
        mainInput = mainInputGO.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        correctCaretPosition(mainInput);
        if (Mathf.Abs(mainInput.caretPosition - prevPos) > 2)
        {
            prevPos = mainInput.caretPosition;
        }
    }

    private void correctCaretPosition(InputField input)
    {
        if (isInsideTag(input.text, input.caretPosition))
        {
            if (prevPos < input.caretPosition)
            {
                moveToClosestEndOfTag(input);
            }

            if (prevPos > input.caretPosition)
            {
                moveToClosestBeginningOfTag(input);
            }
        }
    }

    private bool isInsideTag(string text, int pos)
    {
        for (int i = pos; i < text.Length; ++i)
        {
            if (text[i] == '>')
            {
                return true;

            }
            else if (text[i] == '<')
            {
                return false;
            }
        }
        return false;
    }

    private void moveToClosestEndOfTag(InputField input)
    {
        var text = input.text;
        int i = input.caretPosition;

        while (text[i] != '>' && i < text.Length - 1) ++i;

        input.caretPosition = i + 2 < text.Length ? i + 2 : text.Length;
    }

    private void moveToClosestBeginningOfTag(InputField input)
    {
        var text = input.text;
        int i = input.caretPosition;

        while (text[i] != '<' && i >= 0) --i;

        input.caretPosition = i - 1 > 0 ? i - 1 : 0;
    }

    private bool isInsideOfOpenTag(string text, int pos)
    {
        if (pos == 0) ++pos;
        for (int i = pos; i < text.Length; ++i)
        {
            if (text[i] == '>' && text[i - 1] != '/')
            {
                return true;

            } else if (text[i] == '<')
            {
                return false;
            }
        }
        return false;
    }

    private bool isInsideOfCloseTag(string text, int pos)
    {
        if (pos == 0) ++pos;

        for (int i = pos; i < text.Length; ++i)
        {
            if (text[i] == '>' && text[i - 1] == '/')
            {
                return true;
            }
            else if (text[i] == '<' || text[i] == '>')
            {
                return false;
            }
        }
        return false;
    }

    public void setPrevInput(string input)
    {
        if (prevInput == null)
        {
            prevInput = input;
        }
    }

    public void setReqiredFunctions(string[] functions)
    {
        requiredFunctions = functions;
    }

    public void verifyInput()
    {
        if (mainInput != null)
        {
            var text = mainInput.text;

            bool isValid = true;

            foreach (string function in requiredFunctions)
            {
                if (text.IndexOf(function) == -1)
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                prevInput = text;
            }

            mainInput.text = prevInput;
        }
    }
}
