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
    private void Start()
    {
        CellCol = 10;
        CellRow = 15;
        m_cellNum = CellCol * CellRow;
        m_cell = new GameObject[m_cellNum];

        BuildFlame(CellCol, CellRow);
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
}
