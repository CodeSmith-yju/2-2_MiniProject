using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardInit init;
    //private에서 public으로 전환하여 inspecter창에서 등록함으로써 getComponent매서드를 사용하지않는방향으로 수정
    public Text _name;
    public Text _description;
    public Text _cost;
    public Text _type;

    private TrailRenderer trailObj;

    [SerializeField] private Image imgThumb;
    [SerializeField] private Image imgBgThumb;
    [SerializeField] private Image imgEdgeThumb;
    [SerializeField] private Image imgNameThumb;

    public float handCurveRate;
    public float angle;
    public int order;

    public bool isDraggable = false;

    /// <summary>
    /// hand 내의 좌표.
    /// </summary>
    public Vector3 targetPos;
    
    void Awake()
    {  
        angle = 0.0f;
        trailObj = GetComponent<TrailRenderer>();
    }

    /// <summary>
    /// Card의 CardInit 데이터를 입력받아 초기화한다.
    /// </summary>
    public void SetInitializeData(CardInit init)
    {
        this.init = init;
        //프리팹이 생성될때 기존의 연결이 모두 끊어져서 init을 초기화할 때 같이 초기화했다.
        //_name = transform.Find("Name").transform.Find("Text").GetComponent<Text>();//getcomponent <- 교수님이 바꾸라고했음
        //_description = transform.Find("Description").transform.Find("Text").GetComponent<Text>();
        //_cost = transform.Find("CostBg").transform.Find("Cost").GetComponent<Text>();
        //_type = transform.Find("ImageEdge").transform.Find("Text").GetComponent<Text>();
        
        imgThumb.sprite = init.thumb;
        imgBgThumb.sprite = init.bgThumb;
        imgEdgeThumb.sprite = init.edgeThumb;
        imgNameThumb.sprite = init.nameThumb;
        SetTextData();
    }

    public void SetTextData()
    {
        _name.text = init.cardName;
        _description.text = "" + init.cardDescription;
        _cost.text = "" + init.cost.ToString();
        _type.text = init.cardType;
    }

    /// <summary>
    /// trail을 time시간 후에 활성/비활성화 한다.
    /// </summary>
    public IEnumerator SetActiveOfTrailC(float time, bool tf)
    {        
        float curtime = 0.0f;
        while (curtime < time)
        {
            curtime += Time.deltaTime;
            yield return null;
        }
        trailObj.Clear();
        trailObj.enabled = tf;        
    }

}
