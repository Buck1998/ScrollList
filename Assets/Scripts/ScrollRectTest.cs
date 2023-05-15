using UnityEngine;
using UnityEngine.UI;

public class ScrollRectTest : MonoBehaviour
{
    public class Item
    {
        public GameObject go;
        public RectTransform rectTransform;
        public int iNumber;
        public Text text;
    }

    public ScrollRect _scrollRect;
    public Transform _transform;
    public GameObject _goItem;

    public int _iItemNum = 1000;
    public int _iItemHeight = 100;
    public int _iItemShowNum = 6;
    private int _iminNumber;
    private int _imaxNumber;
    private Item[] _ary_item;

    public ScrollRect _scrollRect2;
    public Transform _transform2;

    void Start()
    {
        _scrollRect.onValueChanged.AddListener(delegate { ChangeList(); });

        _scrollRect.content.sizeDelta = new Vector2(_scrollRect.content.sizeDelta.x, _iItemNum * _iItemHeight + _iItemHeight);

        _ary_item = new Item[_iItemShowNum];
        for (int i = 0; i < _iItemShowNum; i++)
        {
            Item item = new Item();
            item.go = GameObject.Instantiate(_goItem, _transform);
            item.rectTransform = item.go.GetComponent<RectTransform>();
            item.rectTransform.anchoredPosition = new Vector2(item.rectTransform.anchoredPosition.x, -1 * _iItemHeight * i);
            item.iNumber = i;
            item.text = item.go.transform.GetChild(0).GetComponent<Text>();
            item.text.text = i.ToString();

            _ary_item[i] = item;

            if (i < _iItemNum)
            {
                _ary_item[i].go.SetActive(true);
            }
        }

        _scrollRect2.content.sizeDelta = new Vector2(_scrollRect2.content.sizeDelta.x, _iItemNum * _iItemHeight + _iItemHeight);
        for (int i = 0; i < _iItemNum + 1; i++)
        {
            Item item = new Item();
            item.go = GameObject.Instantiate(_goItem, _transform2);
            item.rectTransform = item.go.GetComponent<RectTransform>();
            item.rectTransform.anchoredPosition = new Vector2(item.rectTransform.anchoredPosition.x, -1 * _iItemHeight * i);
            item.iNumber = i;
            item.text = item.go.transform.GetChild(0).GetComponent<Text>();
            item.text.text = i.ToString();

            if (i < _iItemNum)
            {
                item.go.SetActive(true);
            }
        }
    }

    public void ChangeList()
    {
        if (_scrollRect.content.anchoredPosition.y <= -1)
        {
            return;
        }

        if (_scrollRect.content.anchoredPosition.y >= (_iItemNum * _iItemHeight - 299))
        {
            return;
        }

        _iminNumber = (int)_scrollRect.content.anchoredPosition.y / _iItemHeight;
        _imaxNumber = _iminNumber + _iItemShowNum - 1;

        for (int i = 0; i < _iItemShowNum; i++)
        {
            for (int j = 0; j < _iItemShowNum; j++)
            {
                if ((_iminNumber + i) > _iItemNum)
                {
                    break;
                }

                if ((_iminNumber + i) == _ary_item[j].iNumber)
                {
                    break;
                }

                if (j != _iItemShowNum - 1)
                {
                    continue;
                }

                for (int k = 0; k < _iItemShowNum; k++)
                {
                    if (_ary_item[k].iNumber > _imaxNumber || _ary_item[k].iNumber < _iminNumber)
                    {
                        _ary_item[k].iNumber = _iminNumber + i;
                        _ary_item[k].text.text = _ary_item[k].iNumber.ToString();
                        _ary_item[k].rectTransform.anchoredPosition = new Vector2(_ary_item[k].rectTransform.anchoredPosition.x, -1 * _iItemHeight * _ary_item[k].iNumber);
                        break;
                    }
                }
                break;
            }
        }
    }
}
