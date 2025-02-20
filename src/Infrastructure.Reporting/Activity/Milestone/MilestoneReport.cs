﻿using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dama.Core.Common.Helpers;
using Dama.Fin.Domain.Contracts.Service.Report;
using Dama.Fin.Domain.Entity.Budgeting;
using Dama.Fin.Domain.Vm.Budgeting;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Dama.Fin.Infrastructure.Reporting.Activity.Milestone
{
    public class MilestoneReport : IMilestoneReport
    {
        public async Task<byte[]> GenerateAsync(List<MilestoneDashboardVm> data, MilestoneDasboardOptions Options)
        {
            if (data == null)
                throw new InvalidEnumArgumentException(nameof(data));

            if (Options == null)
                throw new InvalidEnumArgumentException(nameof(Options));

            await using var ms = new MemoryStream();
            var document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 1);
            var writer = PdfWriter.GetInstance(document, ms);
            document.Open();

            var cb = writer.DirectContent;

            document.Add(GetReportHeader(Options));
            document.Add(GetReportBody(data));

            WritePageFooter(cb, writer);

            document.Close();
            writer.Close();

            var reportBytes = ms.ToArray();

            ms.Close();
            return reportBytes;
        }

        private static void WritePageFooter(PdfContentByte cb, PdfWriter writer)
        {
            var bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

            cb.BeginText();
            cb.SetFontAndSize(bfTimes, 9);

            cb.SetLineWidth(0f);
            cb.MoveTo(30, 40);
            cb.LineTo(815, 40);
            cb.Stroke();

            cb.SetTextMatrix(30, 20);
            cb.ShowText($"Page {writer.PageNumber} of {writer.PageNumber}");

            //cb.SetTextMatrix(400, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Generated by Dama Finance", 407, 20, 0);

            cb.EndText();
        }

        private static Font GetFont(float fontSize, int fontStyle, string fontName = "Tahoma") =>
            FontFactory.GetFont(fontName, fontSize, fontStyle);

        private static PdfPTable GetReportHeader(MilestoneDasboardOptions options)
        {
            var table = new PdfPTable(3)
            {
                WidthPercentage = 100,
                HorizontalAlignment = Element.ALIGN_LEFT
            };

            WriteReportHeader(table, options);

            return table;
        }

        private static void WriteReportHeader(PdfPTable table, MilestoneDasboardOptions options)
        {
            var titleFont = GetFont(13f, 1);
            var subTitleBoldFont = GetFont(10f, 1);
            var subTitleFont = GetFont(10f, 0);
            var emptyRowFont = GetFont(6f, 0);
            var printPeriodFont = GetFont(10f, 0);

            const int maxColumn = 3;

            WriteRow(table, "CAMEROON BAPTIST CONVENTION HEALTH SERVICES", maxColumn, titleFont);
            WriteRow(table, "CDC/PEPFAR HIV FREE PROJECT ZONE I", maxColumn, subTitleFont);
            WriteRow(table, "", maxColumn, emptyRowFont);
            WriteRow(table, $"{options.ReportTitle.ToUpper()}", maxColumn, subTitleBoldFont);
            WriteEmptyRow(table, "", 1, maxColumn, emptyRowFont);
            WriteRow(table, $"PERIOD FROM {options.StartDate.ToShortDateFormat()} - {options.EndDate.ToShortDateFormat()}", maxColumn, printPeriodFont);
            WriteEmptyRow(table, "", 1, maxColumn, emptyRowFont);
            WriteRow(table, $"{options.Region.ToUpper()} REGION", maxColumn, printPeriodFont);
            WriteEmptyRow(table, "", 2, maxColumn, emptyRowFont);
        }

        private static void WriteRow(PdfPTable table, string text, int colSpan, Font font,
            int horizontalAlignment = Element.ALIGN_CENTER, int border = 0, int extraParagraphSpace = 0)
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                Colspan = colSpan,
                HorizontalAlignment = horizontalAlignment,
                Border = border,
                ExtraParagraphSpace = extraParagraphSpace
            };
            table.AddCell(cell);
            table.CompleteRow();
        }

        private static void WriteEmptyRow(PdfPTable table, string text, int nCount, int colSpan, Font font,
            int horizontalAlignment = Element.ALIGN_CENTER, int border = 0, int extraParagraphSpace = 0)
        {
            for (var i = 1; i <= nCount; i++)
            {
                var cell = new PdfPCell(new Phrase(text, font))
                {
                    Colspan = colSpan,
                    HorizontalAlignment = horizontalAlignment,
                    Border = border,
                    ExtraParagraphSpace = extraParagraphSpace
                };
                table.AddCell(cell);
                table.CompleteRow();
            }
        }

        private static PdfPTable GetReportBody(List<MilestoneDashboardVm> data)
        {
            var table = new PdfPTable(7)
            {
                WidthPercentage = 100,
                HorizontalAlignment = Element.ALIGN_LEFT
            };

            SetTableColumnWidths(table);

            //table.HeaderRows = 2;

            //Report Header
            WritePageHeader(table);

            var font = GetFont(9f, 0);
            // detail table body

            //sites
            foreach (var milestone in data)
            {
                WriteReportDetail(table, milestone.SiteName, font, BaseColor.White, Element.ALIGN_LEFT);
                WriteReportDetail(table, $"{Truncate(milestone.ActivityPlanDescription, 50)}...", font, BaseColor.White, Element.ALIGN_LEFT);
                WriteReportDetail(table, milestone.BudgetNote, font, BaseColor.White, Element.ALIGN_LEFT);
                WriteReportDetail(table, $"{Truncate(milestone.InterventionName, 25)}...", font, BaseColor.White, Element.ALIGN_LEFT);
                WriteReportDetail(table, milestone.Target.ToString("##,##0"), font, BaseColor.White, Element.ALIGN_RIGHT);
                WriteReportDetail(table, milestone.Achievement.ToString("##,##0"), font, BaseColor.White, Element.ALIGN_RIGHT);
                WriteReportDetail(table, milestone.Budget.ToString("##,##0"), font, BaseColor.White, Element.ALIGN_RIGHT);
            }

            //Report Totals
            WriteReportFooter(table, data);

            return table;
        }

        private static void WriteReportFooter(PdfPTable table, IReadOnlyCollection<MilestoneDashboardVm> data)
        {
            var font = GetFont(9f, 0);

            WriteReportDetail(table, "", font, BaseColor.White, Element.ALIGN_LEFT);
            WriteReportDetail(table, "TOTAL", font, BaseColor.White, Element.ALIGN_LEFT);
            WriteReportDetail(table, "", font, BaseColor.White, Element.ALIGN_LEFT);
            WriteReportDetail(table, "", font, BaseColor.White, Element.ALIGN_LEFT);
            WriteReportDetail(table, data.Sum(x => x.Target).ToString("##,##0"), font, BaseColor.White, Element.ALIGN_RIGHT);
            WriteReportDetail(table, data.Sum(x => x.Achievement).ToString("##,##0"), font, BaseColor.White, Element.ALIGN_RIGHT);
            WriteReportDetail(table, data.Sum(x => x.Budget).ToString("##,##0"), font, BaseColor.White, Element.ALIGN_RIGHT);
        }

        private static void WritePageHeader(PdfPTable table)
        {
            var font = GetFont(9f, 0);

            WriteReportDetail(table, "SITE", font, BaseColor.Gray);
            WriteReportDetail(table, "ACTIVITY", font, BaseColor.Gray);
            WriteReportDetail(table, "BUDGET NOTES", font, BaseColor.Gray);
            WriteReportDetail(table, "INTERVENTION", font, BaseColor.Gray);
            WriteReportDetail(table, "TARGET", font, BaseColor.Gray);
            WriteReportDetail(table, "ACHIEV", font, BaseColor.Gray);
            WriteReportDetail(table, "BUDGET", font, BaseColor.Gray);

            table.CompleteRow();
        }

        private static void WriteReportDetail(PdfPTable table, string text, Font font, BaseColor backgroundColor,
            int horizontalAlignment = Element.ALIGN_CENTER, int verticalAlignment = Element.ALIGN_MIDDLE)
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = verticalAlignment,
                BackgroundColor = backgroundColor,
                Padding = 4,
                NoWrap = true,
                UseBorderPadding = true
            };
            table.AddCell(cell);
        }

        private static void SetTableColumnWidths(PdfPTable table)
        {
            var sizes = new float[7];
            const int w = 30;
            for (var i = 0; i < 7; i++)
            {
                sizes[i] = i switch
                {
                    0 => 50,
                    1 => 100,
                    2 => 50,
                    3 => 50,
                    4 => w,
                    5 => w,
                    6 => w,
                    //7 => w,
                    //8 => w,
                    //9 => w,
                    _ => sizes[i]
                };
            }

            table.SetWidths(sizes);
        }
        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}