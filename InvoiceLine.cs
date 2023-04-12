using System;

namespace LabIII_invoice
{
    internal class InvoiceLine
    {
        //public int Qty { get; set; }
        //public decimal Total => Qty * Product.UnitPrice;
        public Product Product { get; set; }
        public decimal Total => Product.Qty * Product.UnitPrice;

        public void Accept(IVisitor visitor)
        {
            visitor.VisitInvoiceLine(this);
            // Product.Accept(visitor);
        }
    }
}
