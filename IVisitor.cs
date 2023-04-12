using System;

namespace LabIII_invoice
{
    internal interface IVisitor
    {
        void VisitInvoice(Invoice invoice);
        void VisitInvoiceLine(InvoiceLine invoiceLine);
        void VisitProduct(Product product);
        void VisitInvoiceTotal(InvoiceTotal invoiceTotal);

    }

}
