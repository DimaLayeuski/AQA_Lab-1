namespace StoreSimulator;

public class Goods
{
    private string _goodsName;
    private string _category;
    private string _barcodeId;
    private double _price;

    public string GoodsName
    {
        get => _goodsName;
        set => _goodsName = value;
    }

    public string Category
    {
        get => _category;
        set => _category = value;
    }

    public string BarcodeId
    {
        get => _barcodeId;
        set => _barcodeId = value;
    }

    public double Price
    {
        get => _price;
        set => _price = value;
    }
}