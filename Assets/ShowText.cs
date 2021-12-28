using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour
{
    Text guitext;
    float initScale;
    public IEnumerator Play(string content)
    {
        //float s;
        //for (int i = 0; i < 30; i++)
        //{
        //    s = Mathf.Lerp(0, initScale, i / 30f);
        //    transform.localScale = new Vector3(s,s,s);
        //    yield return new WaitForSeconds(1f / 30f);
        //}

        string tmp = "";
        for (int i = 0; i < content.Length; i++)
        {
            tmp += content[i];
            guitext.text = tmp;
            //yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
        //gameObject.transform.localScale = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        guitext = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        initScale = transform.localScale.x;
    }

    
}
