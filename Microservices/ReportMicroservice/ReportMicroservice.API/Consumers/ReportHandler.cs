using OfficeOpenXml;
using ReportMicroservice.API.Events;
using ReportMicroservice.Application.Abstract;
using System;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ReportMicroservice.API.Consumers
{
    public class ReportHandler
    {
        private IReportService _reportService;
        public ReportHandler(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task Handle(ReportRequestedEvent reportEvent)
        {
            var url = $"https://localhost:7179/api/Meter/GetBySerialNo?serialNo={reportEvent.SerialNo}";
            using (HttpClient client = new())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions options = new()
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    ReportContent[]? data = JsonSerializer.Deserialize<ReportContent[]>(responseData, options);
                    if (data != null && data.Length > 0)
                    {
                        GenerateReport(data, reportEvent);
                    }
                }
            }
            await Task.CompletedTask;
        }
        private void GenerateReport(ReportContent[] content, ReportRequestedEvent reportEvent)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string fileName = $"{content[0].MeterSerialNo}";
                string webRootPath = Directory.GetCurrentDirectory();
                string wwwrootPath = Path.Combine(webRootPath, "wwwroot");
                var date = DateTimeOffset.Now.ToUnixTimeSeconds();
                string filePath = Path.Combine(wwwrootPath, $"{fileName}-{date}.xlsx");
                int version = 1;
                while (System.IO.File.Exists(filePath))
                {
                    string lastFileName = $"{fileName}-{date}_v{version}";
                    filePath = Path.Combine(wwwrootPath, $"{lastFileName}.xlsx");
                    version++;
                }

                var newFile = new FileInfo(filePath);
                using (var package = new ExcelPackage(newFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].Value = "Measurement Time";
                    worksheet.Cells["B1"].Value = "Last Index";
                    worksheet.Cells["C1"].Value = "Voltage";
                    worksheet.Cells["D1"].Value = "Current";

                    for (int i = 0; i < content.Length; i++)
                    {
                        worksheet.Cells[$"A{i + 2}"].Value = content[i].MeasurementTime.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[$"B{i + 2}"].Value = content[i].LastIndex;
                        worksheet.Cells[$"C{i + 2}"].Value = content[i].VoltageValue;
                        worksheet.Cells[$"D{i + 2}"].Value = content[i].CurrentValue;
                    }

                    package.Save();
                }

                UpdateReport(reportEvent, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
        }

        private void UpdateReport(ReportRequestedEvent reportEvent, string reportPath)
        {
            var reportId = reportEvent.ReportId;
            var report = _reportService.GetById(reportId);
            report.ReportPath = reportPath;
            report.Status = Entity.EReportStatus.Completed;
            _reportService.Update(report);
        }
    }
}
