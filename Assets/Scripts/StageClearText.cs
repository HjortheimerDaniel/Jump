using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StageClearText : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] Item _item;
    [SerializeField] private GameObject _container;
    [SerializeField] GameObject _nextStageText;
    [SerializeField] GameObject _menuStageText;
    private Vector3 targetPosition = new Vector3(800f, 500f, 0f);
    private float duration = 1.0f;
    private Vector3 startPosition;
    //-36
    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(23f, 636f, 0f);
        _transform = GetComponent<Transform>();
        //_item = GetComponent<Item>();
        startPosition = _transform.position;
        _nextStageText.SetActive(false);
        _menuStageText.SetActive(false);
        //_container = GetComponent<GameObject>();
        //_container.SetActive(false);

    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_item.AllCoinsTaken())
        {
           // _container.SetActive(true);
            //_container.SetActive(true);
            StartCoroutine(EaseText());
            _nextStageText.SetActive(true);
            _menuStageText.SetActive(true);

        }
    }

    private IEnumerator EaseText()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _transform.position = targetPosition;
    }
}

