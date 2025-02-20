using System.Collections.Generic;
using System.IO;
using Dama.Fin.Domain.Contracts.Service.Report;
using Dama.Fin.Domain.Vm.Budgeting;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Dama.Fin.Infrastructure.Reporting.Activity.ActivityPlan;

public class ActivityPlanReport: IActivityPlanReport
{ 

    private const int MaxColumn = 3;
    private readonly Document _document = new Document();
    private Font _fontStyle;
    private PdfPCell _pdfCell;
    private readonly PdfPTable _pdfTable = new PdfPTable(3);
    private readonly MemoryStream _memoryStream = new MemoryStream();

    private List<ActivityPlanVm> _activityPlans;

    public byte[] Generate(List<ActivityPlanVm> activityPlans)
    {
        _activityPlans = activityPlans;
        _document.SetPageSize(PageSize.A4);
        _document.SetMargins(5f, 5f, 20f, 5f);

        _pdfTable.WidthPercentage = 100;
        _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

        var docWrite = PdfWriter.GetInstance(_document, _memoryStream);

        _document.Open();

        var sizes = new float[MaxColumn];
        for (var i = 0; i < MaxColumn; i++)
        {
            sizes[i] = i switch
            {
                0 => 8,
                1 => 12,
                2 => 100,
                _ => sizes[i]
            };
        }
        _pdfTable.SetWidths(sizes);

        ReportHeader();
        EmptyRow(2);
        ReportBody();

        _pdfTable.HeaderRows = 2;

        _document.Add(_pdfTable);

        _document.Close();

        return _memoryStream.ToArray();
    }

    private void ReportBody()
    {
        var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
        _fontStyle= FontFactory.GetFont("Tahoma", 9f, 0);


        //Report Header
        _pdfCell = new PdfPCell(new Phrase("Tenant", fontStyleBold))
        {
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            BackgroundColor = BaseColor.Gray
        };
        _pdfTable.AddCell(_pdfCell);

        _pdfCell = new PdfPCell(new Phrase("Code", fontStyleBold))
        {
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            BackgroundColor = BaseColor.Gray
        };
        _pdfTable.AddCell(_pdfCell);

        _pdfCell = new PdfPCell(new Phrase("Description", fontStyleBold))
        {
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            BackgroundColor = BaseColor.Gray
        };
        _pdfTable.AddCell(_pdfCell);

        _pdfTable.CompleteRow();

        // detail table body
        foreach (var activityPlan in _activityPlans)
        {
            _pdfCell = new PdfPCell(new Phrase(activityPlan.Tenant, _fontStyle))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.White
            };
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase(activityPlan.Code, _fontStyle))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.White
            };
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase(activityPlan.Description, _fontStyle))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                BackgroundColor = BaseColor.White
            };
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();
        }

    }

    private void EmptyRow(int nCount)
    {
        for (var i = 1; i <= nCount; i++)
        {
            _pdfCell = new PdfPCell(new Phrase("", _fontStyle))
            {
                Colspan = MaxColumn,
                Border = 0,
                ExtraParagraphSpace = 10
            };
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
        }
    }

    private void ReportHeader()
    {
        //_pdfCell = new PdfPCell(AddLogo())
        //{
        //    Colspan = 1,
        //    Border = 0
        //};
        //_pdfTable.AddCell(_pdfCell);

        _pdfCell = new PdfPCell(SetPageTitle())
        {
            Colspan = 3,
            Border = 0
        };
        _pdfTable.AddCell(_pdfCell);
    }

    private PdfPTable SetPageTitle()
    {
        const int maxColumn = 3;
        var pdfPTable = new PdfPTable(maxColumn);

        _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
        _pdfCell = new PdfPCell(new Phrase("ACTIVITY PLAN REPORT", _fontStyle))
        {
            Colspan = maxColumn,
            HorizontalAlignment = Element.ALIGN_CENTER,
            Border = 0,
            ExtraParagraphSpace = 0
        };
        pdfPTable.AddCell(_pdfCell);

        pdfPTable.CompleteRow();

        _fontStyle = FontFactory.GetFont("Tahoma", 14f, 1);
        _pdfCell = new PdfPCell(new Phrase("COP23 CWP", _fontStyle))
        {
            Colspan = maxColumn,
            HorizontalAlignment = Element.ALIGN_CENTER,
            Border = 0,
            ExtraParagraphSpace = 0
        };
        pdfPTable.AddCell(_pdfCell);

        pdfPTable.CompleteRow();

        return pdfPTable;
    }

    private PdfPTable AddLogo()
    {
        const int maxColumn = 1;
        var pdfPTable = new PdfPTable(maxColumn);

        string[] paths = { "images", "logo.png" };
        var imagePath = Path.Combine(paths);
        var img = Image.GetInstance(imagePath);

        _pdfCell = new PdfPCell(img)
        {
            Colspan = maxColumn,
            HorizontalAlignment = Element.ALIGN_LEFT,
            Border = 0,
            ExtraParagraphSpace = 0
        };

        pdfPTable.AddCell(_pdfCell);

        pdfPTable.CompleteRow();

        return pdfPTable;
    }
}