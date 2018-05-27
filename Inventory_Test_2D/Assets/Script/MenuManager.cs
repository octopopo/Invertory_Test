using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public delegate void AddingButtonHandler();
    public static event AddingButtonHandler ButtonAdded;

    private Transform m_transform;
    public GameObject testObj;

    private List<string> m_List = new List<string>();

    [SerializeField]
    private int elementCount;
    // Use this for initialization

    private void Awake()
    {
        m_transform = this.GetComponent<Transform>().transform;
        elementCount = 0;
    }
    void Start () {
        ButtonAdded += ItemAdding;
        m_List.Add("bear");
        m_List.Add("buffalo");
        m_List.Add("chick");
        m_List.Add("chicken");
        Debug.Log(m_List[2]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ItemAdding() {
        GameObject instance = Instantiate(Resources.Load("Element", typeof(GameObject))) as GameObject;
        //testObj = Instantiate(Resources.Load("Element", typeof(GameObject))) as GameObject;
        instance.transform.parent = m_transform;
        instance.name = "Element" + elementCount;

        int randNum = Random.Range(0, 4);


        string url = "file://" + Application.streamingAssetsPath + "/" + m_List[randNum] +".png";
        Debug.Log(url);
        WWW www = new WWW(url);
        Sprite m_sp = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        instance.GetComponent<Image>().sprite = m_sp;

        //instance.GetComponents<ElementSC>().elementName = m_List[randNum];
        instance.GetComponent<ElementHand>().eName = m_List[randNum];

        elementCount++;
    }
}
