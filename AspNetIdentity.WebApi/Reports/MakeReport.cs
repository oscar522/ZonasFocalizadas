using AspNetIdentity.WebApi.Reports.Parts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AspNetIdentity.WebApi.Reports
{
    public class MakeReport
    {
        private readonly string FontPath = ConfigurationManager.AppSettings["FontPath"];
        private readonly string ImgHeaderPath = ConfigurationManager.AppSettings["ImgHeader"];
        private readonly string ImgFooterPath = ConfigurationManager.AppSettings["ImgFooter"];
        private readonly string ImgLogo = ConfigurationManager.AppSettings["ImgLogo"];
        private ReportParts reportParts = null;

        public MakeReport(ReportParts _reportParts)
        {
            reportParts = _reportParts;
        }

        public MemoryStream Make()
        {

            MemoryStream ms = new MemoryStream();
            Settings.FontCustom(FontPath);
            Document doc = new Document(PageSize.LETTER, 30, 30, 15, 60);
            PdfWriter pwriter = PdfWriter.GetInstance(doc, ms);

            pwriter.PageEvent = new HeaderFooter(ImgLogo, ImgHeaderPath, ImgFooterPath);

            doc.Open();

            Rectangle page = doc.PageSize;

            #region [PAGINA 1]

            PdfPTable lh = new PdfPTable(1);
            lh.WidthPercentage = 100;
            float[] widths = new float[] { 100f };
            lh.HorizontalAlignment = 1;

            lh.AddCell(Settings.EmptyCell());

            doc.Add(lh);

            lh.SpacingAfter = 50;

            lh = new PdfPTable(new float[] { 25f, 50f, 25f });
            lh.WidthPercentage = 100;
            lh.HorizontalAlignment = 1;

            lh.AddCell(Settings.EmptyCell());
            PdfPCell lhleft1 = new PdfPCell();
            lhleft1.Border = Rectangle.NO_BORDER;
            lhleft1.Rowspan = 3;
            lhleft1.PaddingTop = 0;
            Image img = Image.GetInstance(ImgLogo);
            lhleft1.AddElement(img);
            lh.AddCell(lhleft1);
            lh.AddCell(Settings.EmptyCell());

            doc.Add(lh);


            lh = new PdfPTable(new float[] { 100f });
            lh.SpacingBefore = 50;
            lh.WidthPercentage = 100;
            lh.HorizontalAlignment = 1;
            
            PdfPCell celltmp = new PdfPCell();
            celltmp.MinimumHeight = 20;
            celltmp.PaddingTop = 5;
            celltmp.Border = Rectangle.NO_BORDER;
            Settings.AddText(ref celltmp, reportParts.headerPart.Test, Element.ALIGN_CENTER, Settings.Calibri_Title);
            lh.AddCell(celltmp);

            celltmp = new PdfPCell();
            celltmp.Padding = -5;
            celltmp.Border = Rectangle.NO_BORDER;
            Settings.AddText(ref celltmp, reportParts.headerPart.Company, Element.ALIGN_CENTER, Settings.Calibri_SubTitle);
            lh.AddCell(celltmp);

            celltmp = new PdfPCell();
            celltmp.Padding = -5;
            celltmp.Border = Rectangle.NO_BORDER;
            Settings.AddText(ref celltmp, reportParts.headerPart.Name, Element.ALIGN_CENTER, Settings.Calibri_SubTitle);
            lh.AddCell(celltmp);

            celltmp = new PdfPCell();
            celltmp.Padding = -5;
            celltmp.Border = Rectangle.NO_BORDER;
            Settings.AddText(ref celltmp, reportParts.headerPart.EvaluationDate.ToShortDateString(), Element.ALIGN_CENTER, Settings.Calibri_SubTitle);
            lh.AddCell(celltmp);


            doc.Add(lh);


            lh = new PdfPTable(new float[] { 25f, 50f, 25f });
            lh.SpacingBefore = 100;
            lh.WidthPercentage = 100;
            lh.HorizontalAlignment = 1;

            lh.AddCell(Settings.EmptyCell());
            lhleft1 = new PdfPCell();
            lhleft1.Border = Rectangle.NO_BORDER;
            lhleft1.Rowspan = 3;
            lhleft1.PaddingTop = 0;
            img = Image.GetInstance(reportParts.headerPart.CoverPageImage);
            lhleft1.AddElement(img);
            lh.AddCell(lhleft1);
            lh.AddCell(Settings.EmptyCell());

            doc.Add(lh);

            #endregion

            doc.SetMargins(30, 30, 70, 45);

            #region [PAGINA 2] Descripción

            MakeBody(ref doc, reportParts.bodyParts);
            
            //PdfContentByte pdfContentByte = pwriter.DirectContent;
            //pdfContentByte.SetCMYKColorFill(0, 255, 255, 0);
            //pdfContentByte.SetLineWidth(2f);
            //pdfContentByte.Circle(120f, 250f, 50f);
            //pdfContentByte.Fill();

            #endregion
            
            doc.Close();

            return ms;
        }

        private void MakeBody(ref Document doc, List<BodyPart> bodyParts)
        {
            foreach (BodyPart bodyPart in bodyParts)
            {
                switch (bodyPart.Id_Test)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        foreach (SectionParts sectionParts in bodyPart.sectionParts)
                        {
                            doc.NewPage();
                            Settings.AddSection(ref doc, sectionParts, 450f);
                        }

                        break;
                }
            }

        }
    }
}