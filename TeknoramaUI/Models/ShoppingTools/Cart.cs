﻿namespace TeknoramaUI.Models.ShoppingTools
{
    public class Cart
    {
        Dictionary<int, CartItem> _sepetim;

        public Cart()
        {
            _sepetim = new Dictionary<int, CartItem>();
        }

        public List<CartItem> Sepetim { get { return _sepetim.Values.ToList(); } }

        //Sepete Ekleme
        public void AddToCart(CartItem item)
        {
            if (_sepetim.ContainsKey(item.ID))
            {
                _sepetim[item.ID].Amount += 1;
                return;
            }
            _sepetim.Add(item.ID, item);
        }

        //Sepetten Çıkarma
        public void RemoveFromCart(int id)
        {
            if (_sepetim[id].Amount > 1)
            {
                _sepetim[id].Amount -= 1;
                return;
            }
            _sepetim.Remove(id);
        }

        //Sepet Toplam Fiyatı
        public decimal TotalPrice { get { return _sepetim.Sum(x => x.Value.SubTotal); } }

        //Sepetteki Ürün Sayısı
        public int ProductCount()
        {
            return _sepetim.Sum(x => x.Value.Amount);
        }


    }
}