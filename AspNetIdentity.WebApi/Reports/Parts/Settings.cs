using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Reports.Parts
{
    public static class Settings
    {
        public static Font Calibri_Title = FontFactory.GetFont("Calibri", 20f, 1);
        public static Font Calibri_SubTitle = FontFactory.GetFont("Calibri", 12f, 1);
        public static Font Calibri_12 = FontFactory.GetFont("Calibri", 12f);


        public static Font Calibri_90 = FontFactory.GetFont("Calibri", 9f);
        public static Font Calibri_90_BoldI = FontFactory.GetFont(fontname: "Calibri", size: 9f, style: BaseFont.ITALICANGLE);
        public static Font Calibri_80 = FontFactory.GetFont("Calibri", 8f);
        public static Font Calibri_80_Bold = FontFactory.GetFont("Calibri", 8f, 3);
        public static Font Calibri_70_Bold = FontFactory.GetFont("Calibri", 7f, 3);
        public static Font Calibri_70 = FontFactory.GetFont("Calibri", 7f);
        public static Font Calibri_80_Gray = FontFactory.GetFont("Calibri", 7f);
        public static Font Calibri_60 = FontFactory.GetFont("Calibri", 6f);
        public static Font Calibri_50 = FontFactory.GetFont("Calibri", 5f);
        public static Font Calibri_50_Gray = FontFactory.GetFont("Calibri", 5f);
        public static Font Calibri_70_White = FontFactory.GetFont("Calibri", 7f);
        public static BaseColor ColoGrayCells = new BaseColor(221, 221, 221);
        public static BaseColor ColoHardGray = new BaseColor(192, 192, 192);
        public static BaseColor ColorWhite = new BaseColor(255, 255, 255);
        public static BaseColor ColorShare = new BaseColor(77, 77, 77);
        public static BaseColor ColorHardHGray = new BaseColor(100, 100, 100);
        public static BaseColor ColorBlueBar = new BaseColor(28, 71, 140);

        public static void FontCustom(string rtaFont)
        {
            if (!string.IsNullOrEmpty(rtaFont) && System.IO.File.Exists(rtaFont))
            {
                BaseFont bf = BaseFont.CreateFont(rtaFont, BaseFont.CP1252, BaseFont.EMBEDDED);
                Calibri_Title = new Font(bf, 20f, 1);
                Calibri_SubTitle = new Font(bf, 12f, 1);
                Calibri_12 = new Font(bf, 12f);


                Calibri_80 = new Font(bf, 8f);
                Calibri_80_Bold = new Font(bf, 8f, 3);
                Calibri_70_Bold = new Font(bf, 7f, 1);
                Calibri_70 = new Font(bf, 7f);
                Calibri_70_White = new Font(bf, 7f, 0, ColorWhite);
                Calibri_90 = new Font(bf, 9f);
                Calibri_90_BoldI = new Font(bf, 9f, 3);
                Calibri_60 = new Font(bf, 6f);
                Calibri_80_Gray = new Font(bf, 8f, 0, ColorHardHGray);
                Calibri_50_Gray = new Font(bf, 5f, 0, ColorHardHGray);
            }
        }

        public static PdfPCell EmptyCell()
        {
            PdfPCell lhleft2 = new PdfPCell(new Phrase(" "));
            lhleft2.Border = Rectangle.NO_BORDER;
        
            return lhleft2;
        }

        public static void CreateFielShare(ref PdfPCell pCell, string plabel, string pcontent, float[] pwiths1, float[] pwiths2, float pSpacing, float pMinHeight, float pHeightShare, string pContent2, int pAling, BaseColor pColor)
        {
            PdfPTable tdata = new PdfPTable(4);
            PdfPCell ccll = null;
            float[] widths = null;

            if (pColor == null)
                pColor = Settings.ColorShare;

            tdata.WidthPercentage = 100;
            widths = pwiths1;
            tdata.SetWidths(widths);

            tdata.AddCell(Settings.EmptyCell());
            tdata.AddCell(Settings.EmptyCell());
            ccll = Settings.CreateCell("", Settings.Calibri_70, 0.1f, 0, null, 1);
            ccll.MinimumHeight = pMinHeight;
            tdata.AddCell(ccll);
            tdata.AddCell(Settings.EmptyCell());

            tdata.SpacingBefore = pSpacing;
            tdata.SpacingAfter = (pMinHeight + pHeightShare) * -1;
            pCell.AddElement(tdata);

            tdata = new PdfPTable(4);
            tdata.WidthPercentage = 100;
            widths = pwiths2;
            tdata.SetWidths(widths);

            PdfPCell clabl = CreateCell(plabel, Settings.Calibri_70_Bold, 0, 2, null, 1);
            clabl.PaddingTop = 7;
            tdata.AddCell(clabl);

            tdata.AddCell(Settings.EmptyCell());
            ccll = Settings.CreateCell(pcontent, Settings.Calibri_70, 0f, pAling, Settings.ColorWhite, 1);
            ccll.MinimumHeight = pMinHeight;
            ccll.PaddingTop = 5;
            ccll.BorderColor = Settings.ColorWhite;
            ccll.VerticalAlignment = 1;
            tdata.AddCell(ccll);

            if (string.IsNullOrEmpty(pContent2))
            {
                tdata.AddCell(Settings.EmptyCell());
            }
            else
            {
                clabl = CreateCell(pContent2, Settings.Calibri_70, 0, 0, null, 0);
                clabl.PaddingTop = 7;
                tdata.AddCell(clabl);
            }

            pCell.AddElement(tdata);

        }

        public static void CreateFielShareImg(ref PdfPCell pCell, byte[] pcontent, float[] pwiths1, float[] pwiths2, float pSpacing, float pMinHeight, float pHeightShare)
        {
            PdfPTable tdata = new PdfPTable(4);
            PdfPCell ccll = null;
            float[] widths = null;

            tdata.WidthPercentage = 100;
            widths = pwiths1;
            tdata.SetWidths(widths);

            tdata.AddCell(Settings.EmptyCell());
            tdata.AddCell(Settings.EmptyCell());
            ccll = Settings.CreateCell("", Settings.Calibri_70, 0.1f, 0, null, 1);
            ccll.MinimumHeight = pMinHeight;
            tdata.AddCell(ccll);
            tdata.AddCell(Settings.EmptyCell());

            tdata.SpacingBefore = (pMinHeight - 1) * -1;
            tdata.SpacingAfter = (pMinHeight + pHeightShare) * -1;
            pCell.AddElement(tdata);

            tdata = new PdfPTable(4);
            tdata.WidthPercentage = 100;
            widths = pwiths2;
            tdata.SetWidths(widths);

            PdfPCell clabl = CreateCell("", Settings.Calibri_70_Bold, 0, 2, null, 0);
            clabl.PaddingTop = 7;
            tdata.AddCell(clabl);

            tdata.AddCell(Settings.EmptyCell());
            ccll = new PdfPCell();

            ccll.MinimumHeight = pMinHeight;
            ccll.BackgroundColor = Settings.ColorWhite;
            ccll.BorderColor = Settings.ColorWhite;
            ccll.VerticalAlignment = 1;

            if (pcontent != null && pcontent.Length > 0)
            {
                ccll.Image = Image.GetInstance(pcontent);
                ccll.Image.CompressionLevel = 9;
                ccll.Image.Alignment = 1;
                ccll.Image.ScaleToFit(pMinHeight, pMinHeight);

                float ajust = pMinHeight - ccll.Image.ScaledHeight;

                if (ajust > 0)
                {
                    ccll.PaddingTop = ajust / 2;

                }
            }

            tdata.AddCell(ccll);
            tdata.AddCell(Settings.EmptyCell());

            pCell.AddElement(tdata);

        }

        public static PdfPTable CreateTable(int columns, float[] widths, float percentage, int HorizontalAlignment)
        {
            PdfPTable tbla = new PdfPTable(columns);
            tbla.WidthPercentage = percentage;
            tbla.SetWidths(widths);
            tbla.HorizontalAlignment = HorizontalAlignment;
            return tbla;
        }

        public static PdfPCell CreateCell(string content, Font font, int border, int HorizontalAlignment, BaseColor background, float padding)
        {
            PdfPCell cell = new PdfPCell(new Phrase((content)
                , font)
                );
            cell.BorderWidth = 0;
            cell.BorderWidthBottom = border;
            cell.HorizontalAlignment = HorizontalAlignment;
            cell.BackgroundColor = background;
            cell.Padding = padding;

            cell.SetLeading(0f, 1.5f);

            return cell;
        }

        public static PdfPCell CreateCell(string content, string contentValue, Font font, int border, int HorizontalAlignment, BaseColor background, float padding)
        {
            PdfPTable pdfPTable = new PdfPTable(new float[] { 50, 50 });
            pdfPTable.AddCell(CreateCell(content, font, border, Element.ALIGN_LEFT, null, padding));
            pdfPTable.AddCell(CreateCell(contentValue, font, border, Element.ALIGN_RIGHT, null, padding));
            
            PdfPCell cell = new PdfPCell(pdfPTable);
            cell.BorderWidth = 0;
            cell.BorderWidthBottom = border;
            cell.HorizontalAlignment = HorizontalAlignment;
            cell.BackgroundColor = background;
            cell.Padding = padding;

            cell.SetLeading(0f, 1.5f);

            return cell;
        }

        public static PdfPCell CreateCell(string content, Font font, float border, int HorizontalAlignment, BaseColor background, float padding)
        {
            PdfPCell cell = new PdfPCell(new Phrase((content)
                , font)
                );
            cell.BorderWidth = 0;
            cell.BorderWidthBottom = border;
            cell.HorizontalAlignment = HorizontalAlignment;
            cell.BackgroundColor = background;
            cell.Padding = padding;

            cell.SetLeading(0f, 1.5f);

            return cell;
        }

        public static PdfPCell CreateCell(string content, Font font, float border, int HorizontalAlignment, BaseColor background)
        {
            PdfPCell cell = new PdfPCell(new Phrase((content), font));
            cell.BorderWidth = border;
            cell.HorizontalAlignment = HorizontalAlignment;
            cell.BackgroundColor = background;

            cell.SetLeading(0f, 1.5f);

            return cell;
        }

        public static void AddTitle(ref PdfPCell pCell, string pTitle, int? pHorizontalAligment = 0, float? pWidthLine = 0.5f)
        {
            //TITULO
            PdfPTable tTitle = Settings.CreateTable(1, new float[] { 100 }, 100, 0);
            tTitle.AddCell(Settings.CreateCell(pTitle, Settings.Calibri_Title, 0, (int)pHorizontalAligment, null, 5));
            tTitle.SpacingBefore = 15;
            PdfPCell ccontent = Settings.EmptyCell();
            ccontent.BorderWidth = 0;
            ccontent.BorderWidthBottom = (float)pWidthLine;
            tTitle.AddCell(ccontent);
            pCell.AddElement(tTitle);

        }

        public static void AddText(ref PdfPCell pCell, string pContent, int pHorizontalAligment, Font pFont)
        {
            PdfPTable tTitle = Settings.CreateTable(1, new float[] { 100 }, 100, 0);
            tTitle.AddCell(Settings.CreateCell(pContent, pFont, 0, pHorizontalAligment, null, 2));
            tTitle.SpacingBefore = 5;
            PdfPCell ccontent = Settings.EmptyCell();
            ccontent.BorderWidth = 0;
            tTitle.AddCell(ccontent);

            pCell.AddElement(tTitle);
        }

        public static void AddSection(ref Document pDoc, SectionParts pTexto, float? pImageFitHeight = 500f)
        {
            PdfPTable tcontent = Settings.CreateTable(1, new float[] { 100 }, 100, 0);

            PdfPCell ccontent = new PdfPCell();
            ccontent.Border = Rectangle.NO_BORDER;

            if (!string.IsNullOrEmpty(pTexto.Title))
            {
                Settings.AddTitle(ref ccontent, pTexto.Title);
                tcontent.AddCell(ccontent);
            }

            if (!string.IsNullOrEmpty(pTexto.Description))
            {
                ccontent = Settings.CreateCell(pTexto.Description, Settings.Calibri_12, 0, Rectangle.ALIGN_JUSTIFIED, null, 5);
                ccontent.PaddingTop = 15;
                tcontent.AddCell(ccontent);
                ccontent = Settings.EmptyCell();
                ccontent.PaddingTop = 30;
                tcontent.AddCell(ccontent);
            }

            if (pTexto.Image != null && pTexto.Image.Length > 0)
            {
                ccontent = new PdfPCell();
                ccontent.Border = Rectangle.NO_BORDER;
                ccontent.PaddingTop = 15;

                Image img = Image.GetInstance(pTexto.Image);
                img.ScaleToFit((float)pImageFitHeight, (float)pImageFitHeight);
                img.Alignment = Element.ALIGN_CENTER;
                ccontent.AddElement(img);
                tcontent.AddCell(ccontent);

                ccontent = Settings.EmptyCell();
                ccontent.PaddingTop = 15;
                tcontent.AddCell(ccontent);
            }

            if (pTexto.SubSections != null)
            {
                pTexto.SubSections.ForEach(
                    fe => 
                    {
                        if (!string.IsNullOrEmpty(fe.Title))
                        {
                            BaseColor baseColor = new BaseColor(fe.Color["r"], fe.Color["g"], fe.Color["b"]);
                            if (fe.Value >= 0)
                                ccontent = Settings.CreateCell(fe.Title, fe.Value.ToString(), Settings.Calibri_12, 0, 0, baseColor, 5);
                            else
                                ccontent = Settings.CreateCell(fe.Title, Settings.Calibri_12, 0, 0, baseColor, 5);
                            ccontent.PaddingTop = -5;
                            tcontent.AddCell(ccontent);
                            tcontent.AddCell(Settings.EmptyCell());
                        }

                        if (!string.IsNullOrEmpty(fe.Description))
                        {
                            ccontent = Settings.CreateCell(fe.Description, Settings.Calibri_12, 0, Rectangle.ALIGN_JUSTIFIED, null, 5);
                            ccontent.PaddingTop = -5;
                            tcontent.AddCell(ccontent);
                            tcontent.AddCell(Settings.EmptyCell());
                        }
                    });
            }

            pDoc.Add(tcontent);
        }
    }
}