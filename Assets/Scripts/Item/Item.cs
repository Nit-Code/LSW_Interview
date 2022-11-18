using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected string _id;
    protected string _name;
    protected string _description;
    protected int _price;
    protected Sprite _sprite;

    protected SpriteRenderer _spriteRenderer;
    protected AnimatorOverrideController _animatorOverrideController; //Get from SO or from Prefab?

    [SerializeField] protected ItemManager _itemManager;

    public string Id { get => _id; }
    public string Name { get => _name; }
    public string Description { get => _description; }
    public int Price { get => _price; set => _price = value; }
    public Sprite Sprite { get => _sprite; }

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (Id == "" || Id == null)
            return;

        Init(Id);
    }

    public virtual void Init(string id)
    {
        if (id == "" || id == null)
            return;

        ItemData itemData = _itemManager.GetItemData(id);

        if (itemData == null)
            return;

        _id = itemData.id;
        _name = itemData.id;
        _description = itemData.description;
        _price = itemData.basePrice;
        _sprite = itemData.sprite;
    }
}

