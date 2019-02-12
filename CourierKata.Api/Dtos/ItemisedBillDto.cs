using System.Collections.Generic;

namespace CourierKata.Api
{
    public class DeliveryCostBillDto
    {
        public ItemDto[] Items { get; set; }

        public decimal TotalCost { get; set; }
    }
}