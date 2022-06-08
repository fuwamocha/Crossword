using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCrossword : MonoBehaviour
{

    [SerializeField] private Canvas m_canvas;
    private GameObject[] m_cell;
    public int CellCol { get; private set; }
    public int CellRow { get; private set; }
    private int m_cellNum;
    private int m_setNum;

    private void Start()
    {
        CellCol = 10;
        CellRow = 15;
        m_cellNum = CellCol * CellRow;
        m_cell = new GameObject[m_cellNum];

        BuildFlame(CellCol, CellRow);
        SetWord("どきんちゃん");
        SetWord("ばいきんまん");
    }

    public void BuildFlame(int col, int row)
    {
        var _cellNum = col * row;
        var _cellPrefab = (GameObject)Resources.Load("Prefabs/Cell");

        for (int i = 0; i < _cellNum; i++)
        {
            m_cell[i] = Instantiate(_cellPrefab);
            m_cell[i].transform.SetParent(m_canvas.transform, false);
        }
        var gridLayout = m_canvas.GetComponent<GridLayoutGroup>();
        gridLayout.constraintCount = col;
    }

    private void SetWord(string word)
    {
        var _inputCellPrefab = (GameObject)Resources.Load("Prefabs/WordInputCell");

        for (int i = 0; i < word.Length; i++)
        {
            _inputCellPrefab = Instantiate(_inputCellPrefab);
            _inputCellPrefab.transform.SetParent(m_cell[i + m_setNum].transform, false);
            //debug
            var _cellInputField = _inputCellPrefab.GetComponent<InputField>();
            _cellInputField.text = word[i].ToString();
            //

        }

        m_setNum += word.Length;
    }


    /// <summary>
    /// 正しい文字が入力された時に変更できないようにする
    /// </summary>
    /// <param name="_cellPrefab"></param>
    private void LockChar(GameObject _cellPrefab)
    {
        var _cellInputField = _cellPrefab.GetComponent<InputField>();
        _cellInputField.readOnly = true;
    }
}
