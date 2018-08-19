using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// マウスクリックで Target を移動させるクラス。適当なオブジェクトに追加して使う。
/// </summary>
public class TargetPickerController : MonoBehaviour
{
    /// <summary>表面をどれくらい浮かせるかを設定する</summary>
    public float m_surfaceOffcet = 0.05f;

    /// <summary>Target となるオブジェクト</summary>
    [SerializeField] GameObject m_target;

    void Start()
    {

    }

    void Update()
    {
        // マウスの左ボタンがクリックされていない時は何もしない
        if (!Input.GetMouseButtonDown(0)) return;

        // Ray を準備する
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Ray を発射して当たったかどうか調べる
        bool isHit = Physics.Raycast(ray, out hit, Camera.main.farClipPlane);
        // Ray が当たっていたらその場所に Target を移動する
        if (isHit)
        {
            m_target.transform.position = hit.point + hit.normal * m_surfaceOffcet;
        }
    }
}
