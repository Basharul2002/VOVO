using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOVO
{
    public class PDFGenerate
    {
        private byte[] GeneratePdfEmployee(string userId, string userName, string userCompanyName, string userJobTitle, string userPassword)
        {
            byte[] pdfBytes;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A6.Rotate());
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);

                document.Open();
                // Add a Decorative Border
                PdfContentByte borderContentByte = writer.DirectContent;
                /*
                // Outer Border with Gradient Fill
                PdfShading axial = PdfShading.SimpleAxial(writer, 10, document.PageSize.Height - 10, 20, 10, BaseColor.ORANGE, BaseColor.CYAN);
                PdfShadingPattern shading = new PdfShadingPattern(axial);
                borderContentByte.SetShadingFill(shading);
                borderContentByte.SetLineWidth(10f); // Outer border width
                borderContentByte.Rectangle(5, 5, document.PageSize.Width - 10, document.PageSize.Height - 10); // Outer rectangle
                borderContentByte.FillStroke();
                */
                // Inner Border with Dotted Line
                borderContentByte.SetRGBColorStroke(255, 127, 80); // Coral border color
                borderContentByte.SetLineDash(10f, 5f); // Dotted line pattern
                borderContentByte.SetLineWidth(2f); // Inner border width
                borderContentByte.RoundRectangle(20, 20, document.PageSize.Width - 40, document.PageSize.Height - 40, 15); // Rounded rectangle
                borderContentByte.Stroke();

                // Add Watermark
                PdfContentByte cb = writer.DirectContentUnder;
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.BeginText();
                BaseColor watermarkColor = new BaseColor(0xED, 0xF0, 0xF0); // Light gray watermark color
                cb.SetColorFill(watermarkColor);
                cb.SetFontAndSize(baseFont, 100);
                cb.SetTextMatrix(document.PageSize.Width / 2 - 150, document.PageSize.Height / 2 - 50);
                cb.ShowText("VOVO");
                cb.EndText();

                // Title
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font
                (
                    BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED),
                    30,
                    iTextSharp.text.Font.BOLD,
                    BaseColor.BLACK
                );

                iTextSharp.text.Paragraph titleParagraph = new iTextSharp.text.Paragraph(userJobTitle + " Information", titleFont);
                titleParagraph.Alignment = Element.ALIGN_CENTER;
                titleParagraph.SpacingAfter = 20;
                document.Add(titleParagraph);

                // User Info Table
                PdfPTable table = new PdfPTable(2);
                table.DefaultCell.Border = Rectangle.NO_BORDER;
                table.WidthPercentage = 80;

                // ID
                PdfPCell idCell = new PdfPCell(new Phrase("ID:", FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                idCell.Border = Rectangle.NO_BORDER;
                idCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(idCell);

                PdfPCell userIdCell = new PdfPCell(new Phrase(userId, FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                userIdCell.Border = Rectangle.NO_BORDER;
                userIdCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(userIdCell);

                // Name
                PdfPCell nameCell = new PdfPCell(new Phrase("Name:", FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                nameCell.Border = Rectangle.NO_BORDER;
                nameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(nameCell);

                PdfPCell userNameCell = new PdfPCell(new Phrase(userName, FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                userNameCell.Border = Rectangle.NO_BORDER;
                userNameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(userNameCell);

                // Company Name
                PdfPCell companyNameCell = new PdfPCell(new Phrase("Company Name:", FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                companyNameCell.Border = Rectangle.NO_BORDER;
                companyNameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(companyNameCell);

                PdfPCell userCompanyNameCell = new PdfPCell(new Phrase(userCompanyName, FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                userCompanyNameCell.Border = Rectangle.NO_BORDER;
                userCompanyNameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(userCompanyNameCell);

                // Job Title
                PdfPCell jobTitleCell = new PdfPCell(new Phrase("Job Title:", FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                jobTitleCell.Border = Rectangle.NO_BORDER;
                jobTitleCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(jobTitleCell);

                PdfPCell userJobTitleCell = new PdfPCell(new Phrase(userJobTitle, FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                userJobTitleCell.Border = Rectangle.NO_BORDER;
                userJobTitleCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(userJobTitleCell);

                // Password
                PdfPCell passwordCell = new PdfPCell(new Phrase("Password:", FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                passwordCell.Border = Rectangle.NO_BORDER;
                passwordCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(passwordCell);

                PdfPCell userPasswordCell = new PdfPCell(new Phrase(userPassword, FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK)));
                userPasswordCell.Border = Rectangle.NO_BORDER;
                userPasswordCell.HorizontalAlignment = Element.ALIGN_LEFT;
                table.AddCell(userPasswordCell);

                // Add the table to the document
                document.Add(table);

                // Close the document
                document.Close();

                // Save the PDF content to the memory stream
                pdfBytes = memoryStream.ToArray();
            }

            return pdfBytes;
        }


        public byte[] GenerateBusTicketPDF(string companyName, string busNumber, string busType_ticketID, string date, string passengerName, string from, string to, string boardingPoint_time, string seatNumber, /*System.Drawing.Image logo, */ System.Drawing.Image qrCode, string password)
        {
            Document document = new Document(new iTextSharp.text.Rectangle(630, 370));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                writer.SetEncryption(
                                        PdfWriter.STRENGTH128BITS,
                                        password,
                                        password,
                                        PdfWriter.AllowPrinting
                                     );

                document.Open();


                // Add a Decorative Border
                PdfContentByte borderContentByte = writer.DirectContent;
                borderContentByte.SetRGBColorStroke(255, 127, 80); // Coral border color
                borderContentByte.SetLineWidth(3f); // Border width
                borderContentByte.Rectangle(20, 20, document.PageSize.Width - 40, document.PageSize.Height - 40); // Rectangle coordinates
                borderContentByte.Stroke();


                // Add Watermark
                PdfContentByte cb = writer.DirectContentUnder;
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.BeginText();
                BaseColor watermarkColor = new BaseColor(0xED, 0xF0, 0xF0); // Replace with your desired color code
                cb.SetColorFill(watermarkColor);
                cb.SetFontAndSize(baseFont, 100);
                cb.SetTextMatrix(document.PageSize.Width / 2 - 100, document.PageSize.Height / 2);
                cb.ShowText("VOVO");
                cb.EndText();

                // Add Logo, XYZ Bus Services, and Boarding Pass
                iTextSharp.text.Image logoImage = iTextSharp.text.Image.GetInstance("D:\\University\\C# Coe\\Project - Copy (3) - CopyEsdiit\\Pic\\Icon.png");
                logoImage.Alignment = Element.ALIGN_CENTER;
                iTextSharp.text.Font companyNameFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 30, iTextSharp.text.Font.BOLD);
                companyNameFont.Color = BaseColor.BLACK;
                Chunk companyNameChunk = new Chunk(companyName, companyNameFont);
                Paragraph topParagraph = new Paragraph();
                topParagraph.Alignment = Element.ALIGN_CENTER;
                topParagraph.Add(new Chunk(logoImage, 0, 0));
                //topParagraph.Add(new Chunk("  ")); // Add some space between logo and company name
                topParagraph.Add(companyNameChunk);
                document.Add(topParagraph);


                iTextSharp.text.Font boardingPassFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 25, iTextSharp.text.Font.BOLD);
                boardingPassFont.Color = BaseColor.BLACK;
                Paragraph boardingPass = new Paragraph("BOARDING PASS", boardingPassFont);
                boardingPass.Alignment = Element.ALIGN_LEFT;
                document.Add(boardingPass);


                // Create table with 2 rows
                PdfPTable table = new PdfPTable(2);
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table.WidthPercentage = 100; // Set table width to 100% of page width


                // Set cell border to none for all cells
                table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;


                // Add left column content
                PdfPCell busTypeCell = new PdfPCell();
                iTextSharp.text.Font busTypeFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 13, iTextSharp.text.Font.BOLD);
                busTypeFont.Color = BaseColor.BLACK;
                Paragraph busTypeParagraph = new Paragraph(busType_ticketID, busTypeFont);
                busTypeParagraph.Alignment = Element.ALIGN_LEFT;
                busTypeCell.AddElement(busTypeParagraph);
                busTypeCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table.AddCell(busTypeCell);


                // Font
                iTextSharp.text.Font dateFont1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 17, iTextSharp.text.Font.BOLD);
                dateFont1.Color = BaseColor.BLACK;
                iTextSharp.text.Font dateFont2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 17, iTextSharp.text.Font.NORMAL);
                dateFont2.Color = BaseColor.BLACK;


                // Date
                PdfPCell dateTitleCell = new PdfPCell();
                Paragraph dateTitleParagraph = new Paragraph("Date", dateFont1);
                dateTitleCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                dateTitleCell.AddElement(dateTitleParagraph);
                dateTitleCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table.AddCell(dateTitleCell);

                // Font
                iTextSharp.text.Font font1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 13, iTextSharp.text.Font.BOLD);
                font1.Color = BaseColor.BLACK;
                iTextSharp.text.Font font2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 13, iTextSharp.text.Font.NORMAL);
                font2.Color = BaseColor.BLACK;


                // Pasenger Name
                PdfPCell passengerNameCell = new PdfPCell();
                passengerNameCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph passengerNameParagraph = new Paragraph();
                Chunk passengerNameChunk1 = new Chunk("Passenger Name          :  ", font1);
                Chunk passengerNameChunk2 = new Chunk(passengerName, font2);
                passengerNameParagraph.Add(passengerNameChunk1);
                passengerNameParagraph.Add(passengerNameChunk2);
                passengerNameCell.AddElement(passengerNameParagraph);
                table.AddCell(passengerNameCell);


                // Date Show
                PdfPCell pdfDateCell = new PdfPCell();
                Paragraph dateParagraph = new Paragraph(date, dateFont2);
                pdfDateCell.HorizontalAlignment = Element.ALIGN_RIGHT; // Align to the right
                pdfDateCell.AddElement(dateParagraph);
                pdfDateCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                table.AddCell(pdfDateCell);


                // Draw a decorative break line
                PdfContentByte dashedLineContentByte = writer.DirectContent;
                dashedLineContentByte.SetLineDash(4, 2); // Set a dashed pattern (line length, gap length)
                dashedLineContentByte.SetLineWidth(2f); // Line width
                BaseColor lineColor = new BaseColor(255, 127, 80); // RGB values for coral color
                dashedLineContentByte.SetColorStroke(lineColor); // Line color

                float lineStartX = 22;
                float lineEndX = document.PageSize.Width - 20;
                float lineY = 220;

                dashedLineContentByte.MoveTo(lineStartX, lineY);
                dashedLineContentByte.LineTo(lineEndX, lineY);
                dashedLineContentByte.Stroke();


                // From
                PdfPCell fromCell = new PdfPCell();
                fromCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph fromParagraph = new Paragraph();
                Chunk fromChunk1 = new Chunk("From         :  ", font1);
                Chunk fromChunk2 = new Chunk(from, font2);
                fromParagraph.Add(fromChunk1);
                fromParagraph.Add(fromChunk2);
                fromCell.AddElement(fromParagraph);
                table.AddCell(fromCell);


                // Boarding Point
                PdfPCell boardingPointCell = new PdfPCell();
                boardingPointCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph boardingPointParagraph = new Paragraph();
                Chunk boardingPointChunk1 = new Chunk("Boarding Point    :  ", font1);
                Chunk boardingPointChunk2 = new Chunk(boardingPoint_time, font2);
                boardingPointParagraph.Add(boardingPointChunk1);
                boardingPointParagraph.Add(boardingPointChunk2);
                boardingPointCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                boardingPointCell.AddElement(boardingPointParagraph);
                table.AddCell(boardingPointCell);


                // To
                PdfPCell toCell = new PdfPCell();
                toCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph toParagraph = new Paragraph();
                Chunk toChunk1 = new Chunk("To             :  ", font1);
                Chunk toChunk2 = new Chunk(to, font2);
                toParagraph.Add(toChunk1);
                toParagraph.Add(toChunk2);
                toCell.AddElement(toParagraph);
                table.AddCell(toCell);


                // Bus Number
                PdfPCell busNumberCell = new PdfPCell();
                busNumberCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph busNumberParagraph = new Paragraph();
                Chunk busNumberChunk1 = new Chunk("Bus Number        :  ", font1);
                Chunk busNumberChunk2 = new Chunk(busNumber, font2);
                busNumberParagraph.Add(busNumberChunk1);
                busNumberParagraph.Add(busNumberChunk2);
                busNumberCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                busNumberCell.AddElement(busNumberParagraph);
                table.AddCell(busNumberCell);


                // Seat Number
                PdfPCell seatNumberCell = new PdfPCell();
                seatNumberCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph seatNumberParagraph = new Paragraph();
                Chunk seatNumberTitleChunk = new Chunk("Seat Number :  ", font1);
                Chunk seatNumberChunk = new Chunk(seatNumber, font2);
                seatNumberParagraph.Add(seatNumberTitleChunk);
                seatNumberParagraph.Add(seatNumberChunk);
                seatNumberCell.AddElement(seatNumberParagraph);
                table.AddCell(seatNumberCell);

                PdfPCell pdfPCell = new PdfPCell();
                pdfPCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                Paragraph pdfPCellParagraph = new Paragraph("", font2);
                pdfPCell.AddElement(pdfPCellParagraph);
                table.AddCell(pdfPCell);

                // Add table 
                document.Add(table);


                // Add Thank You Message
                iTextSharp.text.Font thankYouFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14);
                Paragraph thankYou = new Paragraph("Thank you for choosing XYZ Bus Services.\nHave a safe journey!", thankYouFont);
                thankYou.Alignment = Element.ALIGN_CENTER;
                document.Add(thankYou);

                
                // Create an empty paragraph for spacing below the thank you message
                /*
                Paragraph spacingParagraph = new Paragraph(" ");
                spacingParagraph.SpacingBefore = 1; // Adjust the spacing as needed
                document.Add(spacingParagraph);
                */
                

                // Convert the System.Drawing.Image to iTextSharp.text.Image
                iTextSharp.text.Image iTextBarcodeImage = iTextSharp.text.Image.GetInstance(qrCode, System.Drawing.Imaging.ImageFormat.Png);

                // Specify the desired width and height for the barcode
                float barcodeWidth = 100; // Set your desired width here
                float barcodeHeight = 65; // Set your desired height here
                iTextBarcodeImage.ScaleToFit(barcodeWidth, barcodeHeight); // Scale the image to fit the desired dimensions

                // Create a new paragraph for the barcode
                Paragraph barcodeParagraph = new Paragraph();
                barcodeParagraph.Add(new Chunk(iTextBarcodeImage, 0, 0, true)); // Add the barcode image to the paragraph with alignment
                barcodeParagraph.Alignment = Element.ALIGN_CENTER;

                // Create a cell and add the paragraph to it
                PdfPCell barcodeCell = new PdfPCell(barcodeParagraph);
                barcodeCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                barcodeCell.HorizontalAlignment = Element.ALIGN_CENTER;

                // Create a table for the cell
                PdfPTable barcodeTable = new PdfPTable(1);
                barcodeTable.WidthPercentage = 100;
                barcodeTable.AddCell(barcodeCell);

                // Add the table to the document
                document.Add(barcodeTable);

                document.Close();

                // Save the PDF to a file
                File.WriteAllBytes("BusTicket.pdf", memoryStream.ToArray());

                return memoryStream.ToArray();
            }
        }

        public byte[] EmployeePDF(string userId, string name, string companyName, string jobTitle, string password)
        {
            //string userId, string userName, string userCompanyName, string userJobTitle, string userPassword
            // userId, name, companyName, jobTitle, password
            return GeneratePdfEmployee(userId, name, companyName, jobTitle, password);
        }


    }


}
