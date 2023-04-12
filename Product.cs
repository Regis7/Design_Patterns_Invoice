using System;

namespace LabIII_invoice
{
    internal class Product
    {
        
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; } 

        public void Accept(IVisitor visitor)
        {
            visitor.VisitProduct(this);
        }
    }
}
