namespace Task6.Models;

[Serializable]
public class Shop
{
    private int _id;
    private string _name;
    private string _description;
    private List<Phone> _phones;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public List<Phone> Phones
    {
        get => _phones;
        set => _phones = value;
    }
}