using Serenity.Services;

namespace SerenityIdentityServerIntegration.Northwind
{
    public class OrderListRequest : ListRequest
    {
        public int? ProductID { get; set; }
    }
}