namespace LibAcc.Abstractions
{
    public class BookAttribute
    {
        public int BookAttributeId { get; set; }

        public int BookId { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
