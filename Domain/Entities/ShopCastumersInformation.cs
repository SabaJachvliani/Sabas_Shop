namespace Domain.Entities
{
    public class ShopCastumersInformation
    {
        public int Id { get; set; }
        public string Mail { get; set; } = null!;
        public string Addres { get; set; } = null!;

        public int CostumerId { get; set; }
        public ShopCostumer ShopCostumers { get; set; } = null!;

    }
}
