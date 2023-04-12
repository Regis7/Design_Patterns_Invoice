using System;

namespace LabIII_invoice
{
    internal class XmlExport: IVisitor
    {
        private string space = "";

        public void VisitInvoice(Invoice invoice)
        {
            Console.WriteLine($"{space}<invoice date=\"{invoice.Date.ToShortDateString()}\">");
            space += "  ";
            Console.WriteLine($"{space}<customerNumber>{invoice.CustomerNumber}</customerNumber>");
            Console.WriteLine($"{space}<invoiceNumber>{invoice.InvoiceNumber}</invoiceNumber>");
            Console.WriteLine($"{space}<paymentBy>{invoice.PaymentBy.ToShortDateString()}</paymentBy>");
            Console.WriteLine($"{space}<lines>");
            space += "  ";
        }

        public void VisitInvoiceLine(InvoiceLine invoiceLine)
        {
            invoiceLine.Product.Accept(this);
            //Console.WriteLine($"{space}<line qty={invoiceLine.Qty} productTitle=\"{invoiceLine.Product.Title}\" unitPrice=\"{invoiceLine.Product.UnitPrice}\" total=\"{invoiceLine.Total}\"/>");
            Console.WriteLine($" total=\"{invoiceLine.Total:C}\"/>");
            // Console.WriteLine($"{space}<line " +
            //     $"total=\"{invoiceLine.Total:C}\"/>");
        }

        
        public void VisitInvoiceTotal(InvoiceTotal invoiceTotal)
        {
            space = space.Substring(0, space.Length - 2);
            Console.WriteLine($"{space}</lines>");
            Console.WriteLine($"{space}<total pre-tax=\"{invoiceTotal.PreTaxTotal:c}\" tax=\"{invoiceTotal.Tax:c}\" total=\"{invoiceTotal.Total:c}\"/>");
            space = space.Substring(0, space.Length - 2);
            Console.WriteLine($"{space}</invoice>");
        }

        public void VisitProduct(Product product)
        {
            // Console.WriteLine($"{space}<line " +
            //     $"qty={product.Qty} " +
            //     $"productTitle=\"{product.Title}\" " +
            //     $"unitPrice=\"{product.UnitPrice}\"/>");
            Console.Write($"{space}<line qty={product.Qty} productTitle=\"{product.Title}\" unitPrice=\"{product.UnitPrice:C}");
        }
    }
}
