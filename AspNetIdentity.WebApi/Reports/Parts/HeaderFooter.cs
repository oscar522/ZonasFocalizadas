using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Reports.Parts
{
    public class HeaderFooter : PdfPageEventHelper
    {
        private string LogoHeader;
        private string ImgHeaderPath;
        private string ImgFooterPath;

        public HeaderFooter(string pLogoHeader, string pImgHeaderPath, string pImgFooterPath)
        {
            LogoHeader = pLogoHeader;
            ImgHeaderPath = pImgHeaderPath;
            ImgFooterPath = pImgFooterPath;
        }

        // write on top of document
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
        }

        // write on start of each page
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            if (document.PageNumber > 1)
            {
                PdfPTable tbHeader = Settings.CreateTable(1, new float[] { 100 }, 100, 0);
                tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;


                PdfPCell _cell = new PdfPCell();
                _cell.Border = 0;

                Image img = Image.GetInstance(ImgHeaderPath);
                img.ScaleAbsolute(550f, 65f);
                _cell.AddElement(img);
                
                tbHeader.AddCell(_cell);

                tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 55, writer.DirectContent);
            }
        }
        // write on end of each page
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            if (document.PageNumber > 1)
            {
                base.OnEndPage(writer, document);

                PdfPTable tfooter = Settings.CreateTable(4, new float[] { 70, 15, 5, 10 }, 100f, 0);

                PdfPCell cf = Settings.CreateCell(" ", Settings.Calibri_60, 0, 0, null, 0);
                cf.BorderWidthTop = 0.5f;
                cf.Colspan = 4;
                cf.PaddingBottom = -25f;

                tfooter.AddCell(cf);

                cf = Settings.CreateCell("Human Cloud V1. © All rights reserved.", Settings.Calibri_60, 0, 0, null, 5);
                cf.PaddingBottom = -3f;
                tfooter.AddCell(cf);

                cf = Settings.CreateCell(" ", Settings.Calibri_60, 0, 0, null, 5);
                cf.PaddingBottom = -3f;
                tfooter.AddCell(cf);

                cf = Settings.CreateCell(" ", Settings.Calibri_60, 0, 0, null, 5);
                cf.PaddingBottom = -3f;
                tfooter.AddCell(cf);

                cf = Settings.CreateCell(DateTime.Now.ToShortDateString(), Settings.Calibri_60, 0, 2, null, 5);
                cf.PaddingBottom = -3f;
                tfooter.AddCell(cf);

                cf = Settings.CreateCell("Human Cloud is a registered trademark, used under license of Gestores Talento Humano SAS.", Settings.Calibri_60, 0, 0, null, 5);

                tfooter.AddCell(cf);
                tfooter.AddCell(Settings.EmptyCell());
                tfooter.AddCell(Settings.EmptyCell());
                tfooter.AddCell(Settings.EmptyCell());
                tfooter.TotalWidth = document.Right - document.Left;

                tfooter.WriteSelectedRows(0, -1, document.Left, document.Bottom, writer.DirectContent);
            }
        }
    }
}