using Task6.Enums;

namespace Task6.Models;

[Serializable]
public class Phone
{
    private string _model;
    private OperatingSystemType _operatingSystemType;
    private string _marketLaunchDate;
    private string _price;
    private bool _isAvailable;
    private int _shopId;

    public string Model
    {
        get => _model;
        set => _model = value;
    }

    public OperatingSystemType OperatingSystemType
    {
        get => _operatingSystemType;
        set => _operatingSystemType = value;
    }

    public string MarketLaunchDate
    {
        get => _marketLaunchDate;
        set => _marketLaunchDate = value;
    }

    public string Price
    {
        get => _price;
        set => _price = value;
    }

    public bool IsAvailable
    {
        get => _isAvailable;
        set => _isAvailable = value;
    }

    public int ShopId
    {
        get => _shopId;
        set => _shopId = value;
    }
}