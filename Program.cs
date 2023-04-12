using System;

namespace LabIII_invoice 
{
     internal class InvoiceTotal
    {
        public decimal PreTaxTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitInvoiceTotal(this);
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            var invoice = new Invoice
            {
                Date = new DateTime(2023, 01, 05),
                CustomerNumber = 5678,
                InvoiceNumber = 1234,
                PaymentBy = new DateTime(2023, 02, 05),
                invoicelines = new List<InvoiceLine>
            {
                new InvoiceLine { 
                     
                    Product = new Product 
                    { 
                        Qty = 1,
                        Title = "Mythical Man-Month", 
                        UnitPrice = 45m 
                    } 
                },
                new InvoiceLine {
                    
                    Product = new Product 
                    {
                        Qty = 4,
                        Title = "Ream of paper (500)",
                        UnitPrice = 5m 
                    } 
                },
                new InvoiceLine {
                    
                    Product = new Product 
                    { 
                        Qty = 1,
                        Title = "Standart Fruit Laptop",
                        UnitPrice = 2000m 
                    }
                }
            }
            };

            
            var visitor = new OperationConsoleString();
            invoice.Accept(visitor);
            Console.WriteLine(visitor.ToString());


            // XML representation 
            var xml = new XmlExport();
            invoice.Accept(xml);
            Console.WriteLine(xml.ToString());

        }
    }
}