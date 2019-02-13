namespace CourierKata.Domain
{
    public struct Parcel
    {
        public Parcel(int height, int width)
        {
            this.Dimension = new Dimension
            {
                Height = height,
                Width = width,
            };
        }

        public Dimension Dimension { get; private set; }
    }
}