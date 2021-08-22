using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MAX_KID.Models.Entities
{
    public class CartItem
    {
        public SANPHAM Sanpham { get; set; }
        public int Quantity { set; get; }

        public int Count { get; set; }
    }
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(SANPHAM sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.Sanpham.ID_SanPham == sp.ID_SanPham)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    Sanpham = sp,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.Sanpham.ID_SanPham == sp.ID_SanPham);
                }
            }
        }

        public void RemoveLine(SANPHAM sp)
        {
            lineCollection.RemoveAll(l => l.Sanpham.ID_SanPham == sp.ID_SanPham);
        }

        public long? ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Sanpham.GiaSanPham * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }

        public int TotalItem()
        {
            var sum = lineCollection.Sum(p => p.Quantity);
            return sum;
        }
    }
}