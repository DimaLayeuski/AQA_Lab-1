using Bogus;

namespace StoreSimulator;

public class GoodsGenerator
{
    private static readonly Faker<Goods?>? GoodsFaker;

    static GoodsGenerator()
    {
        GoodsFaker = new Faker<Goods?>()
            .RuleFor(product => product!.Category, faker => faker.Commerce.Categories(1)[0])
            .RuleFor(product => product!.BarcodeId, faker => faker.Commerce.Ean13())
            .RuleFor(product => product!.GoodsName, faker => faker.Commerce.ProductName())
            .RuleFor(product => product!.Price, faker => double.Parse(faker.Commerce.Price()));
    }

 }

