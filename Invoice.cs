using System;

namespace LabIII_invoice
{
    internal class Invoice
    {

        public DateTime Date { get; set; }
        public int CustomerNumber { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime PaymentBy { get; set; }
        public List<InvoiceLine> invoicelines { get; set; } = new List<InvoiceLine>();
         
        public void Accept(IVisitor visitor)
        {
            visitor.VisitInvoice(this);
            foreach (var invoiceline in invoicelines)
            {
                invoiceline.Accept(visitor);
            }
            var invoiceTotal = new InvoiceTotal
            {
                PreTaxTotal = invoicelines.Sum(invoiceline => invoiceline.Total),
             
            };
            invoiceTotal.Tax = Math.Ceiling(invoiceTotal.PreTaxTotal * 0.1m);
            invoiceTotal.Total = Math.Ceiling(invoiceTotal.PreTaxTotal + invoiceTotal.Tax);
            invoiceTotal.Accept(visitor);

        }
    }
}
