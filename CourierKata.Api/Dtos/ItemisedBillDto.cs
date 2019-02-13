using System.Collections.Generic;

namespace CourierKata.Api
{
    public class DeliveryCostBillDto
    {
        public DeliveryCostBillDto()
        {
            this.Items = new List<ItemDto>();
        }
        
        public List<ItemDto> Items { get; set; }

        public decimal TotalCost { get; set; }
    }
}