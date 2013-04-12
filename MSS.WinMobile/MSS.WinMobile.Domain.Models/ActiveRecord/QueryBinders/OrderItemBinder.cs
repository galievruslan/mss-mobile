namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryBinders
{
    public class OrderItemBinder : QueryBinder<OrderItem>
    {
        public override string SaveBinder(string template, OrderItem @object)
        {
            return string.Format(template,
                                 @object.Id,
                                 @object.OrderId,
                                 @object.Product != null ? string.Format("{0}, ", @object.Product.Id) : "NULL, ",
                                 @object.Quantity);
        }
    }
}
