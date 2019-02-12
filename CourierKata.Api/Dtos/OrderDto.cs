using System.Collections.Generic;

namespace CourierKata.Api
{
    public class OrderDto
    {
        public List<ParcelDto> Parcels { get; set; }
    }
}