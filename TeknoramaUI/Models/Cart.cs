namespace TeknoramaUI.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> _basket;

        public Cart()
        {
            _basket = new Dictionary<int, CartItem>();
        }

        public List<CartItem> Basket { get { return _basket.Values.ToList(); } }

        //Sepete Ekleme
        public void AddToCart(CartItem item)
        {
            if (_basket.ContainsKey(item.Id))
            {
                _basket[item.Id].Amount += 1;
                return;
            }
            _basket.Add(item.Id, item);
        }

        //Sepetten Çıkarma
        public void RemoveFromCart(int id)
        {
            if (_basket[id].Amount > 1)
            {
                _basket[id].Amount -= 1;
                return;
            }
            _basket.Remove(id);
        }

        //Sepet Toplam Fiyatı
        public decimal TotalPrice { get { return _basket.Sum(x => x.Value.SubTotal); } }

        //Sepetteki Ürün Sayısı
        public int ProductCount()
        {
            return _basket.Sum(x => x.Value.Amount);
        }


    }
}