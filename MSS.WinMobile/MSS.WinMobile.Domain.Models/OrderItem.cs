namespace MSS.WinMobile.Domain.Models
{
    public class OrderItem : Model
    {
        protected OrderItem() {
        }

        protected OrderItem(Order order) {
            OrderId = order.Id;
        }

        public int OrderId { get; protected set; }

        public int ProductId { get; protected set; }
        public string ProductName { get; protected set; }

        public int UnitOfMeasureId { get; protected set; }
        public string UnitOfMeasureName { get; protected set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public void SetProduct(Product product) {
            ProductId = product.Id;
            ProductName = product.Name;
        }

        public void SetUnitOfMeasure(UnitOfMeasure unitOfMeasure) {
            UnitOfMeasureId = unitOfMeasure.Id;
            UnitOfMeasureName = UnitOfMeasureName;
        }
    }
}
