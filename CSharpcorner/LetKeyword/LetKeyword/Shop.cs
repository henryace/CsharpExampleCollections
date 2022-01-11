using System.Collections.Generic;

namespace LetKeyword
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
    }
}