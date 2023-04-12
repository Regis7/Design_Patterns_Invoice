using System;
using System.Text;

namespace LabIII_invoice
{
    internal class OperationConsoleString: IVisitor
    {
        StringBuilder builder = new StringBuilder();

        public void VisitInvoice(Invoice invoice)
        {
            builder.AppendLine(" ");
            builder.AppendLine($"Invoice \t\t\t Date: {invoice.Date.ToShortDateString()}");
            builder.AppendLine(" ");
            builder.AppendLine($"Customer number: {invoice.CustomerNumber}");
            builder.AppendLine($"Invoice number: {invoice.InvoiceNumber}");
            builder.AppendLine($"Payment by: {invoice.PaymentBy.ToShortDateString()}");
            builder.AppendLine(" ");
            builder.AppendLine("Qty\tProduct\t\t\tUnit Price\tTotal");
            builder.AppendLine(" ");

        }

        public void VisitInvoiceLine(InvoiceLine invoiceLine)
        {
            // builder.AppendLine($"{invoiceLine.Qty}\t{invoiceLine.Product.Title}\t" +
            //     $"{invoiceLine.Product.UnitPrice:C}\t\t{invoiceLine.Total:C}");
            // builder.AppendLine("");
            invoiceLine.Product.Accept(this);
            builder.AppendLine($"\t\t{invoiceLine.Total:C}");
        }

        public void VisitInvoiceTotal(InvoiceTotal invoiceTotal)
        {
            builder.AppendLine($"\t\t\t\tPre-tax total: {invoiceTotal.PreTaxTotal:C}");
            builder.AppendLine($"\t\t\t\tTax(10%): {invoiceTotal.Tax:C}");
            builder.AppendLine($"\t\t\t\tTotal: {invoiceTotal.Total:C}");
        }

        public void VisitProduct(Product product)
        {
            builder.Append($"{product.Qty}\t{product.Title}\t{product.UnitPrice:C}");
        }

        public override string ToString() => builder.ToString();



    }
}
